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
    
    public partial class dComment
    {
        public string cId { get; set; }
        public string cAccount { get; set; }
        public Nullable<System.DateTime> dDate { get; set; }
        public Nullable<System.DateTime> dThru { get; set; }
        public string cType_ID { get; set; }
        public Nullable<bool> lPin_note { get; set; }
        public Nullable<bool> lStatement { get; set; }
        public Nullable<bool> lRoute { get; set; }
        public string mComment { get; set; }
        public Nullable<decimal> nThru_date_interval { get; set; }
        public string cInverse_julian { get; set; }
        public Nullable<bool> lActive { get; set; }
        public Nullable<decimal> nOld_route { get; set; }
        public string cOld_day { get; set; }
        public Nullable<System.DateTime> tTime_stamp { get; set; }
    }
}