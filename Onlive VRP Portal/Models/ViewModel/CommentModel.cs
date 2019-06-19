using System;
using System.ComponentModel.DataAnnotations;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class NewCommentView
    {
        [Key]
        public string MessageID { get; set; }

        public string Account { get; set; }
        public DateTime Date { get; set; }
        public DateTime ThroughDate { get; set; }
        public string TypeID { get; set; }
        public bool isPinNote { get; set; }
        public bool isStatement { get; set; }
        public bool isRoute { get; set; }
        public string Comment { get; set; }
        public int Interval { get; set; }
        public string InverseJulian { get; set; }
        public bool isActive { get; set; }
        public int OldRoute { get; set; }
        public string OldDay { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}