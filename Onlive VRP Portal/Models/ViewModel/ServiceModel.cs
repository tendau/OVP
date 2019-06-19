using Onlive_VRP_Portal.Models.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class ServiceDataView
    {
        public string ID { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool Checked { get; set; }
        public RouteDataView RDV { get; set; }
    }

    public class ServicePartialView
    {
        public List<ServiceDataView> currentServices;
        public SelectList CurrentServicesDD { get; set; }

        [Required]
        public string SelectedServiceType { get; set; }

        [Required]
        public string SelectedOTServiceType { get; set; }

        [Required]
        public string SelectedFrequency { get; set; }

        [Required]
        public string SelectedSize { get; set; }

        [Required]
        public string SelectedCurrentService { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime OTServiceDate { get; set; }

        public DateTime? RestartDate { get; set; }

        public List<SelectListItem> AvailableRecurringServices { get; set; }

        public List<SelectListItem> AvailableOneTimeServices { get; set; }

        public List<SelectListItem> ChangeServiceOptions { get; set; }

        public List<SelectListItem> FrequencyOptions { get; set; }

        public List<SelectListItem> SizeOptions { get; set; }
    }

    public class ServiceSelector
    {
        public string ServiceID { get; set; }
        public string ServiceDisplay { get; set; }
    }

    //public class SingleServiceSelector
    //{
    //    public string ServiceID { get; set; }
    //    public string ServiceDisplay { get; set; }
    //}

    //public class ChangeServiceSelector
    //{
    //    public string ChangeID { get; set; }
    //    public string ChangeDisplay { get; set; }
    //}
}