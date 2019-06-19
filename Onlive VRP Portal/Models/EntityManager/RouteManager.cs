using Onlive_VRP_Portal.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class RouteManager
    {
        public RouteDataView GetRouteData(string account)
        {
            using (Entities db = new Entities())
            {
                RouteDataView RDV = new RouteDataView();
                RDV.dates = new List<string>();
                var route = db.dRoute.Where(o => o.cAccount.Equals(account));

                if (route.Any())
                {
                    RDV.RouteID = route.First().cID;
                    RDV.DayOfWeek = route.First().cRoute_ID.Substring(0, 2);
                    var dates = db.dRoute_Cycle_Date.Where(o => o.cRoute_Cycle_ID.Equals(route.FirstOrDefault().cRoute_Cycle_ID)
                    && o.dDate.Month.Equals(DateTime.Now.Month) && o.dDate.Year.Equals(DateTime.Now.Year));
                    foreach (var date in dates)
                    {
                        if (date.dDate.DayOfWeek.ToString().Substring(0, 2).Equals(RDV.DayOfWeek, StringComparison.InvariantCultureIgnoreCase))
                            RDV.dates.Add(date.dDate.Day.ToString());
                    }
                }

                return RDV;
            }
        }

        public List<string> GetRoutes(string account)
        {
            List<string> routes = new List<string>();

            using (Entities db = new Entities())
            {
                var allRoutes = db.dRoute.Where(o => o.cAccount.Equals(account));

                if (allRoutes.Any())
                {
                    foreach (var route in allRoutes)
                    {
                        routes.Add(route.cRoute_ID);
                    }
                }
            }

            return routes;
        }
    }
}