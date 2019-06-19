using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class ServiceManager
    {
        public List<ServiceDataView> GetServiceData(string account)
        {
            using (Entities db = new Entities())

            {
                List<ServiceDataView> SDV = new List<ServiceDataView>();
                RouteManager RM = new RouteManager();

                var services = db.dCharge.Where(o => o.cAccount.Equals(account));
                foreach (var service in services)
                {
                    if (service.dStop_date > DateTime.Today || service.dStop_date < new DateTime(1900, 01, 02))
                    {
                        ServiceDataView dataView = new ServiceDataView();
                        dataView.Description = service.cDescript;
                        dataView.ID = service.cId;
                        if (service.nOverride != 0) dataView.Price = service.nOverride;
                        else
                        {
                            dCode code = db.dCode.Where(o => o.cCode.Equals(service.cCode)).First();
                            dataView.Price = code.nUnit_price * service.nUnits;
                        }

                        dataView.RDV = RM.GetRouteData(account);
                        SDV.Add(dataView);
                    }
                }

                return SDV;
            }
        }

        public void StopService(string account, DateTime? RestartDate, string[] serviceIDs)
        {
            using (Entities db = new Entities())
            {
                var services = db.dCharge.Where(o => o.cAccount.Equals(account));

                foreach (var id in serviceIDs)
                {
                    services.Where(o => o.cId.Equals(id)).First().dStop_date = DateTime.Today;
                    if(RestartDate != null)
                    {
                        services.Where(o => o.cId.Equals(id)).First().dStart_date = RestartDate;
                    }
                }

                db.SaveChanges();

                System.Diagnostics.Debug.WriteLine("Successfully set stop dates");
            }

            TrayManager TM = new TrayManager();
            TM.CreateTrayItem(account, "ORP-Stop Service", "A customer has requested to stop one or more services. "
                + "Please review the stopped services and confirm that the service has been stopped correctly.");
        }

        public List<SelectListItem> GetAvailableServices(string servType)
        {
            List<SelectListItem> availableServices = null;
            using (Entities db = new Entities())
            {
                var query = (from services in db.dOVP_Services
                             where services.ServType == servType
                             select new SelectListItem { Text = services.ServDescription, Value = services.ServTitle }).Distinct();
                availableServices = query.ToList();

                System.Diagnostics.Debug.WriteLine("Successfully populated list");

                return (availableServices);
            }
        }

        internal List<ServiceSelector> GetServiceSelector(string account)
        {
            using (Entities db = new Entities())

            {
                List<ServiceSelector> SS = new List<ServiceSelector>();

                var services = db.dCharge.Where(o => o.cAccount.Equals(account));
                foreach (var service in services)
                {
                    if (service.dStop_date > DateTime.Today || service.dStop_date < new DateTime(1900, 01, 02))
                    {
                        ServiceSelector ServSelector = new ServiceSelector();
                        ServSelector.ServiceDisplay = service.cDescript;
                        ServSelector.ServiceID = service.cId;
                        SS.Add(ServSelector);
                    }
                }

                return SS;
            }
        }

        internal List<SelectListItem> GetChangeServiceSelector()
        {
            
            List<SelectListItem> changeServices = new List<SelectListItem>();
            SelectListItem changeDefault = new SelectListItem();
            changeDefault.Value = "default";
            changeDefault.Text = "Select an option...";
            changeServices.Add(changeDefault);
            SelectListItem changeSize = new SelectListItem();
            changeSize.Value = "size";
            changeSize.Text = "Request larger/smaller can";
            changeServices.Add(changeSize);
            SelectListItem changeFrequency = new SelectListItem();
            changeFrequency.Value = "frequency";
            changeFrequency.Text = "Change the amount of pickups per week";
            changeServices.Add(changeFrequency);
            return changeServices;
        }

        internal List<SelectListItem> GetChangeFrequencySelector()
        {

            List<SelectListItem> changeFrequency = new List<SelectListItem>();
            for(int i = 1; i <= 7; i++)
            {
                SelectListItem newItem = new SelectListItem();
                newItem.Value = i.ToString();
                newItem.Text = i.ToString() + " pickup(s) per week";
                changeFrequency.Add(newItem);
            }
            return changeFrequency;
        }

        internal List<SelectListItem> GetChangeSizeSelector()
        {

            List<SelectListItem> changeSize = new List<SelectListItem>();
            SelectListItem largerOption = new SelectListItem();
            largerOption.Value = "larger";
            largerOption.Text = "Request larger bin";
            changeSize.Add(largerOption);

            SelectListItem smallerOption = new SelectListItem();
            smallerOption.Value = "smaller";
            smallerOption.Text = "Request smaller bin";
            changeSize.Add(smallerOption);
            return changeSize;
        }
    }
}