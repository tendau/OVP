//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Onlive_VRP_Portal.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class dWorkorder_Charge
    {
        public string cID { get; set; }
        public string cWorkorder { get; set; }
        public string cContract_ID { get; set; }
        public string cCharge_ID { get; set; }
        public string cContract_Charge_ID { get; set; }
        public Nullable<decimal> nOrder { get; set; }
        public Nullable<bool> lRental { get; set; }
        public Nullable<bool> lActive { get; set; }
        public string cCode { get; set; }
        public string cDescript { get; set; }
        public Nullable<decimal> nUnits { get; set; }
        public Nullable<decimal> nOverride { get; set; }
        public string cReference { get; set; }
        public Nullable<decimal> nVolume { get; set; }
        public string mComment { get; set; }
        public Nullable<decimal> nCost { get; set; }
        public Nullable<decimal> nBatch { get; set; }
        public Nullable<decimal> nEntry { get; set; }
        public Nullable<System.DateTime> tTime_stamp { get; set; }
        public string cBatch_ID { get; set; }
    }
}