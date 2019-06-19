using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignUpView user)
        {
            using (Entities db = new Entities())
            {
                dOVP_SYSUser SU = new dOVP_SYSUser();

                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
                user.Token = token;

                SU.LoginName = user.LoginName;
                SU.cAccount = user.Account.PadLeft(10);
                SU.cEmail = user.Email;
                SU.lConfirmedEmail = false;
                SU.PasswordEncryptedText = PasswordHelper.ComputeHash(user.Password, "SHA512", null);
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;
                SU.cEncrytedToken = user.Token;

                db.dOVP_SYSUser.Add(SU);
                db.SaveChanges();

                dOVP_SYSUserProfile SUP = new dOVP_SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;

                db.dOVP_SYSUserProfile.Add(SUP);
                db.SaveChanges();

                if (user.LOOKUPRoleID > 0)
                {
                    dOVP_SYSUserRole SUR = new dOVP_SYSUserRole();
                    SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                    SUR.SYSUserID = user.SYSUserID;
                    SUR.IsActive = true;
                    SUR.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;

                    db.dOVP_SYSUserRole.Add(SUR);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateUserAccount(UserProfileView user)
        {
            using (Entities db = new Entities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        dOVP_SYSUser SU = db.dOVP_SYSUser.Find(user.SYSUserID);
                        SU.LoginName = user.LoginName;
                        SU.PasswordEncryptedText = user.Password;
                        SU.RowCreatedSYSUserID = user.SYSUserID;
                        SU.RowModifiedSYSUserID = user.SYSUserID;
                        SU.RowCreatedDateTime = DateTime.Now;
                        SU.RowModifiedDateTime = DateTime.Now;

                        db.SaveChanges();

                        var userProfile = db.dOVP_SYSUserProfile.Where(o => o.SYSUserID == user.SYSUserID);
                        if (userProfile.Any())
                        {
                            dOVP_SYSUserProfile SUP = userProfile.FirstOrDefault();
                            SUP.SYSUserID = SU.SYSUserID;
                            SUP.FirstName = user.FirstName;
                            SUP.LastName = user.LastName;
                            SUP.RowCreatedSYSUserID = user.SYSUserID;
                            SUP.RowModifiedSYSUserID = user.SYSUserID;
                            SUP.RowCreatedDateTime = DateTime.Now;
                            SUP.RowModifiedDateTime = DateTime.Now;

                            db.SaveChanges();
                        }

                        if (user.LOOKUPRoleID > 0)
                        {
                            var userRole = db.dOVP_SYSUserRole.Where(o => o.SYSUserID == user.SYSUserID);
                            dOVP_SYSUserRole SUR = null;
                            if (userRole.Any())
                            {
                                SUR = userRole.FirstOrDefault();
                                SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                                SUR.SYSUserID = user.SYSUserID;
                                SUR.IsActive = true;
                                SUR.RowCreatedSYSUserID = user.SYSUserID;
                                SUR.RowModifiedSYSUserID = user.SYSUserID;
                                SUR.RowCreatedDateTime = DateTime.Now;
                                SUR.RowModifiedDateTime = DateTime.Now;
                            }
                            else
                            {
                                SUR = new dOVP_SYSUserRole();
                                SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                                SUR.SYSUserID = user.SYSUserID;
                                SUR.IsActive = true;
                                SUR.RowCreatedSYSUserID = user.SYSUserID;
                                SUR.RowModifiedSYSUserID = user.SYSUserID;
                                SUR.RowCreatedDateTime = DateTime.Now;
                                SUR.RowModifiedDateTime = DateTime.Now;
                                db.dOVP_SYSUserRole.Add(SUR);
                            }

                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        internal bool isTokenValid(string token, string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any() && user.First().cEncrytedToken == token)
                    return true;
                else
                    return false;
            }
        }

        internal bool? IsEmailConfirmed(string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().lConfirmedEmail;
                else
                    return false;
            }
        }

        public void DeleteUser(int userID)
        {
            using (Entities db = new Entities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var SUR = db.dOVP_SYSUserRole.Where(o => o.SYSUserID == userID);
                        if (SUR.Any())
                        {
                            db.dOVP_SYSUserRole.Remove(SUR.FirstOrDefault());
                            db.SaveChanges();
                        }

                        var SUP = db.dOVP_SYSUserProfile.Where(o => o.SYSUserID == userID);
                        if (SUP.Any())
                        {
                            db.dOVP_SYSUserProfile.Remove(SUP.FirstOrDefault());
                            db.SaveChanges();
                        }

                        var SU = db.dOVP_SYSUser.Where(o => o.SYSUserID == userID);
                        if (SU.Any())
                        {
                            db.dOVP_SYSUser.Remove(SU.FirstOrDefault());
                            db.SaveChanges();
                        }

                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public bool IsAccountExist(string account)
        {
            account = account.PadLeft(10);
            using (Entities db = new Entities())
            {
                return db.dCustomer.Where(o => o.cAccount.Equals(account)).Any();
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (Entities db = new Entities())
            {
                return db.dOVP_SYSUser.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }

        public bool IsUserInRole(string loginName, string roleName)
        {
            using (Entities db = new Entities())
            {
                dOVP_SYSUser SU = db.dOVP_SYSUser.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (SU != null)
                {
                    var roles = from q in db.dOVP_SYSUserRole
                                join r in db.dOVP_LOOKUPRole on q.LOOKUPRoleID equals r.LOOKUPRoleID
                                where r.RoleName.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
                                select r.RoleName;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public List<LOOKUPAvailableRole> GetAllRoles()
        {
            using (Entities db = new Entities())
            {
                var roles = db.dOVP_LOOKUPRole.Select(o => new LOOKUPAvailableRole
                {
                    LOOKUPRoleID = o.LOOKUPRoleID,
                    RoleName = o.RoleName,
                    RoleDescription = o.RoleDescription
                }).ToList();

                return roles;
            }
        }

        public int GetUserID(string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.Equals(loginName));
                if (user.Any()) return user.FirstOrDefault().SYSUserID;
            }
            return 0;
        }

        public string GetUserAccount(string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.Equals(loginName));
                if (user.Any()) return user.FirstOrDefault().cAccount;
            }
            return "0";
        }

        public string GetUserArea(string loginName)
        {
            using (Entities db = new Entities())
            {
                string accountID = GetUserAccount(loginName);
                var account = db.dCustomer.Where(o => o.cAccount.Equals(accountID));
                if (account.Any()) return account.FirstOrDefault().cArea_ID;
            }
            return "0";
        }

        public List<UserProfileView> GetAllUserProfiles()
        {
            List<UserProfileView> profiles = new List<UserProfileView>();

            using (Entities db = new Entities())
            {
                UserProfileView UPV;
                var users = db.dOVP_SYSUser.ToList();

                foreach (dOVP_SYSUser u in db.dOVP_SYSUser)
                {
                    UPV = new UserProfileView();
                    UPV.SYSUserID = u.SYSUserID;
                    UPV.LoginName = u.LoginName;
                    UPV.Password = u.PasswordEncryptedText;

                    var SUP = db.dOVP_SYSUserProfile.Find(u.SYSUserID);
                    if (SUP != null)
                    {
                        UPV.FirstName = SUP.FirstName;
                        UPV.LastName = SUP.LastName;
                    }

                    var SUR = db.dOVP_SYSUserRole.Where(o => o.SYSUserID.Equals(u.SYSUserID));
                    if (SUR.Any())
                    {
                        var userRole = SUR.FirstOrDefault();
                        UPV.LOOKUPRoleID = userRole.LOOKUPRoleID;
                        UPV.RoleName = userRole.dOVP_LOOKUPRole.RoleName;
                        UPV.IsRoleActive = userRole.IsActive;
                    }

                    profiles.Add(UPV);
                }
            }

            return profiles;
        }

        public UserDataView GetUserDataView(string loginName)
        {
            UserDataView UDV = new UserDataView();
            List<UserProfileView> profiles = GetAllUserProfiles();
            List<LOOKUPAvailableRole> roles = GetAllRoles();

            int? userAssignedRoleID = 0, userID = 0;
            string userGender = string.Empty;

            userID = GetUserID(loginName);
            using (Entities db = new Entities())
            {
                userAssignedRoleID = db.dOVP_SYSUserRole.Where(o => o.SYSUserID == userID)?.FirstOrDefault().LOOKUPRoleID;
            }

            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender
            {
                Text = "Male",
                Value = "M"
            });
            genders.Add(new Gender
            {
                Text = "Female",
                Value = "F"
            });

            UDV.UserProfile = profiles;
            UDV.UserRoles = new UserRoles
            {
                SelectedRoleID = userAssignedRoleID,
                UserRoleList = roles
            };

            UDV.UserGender = new UserGender
            {
                SelectedGender = userGender,
                Gender = genders
            };

            return UDV;
        }

        public string GetUserEmail(string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.Equals(loginName));
                if (user.Any()) return user.FirstOrDefault().cEmail;
            }
            return "0";
        }

        public void ConfirmEmail(string loginName)
        {
            using (Entities db = new Entities())
            {
                var user = db.dOVP_SYSUser.Where(o => o.LoginName.Equals(loginName));
                if (user.Any())
                    user.First().lConfirmedEmail = true;
                else
                {
                }

                db.SaveChanges();
            }
        }

        public bool VerifyPassword(string plainTextPW, string dbPassword)
        {
            return PasswordHelper.VerifyHash(plainTextPW, "SHA512", dbPassword);
        }
    }
}