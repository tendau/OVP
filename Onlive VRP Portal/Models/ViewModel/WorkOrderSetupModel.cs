using System.ComponentModel.DataAnnotations;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class WorkOrderSetupView
    {
        [Key]
        public string WOType { get; set; }
        public string Department { get; set; }
        public string WODescription { get; set; }
    }
}