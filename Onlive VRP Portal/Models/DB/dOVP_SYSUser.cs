//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Onlive_VRP_Portal.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class dOVP_SYSUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dOVP_SYSUser()
        {
            this.dOVP_SYSUserProfile = new HashSet<dOVP_SYSUserProfile>();
            this.dOVP_SYSUserRole = new HashSet<dOVP_SYSUserRole>();
        }
    
        public int SYSUserID { get; set; }
        public string LoginName { get; set; }
        public string PasswordEncryptedText { get; set; }
        public int RowCreatedSYSUserID { get; set; }
        public Nullable<System.DateTime> RowCreatedDateTime { get; set; }
        public int RowModifiedSYSUserID { get; set; }
        public Nullable<System.DateTime> RowModifiedDateTime { get; set; }
        public bool lConfirmedEmail { get; set; }
        public string cEmail { get; set; }
        public string cAccount { get; set; }
        public string cEncrytedToken { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dOVP_SYSUserProfile> dOVP_SYSUserProfile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dOVP_SYSUserRole> dOVP_SYSUserRole { get; set; }
    }
}
