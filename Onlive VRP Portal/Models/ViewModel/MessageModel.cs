using System;
using System.ComponentModel.DataAnnotations;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class MessageDataView
    {
        public string subject { get; set; }
        public string message { get; set; }
    }

    public class AdminMessageView
    {
        [Key]
        public string messageID { get; set; }

        public string account { get; set; }
        public string area { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime? date { get; set; }
    }
}