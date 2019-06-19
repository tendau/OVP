using System.Collections.Generic;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class RouteDataView
    {
        public string RouteID { get; set; }
        public string DayOfWeek { get; set; }
        public string Schedule { get; set; }
        public List<string> dates { get; set; }
    }
}