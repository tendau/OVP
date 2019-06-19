using System.ComponentModel.DataAnnotations;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class CustomerDataView
    {
        [Key]
        public string Account { get; set; }

        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingPhone { get; set; }
        public string BillingEmail { get; set; }
        public decimal? Balance { get; set; }

        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; }
        public string SiteZip { get; set; }
        public string SitePhone { get; set; }
        public string SiteEmail { get; set; }
    }

    public class NewCustomerView
    {
        [Key]
        public string Account { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing First Name")]
        public string BillingFirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing Last Name")]
        public string BillingLastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing Address Number")]
        public string BillingAddressNumber { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Apt Number/Suffix")]
        public string BillingSuf { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing Street")]
        public string BillingStreet { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing City")]
        public string BillingCity { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing State")]
        public string BillingState { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Billing Zip")]
        public string BillingZip { get; set; }

        [Display(Name = "Billing Phone Number")]
        public string Billingphone { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Site First Name")]
        public string SiteFirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Site Last Name")]
        public string SiteLastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Site Address Number")]
        public string StreetNum { get; set; }

        [Display(Name = "Site Street")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Apt Number/Suffix")]
        public string StreetSuf { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Site City")]
        public string SiteCity { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Site State")]
        public string SiteState { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Site Zip")]
        public string SiteZip { get; set; }

        [Display(Name = "Site Phone Number")]
        public string Sitephone { get; set; }

        public UserSignUpView USV { get; set; }
    }

    public class EditCustomerview
    {
        [Display(Name = "Billing Name")]
        public string BillingName { get; set; }

        [Display(Name = "Billing Phone Number")]
        public string Billingphone { get; set; }

        [Display(Name = "Billing Email")]
        public string BillingEmail { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        [Display(Name = "Site Phone Number")]
        public string SitePhone { get; set; }

        [Display(Name = "Site Email")]
        public string SiteEmail { get; set; }
    }
}