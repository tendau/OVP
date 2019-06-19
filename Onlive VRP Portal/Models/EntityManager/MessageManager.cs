using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class MessageManager
    {
        public List<MessageDataView> GetMessages(string account, string area)
        {
            using (Entities db = new Entities())
            {
                List<MessageDataView> MDV = new List<MessageDataView>();

                var messages = db.dOVP_Message.Where(o => o.cAccount.Equals(account) || (o.cAccount.Equals(null) && ((o.cArea_ID.Equals(area) || o.cArea_ID.Equals(null)))));
                foreach (var message in messages)
                {
                    MessageDataView dataView = new MessageDataView();
                    dataView.subject = message.cSubject;
                    dataView.message = message.cMessage;

                    MDV.Add(dataView);
                }

                return MDV;
            }
        }

        public List<AdminMessageView> GetAllMessages()
        {
            using (Entities db = new Entities())
            {
                List<AdminMessageView> MDV = new List<AdminMessageView>();

                var messages = db.dOVP_Message.OrderBy(o => o.dDate);

                foreach (var message in messages)
                {
                    AdminMessageView dataView = new AdminMessageView();
                    dataView.account = message.cAccount;
                    dataView.area = message.cArea_ID;
                    dataView.date = message.dDate;
                    dataView.message = message.cMessage;
                    dataView.subject = message.cSubject;

                    MDV.Add(dataView);
                }

                return MDV;
            }
        }

        public void CreateNewMessage(string account, string subject, string message)
        {
            using (Entities db = new Entities())
            {
                dOVP_Message newMessage = new dOVP_Message();
                newMessage.cMessageID = "MS" + db.VrpGetNextID("MS", "dOVP_Message", 1).First();
                newMessage.cSubject = subject;
                newMessage.cMessage = message;
                newMessage.dDate = DateTime.Now;
                if (account != "")
                {
                    newMessage.cAccount = account.PadLeft(10);
                }

                db.dOVP_Message.Add(newMessage);
                db.SaveChanges();
            }
        }

        public void DeleteMessage(string MessageID)
        {
            using (Entities db = new Entities())
            {
                dOVP_Message message = db.dOVP_Message.Where(o => o.cMessageID.Equals(MessageID)).First();
                if (message != null)
                {
                    db.dOVP_Message.Remove(message);
                    db.SaveChanges();
                }
                //throw exception
            }
        }

        public void GetMessagesFromComments(string account)
        {
            using (Entities db = new Entities())
            {
                var comments = db.dComment.Where(o => o.cType_ID.Equals("WEB"));
                foreach (var comment in comments)
                {
                    dOVP_Message message = new dOVP_Message();
                    message.cMessageID = "MS" + db.VrpGetNextID("MS", "dOVP_Message", 1).First();
                    message.cSubject = "Message from office";
                    message.cMessage = comment.mComment;
                    message.cAccount = account;
                    message.dDate = comment.dDate;

                    db.dOVP_Message.Add(message);
                    db.SaveChanges();
                }
            }
        }
    }
}