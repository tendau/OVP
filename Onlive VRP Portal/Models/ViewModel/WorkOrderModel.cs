using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class WorkOrderDataView
    {
        [Key]
        public string WorkOrderID { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; }
        public string Description { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public string Comment { get; set; }
        public string Level { get; set; }
    }

    public class WorkOrderType
    {
        public string typeDisplay { get; set; }
        public string type { get; set; }
    }

    public class WorkOrderView
    {
        public string newWoType { get; set; }
        public DateTime newWoDate { get; set; }
        public List<WorkOrderDataView> WDV = new List<WorkOrderDataView>();
        public List<WorkOrderType> types = new List<WorkOrderType>();
    }
}