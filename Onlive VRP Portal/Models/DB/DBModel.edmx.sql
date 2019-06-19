
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2018 10:44:36
-- Generated from EDMX file: C:\Users\cearley\source\repos\Onlive VRP Portal\Onlive VRP Portal\Models\DB\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VRPE10-OVP-TEST];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__dOVP_SYSU__LOOKU__534E2C48]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[dOVP_SYSUserRole] DROP CONSTRAINT [FK__dOVP_SYSU__LOOKU__534E2C48];
GO
IF OBJECT_ID(N'[dbo].[FK__dOVP_SYSU__SYSUs__4D9552F2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[dOVP_SYSUserProfile] DROP CONSTRAINT [FK__dOVP_SYSU__SYSUs__4D9552F2];
GO
IF OBJECT_ID(N'[dbo].[FK__dOVP_SYSU__SYSUs__54425081]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[dOVP_SYSUserRole] DROP CONSTRAINT [FK__dOVP_SYSU__SYSUs__54425081];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[dCharge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dCharge];
GO
IF OBJECT_ID(N'[dbo].[dCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dCode];
GO
IF OBJECT_ID(N'[dbo].[dComment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dComment];
GO
IF OBJECT_ID(N'[dbo].[dComment_Type_Setup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dComment_Type_Setup];
GO
IF OBJECT_ID(N'[dbo].[dCustomer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dCustomer];
GO
IF OBJECT_ID(N'[dbo].[dOVP_LOOKUPRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dOVP_LOOKUPRole];
GO
IF OBJECT_ID(N'[dbo].[dOVP_Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dOVP_Message];
GO
IF OBJECT_ID(N'[dbo].[dOVP_SYSUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dOVP_SYSUser];
GO
IF OBJECT_ID(N'[dbo].[dOVP_SYSUserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dOVP_SYSUserProfile];
GO
IF OBJECT_ID(N'[dbo].[dOVP_SYSUserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dOVP_SYSUserRole];
GO
IF OBJECT_ID(N'[dbo].[dRoute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dRoute];
GO
IF OBJECT_ID(N'[dbo].[dRoute_Cycle_Date]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dRoute_Cycle_Date];
GO
IF OBJECT_ID(N'[dbo].[dTray]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dTray];
GO
IF OBJECT_ID(N'[dbo].[dWorkOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dWorkOrder];
GO
IF OBJECT_ID(N'[dbo].[dWorkorder_Charge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dWorkorder_Charge];
GO
IF OBJECT_ID(N'[dbo].[dWorkorder_Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dWorkorder_Comment];
GO
IF OBJECT_ID(N'[dbo].[dWorkorder_Setup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dWorkorder_Setup];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'dCustomer'
CREATE TABLE [dbo].[dCustomer] (
    [cAccount] char(10)  NOT NULL,
    [cOld_Account] char(8)  NULL,
    [lMaster_billing] bit  NULL,
    [cBill_account] char(10)  NULL,
    [cUser_num] char(40)  NULL,
    [cName] char(40)  NULL,
    [cName_2] char(40)  NULL,
    [cAddress_1] char(40)  NULL,
    [cAddress_2] char(40)  NULL,
    [cCity] char(40)  NULL,
    [cState] char(3)  NULL,
    [cZip] char(10)  NULL,
    [dZip_date] datetime  NULL,
    [cZip_barcode] char(12)  NULL,
    [cCarrier_rt] char(4)  NULL,
    [cPhone] char(18)  NULL,
    [cFax] char(35)  NULL,
    [cContact] char(40)  NULL,
    [cE_mail] char(50)  NULL,
    [cSite_name] char(40)  NULL,
    [cSite_street_number] char(9)  NULL,
    [cSite_street_name] char(40)  NULL,
    [cSite_street_suffix] char(10)  NULL,
    [cSite_address] char(60)  NULL,
    [cSite_city] char(40)  NULL,
    [cSite_state] char(3)  NULL,
    [cSite_zip] char(10)  NULL,
    [cSite_phone] char(18)  NULL,
    [cSite_fax] char(35)  NULL,
    [cSite_contact] char(40)  NULL,
    [cSite_e_mail] char(50)  NULL,
    [cArea_ID] char(14)  NOT NULL,
    [cType_ID] char(14)  NOT NULL,
    [cCycle_ID] char(14)  NOT NULL,
    [cTax_Table_ID] char(14)  NULL,
    [cGroup_ID] char(14)  NULL,
    [cSystem_ID] char(14)  NULL,
    [cStatus_ID] char(14)  NOT NULL,
    [cNew_status_ID] char(14)  NULL,
    [dNew_status_date] datetime  NULL,
    [cIndex_type] char(1)  NULL,
    [dStart] datetime  NULL,
    [dReview] datetime  NULL,
    [dSuspend] datetime  NULL,
    [dRestart] datetime  NULL,
    [dStop] datetime  NULL,
    [cRecycle] char(7)  NULL,
    [cMap1] char(3)  NULL,
    [cMap2] char(3)  NULL,
    [cMap3] char(3)  NULL,
    [cGeocode] char(20)  NULL,
    [cLongitude] char(13)  NULL,
    [cLatitude] char(13)  NULL,
    [cMap_other] char(13)  NULL,
    [nUnbilled] decimal(12,3)  NULL,
    [nCurrent] decimal(12,3)  NULL,
    [nThirty] decimal(12,3)  NULL,
    [nSixty] decimal(12,3)  NULL,
    [nNinety] decimal(12,3)  NULL,
    [nOne_twenty] decimal(12,3)  NULL,
    [nBalance] decimal(12,3)  NULL,
    [nLate_charg] decimal(12,3)  NULL,
    [cLate_start] char(2)  NULL,
    [nLast_l_chg] decimal(12,3)  NULL,
    [nComputd_on] decimal(12,3)  NULL,
    [dLast_late_charge_date] datetime  NULL,
    [cNotice_start] char(2)  NULL,
    [nLast_notic] decimal(1,0)  NULL,
    [dLast_notice_date] datetime  NULL,
    [nLast_paid] decimal(12,3)  NULL,
    [dDate_paid] datetime  NULL,
    [cPurchase_order] char(20)  NULL,
    [dPo_expires] datetime  NULL,
    [nCr_limit] decimal(12,3)  NULL,
    [nDeposit] decimal(12,3)  NULL,
    [dDepos_date] datetime  NULL,
    [lContract_required] bit  NULL,
    [lBank_eft] bit  NULL,
    [cBank_ID] char(14)  NULL,
    [cBank_acct] char(15)  NULL,
    [cBank_drawr] char(40)  NULL,
    [cCurrent_invoice] char(8)  NULL,
    [cChanges] char(1)  NULL,
    [cUser_1] char(30)  NULL,
    [cUser_2] char(30)  NULL,
    [cUser_3] char(30)  NULL,
    [cUser_4] char(30)  NULL,
    [cUser_5] char(30)  NULL,
    [nInvoices] decimal(5,0)  NULL,
    [nComments] decimal(5,0)  NULL,
    [nServicelinks] decimal(5,0)  NULL,
    [nCharges] decimal(5,0)  NULL,
    [nRoutes] decimal(5,0)  NULL,
    [nContainers] decimal(5,0)  NULL,
    [nContracts] decimal(5,0)  NULL,
    [nWorkorders] decimal(5,0)  NULL,
    [lRequires_financial_approval] bit  NULL,
    [lRequires_operations_approval] bit  NULL,
    [dLast_servc] datetime  NULL,
    [cProrate_type] char(10)  NULL,
    [dProrate_date] datetime  NULL,
    [tTime_stamp] datetime  NULL,
    [cSite_ID] char(14)  NOT NULL,
    [cCell_Phone] char(18)  NULL,
    [cSite_Cell_Phone] char(18)  NULL,
    [lEmail_Statement] bit  NULL,
    [lEmail_Only_Statement] bit  NULL
);
GO

-- Creating table 'dTray'
CREATE TABLE [dbo].[dTray] (
    [cID] char(14)  NOT NULL,
    [cTray_ID] char(14)  NULL,
    [lSend] bit  NULL,
    [lPriority] bit  NULL,
    [lAuto_show] bit  NULL,
    [lComplete] bit  NULL,
    [dCreate_date] datetime  NULL,
    [cCreate_time] char(8)  NULL,
    [dSend_date] datetime  NULL,
    [cSend_time] char(8)  NULL,
    [dSchedule_date] datetime  NULL,
    [cSchedule_time] char(8)  NULL,
    [dComplete_date] datetime  NULL,
    [cComplete_time] char(8)  NULL,
    [cFrom_user_id] char(10)  NULL,
    [cTo_Tray_ID] char(14)  NULL,
    [cSend_Tray_ID] char(14)  NULL,
    [cAccount] char(10)  NULL,
    [cEntity_id] char(14)  NULL,
    [cSource_ID] char(14)  NULL,
    [lForward_email] bit  NULL,
    [cSubject] char(50)  NULL,
    [mComment] varchar(max)  NULL,
    [tTime_stamp] datetime  NULL
);
GO

-- Creating table 'dWorkOrder'
CREATE TABLE [dbo].[dWorkOrder] (
    [lSelected] bit  NULL,
    [cSelected_user] char(10)  NULL,
    [cAccount] char(10)  NOT NULL,
    [cSite_name] char(40)  NULL,
    [cSite_address] char(60)  NULL,
    [dSchd_dt] datetime  NULL,
    [cSchd_time] char(8)  NULL,
    [cWorkorder] char(14)  NOT NULL,
    [cWorkorder_Type] char(14)  NOT NULL,
    [cLevel] char(2)  NOT NULL,
    [cDepartment_ID] char(14)  NULL,
    [cService_description] char(35)  NULL,
    [cContract_ID] char(14)  NULL,
    [cPurchase_order] char(20)  NULL,
    [cInvoice] char(10)  NULL,
    [cUser_cod] char(2)  NULL,
    [lPrinted] bit  NULL,
    [lRequired_check_passed] bit  NULL,
    [lCompleted] bit  NULL,
    [cAcct_Route_ID] char(14)  NULL,
    [cRoute_ID] char(14)  NULL,
    [cTransporter_ID] char(14)  NULL,
    [cVehicle_ID] char(14)  NULL,
    [nOdom_out] decimal(6,0)  NULL,
    [nOdom_in] decimal(6,0)  NULL,
    [cReceiver_ID] char(14)  NULL,
    [cDocket_ID] char(14)  NULL,
    [nVolume] decimal(10,4)  NULL,
    [cUnit_Of_Measure_ID] char(14)  NULL,
    [nLf_cost] decimal(12,3)  NULL,
    [dCritical_date] datetime  NULL,
    [cCritical_start_time] char(8)  NULL,
    [cCritical_end_time] char(8)  NULL,
    [nCritical_duration] decimal(5,2)  NULL,
    [nTotal_cost] decimal(12,3)  NULL,
    [nTotal_revenue] decimal(12,3)  NULL,
    [nProfit] decimal(12,3)  NULL,
    [lBatch_created] bit  NULL,
    [nSequence] decimal(9,4)  NULL,
    [cCroute_fk] char(14)  NULL,
    [tTime_stamp] datetime  NULL,
    [cCanceled_Level] char(2)  NULL,
    [cWO_User_Character_1] char(40)  NULL,
    [cWO_User_Character_2] char(40)  NULL,
    [cWO_User_Character_3] char(40)  NULL,
    [lWO_User_Checkbox_1] bit  NULL,
    [lWO_User_Checkbox_2] bit  NULL,
    [lWO_User_Checkbox_3] bit  NULL,
    [dWO_User_Date_1] datetime  NULL,
    [dWO_User_Date_2] datetime  NULL,
    [dWO_User_Date_3] datetime  NULL,
    [nWO_User_Number_1] decimal(12,3)  NULL,
    [nWO_User_Number_2] decimal(12,3)  NULL,
    [nWO_User_Number_3] decimal(12,3)  NULL,
    [mWO_User_Memo_1] varchar(max)  NULL,
    [mWO_User_Memo_2] varchar(max)  NULL,
    [mWO_User_Memo_3] varchar(max)  NULL,
    [nDuration] decimal(5,2)  NULL,
    [cInterval_ID] char(14)  NULL,
    [cSeries_ID] char(10)  NULL
);
GO

-- Creating table 'dWorkorder_Charge'
CREATE TABLE [dbo].[dWorkorder_Charge] (
    [cID] char(14)  NOT NULL,
    [cWorkorder] char(14)  NOT NULL,
    [cContract_ID] char(14)  NULL,
    [cCharge_ID] char(14)  NULL,
    [cContract_Charge_ID] char(14)  NULL,
    [nOrder] decimal(2,0)  NULL,
    [lRental] bit  NULL,
    [lActive] bit  NULL,
    [cCode] char(6)  NOT NULL,
    [cDescript] char(35)  NULL,
    [nUnits] decimal(9,3)  NULL,
    [nOverride] decimal(12,3)  NULL,
    [cReference] char(20)  NULL,
    [nVolume] decimal(10,4)  NULL,
    [mComment] varchar(max)  NULL,
    [nCost] decimal(12,3)  NULL,
    [nBatch] decimal(8,0)  NULL,
    [nEntry] decimal(5,0)  NULL,
    [tTime_stamp] datetime  NULL,
    [cBatch_ID] char(14)  NULL
);
GO

-- Creating table 'dWorkorder_Comment'
CREATE TABLE [dbo].[dWorkorder_Comment] (
    [cID] char(14)  NOT NULL,
    [cWorkorder] char(14)  NOT NULL,
    [cContract_ID] char(14)  NULL,
    [cComment_ID] char(14)  NULL,
    [lCreate_comment] bit  NULL,
    [nOrder] decimal(2,0)  NULL,
    [cComment_Type_ID] char(14)  NOT NULL,
    [mComment] varchar(max)  NULL,
    [cCreated_Comment_ID] char(14)  NULL,
    [cWorkorder_Setup_ID] char(14)  NULL,
    [lProcessed] bit  NULL,
    [tTime_stamp] datetime  NULL
);
GO

-- Creating table 'dWorkorder_Setup'
CREATE TABLE [dbo].[dWorkorder_Setup] (
    [cWorkorder_Type] char(14)  NOT NULL,
    [cLevel] char(2)  NOT NULL,
    [cDepartment_ID] char(14)  NULL,
    [cTray_ID] char(14)  NULL,
    [cDescript] char(25)  NULL,
    [cService_description] char(25)  NULL,
    [cSend_Back_Level] char(2)  NULL,
    [lOn_call] bit  NULL,
    [lCheck_Inactive_Delete] bit  NULL,
    [cAuto_route] char(1)  NULL,
    [lAuto_dspch] bit  NULL,
    [lCreate_onetime_sequence] bit  NULL,
    [lPrint] bit  NULL,
    [cPrint_to] char(40)  NULL,
    [lProcess] bit  NULL,
    [lLast_level] bit  NULL,
    [lRequired_view] bit  NULL,
    [lCheck_required_on_save] bit  NULL,
    [lLog_save] bit  NULL,
    [lCopy_Service_Code_Comment] bit  NULL,
    [lCheck_required] bit  NULL,
    [lCheck_charge_required] bit  NULL,
    [lCheck_comment_required] bit  NULL,
    [lCheck_container_required] bit  NULL,
    [lCheck_datetime_required] bit  NULL,
    [lCheck_content_required] bit  NULL,
    [lTransport_tab] bit  NULL,
    [lFinancial_tab] bit  NULL,
    [cCharge_tab] char(1)  NULL,
    [cContainer_tab] char(1)  NULL,
    [cComment_tab] char(1)  NULL,
    [cDate_tab] char(1)  NULL,
    [cContent_tab] char(1)  NULL,
    [lUser_tab] bit  NULL,
    [lLandfill_tab] bit  NULL,
    [nStart_tab] decimal(1,0)  NULL,
    [e_caccount] char(1)  NULL,
    [E_CSITE_NAME] char(1)  NULL,
    [E_CSITE_ADDRESS] char(1)  NULL,
    [E_CWORKORDER] char(1)  NULL,
    [E_CWORKORDER_TYPE] char(1)  NULL,
    [E_CLEVEL] char(1)  NULL,
    [E_CDEPARTMENT_ID] char(1)  NULL,
    [E_CSERVICE_DESCRIPTION] char(1)  NULL,
    [E_DSCHD_DT] char(1)  NULL,
    [E_CSCHD_TIME] char(1)  NULL,
    [E_CCONTRACT_ID] char(1)  NULL,
    [E_CPURCHASE_ORDER] char(1)  NULL,
    [E_CINVOICE] char(1)  NULL,
    [E_CUSER_COD] char(1)  NULL,
    [cE_acct_day] char(1)  NULL,
    [E_CACCT_ROUTE_ID] char(1)  NULL,
    [cE_day] char(1)  NULL,
    [E_CROUTE_ID] char(1)  NULL,
    [E_CTRANSPORTER_ID] char(1)  NULL,
    [E_CVEHICLE_ID] char(1)  NULL,
    [E_NODOM_OUT] char(1)  NULL,
    [E_NODOM_IN] char(1)  NULL,
    [lUpdate_container_on_advance] bit  NULL,
    [cDel_rmv_ct] char(1)  NULL,
    [cDisp_code] char(6)  NULL,
    [E_CRECEIVER_ID] char(1)  NULL,
    [E_CDOCKET_ID] char(1)  NULL,
    [E_NVOLUME] char(1)  NULL,
    [E_CMEASURE] char(1)  NULL,
    [E_NLF_COST] char(1)  NULL,
    [cImage_ID] char(14)  NULL,
    [tTime_stamp] datetime  NULL,
    [cCancel_Level] char(2)  NULL,
    [e_cCanceled_Level] char(1)  NULL,
    [e_cWO_User_Character_1] char(1)  NULL,
    [e_cWO_User_Character_2] char(1)  NULL,
    [e_cWO_User_Character_3] char(1)  NULL,
    [e_cWO_User_Checkbox_1] char(1)  NULL,
    [e_cWO_User_Checkbox_2] char(1)  NULL,
    [e_cWO_User_Checkbox_3] char(1)  NULL,
    [e_cWO_User_Date_1] char(1)  NULL,
    [e_cWO_User_Date_2] char(1)  NULL,
    [e_cWO_User_Date_3] char(1)  NULL,
    [e_cWO_User_Number_1] char(1)  NULL,
    [e_cWO_User_Number_2] char(1)  NULL,
    [e_cWO_User_Number_3] char(1)  NULL,
    [e_cWO_User_Memo_1] char(1)  NULL,
    [e_cWO_User_Memo_2] char(1)  NULL,
    [e_cWO_User_Memo_3] char(1)  NULL,
    [lProcess_Post_Charge] bit  NULL,
    [lProcess_Post_Landfill_Charge] bit  NULL,
    [lProcess_Move_Container] bit  NULL,
    [lProcess_Create_Comment] bit  NULL,
    [lProcess_Create_Docket] bit  NULL,
    [e_cDuration] char(1)  NULL,
    [lPlanner_Bell] bit  NULL,
    [lPlanner_House] bit  NULL,
    [lPlanner_Key] bit  NULL,
    [lPlanner_Question] bit  NULL
);
GO

-- Creating table 'dCharge'
CREATE TABLE [dbo].[dCharge] (
    [cId] char(14)  NOT NULL,
    [cAccount] char(10)  NOT NULL,
    [cArea_ID] char(14)  NULL,
    [cCycle_ID] char(14)  NULL,
    [cCode] char(6)  NOT NULL,
    [cDescript] char(35)  NULL,
    [nUnits] decimal(9,3)  NULL,
    [nOverride] decimal(12,3)  NULL,
    [cReference] char(20)  NULL,
    [nFrequency] decimal(3,1)  NULL,
    [nDiscount] decimal(5,2)  NULL,
    [dLast_service] datetime  NULL,
    [dNext_service] datetime  NULL,
    [dStart_date] datetime  NULL,
    [dReview_date] datetime  NULL,
    [dLast_review_date] datetime  NULL,
    [dApproved_date] datetime  NULL,
    [cApproved_user] char(10)  NULL,
    [dStop_date] datetime  NULL,
    [cStop_code_ID] char(14)  NULL,
    [cContract] char(14)  NULL,
    [nLinks] decimal(5,0)  NULL,
    [mComment] varchar(max)  NULL,
    [cProrate_type] char(10)  NULL,
    [dProrate_date] datetime  NULL,
    [lHistory] bit  NULL,
    [nOld_route] decimal(3,0)  NULL,
    [cOld_day] char(2)  NULL,
    [cOld_days] char(7)  NULL,
    [cOld_container] char(8)  NULL,
    [tTime_stamp] datetime  NULL,
    [nPrice_Per_Service] decimal(12,3)  NULL
);
GO

-- Creating table 'dCode'
CREATE TABLE [dbo].[dCode] (
    [cCode] char(6)  NOT NULL,
    [cDescript] char(35)  NULL,
    [cCategory_ID] char(14)  NULL,
    [nUnit_price] decimal(12,3)  NULL,
    [nFactor] decimal(7,2)  NULL,
    [cUnit_Of_Measure_ID] char(14)  NULL,
    [lCredit] bit  NULL,
    [lSuspend] bit  NULL,
    [lContract_required] bit  NULL,
    [lService] bit  NULL,
    [lRental] bit  NULL,
    [lOnly_area_pricing] bit  NULL,
    [lAuto_copy_content_profile] bit  NULL,
    [lAccumulate_volume_stats] bit  NULL,
    [lUnits_required] bit  NULL,
    [lReference_required] bit  NULL,
    [lComment_required] bit  NULL,
    [lVolume_required] bit  NULL,
    [lCost_required] bit  NULL,
    [cGl_credit] char(17)  NULL,
    [cGl_debit] char(17)  NULL,
    [lIs_tax_code] bit  NULL,
    [lTax_1] bit  NULL,
    [lTax_2] bit  NULL,
    [lTax_3] bit  NULL,
    [lTax_4] bit  NULL,
    [lTax_5] bit  NULL,
    [cLink_type] char(1)  NULL,
    [cLink_code] char(6)  NULL,
    [nBreakpoint] decimal(8,3)  NULL,
    [cImage_ID] char(14)  NULL,
    [mComment] varchar(max)  NULL,
    [cReporting_Level_1] char(14)  NULL,
    [cReporting_Level_2] char(14)  NULL,
    [cReporting_Level_3] char(14)  NULL,
    [tTime_stamp] datetime  NULL,
    [nPrice_Per_Service] decimal(12,3)  NULL,
    [nPrice_Per_Service_Factor] decimal(5,2)  NULL
);
GO

-- Creating table 'dOVP_Message'
CREATE TABLE [dbo].[dOVP_Message] (
    [cMessageID] varchar(14)  NOT NULL,
    [cAccount] varchar(14)  NULL,
    [cArea_ID] varchar(14)  NULL,
    [cSubject] varchar(25)  NULL,
    [cMessage] varchar(max)  NULL,
    [dDate] datetime  NULL
);
GO

-- Creating table 'dComment'
CREATE TABLE [dbo].[dComment] (
    [cId] char(14)  NOT NULL,
    [cAccount] char(10)  NOT NULL,
    [dDate] datetime  NULL,
    [dThru] datetime  NULL,
    [cType_ID] char(14)  NULL,
    [lPin_note] bit  NULL,
    [lStatement] bit  NULL,
    [lRoute] bit  NULL,
    [mComment] varchar(max)  NULL,
    [nThru_date_interval] decimal(3,0)  NULL,
    [cInverse_julian] char(8)  NULL,
    [lActive] bit  NULL,
    [nOld_route] decimal(3,0)  NULL,
    [cOld_day] char(2)  NULL,
    [tTime_stamp] datetime  NULL
);
GO

-- Creating table 'dComment_Type_Setup'
CREATE TABLE [dbo].[dComment_Type_Setup] (
    [cID] char(14)  NOT NULL,
    [cDescript] char(30)  NULL,
    [lPin_note] bit  NULL,
    [lStatement] bit  NULL,
    [lRoute] bit  NULL,
    [lComment_required] bit  NULL,
    [cImage_ID] char(14)  NULL,
    [cAuto_link_entity] char(1)  NULL,
    [mPredefined] varchar(max)  NULL,
    [nThru_date_interval] decimal(3,0)  NULL,
    [tTime_stamp] datetime  NULL
);
GO

-- Creating table 'dOVP_LOOKUPRole'
CREATE TABLE [dbo].[dOVP_LOOKUPRole] (
    [LOOKUPRoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(100)  NULL,
    [RoleDescription] varchar(500)  NULL,
    [RowCreatedSYSUserID] int  NOT NULL,
    [RowCreatedDateTime] datetime  NULL,
    [RowModifiedSYSUserID] int  NOT NULL,
    [RowModifiedDateTime] datetime  NULL
);
GO

-- Creating table 'dOVP_SYSUser'
CREATE TABLE [dbo].[dOVP_SYSUser] (
    [SYSUserID] int IDENTITY(1,1) NOT NULL,
    [LoginName] varchar(50)  NOT NULL,
    [PasswordEncryptedText] varchar(200)  NOT NULL,
    [RowCreatedSYSUserID] int  NOT NULL,
    [RowCreatedDateTime] datetime  NULL,
    [RowModifiedSYSUserID] int  NOT NULL,
    [RowModifiedDateTime] datetime  NULL,
    [lConfirmedEmail] bit  NOT NULL,
    [cEmail] varchar(50)  NULL,
    [cAccount] varchar(10)  NULL,
    [cEncrytedToken] varchar(50)  NULL
);
GO

-- Creating table 'dOVP_SYSUserProfile'
CREATE TABLE [dbo].[dOVP_SYSUserProfile] (
    [SYSUserProfileID] int IDENTITY(1,1) NOT NULL,
    [SYSUserID] int  NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [RowCreatedSYSUserID] int  NOT NULL,
    [RowCreatedDateTime] datetime  NULL,
    [RowModifiedSYSUserID] int  NOT NULL,
    [RowModifiedDateTime] datetime  NULL
);
GO

-- Creating table 'dOVP_SYSUserRole'
CREATE TABLE [dbo].[dOVP_SYSUserRole] (
    [SYSUserRoleID] int IDENTITY(1,1) NOT NULL,
    [SYSUserID] int  NOT NULL,
    [LOOKUPRoleID] int  NOT NULL,
    [IsActive] bit  NULL,
    [RowCreatedSYSUserID] int  NOT NULL,
    [RowCreatedDateTime] datetime  NULL,
    [RowModifiedSYSUserID] int  NOT NULL,
    [RowModifiedDateTime] datetime  NULL
);
GO

-- Creating table 'dRoute'
CREATE TABLE [dbo].[dRoute] (
    [cID] char(14)  NOT NULL,
    [cAccount] char(10)  NOT NULL,
    [cRoute_ID] char(14)  NOT NULL,
    [nSequence] decimal(9,4)  NULL,
    [dStart_date] datetime  NULL,
    [dStop_date] datetime  NULL,
    [cRoute_Cycle_ID] char(14)  NOT NULL,
    [lActive] bit  NULL,
    [cLink_ID] char(14)  NULL,
    [tTime_stamp] datetime  NULL,
    [cAlt_Route_ID] char(14)  NULL,
    [nAlt_Sequence] decimal(9,4)  NULL,
    [cBearing] char(3)  NULL,
    [cGeo_Index] char(20)  NULL,
    [cLatitude] char(13)  NULL,
    [cLongitude] char(13)  NULL,
    [cOnRoute_1] char(1)  NULL,
    [cOnRoute_2] char(1)  NULL,
    [cService_Window_1_Start_Time] char(8)  NULL,
    [cService_Window_1_End_Time] char(8)  NULL,
    [cService_Window_2_Start_Time] char(8)  NULL,
    [cService_Window_2_End_Time] char(8)  NULL,
    [cService_No_Service_Start_Time] char(8)  NULL,
    [cService_No_Service_End_Time] char(8)  NULL
);
GO

-- Creating table 'dRoute_Cycle_Date'
CREATE TABLE [dbo].[dRoute_Cycle_Date] (
    [cRoute_Cycle_ID] char(14)  NOT NULL,
    [dDate] datetime  NOT NULL,
    [tTime_stamp] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [cAccount] in table 'dCustomer'
ALTER TABLE [dbo].[dCustomer]
ADD CONSTRAINT [PK_dCustomer]
    PRIMARY KEY CLUSTERED ([cAccount] ASC);
GO

-- Creating primary key on [cID] in table 'dTray'
ALTER TABLE [dbo].[dTray]
ADD CONSTRAINT [PK_dTray]
    PRIMARY KEY CLUSTERED ([cID] ASC);
GO

-- Creating primary key on [cWorkorder] in table 'dWorkOrder'
ALTER TABLE [dbo].[dWorkOrder]
ADD CONSTRAINT [PK_dWorkOrder]
    PRIMARY KEY CLUSTERED ([cWorkorder] ASC);
GO

-- Creating primary key on [cID] in table 'dWorkorder_Charge'
ALTER TABLE [dbo].[dWorkorder_Charge]
ADD CONSTRAINT [PK_dWorkorder_Charge]
    PRIMARY KEY CLUSTERED ([cID] ASC);
GO

-- Creating primary key on [cID] in table 'dWorkorder_Comment'
ALTER TABLE [dbo].[dWorkorder_Comment]
ADD CONSTRAINT [PK_dWorkorder_Comment]
    PRIMARY KEY CLUSTERED ([cID] ASC);
GO

-- Creating primary key on [cWorkorder_Type], [cLevel] in table 'dWorkorder_Setup'
ALTER TABLE [dbo].[dWorkorder_Setup]
ADD CONSTRAINT [PK_dWorkorder_Setup]
    PRIMARY KEY CLUSTERED ([cWorkorder_Type], [cLevel] ASC);
GO

-- Creating primary key on [cId] in table 'dCharge'
ALTER TABLE [dbo].[dCharge]
ADD CONSTRAINT [PK_dCharge]
    PRIMARY KEY CLUSTERED ([cId] ASC);
GO

-- Creating primary key on [cCode] in table 'dCode'
ALTER TABLE [dbo].[dCode]
ADD CONSTRAINT [PK_dCode]
    PRIMARY KEY CLUSTERED ([cCode] ASC);
GO

-- Creating primary key on [cMessageID] in table 'dOVP_Message'
ALTER TABLE [dbo].[dOVP_Message]
ADD CONSTRAINT [PK_dOVP_Message]
    PRIMARY KEY CLUSTERED ([cMessageID] ASC);
GO

-- Creating primary key on [cId] in table 'dComment'
ALTER TABLE [dbo].[dComment]
ADD CONSTRAINT [PK_dComment]
    PRIMARY KEY CLUSTERED ([cId] ASC);
GO

-- Creating primary key on [cID] in table 'dComment_Type_Setup'
ALTER TABLE [dbo].[dComment_Type_Setup]
ADD CONSTRAINT [PK_dComment_Type_Setup]
    PRIMARY KEY CLUSTERED ([cID] ASC);
GO

-- Creating primary key on [LOOKUPRoleID] in table 'dOVP_LOOKUPRole'
ALTER TABLE [dbo].[dOVP_LOOKUPRole]
ADD CONSTRAINT [PK_dOVP_LOOKUPRole]
    PRIMARY KEY CLUSTERED ([LOOKUPRoleID] ASC);
GO

-- Creating primary key on [SYSUserID] in table 'dOVP_SYSUser'
ALTER TABLE [dbo].[dOVP_SYSUser]
ADD CONSTRAINT [PK_dOVP_SYSUser]
    PRIMARY KEY CLUSTERED ([SYSUserID] ASC);
GO

-- Creating primary key on [SYSUserProfileID] in table 'dOVP_SYSUserProfile'
ALTER TABLE [dbo].[dOVP_SYSUserProfile]
ADD CONSTRAINT [PK_dOVP_SYSUserProfile]
    PRIMARY KEY CLUSTERED ([SYSUserProfileID] ASC);
GO

-- Creating primary key on [SYSUserRoleID] in table 'dOVP_SYSUserRole'
ALTER TABLE [dbo].[dOVP_SYSUserRole]
ADD CONSTRAINT [PK_dOVP_SYSUserRole]
    PRIMARY KEY CLUSTERED ([SYSUserRoleID] ASC);
GO

-- Creating primary key on [cID] in table 'dRoute'
ALTER TABLE [dbo].[dRoute]
ADD CONSTRAINT [PK_dRoute]
    PRIMARY KEY CLUSTERED ([cID] ASC);
GO

-- Creating primary key on [cRoute_Cycle_ID], [dDate] in table 'dRoute_Cycle_Date'
ALTER TABLE [dbo].[dRoute_Cycle_Date]
ADD CONSTRAINT [PK_dRoute_Cycle_Date]
    PRIMARY KEY CLUSTERED ([cRoute_Cycle_ID], [dDate] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LOOKUPRoleID] in table 'dOVP_SYSUserRole'
ALTER TABLE [dbo].[dOVP_SYSUserRole]
ADD CONSTRAINT [FK__dOVP_SYSU__LOOKU__534E2C48]
    FOREIGN KEY ([LOOKUPRoleID])
    REFERENCES [dbo].[dOVP_LOOKUPRole]
        ([LOOKUPRoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__dOVP_SYSU__LOOKU__534E2C48'
CREATE INDEX [IX_FK__dOVP_SYSU__LOOKU__534E2C48]
ON [dbo].[dOVP_SYSUserRole]
    ([LOOKUPRoleID]);
GO

-- Creating foreign key on [SYSUserID] in table 'dOVP_SYSUserProfile'
ALTER TABLE [dbo].[dOVP_SYSUserProfile]
ADD CONSTRAINT [FK__dOVP_SYSU__SYSUs__4D9552F2]
    FOREIGN KEY ([SYSUserID])
    REFERENCES [dbo].[dOVP_SYSUser]
        ([SYSUserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__dOVP_SYSU__SYSUs__4D9552F2'
CREATE INDEX [IX_FK__dOVP_SYSU__SYSUs__4D9552F2]
ON [dbo].[dOVP_SYSUserProfile]
    ([SYSUserID]);
GO

-- Creating foreign key on [SYSUserID] in table 'dOVP_SYSUserRole'
ALTER TABLE [dbo].[dOVP_SYSUserRole]
ADD CONSTRAINT [FK__dOVP_SYSU__SYSUs__54425081]
    FOREIGN KEY ([SYSUserID])
    REFERENCES [dbo].[dOVP_SYSUser]
        ([SYSUserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__dOVP_SYSU__SYSUs__54425081'
CREATE INDEX [IX_FK__dOVP_SYSU__SYSUs__54425081]
ON [dbo].[dOVP_SYSUserRole]
    ([SYSUserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------