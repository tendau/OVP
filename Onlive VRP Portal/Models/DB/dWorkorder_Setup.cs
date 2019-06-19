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
    
    public partial class dWorkorder_Setup
    {
        public string cWorkorder_Type { get; set; }
        public string cLevel { get; set; }
        public string cDepartment_ID { get; set; }
        public string cTray_ID { get; set; }
        public string cDescript { get; set; }
        public string cService_description { get; set; }
        public string cSend_Back_Level { get; set; }
        public Nullable<bool> lOn_call { get; set; }
        public Nullable<bool> lCheck_Inactive_Delete { get; set; }
        public string cAuto_route { get; set; }
        public Nullable<bool> lAuto_dspch { get; set; }
        public Nullable<bool> lCreate_onetime_sequence { get; set; }
        public Nullable<bool> lPrint { get; set; }
        public string cPrint_to { get; set; }
        public Nullable<bool> lProcess { get; set; }
        public Nullable<bool> lLast_level { get; set; }
        public Nullable<bool> lRequired_view { get; set; }
        public Nullable<bool> lCheck_required_on_save { get; set; }
        public Nullable<bool> lLog_save { get; set; }
        public Nullable<bool> lCopy_Service_Code_Comment { get; set; }
        public Nullable<bool> lCheck_required { get; set; }
        public Nullable<bool> lCheck_charge_required { get; set; }
        public Nullable<bool> lCheck_comment_required { get; set; }
        public Nullable<bool> lCheck_container_required { get; set; }
        public Nullable<bool> lCheck_datetime_required { get; set; }
        public Nullable<bool> lCheck_content_required { get; set; }
        public Nullable<bool> lTransport_tab { get; set; }
        public Nullable<bool> lFinancial_tab { get; set; }
        public string cCharge_tab { get; set; }
        public string cContainer_tab { get; set; }
        public string cComment_tab { get; set; }
        public string cDate_tab { get; set; }
        public string cContent_tab { get; set; }
        public Nullable<bool> lUser_tab { get; set; }
        public Nullable<bool> lLandfill_tab { get; set; }
        public Nullable<decimal> nStart_tab { get; set; }
        public string e_caccount { get; set; }
        public string E_CSITE_NAME { get; set; }
        public string E_CSITE_ADDRESS { get; set; }
        public string E_CWORKORDER { get; set; }
        public string E_CWORKORDER_TYPE { get; set; }
        public string E_CLEVEL { get; set; }
        public string E_CDEPARTMENT_ID { get; set; }
        public string E_CSERVICE_DESCRIPTION { get; set; }
        public string E_DSCHD_DT { get; set; }
        public string E_CSCHD_TIME { get; set; }
        public string E_CCONTRACT_ID { get; set; }
        public string E_CPURCHASE_ORDER { get; set; }
        public string E_CINVOICE { get; set; }
        public string E_CUSER_COD { get; set; }
        public string cE_acct_day { get; set; }
        public string E_CACCT_ROUTE_ID { get; set; }
        public string cE_day { get; set; }
        public string E_CROUTE_ID { get; set; }
        public string E_CTRANSPORTER_ID { get; set; }
        public string E_CVEHICLE_ID { get; set; }
        public string E_NODOM_OUT { get; set; }
        public string E_NODOM_IN { get; set; }
        public Nullable<bool> lUpdate_container_on_advance { get; set; }
        public string cDel_rmv_ct { get; set; }
        public string cDisp_code { get; set; }
        public string E_CRECEIVER_ID { get; set; }
        public string E_CDOCKET_ID { get; set; }
        public string E_NVOLUME { get; set; }
        public string E_CMEASURE { get; set; }
        public string E_NLF_COST { get; set; }
        public string cImage_ID { get; set; }
        public Nullable<System.DateTime> tTime_stamp { get; set; }
        public string cCancel_Level { get; set; }
        public string e_cCanceled_Level { get; set; }
        public string e_cWO_User_Character_1 { get; set; }
        public string e_cWO_User_Character_2 { get; set; }
        public string e_cWO_User_Character_3 { get; set; }
        public string e_cWO_User_Checkbox_1 { get; set; }
        public string e_cWO_User_Checkbox_2 { get; set; }
        public string e_cWO_User_Checkbox_3 { get; set; }
        public string e_cWO_User_Date_1 { get; set; }
        public string e_cWO_User_Date_2 { get; set; }
        public string e_cWO_User_Date_3 { get; set; }
        public string e_cWO_User_Number_1 { get; set; }
        public string e_cWO_User_Number_2 { get; set; }
        public string e_cWO_User_Number_3 { get; set; }
        public string e_cWO_User_Memo_1 { get; set; }
        public string e_cWO_User_Memo_2 { get; set; }
        public string e_cWO_User_Memo_3 { get; set; }
        public Nullable<bool> lProcess_Post_Charge { get; set; }
        public Nullable<bool> lProcess_Post_Landfill_Charge { get; set; }
        public Nullable<bool> lProcess_Move_Container { get; set; }
        public Nullable<bool> lProcess_Create_Comment { get; set; }
        public Nullable<bool> lProcess_Create_Docket { get; set; }
        public string e_cDuration { get; set; }
        public Nullable<bool> lPlanner_Bell { get; set; }
        public Nullable<bool> lPlanner_House { get; set; }
        public Nullable<bool> lPlanner_Key { get; set; }
        public Nullable<bool> lPlanner_Question { get; set; }
    }
}
