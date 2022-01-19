using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using CaotunSpring.DH.Tools;
using RadzenDh5.Data;
using Microsoft.EntityFrameworkCore;

namespace RadzenDh5.Pages
{
    //public partial class XXP070PltDtlsComponent
    // public partial class P070PltDtlsComponent
    public partial class P070PDAComponent
    {
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P070";
            await base.OnInitializedAsync();
            await Load();
            // FOR DEV USAGE
            //GoodMsg = $@"USER_ID={DhUser}, USER_NAME={DhUsername}, PROG_ID={PROG_ID}, PROG_WRT(APPROVE,UPDATE) = ({progWrt.APPROVE_WRT},{progWrt.UPDATE_WRT}) ";
            //ErrMsg = $@"USER_ID={DhUser}, USER_NAME={DhUsername}, PROG_ID={PROG_ID}, PROG_WRT(APPROVE,UPDATE) = ({progWrt.APPROVE_WRT},{progWrt.UPDATE_WRT}) ";
        }
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> _getPltDtlsResult;



        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult
        {
            get
            {
                return _getPltDtlsResult;
            }
            set
            {
                if (!object.Equals(_getPltDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPltDtlsResult", NewValue = value, OldValue = _getPltDtlsResult };
                    _getPltDtlsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }


        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetPltDtlsResult = await Mark10Sqlexpress04.GetPltDtls();
            getPltDtlsResult = mark10Sqlexpress04GetPltDtlsResult;
        }




        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> getVp070sResult1 { get; set; } // as source
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> getVp070sResult2 { get; set; } // as target


        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList1 { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList2 { get; set; }

        public string tbPLT1; // same name as WES
        public string tbPLT2;
        //if (sName == "tbPLT1") { dtPLT1.Clear(); dtPLT1 = dtTable.Copy(); tbGW_S.Text = Decimal.Round(dGrossWeight, 3).ToString(); tbV_S.Text = Decimal.Round(dVolume, 3).ToString();

        //if (sName == "tbPLT2") { dtPLT2.Clear(); dtPLT2 = dtTable.Copy(); tbGW_T.Text = Decimal.Round(dGrossWeight, 3).ToString(); tbV_T.Text = Decimal.Round(dVolume, 3).ToString();
        public string tbGW_S { get { return "" + _tbGW_S; } set { tbGW_S = value; } }
        public string tbV_S { get { return "" + _tbV_S; } set { tbV_S = value; } }
        public string tbGW_T { get { return "" + _tbGW_T; } set { tbGW_T = value; } }
        public string tbV_T { get { return "" + _tbV_T; } set { tbV_T = value; } }

        public decimal _tbGW_S;
        public decimal _tbV_S;
        public decimal _tbGW_T;
        public decimal _tbV_T;


        public string GW_VOL = "GWt(KG)/Vol(M3)";



        public (bool, string) CommonCheck()
        {
            //if (!DhGlobals.IsAuthApprove(Security.User.UserName, "P070"))
            //{
            //    // NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.no_authorization_to_execute);
            //    return (false, DhGlobalStatic.no_authorization_to_execute);
            //}
            if (tbPLT1 == null || tbPLT1 == "") // 一開始還沒填, 或是後來清空
            {
                //    NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.destination_storage_unit_number_must_input);
                return (false, DhGlobalStatic.source_storage_unit_number_must_input);
            }
            if (tbPLT2 == null || tbPLT2 == "") // 一開始還沒填, 或是後來清空
            {
                //    NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.destination_storage_unit_number_must_input);
                return (false, DhGlobalStatic.destination_storage_unit_number_must_input);
            }

            tbPLT1 = tbPLT1.Trim();//自動去掉前後空格, 預期會反應到用戶的頁面效果
            if (tbPLT1.Length != 6)
            {
                NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.source_storage_unit_number_incorrect);
                return (false, DhGlobalStatic.source_storage_unit_number_incorrect);
            }
            tbPLT2 = tbPLT2.Trim();//自動去掉前後空格, 預期會反應到用戶的頁面效果
            if (tbPLT2.Length != 6)
            {
                NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.destination_storage_unit_number_incorrect);
                return (false, DhGlobalStatic.source_storage_unit_number_incorrect);
            }
            return (true, "OK");
        }

        public (bool, string) CheckWeightVolume(RadzenDh5.Models.Mark10Sqlexpress04.Vp070 row, string sSU_ID_TO, string sLOC_NO_TO, string sSU_TYPE_TO, decimal dGrossWeight_TO, decimal dVolume_TO)
        {
            decimal dSKU_QTY = Convert.ToDecimal(row.SKU_QTY);
            string sLOC_QTY = Convert.ToString(row.LOC_QTY);
            string sGROSS_WEIGHT = Convert.ToString(row.GROSS_WEIGHT);
            string sNET_WEIGHT = Convert.ToString(row.NET_WEIGHT);    // 目前沒有
            string sWEIGHT_UNIT = Convert.ToString(row.WEIGHT_UNIT);  // 目前沒有
            string sVOLUME = Convert.ToString(row.VOLUME);
            string sVOLUME_UNIT = Convert.ToString(row.VOLUME_UNIT);

            dGrossWeight_TO = dGrossWeight_TO + Decimal.Round(Convert.ToDecimal(sGROSS_WEIGHT) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
            dVolume_TO = dVolume_TO + Decimal.Round(Convert.ToDecimal(sVOLUME) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);


            decimal WeightLimit = 960;

            // DEBUG TESTING PURPOSE
            //decimal WeightLimit = 1;

            if (dGrossWeight_TO > WeightLimit)
            {
                return (false, "Can't over 960KG");
            }



            decimal L1Limit = (Decimal)1.617;
            decimal L2Limit = (Decimal)1.925;



            if (sSU_TYPE_TO == "L1" && dVolume_TO > L1Limit)
            {
                return (false, "Storage unit type L1 can't over 1.617 M3");
            }
            if (sSU_TYPE_TO == "L2" && dVolume_TO > L2Limit)
            {
                return (false, "Storage unit type L2 can't over 1.925 M3");
            }
            return (true, "OK");

        }


        public async Task<(bool, string)> ChangePalletQty(RadzenDh5.Models.Mark10Sqlexpress04.Vp070 row, string sSU_ID_TO, string sLOC_NO_TO, string sSU_TYPE_TO, decimal dGrossWeight_TO, decimal dVolume_TO)
        {
            //if (string.IsNullOrEmpty(sSU_ID_TO)) throw new Exception("destination storage unit number must input");
            //if (sSU_ID_TO.Length != 6) throw new Exception("destination storage unit number incorrect");
            if (string.IsNullOrEmpty(sSU_ID_TO))
            {
                return (false, "destination storage unit number must input");
            }
            if (sSU_ID_TO.Length != 6)
            {
                return (false, "destination storage unit number incorrect");
            }

            (bool IsCheck1Ok, string Check1Msg) = CheckWeightVolume(row, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight_TO, dVolume_TO);
            if (!IsCheck1Ok)
            {
                return (false, Check1Msg);
            }

            //https://docs.microsoft.com/en-us/ef/core/saving/transactions
            using var transaction = AppDb.Database.BeginTransaction();
            //string sWHSE_NO = Convert.ToString(dgvRow.Cells["WHSE_NO"].Value);
            //string sIN_NO = Convert.ToString(dgvRow.Cells["IN_NO"].Value);
            //string sIN_LINE = Convert.ToString(dgvRow.Cells["IN_LINE"].Value);
            //string sSU_ID = Convert.ToString(dgvRow.Cells["SU_ID"].Value);
            //string sSU_TYPE = Convert.ToString(dgvRow.Cells["SU_TYPE"].Value);
            //string sIN_SNO = Convert.ToString(dgvRow.Cells["IN_SNO"].Value);

            //string sGR_DATE = Convert.ToString(dgvRow.Cells["GR_DATE"].Value);
            //string sEXPIRE_DATE = Convert.ToString(dgvRow.Cells["EXPIRE_DATE"].Value);
            //string sDATE_CODE = Convert.ToString(dgvRow.Cells["DATE_CODE"].Value);

            //string sPLANT = Convert.ToString(dgvRow.Cells["PLANT"].Value);
            //string sSTGE_LOC = Convert.ToString(dgvRow.Cells["STGE_LOC"].Value);
            //string sSKU_NO = Convert.ToString(dgvRow.Cells["SKU_NO"].Value);
            //string sBATCH_NO = Convert.ToString(dgvRow.Cells["BATCH_NO"].Value);
            //string sSTK_CAT = Convert.ToString(dgvRow.Cells["STK_CAT"].Value);
            //string sSTK_SPECIAL_IND = Convert.ToString(dgvRow.Cells["STK_SPECIAL_IND"].Value);
            //string sSTK_SPECIAL_NO = Convert.ToString(dgvRow.Cells["STK_SPECIAL_NO"].Value);
            //string sGTIN_UNIT = Convert.ToString(dgvRow.Cells["GTIN_UNIT"].Value);
            //string sGTIN_QTY = Convert.ToString(dgvRow.Cells["GTIN_QTY"].Value);

            string sWHSE_NO = Convert.ToString(row.WHSE_NO);
            string sIN_NO = Convert.ToString(row.IN_NO);
            string sIN_LINE = Convert.ToString(row.IN_LINE);
            string sSU_ID = Convert.ToString(row.SU_ID);
            string sSU_TYPE = Convert.ToString(row.SU_TYPE);
            string sIN_SNO = Convert.ToString(row.IN_SNO);

            string sGR_DATE = Convert.ToString(row.GR_DATE);
            string sEXPIRE_DATE = Convert.ToString(row.EXPIRE_DATE);
            string sDATE_CODE = Convert.ToString(row.DATE_CODE);

            string sPLANT = Convert.ToString(row.PLANT);
            string sSTGE_LOC = Convert.ToString(row.STGE_LOC);
            string sSKU_NO = Convert.ToString(row.SKU_NO);
            string sBATCH_NO = Convert.ToString(row.BATCH_NO);
            string sSTK_CAT = Convert.ToString(row.STK_CAT);
            string sSTK_SPECIAL_IND = Convert.ToString(row.STK_SPECIAL_IND);
            string sSTK_SPECIAL_NO = Convert.ToString(row.STK_SPECIAL_NO);
            string sGTIN_UNIT = Convert.ToString(row.GTIN_UNIT);
            string sGTIN_QTY = Convert.ToString(row.GTIN_QTY);

            bool bDelete = true;
            string sGTIN_QTY_OLD = Convert.ToString(row.GTIN_QTY);
            if (string.IsNullOrEmpty(sGTIN_QTY_OLD)) sGTIN_QTY_OLD = sGTIN_QTY;
            if (sGTIN_QTY_OLD != sGTIN_QTY) bDelete = false;

            string sSKU_UNIT = Convert.ToString(row.SKU_UNIT);
            string sSKU_QTY = Convert.ToString(row.SKU_QTY);
            string sCOUNT_DATE = Convert.ToString(row.COUNT_DATE);

            decimal dGTIN_QTY = Convert.ToDecimal(row.GTIN_QTY);
            decimal dSKU_QTY = Convert.ToDecimal(row.SKU_QTY);

            string sSTGE_TYPE = Convert.ToString(row.STGE_TYPE);
            string sSTGE_BIN = Convert.ToString(row.STGE_BIN);
            string sLOC_NO = Convert.ToString(row.LOC_NO);
            decimal dGTIN_NUMERATOR = Convert.ToDecimal(row.GTIN_NUMERATOR);
            decimal dGTIN_DENOMINATOR = Convert.ToDecimal(row.GTIN_DENOMINATOR);
            string sGROSS_WEIGHT = Convert.ToString(row.GROSS_WEIGHT);
            string sNET_WEIGHT = Convert.ToString(row.NET_WEIGHT);
            string sWEIGHT_UNIT = Convert.ToString(row.WEIGHT_UNIT);
            string sVOLUME = Convert.ToString(row.VOLUME);
            string sVOLUME_UNIT = Convert.ToString(row.VOLUME_UNIT);
            string sLOC_QTY = Convert.ToString(row.LOC_QTY);

            dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;

            //計算移動的GROSS_WEIGHT,NET_WEIGHT,VOLUME

            decimal dGrossWeight = Decimal.Round(Convert.ToDecimal(sGROSS_WEIGHT) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
            decimal dNetWeight = Decimal.Round(Convert.ToDecimal(sNET_WEIGHT) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
            decimal dVolume = Decimal.Round(Convert.ToDecimal(sVOLUME) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);

            string sSQL;
            int cnt1 = 0;
            int cnt2 = 0;
            int cnt3 = 0;
            int cnt4 = 0;
            int cnt5 = 0;
            int cnt6 = 0;
            int cnt7 = 0;
            int cnt8 = 0;
            int cnt9 = 0;
            //insert PLT_DTL_HIS from PLT1.IN_SNO(source)
            try
            {

                sSQL = string.Format(@"
                        insert into PLT_DTL_HIS
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                        from PLT_DTL 
                        where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                    ", await DhGlobals.GetDhUsernameAsync(Security.User.UserName), sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                //iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                //if (iResult < 1) throw new Exception("data not create:" + sSQL);





                cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                if (cnt1 < 1)
                {
                    return (false, "data not create:" + sSQL);
                }


                //  NotificationService.Notify(NotificationSeverity.Error, $@" 寫入HISTORY {cnt1}筆"); // NOTE by Mark, 05/04, working very well
                //insert PLT_DTL_HIS from PLT2.IN_SNO
                if (sIN_SNO == "**********") //無序列號
                {
                    //insert PLT_DTL_HIS from PLT1.IN_SNO(destination)
                    sSQL = string.Format(@"
                            insert into PLT_DTL_HIS
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                            from PLT_DTL 
                            where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                        ", await DhGlobals.GetDhUsernameAsync(Security.User.UserName), sSU_ID_TO, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                    //iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                    if (cnt2 > 0) //目標托盤已存在
                    {
                        //update PLT_DTL(destination)
                        sSQL = string.Format(@"
                                update PLT_DTL set GTIN_QTY=GTIN_QTY+{5},SKU_QTY=SKU_QTY+{6}
                                where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                            ", sWHSE_NO, sSU_ID_TO, sIN_NO, sIN_LINE, sIN_SNO, dGTIN_QTY, dSKU_QTY);

                        cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        if (cnt3 < 1)
                        {
                            //throw new Exception("data not update:" + sSQL);
                            return (false, "data not update:" + sSQL);
                        }
                        if (!bDelete)
                        {
                            //updat PLT_DTL(source)
                            sSQL = string.Format(@"
                                    update PLT_DTL set GTIN_QTY=GTIN_QTY-{5},SKU_QTY=SKU_QTY-{6}
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                                ", sWHSE_NO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, dGTIN_QTY, dSKU_QTY);
                            cnt4 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                            if (cnt4 < 1)
                            {
                                return (false, "data not update:" + sSQL);
                            }
                        }
                        else
                        {
                            //delete PLT_DTL(source)
                            sSQL = string.Format(@"
                                    delete PLT_DTL 
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                                ", sWHSE_NO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO);
                            cnt5 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                            if (cnt5 < 1)
                            {
                                return (false, "data not update:" + sSQL);
                            }
                        }
                    }
                    else
                    {
                        if (!bDelete) //拆成2筆
                        {
                            //insert PLT_DTL(destination)
                            sSQL = string.Format(@"
                                    insert into PLT_DTL 
                                    select '{0}' as SU_ID,SU_TYPE,IN_SNO,WHSE_NO,IN_NO,IN_LINE,GR_DATE,EXPIRE_DATE,DATE_CODE,SKU_NO,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,{1} as GTIN_QTY,SKU_UNIT,{2} as SKU_QTY,'0000-00-00' as COUNT_DATE,0 as GTIN_ALO_QTY,0 as SKU_ALO_QTY
                                    where SU_ID='{3}' and IN_NO='{4}' and IN_LINE='{5}' and IN_SNO='{6}' and WHSE_NO='{7}'
                                ", sSU_ID_TO, dGTIN_QTY, dSKU_QTY, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);

                            cnt6 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                            if (cnt6 < 1)
                            {
                                return (false, "data not creat:" + sSQL);
                            }
                            //updat PLT_DTL(source)
                            sSQL = string.Format(@"
                                    update PLT_DTL set GTIN_QTY=GTIN_QTY-{5},SKU_QTY=SKU_QTY-{6}
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                                ", sWHSE_NO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, dGTIN_QTY, dSKU_QTY);
                            cnt7 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                            if (cnt7 < 1)
                            {
                                return (false, "data not update:" + sSQL);
                            }
                        }
                        else
                        {
                            //直接整筆更新為新托盤ID
                            //update PLT_DTL(source) to destination
                            sSQL = string.Format(@"
                                    update PLT_DTL set SU_ID='{0}'
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                                ", sSU_ID_TO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);

                            cnt8 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                            if (cnt8 < 1)
                            {
                                return (false, "data not update:" + sSQL);
                            }
                        }
                    }
                }
                else //有序列號，直接更新SU_ID為目的托盤
                {
                    //update PLT_DTL(source) to destination
                    sSQL = string.Format(@"
                            update PLT_DTL set SU_ID='{0}'
                            where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                        ", sSU_ID_TO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                    cnt9 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                    if (cnt9 < 1)
                    {
                        return (false, "data not update:" + sSQL);
                    }
                }


                //https://www.entityframeworktutorial.net/entityframework6/transaction-in-entity-framework.aspx
                // WORKING HERE 
                //NotificationService.Notify(NotificationSeverity.Error, $@"  寫入HISTORY ({cnt1},{cnt2},{cnt3},{cnt4},{cnt5},{cnt6},{cnt7},{cnt8},{cnt9}) 筆"); // NOTE by Mark, 05/04, working very well

                // NOTE by Mark,05/04,  這是第二部分
                //insert LOC_DTL_HIS from PLT1(source)

                sSQL = string.Format(@"
                        insert into LOC_DTL_HIS
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                        from LOC_DTL 
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}'
                    ", await DhGlobals.GetDhUsernameAsync(Security.User.UserName), sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                if (cnt1 < 1)
                {
                    return (false, "data not update:" + sSQL);
                }

                //delete or update LOC_DTL from PLT1(source)
                //dtSQL = new DataTable();
                sSQL = string.Format(@"
                        select * from LOC_DTL
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{0}'
                    ", sGTIN_UNIT, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                //dtSQL = new DataTable();
                //WMSDB.funGetDT(sSQL, ref dtSQL, dbConnection, dbTransaction);
                var obj2 = await AppDb.LocDtls.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();
                // #3885 of Globals.cs
                cnt2 = obj2.Count();
                if (obj2.Count() > 0)
                {
                    //Source LOC_DTL
                    var src = obj2.FirstOrDefault();
                    decimal dGtinQty = Convert.ToDecimal(src.GTIN_QTY);
                    decimal dGtinAloQty = Convert.ToDecimal(src.GTIN_ALO_QTY);
                    if (dGtinAloQty > 0)
                    {
                        return (false, "this pallet have allocate quanity, can't move");
                    }

                    if (dGtinQty > dGTIN_QTY) //拆行
                    {
                        //update LOC_DTL(source)
                        dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;
                        sSQL = string.Format(@"
                                update LOC_DTL set GTIN_QTY=GTIN_QTY-{0},SKU_QTY=SKU_QTY-{1},TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}',GROSS_WEIGHT=GROSS_WEIGHT-{13},NET_WEIGHT=NET_WEIGHT-{14},VOLUME=VOLUME-{15}
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and GTIN_UNIT='{12}'
                            ", dGTIN_QTY, dSKU_QTY, await DhGlobals.GetDhUsernameAsync(Security.User.UserName), sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGrossWeight, dNetWeight, dVolume);
                        cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                        if (cnt3 < 1)
                        {
                            return (false, "data not update:" + sSQL);
                        }

                    }
                    else //#3902
                    {
                        //delete
                        sSQL = string.Format(@"
                                delete LOC_DTL
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and GTIN_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                        cnt4 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                        if (cnt4 < 1)
                        {
                            return (false, "data not update:" + sSQL);
                        }
                    }

                }
                else
                {
                    //異常 #3915
                    return (false, "#3915 data not update:" + sSQL);
                }

                //insert LOC_DTL_HIS from PLT2(destination) #3919
                sSQL = string.Format(@"
                        insert into LOC_DTL_HIS
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                        from LOC_DTL 
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}'
                    ", await DhGlobals.GetDhUsernameAsync(Security.User.UserName), sWHSE_NO, sSU_ID_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                cnt5 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);


                //Insert or update LOC_DTL from PLT2(destination)
                sSQL = string.Format(@"
                        select * from LOC_DTL
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{0}'
                    ", sGTIN_UNIT, sWHSE_NO, sSU_ID_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                var obj6 = await AppDb.LocDtls.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();
                cnt6 = obj6.Count();


                if (cnt6 > 0)//目標數據已存在 #3936
                {
                    dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;
                    //destination LOC_DTL
                    //update
                    sSQL = string.Format(@"
                            update LOC_DTL set GTIN_QTY=GTIN_QTY+{0},SKU_QTY=SKU_QTY+{1},TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}',GROSS_WEIGHT=GROSS_WEIGHT+{13},NET_WEIGHT=NET_WEIGHT+{14},VOLUME=VOLUME+{15}
                            where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and GTIN_UNIT='{12}'
                        ", dGTIN_QTY, dSKU_QTY, await DhGlobals.GetDhUsernameAsync(Security.User.UserName), sWHSE_NO, sSU_ID_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGrossWeight, dNetWeight, dVolume);
                    cnt7 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                    if (cnt7 < 1)
                    {
                        return (false, "#3946, data not update:" + sSQL);
                    }
                }
                else //#3948
                {
                    //insert
                    dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;
                    sSQL = string.Format(@"
                            insert into LOC_DTL(WHSE_NO,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_ALO_QTY,SKU_ALO_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}',convert(varchar(19),getdate(),20),'{27}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sSTGE_TYPE, sSTGE_BIN, sSU_ID_TO, sSU_TYPE_TO, sLOC_NO_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY, sSKU_UNIT, dSKU_QTY, dGTIN_NUMERATOR, dGTIN_DENOMINATOR, dGrossWeight, dNetWeight, sWEIGHT_UNIT, dVolume, sVOLUME_UNIT, 0, 0, ""
                            , await DhGlobals.GetDhUsernameAsync(Security.User.UserName));
                    cnt8 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                    if (cnt8 < 1)
                    {
                        return (false, "#3957, data not update:" + sSQL);
                    }
                }

                //NotificationService.Notify(NotificationSeverity.Error, $@"  寫入HISTORY ({cnt1},{cnt2},{cnt3},{cnt4},{cnt5},{cnt6},{cnt7},{cnt8},{cnt9}) 筆"); // NOTE by Mark, 05/04, working very well

                //生成TX_LOG & TX_SNO #3960
                string sCMD_DATE = DhGlobals.GetCmdDate();
                // DateTime.Now.ToString("yyMMdd");
                //  string sTX_NO = sCMD_DATE + GetCmdSno(ref dbConnection, ref dbTransaction, "TX", sCMD_DATE, 4);

                (bool IsSnoTX, string SnoTxMsg) = await GetCmdSnoTrans("TX", sCMD_DATE, 4);
                if (!IsSnoTX)
                {
                    return (false, SnoTxMsg);

                }

                string sTX_NO = sCMD_DATE + SnoTxMsg;

                //生成TX_LOG   LINE#3964
                sSQL = string.Format(@"
                        insert into TX_LOG (WHSE_NO,TX_NO,TX_LINE,STGE_TYPE,STGE_TYPE_TO,STGE_BIN,STGE_BIN_TO,SU_ID,SU_ID_TO,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,TX_USER,TX_DATE,TX_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}',convert(varchar(19),getdate(),20),'X','','1','Y','{21}',convert(varchar(19),getdate(),20),'{21}',convert(varchar(19),getdate(),20))
                    ", sWHSE_NO, sTX_NO, "0001", sSTGE_TYPE, sSTGE_TYPE, sSTGE_BIN, sSTGE_BIN, sSU_ID, sSU_ID_TO, sLOC_NO_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY, sSKU_UNIT, dSKU_QTY
                        , await DhGlobals.GetDhUsernameAsync(Security.User.UserName));
                cnt9 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                if (cnt9 < 1)
                {
                    return (false, "#3970, data not update:" + sSQL);
                }

                int cnt10 = 0;
                //生成TX_SNO
                sSQL = string.Format(@"
                        insert into TX_SNO 
                        select distinct '{0}' as TX_NO, '{1}' as TX_LINE, IN_SNO 
                        from PLT_DTL 
                        where SU_ID='{2}' and SKU_NO='{3}' and PLANT='{4}' and STGE_LOC='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}' and IN_SNO='{11}'
                    ", sTX_NO, "0001", sSU_ID_TO, sSKU_NO, sPLANT, sSTGE_LOC, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO);
                cnt10 = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                if (cnt10 < 1)
                {
                    return (false, "#3980, data not create:" + sSQL);
                }

            }
            catch (Exception ex)
            {
                return (false, "Exception " + ex.Message);
            }
            transaction.Commit();
            return (true, "OK");

        }

        public async Task<(bool, string)> GetCmdSnoTrans(string sType, string sDate, int iLen)
        {
            string sSQL = "";
            string sCmdSno = "";
            int iValue = 0;

            int iRet = 0;
            // Globals.cs Line# 307
            try
            {
                sSQL = string.Format(@"update SNO_CTL set SNO=SNO+1,TRN_DATE='{1}' where SNO_TYPE='{0}' and TRN_DATE='{1}'", sType, sDate);
                iRet = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                if (iRet < 1)
                {
                    iValue = 1;
                    sSQL = string.Format(@"delete SNO_CTL where SNO_TYPE='{0}'", sType);
                    iRet = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                    sSQL = "insert into SNO_CTL(SNO_TYPE,TRN_DATE,SNO) Values('" + sType + "','" + sDate + "',1)";
                    iRet = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                    if (iRet < 1)
                    {
                        return (false, "no SNO_CTL data：" + sSQL);

                    }
                    else
                    {
                        //   return iValue.ToString().PadLeft(iLen, '0');
                        return (true, iValue.ToString().PadLeft(iLen, '0'));
                    }
                }

                sSQL = "select * from SNO_CTL where SNO_TYPE='" + sType + "'";
                //dt = new DataTable();
                //WMSDB.funGetDT(sSQL, ref dt, dbConnection, dbTransaction);
                var obj = await AppDb.SnoCtls.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();
                if (obj.Count() > 0)
                {
                    var item = obj.FirstOrDefault();
                    iValue = int.Parse(Convert.ToString(item.SNO));
                    int iMax = Convert.ToInt32(Math.Pow(10, iLen) - 1);
                    if (sType == "CmdSno") iMax = 29998;
                    if (iValue > iMax)
                    {
                        iValue = 1;
                        sSQL = "update SNO_CTL set SNO=1,TRN_DATE='" + sDate + "' where SNO_TYPE='" + sType + "'";
                        iRet = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        if (iRet < 1)
                        {
                            return (false, "no SNO_CTL data：" + sSQL);
                        }
                        else
                        {
                            return (true, iValue.ToString().PadLeft(iLen, '0'));
                        }
                    }
                    else
                    {
                        sCmdSno = iValue.ToString().PadLeft(iLen, '0');
                        return (true, sCmdSno);
                    }
                }
                else
                {
                    return (false, "no SNO_CTL data：" + sSQL);
                }

            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }

        }
        public async Task OnAddClick(RadzenDh5.Models.Mark10Sqlexpress04.Vp070 item)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";




                (bool IsOk, string msg) = CommonCheck();
                if (!IsOk)
                {
                    NotificationService.Notify(NotificationSeverity.Info, msg);
                    return;
                }
                // It's time to update rows
                // It can be empty, but not null
                getVp070sResult1 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT1).AsNoTracking().ToListAsync();
                getVp070sResult2 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT2).AsNoTracking().ToListAsync();



                //string sWHSE_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["WHSE_NO"].Value);
                //string sSKU_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SKU_NO"].Value);
                //string sLOC_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["LOC_NO"].Value);
                string sWHSE_NO = item.WHSE_NO;
                string sSKU_NO = item.SKU_NO;
                string sLOC_NO = item.LOC_NO;


                string sLOC_NO_TO = sLOC_NO;
                //            if (dtPLT2.Rows.Count > 0) sLOC_NO_TO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["LOC_NO"].Value);
                if (getVp070sResult2.Count() > 0)
                {
                    sLOC_NO_TO = getVp070sResult2.FirstOrDefault().LOC_NO;
                }

                //string sSU_TYPE = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SU_TYPE"].Value);
                //string sSU_TYPE_TO = sSU_TYPE;
                string sSU_TYPE = item.SU_TYPE;
                string sSU_TYPE_TO = sSU_TYPE;
                //if (dtPLT2.Rows.Count > 0) sSU_TYPE_TO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["SU_TYPE"].Value);
                if (getVp070sResult2.Count() > 0)
                {
                    sSU_TYPE_TO = getVp070sResult2.FirstOrDefault().SU_TYPE;
                }


                //DataGridViewRow[] dgvRows = new DataGridViewRow[1];
                //dgvRows[0] = m_dgvPLT1.CurrentRow;

                //decimal dGrossWeight = Convert.ToDecimal(tbGW_T.Text);
                //decimal dVolume = Convert.ToDecimal(tbV_T.Text);

                // NOTE by Mark, 05/04
                // _T 是  TARGET
                decimal dGrossWeight = Convert.ToDecimal(tbGW_T);
                decimal dVolume = Convert.ToDecimal(tbV_T);

                // NOTE by Mark, 05/04, 直接在這裡先調試 ChangePalletQty, it's good for Add/Remove
                //Globals.ChangePalletQty(dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);
                string sSU_ID_TO = tbPLT2.Trim();

                (bool IsChanageOk, string IsChanageMsg) = await ChangePalletQty(item, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);

                if (IsChanageOk)
                {
                    NotificationService.Notify(NotificationSeverity.Success, "Change success");
                    await ButtonReloadClick();
                }
                else
                {
                    NotificationService.Notify(NotificationSeverity.Info, " Change failed " + IsChanageMsg);

                }



                await UpdateSourceWeightAndVolumeAsync();
                await UpdateTargetWeightAndVolumeAsync();
                // UpdateWeightAndVolume();
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }

        }
        public async Task OnRemoveClick(RadzenDh5.Models.Mark10Sqlexpress04.Vp070 item)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";


                (bool IsOk, string msg) = CommonCheck();
                if (!IsOk)
                {
                    NotificationService.Notify(NotificationSeverity.Info, msg);
                    return;
                }
                // It's time to update rows
                // It can be empty, but not null
                getVp070sResult1 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT1).AsNoTracking().ToListAsync();
                getVp070sResult2 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT2).AsNoTracking().ToListAsync();



                //string sWHSE_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["WHSE_NO"].Value);
                //string sSKU_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SKU_NO"].Value);
                //string sLOC_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["LOC_NO"].Value);
                string sWHSE_NO = item.WHSE_NO;
                string sSKU_NO = item.SKU_NO;
                string sLOC_NO = item.LOC_NO;


                string sLOC_NO_TO = sLOC_NO;
                //            if (dtPLT2.Rows.Count > 0) sLOC_NO_TO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["LOC_NO"].Value);
                if (getVp070sResult1.Count() > 0)
                {
                    sLOC_NO_TO = getVp070sResult1.FirstOrDefault().LOC_NO;
                }

                //string sSU_TYPE = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SU_TYPE"].Value);
                //string sSU_TYPE_TO = sSU_TYPE;
                string sSU_TYPE = item.SU_TYPE;
                string sSU_TYPE_TO = sSU_TYPE;
                //if (dtPLT2.Rows.Count > 0) sSU_TYPE_TO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["SU_TYPE"].Value);
                if (getVp070sResult1.Count() > 0)
                {
                    sSU_TYPE_TO = getVp070sResult1.FirstOrDefault().SU_TYPE;
                }


                // NOTE by Mark, 05/04
                // _S 是  Source
                decimal dGrossWeight = Convert.ToDecimal(tbGW_S); //LINE#253 of P070.cs
                decimal dVolume = Convert.ToDecimal(tbV_S);

                // NOTE by Mark, 05/04, 直接在這裡先調試 ChangePalletQty, it's good for Add/Remove
                //Globals.ChangePalletQty(dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);
                string sSU_ID_TO = tbPLT1.Trim();

                (bool IsChanageOk, string IsChanageMsg) = await ChangePalletQty(item, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);

                if (IsChanageOk)
                {
                    NotificationService.Notify(NotificationSeverity.Success, "Change success");
                    await ButtonReloadClick();
                }
                else
                {
                    NotificationService.Notify(NotificationSeverity.Info, " Change failed " + IsChanageMsg);

                }

                await UpdateSourceWeightAndVolumeAsync();
                await UpdateTargetWeightAndVolumeAsync();
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }

        public async Task ButtonReloadClick()
        {
            //   console.Log($"{buttonName} clicked");
            getVp070sResult1 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT1).AsNoTracking().ToListAsync();
            getVp070sResult2 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT2).AsNoTracking().ToListAsync();



            await UpdateSourceWeightAndVolumeAsync();
            await UpdateTargetWeightAndVolumeAsync();

            //NotificationService.Notify(NotificationSeverity.Info, "配合WES併行,如在WES有變動, 此時可以reload");
            NotificationService.Notify(NotificationSeverity.Info, "Reload success");

        }

        async Task UpdateSourceWeightAndVolumeAsync()
        {
            _tbGW_S = 0;
            _tbV_S = 0;

            //_tbGW_T = 0;
            //_tbV_T = 0;

            if (getVp070sResult1 != null && getVp070sResult1.Count() > 0)
            {
                foreach (var x in getVp070sResult1)
                {
                    _tbGW_S = _tbGW_S + (x.GROSS_WEIGHT * x.SKU_QTY) / x.LOC_QTY;
                    _tbV_S = _tbV_S + (x.VOLUME * x.SKU_QTY) / x.LOC_QTY;
                }
            }
            //if (getVp070sResult2 !=null && getVp070sResult2.Count() > 0)
            //{
            //    foreach (var x in getVp070sResult2)
            //    {
            //        _tbGW_T = _tbGW_T + (x.GROSS_WEIGHT * x.SKU_QTY) / x.LOC_QTY;
            //        _tbV_T = _tbV_T + (x.VOLUME * x.SKU_QTY) / x.LOC_QTY;
            //    }
            //}

        }

        async Task UpdateTargetWeightAndVolumeAsync()
        {
            //_tbGW_S = 0;
            //_tbV_S = 0;

            _tbGW_T = 0;
            _tbV_T = 0;

            //if (getVp070sResult1 != null && getVp070sResult1.Count() > 0)
            //{
            //    foreach (var x in getVp070sResult1)
            //    {
            //        _tbGW_S = _tbGW_S + (x.GROSS_WEIGHT * x.SKU_QTY) / x.LOC_QTY;
            //        _tbV_S = _tbV_S + (x.VOLUME * x.SKU_QTY) / x.LOC_QTY;
            //    }
            //}
            if (getVp070sResult2 != null && getVp070sResult2.Count() > 0)
            {
                foreach (var x in getVp070sResult2)
                {
                    _tbGW_T = _tbGW_T + (x.GROSS_WEIGHT * x.SKU_QTY) / x.LOC_QTY;
                    _tbV_T = _tbV_T + (x.VOLUME * x.SKU_QTY) / x.LOC_QTY;
                }
            }

        }


        protected async Task OnTxt1Change(string value, string name)
        {
            if (value.Length == 6)
            {
                //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = ".Source..寫業務邏輯", Duration = 4000 });
                //protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> getVp070sResult1 { get; set; } // as source

                getVp070sResult1 = await AppDb.Vp070s.Where(a => a.SU_ID == value).AsNoTracking().ToListAsync();

                //     StateHasChanged();

                if (getVp070sResult1.Count() > 0)
                {
                    //_tbGW_S = 0;
                    //_tbV_S = 0;
                    //foreach (var x in getVp070sResult1)
                    //{
                    //    _tbGW_S = _tbGW_S + (x.GROSS_WEIGHT * x.SKU_QTY) / x.LOC_QTY;
                    //    _tbV_S = _tbV_S + (x.VOLUME * x.SKU_QTY) / x.LOC_QTY;
                    //}


                    await UpdateSourceWeightAndVolumeAsync();
                    await UpdateTargetWeightAndVolumeAsync();
                }
                else
                {
                    NotificationService.Notify(NotificationSeverity.Info, "Source has no records");

                }

            }
            else
            {
                NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.incorect_storage_unit_number);
                getVp070sResult1 = null;
                _tbGW_S = 0;
                _tbV_S = 0;

            }
        }
        protected async Task OnTxt2Change(string value, string name)
        {
            //   console.Log($"{name} value changed to {value}");
            if (value.Length == 6)
            {
                //                pltDtlsList2 = AppDb.PltDtls.Where(a => a.SU_ID == value).ToList();
                getVp070sResult2 = await AppDb.Vp070s.Where(a => a.SU_ID == value).AsNoTracking().ToListAsync();

                if (getVp070sResult2.Count() > 0)
                {
                    //_tbGW_T = 0;
                    //_tbV_T = 0;
                    //foreach (var x in getVp070sResult2)
                    //{
                    //    _tbGW_T = _tbGW_T + (x.GROSS_WEIGHT * x.SKU_QTY) / x.LOC_QTY;
                    //    _tbV_T = _tbV_T + (x.VOLUME * x.SKU_QTY) / x.LOC_QTY;
                    //}

                    await UpdateSourceWeightAndVolumeAsync();
                    await UpdateTargetWeightAndVolumeAsync();
                }
                else
                {
                    NotificationService.Notify(NotificationSeverity.Info, "Target has no records");

                }

            }
            else
            {
                NotificationService.Notify(NotificationSeverity.Info, DhGlobalStatic.incorect_storage_unit_number);

                getVp070sResult2 = null;
                _tbGW_T = 0;
                _tbV_T = 0;

            }

        }


        //public void ToAdd()
        //{
        //    var Summary = "TODO";
        //    var Detail = "這部份業務邏輯比較多, 要另外花時間處理";
        //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = Summary, Detail = Detail, Duration = 4000 });

        //}
        //public void ToRemove()
        //{
        //    var Summary = "TODO";
        //    var Detail = "這部份業務邏輯比較多, 要另外花時間處理";
        //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = Summary, Detail = Detail, Duration = 4000 });

        //}

    }
}
