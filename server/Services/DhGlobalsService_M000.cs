//using CaotunSpring.DH.Tools.Data;
//using RadzenDh5.Models;
using RadzenDh5.DHModels;
using RadzenDh5.DHData;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using NPOI.XSSF.UserModel;

namespace CaotunSpring.DH.Tools
{
    public static class IWorkBookExtensions
    {

        //https://stackoverflow.com/questions/53647766/npoi-export-excel-directly-to-frontend-without-saving-it-on-server
        public static void WriteExcelToResponse(this IWorkbook book, HttpContext httpContext, string templateName)
        {
            var response = httpContext.Response;
            response.ContentType = "application/vnd.ms-excel";
            if (!string.IsNullOrEmpty(templateName))
            {
                var contentDisposition = new Microsoft.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                contentDisposition.SetHttpFileName(templateName);
                response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
            }
            book.Write(response.Body);
        }
    }
    public partial class DhGlobalsService
    {
        //if (sPRTY == sPRTY_TO) throw new Exception("same priority change");
        //if (sCMD_STS != "0" && sCMD_STS != "X") throw new Exception("Executed CMD_STS=" + sCMD_STS + " can't change");
        //if (sCMD_MODE != "2") throw new Exception("Not store out CMD can't change");
        private HSSFCellStyle GetTitleStyle(IWorkbook wb)
        {
            HSSFCellStyle oStyle = (HSSFCellStyle)wb.CreateCellStyle();

            //設定背景顏色
            oStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Lime.Index;
            oStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;//灰色，顏色參考資料http://www.dotblogs.com.tw/lastsecret/archive/2010/12/20/20250.aspx
            oStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//粗
            oStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//細實線
            oStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//虛線
            oStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//...  
            return oStyle;
        }

        private HSSFCellStyle GetDetailContent(IWorkbook wb)
        {
            HSSFCellStyle oStyle = (HSSFCellStyle)wb.CreateCellStyle();

            //設定上下左右的框線
            oStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//粗
            oStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//細實線
            oStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//虛線
            oStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//...  

            return oStyle;
        }

        public void Save_Excel(DataTable dt, string ReportFile, string ReportName, string ReportDateFrom, string ReportDateTo)
        {
            #region COM组件将数据导Excel

            #endregion
            #region NIPO组件导出
            HSSFWorkbook workbook = new HSSFWorkbook();

            MemoryStream ms = new MemoryStream();

            //创建一个名称为exportSheet的工作表
            ISheet exportSheet = workbook.CreateSheet(ReportName);

            // Is it really necessary?
            //数据源
            //System.Data.DataTable dt = new System.Data.DataTable();
            //dt = dd.Copy();

            System.Data.DataTable tbReport = dt;

            //第一行:
            HSSFCellStyle cs0 = (HSSFCellStyle)workbook.CreateCellStyle();
            //文字置中左
            cs0.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cs0.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            HSSFFont font0 = (HSSFFont)workbook.CreateFont();
            //字體顏色4
            font0.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;
            
            //字體粗體
            //font0.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Normal;

            //字體尺寸
            font0.FontHeightInPoints = 12;
            cs0.SetFont(font0);
            //打印时间
            string sPrintTime = string.Format("Print Time: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")));
            exportSheet.CreateRow(0).CreateCell(0).SetCellValue(sPrintTime);
            exportSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
            exportSheet.GetRow(0).GetCell(0).CellStyle = cs0;

            //報表标题
            HSSFCellStyle cs1 = (HSSFCellStyle)workbook.CreateCellStyle();
            //文字置中左
            cs1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cs1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            HSSFFont font1 = (HSSFFont)workbook.CreateFont();
            //字體顏色
            font1.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
            //字體粗體
            //font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            font1.IsBold = true;

            //字體尺寸
            font1.FontHeightInPoints = 25;
            cs1.SetFont(font1);
            exportSheet.CreateRow(1).CreateCell(0).SetCellValue(ReportName);
            exportSheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, dt.Columns.Count - 1));
            exportSheet.GetRow(1).GetCell(0).CellStyle = cs1;

            //日期標題

            string strDF = ReportDateFrom.Trim();
            string strDT = ReportDateTo.Trim();
            int R = 0;  //新增行的位置
            int ColumnsC = dt.Columns.Count;//表格列数


            //string strFreeze = string.Empty;
            string strFreeze = "A4:F4"; // DEV BY MARK, 05/10


            if (strDF.Length > 0 && strDT.Trim().Length > 0)
            {
                R = 3; //有时间

                if (ColumnsC == 9)
                {
                    strFreeze = "A4:I4";
                }
                if (ColumnsC == 8)
                {
                    strFreeze = "A4:H4";
                }
                if (ColumnsC == 6)
                {
                    strFreeze = "A4:F4";
                }

            }
            else
            {
                R = 2;//没有时间
                if (ColumnsC == 10)
                {
                    strFreeze = "A3:J3";
                }
                if (ColumnsC == 12)
                {
                    strFreeze = "A3:L3";
                }
            }

            //hxy0916 Inquiry
            if (R == 3)
            {
                string sDate = string.Format("Date: {0} to {1}", ReportDateFrom, ReportDateTo);
                exportSheet.CreateRow(2).CreateCell(0).SetCellValue(sDate);
            }



            if (strDF.Length > 0 && strDT.Trim().Length > 0)
            {
                exportSheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, dt.Columns.Count - 1));
                HSSFCellStyle cs2 = (HSSFCellStyle)workbook.CreateCellStyle();
                cs2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                cs2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left; //靠左
                HSSFFont font2 = (HSSFFont)workbook.CreateFont();
                //字體顏色
                font2.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
                //字體粗體
                //font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                font2.IsBold = true;
                //字體尺寸
                font2.FontHeightInPoints = 14;
                cs2.SetFont(font2);
                exportSheet.GetRow(2).GetCell(0).CellStyle = cs2;
            }


            //头部标题
            if (R == 3)
            {
                IRow HeaderRow = exportSheet.CreateRow(3);

                //循环添加标题
                HSSFCellStyle oStyle = this.GetTitleStyle(workbook);

                foreach (DataColumn column in tbReport.Columns)
                {
                    HeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    HeaderRow.GetCell(column.Ordinal).CellStyle = oStyle;

                    //欄位寬度
                    //exportSheet.SetColumnWidth(column.Ordinal, 5000);
                }
            }
            else
            {
                IRow HeaderRow = exportSheet.CreateRow(R);

                //循环添加标题
                HSSFCellStyle oStyle = this.GetTitleStyle(workbook);
                foreach (DataColumn column in tbReport.Columns)
                {
                    HeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    HeaderRow.GetCell(column.Ordinal).CellStyle = oStyle;

                    //欄位寬度
                    //exportSheet.SetColumnWidth(column.Ordinal, 5000);
                }
            }




            // 内容
            int paymentRowIndex = 0;
            if (R == 3)
            {
                paymentRowIndex = 4;

            }
            else
            {
                paymentRowIndex = 3;
            }

            //progressBar1.Value = 0;//设置进度栏的当前位置为0
            //progressBar1.Minimum = 1;//设置进度栏的最小值为0
            //progressBar1.Maximum = dt.Rows.Count + 4;//设置进度栏的最大

            HSSFCellStyle contentStyle = this.GetDetailContent(workbook);
            foreach (DataRow row in tbReport.Rows)
            {
                IRow newRow = exportSheet.CreateRow(paymentRowIndex);

                //循环添加列的对应内容
                foreach (DataColumn column in tbReport.Columns)
                {
                    newRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    newRow.GetCell(column.Ordinal).CellStyle = contentStyle;
                }

                paymentRowIndex++;
                //   progressBar1.Value = paymentRowIndex;
            }

            //列宽自适应，只对英文和数字有效
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                exportSheet.AutoSizeColumn(i);
            }


            //凍結窗格
            if (R == 3)
            {
                exportSheet.CreateFreezePane(1, 4, 1, 4);
                CellRangeAddress cr = CellRangeAddress.ValueOf(strFreeze);
                exportSheet.SetAutoFilter(cr);
            }
            else
            {
                exportSheet.CreateFreezePane(1, 3, 1, 3);
                CellRangeAddress cr = CellRangeAddress.ValueOf(strFreeze);
                exportSheet.SetAutoFilter(cr);

            }


            exportSheet.PrintSetup.Landscape = true;
            exportSheet.PrintSetup.PaperSize = 9; //A4

            exportSheet.PrintSetup.UsePage = false; //自動從第一頁起始
            exportSheet.PrintSetup.NoColor = true; //單色

            exportSheet.PrintSetup.Copies = 1;

            exportSheet.PrintSetup.HeaderMargin = 30;
            exportSheet.PrintSetup.FooterMargin = 30;
            exportSheet.RepeatingRows = new CellRangeAddress(0, 3, 0, 8);

            string sFileName = null;
            //sFileName = System.Windows.Forms.Application.StartupPath;
            sFileName = "C:\\ASRS2";
            string wwwroot = env.WebRootPath;
            string ReportPath = wwwroot + "/Reports";
            //sFileName = sFileName + "\\" + ReportName + "";
            sFileName = ReportPath + "\\" + ReportName + "";

            if (System.IO.Directory.Exists(sFileName) == false)
            {
                System.IO.Directory.CreateDirectory(sFileName);
            }

            sFileName = sFileName + "\\" + ReportFile;

            // THIS STILL SAVE ONE COPY ON SERVER
            //workbook.WriteExcelToResponse(HttpContext, ReportFile); // NOT working!

            if (System.IO.File.Exists(sFileName) == false)
                using (FileStream fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            else
                using (FileStream fs = new FileStream(sFileName, FileMode.Open, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            workbook = null;
            ms.Close();
            ms.Dispose();
            #endregion
        }

        public async Task Save_ExcelXlsxAsync(DataTable dd, string ReportPath, string ReportFile, string ReportName, string ReportDateFrom, string ReportDateTo)
        {

            #region NIPO组件导出
            //https://dotblogs.com.tw/mis2000lab/2014/07/02/npoi-20-for-aspnet_20140703
            XSSFWorkbook workbook = new XSSFWorkbook();

            MemoryStream ms = new MemoryStream();

            //创建一个名称为exportSheet的工作表
            ISheet exportSheet = workbook.CreateSheet(ReportName);


            //数据源
            System.Data.DataTable dt = new System.Data.DataTable();

            // 列强制转换
            //for (int count = 0; count < dgvGrid.Columns.Count; count++)
            //{
            //    DataColumn dc = new DataColumn(dgvGrid.Columns[count].Name.ToString());
            //    dt.Columns.Add(dc);
            //}

            // //循环行
            //for (int count = 0; count < dgvGrid.Rows.Count; count++)
            //{
            //    DataRow dr = dt.NewRow();
            //    for (int countsub = 0; countsub < dgvGrid.Columns.Count; countsub++)
            //    {
            //        dr[countsub] = Convert.ToString(dgvGrid.Rows[count].Cells[countsub].Value);
            //    }
            //    dt.Rows.Add(dr);
            //}


            dt = dd.Copy();
            System.Data.DataTable tbReport = dt;

            //第一行:
            HSSFCellStyle cs0 = (HSSFCellStyle)workbook.CreateCellStyle();
            //文字置中左
            cs0.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cs0.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            HSSFFont font0 = (HSSFFont)workbook.CreateFont();
            //字體顏色4
            font0.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;
            
            //字體粗體
            //font0.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Normal;


            //字體尺寸
            font0.FontHeightInPoints = 12;
            cs0.SetFont(font0);
            //打印时间
            string sPrintTime = string.Format("Print Time: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")));
            exportSheet.CreateRow(0).CreateCell(0).SetCellValue(sPrintTime);
            exportSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
            exportSheet.GetRow(0).GetCell(0).CellStyle = cs0;

            //報表标题
            HSSFCellStyle cs1 = (HSSFCellStyle)workbook.CreateCellStyle();
            //文字置中左
            cs1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cs1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            HSSFFont font1 = (HSSFFont)workbook.CreateFont();
            //字體顏色
            font1.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
            
            //字體粗體
            //font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            //字體尺寸
            font1.FontHeightInPoints = 25;
            cs1.SetFont(font1);
            exportSheet.CreateRow(1).CreateCell(0).SetCellValue(ReportName);
            exportSheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, dt.Columns.Count - 1));
            exportSheet.GetRow(1).GetCell(0).CellStyle = cs1;

            //日期標題

            string strDF = ReportDateFrom.Trim();
            string strDT = ReportDateTo.Trim();
            int R = 0;  //新增行的位置
            int ColumnsC = dt.Columns.Count;//表格列数


            //string strFreeze = string.Empty;
            string strFreeze = "A4:F4"; // DEV BY MARK, 05/10


            if (strDF.Length > 0 && strDT.Trim().Length > 0)
            {
                R = 3; //有时间

                if (ColumnsC == 9)
                {
                    strFreeze = "A4:I4";
                }
                if (ColumnsC == 8)
                {
                    strFreeze = "A4:H4";
                }
                if (ColumnsC == 6)
                {
                    strFreeze = "A4:F4";
                }

            }
            else
            {
                R = 2;//没有时间
                if (ColumnsC == 10)
                {
                    strFreeze = "A3:J3";
                }
                if (ColumnsC == 12)
                {
                    strFreeze = "A3:L3";
                }
            }

            //hxy0916 Inquiry
            if (R == 3)
            {
                string sDate = string.Format("Date: {0} to {1}", ReportDateFrom, ReportDateTo);
                exportSheet.CreateRow(2).CreateCell(0).SetCellValue(sDate);
            }



            if (strDF.Length > 0 && strDT.Trim().Length > 0)
            {
                exportSheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, dt.Columns.Count - 1));
                HSSFCellStyle cs2 = (HSSFCellStyle)workbook.CreateCellStyle();
                cs2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                cs2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left; //靠左
                HSSFFont font2 = (HSSFFont)workbook.CreateFont();
                //字體顏色
                font2.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
                
                //字體粗體
                //font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                
                
                //字體尺寸
                font2.FontHeightInPoints = 14;
                cs2.SetFont(font2);
                exportSheet.GetRow(2).GetCell(0).CellStyle = cs2;
            }


            //头部标题
            if (R == 3)
            {
                IRow HeaderRow = exportSheet.CreateRow(3);

                //循环添加标题
                HSSFCellStyle oStyle = this.GetTitleStyle(workbook);

                var debug1 = tbReport.Columns.Count;
                foreach (DataColumn column in tbReport.Columns)
                {
                    HeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    HeaderRow.GetCell(column.Ordinal).CellStyle = oStyle;

                    //欄位寬度
                    //exportSheet.SetColumnWidth(column.Ordinal, 5000);
                }
            }
            else
            {
                IRow HeaderRow = exportSheet.CreateRow(R);

                //循环添加标题
                HSSFCellStyle oStyle = this.GetTitleStyle(workbook);
                foreach (DataColumn column in tbReport.Columns)
                {
                    HeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    HeaderRow.GetCell(column.Ordinal).CellStyle = oStyle;

                    //欄位寬度
                    //exportSheet.SetColumnWidth(column.Ordinal, 5000);
                }
            }




            // 内容
            int paymentRowIndex = 0;
            if (R == 3)
            {
                paymentRowIndex = 4;

            }
            else
            {
                paymentRowIndex = 3;
            }

            //progressBar1.Value = 0;//设置进度栏的当前位置为0
            //progressBar1.Minimum = 1;//设置进度栏的最小值为0
            //progressBar1.Maximum = dt.Rows.Count + 4;//设置进度栏的最大

            HSSFCellStyle contentStyle = this.GetDetailContent(workbook);

            foreach (DataRow row in tbReport.Rows)
            {

                // DEBUG Exception thrown: 'System.Threading.Tasks.TaskCanceledException' in System.Private.CoreLib.dll
                IRow newRow = exportSheet.CreateRow(paymentRowIndex);

                //循环添加列的对应内容
                foreach (DataColumn column in tbReport.Columns)
                {
                    newRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());


                    // 是否可以區塊處理?
                    // newRow.GetCell(column.Ordinal).CellStyle = contentStyle;
                }

                paymentRowIndex++;
                //   progressBar1.Value = paymentRowIndex;
            }

            //列宽自适应，只对英文和数字有效
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                exportSheet.AutoSizeColumn(i);
            }




            //凍結窗格
            if (R == 3)
            {
                exportSheet.CreateFreezePane(1, 4, 1, 4);
                CellRangeAddress cr = CellRangeAddress.ValueOf(strFreeze);
                exportSheet.SetAutoFilter(cr);
            }
            else
            {
                exportSheet.CreateFreezePane(1, 3, 1, 3);
                CellRangeAddress cr = CellRangeAddress.ValueOf(strFreeze);
                exportSheet.SetAutoFilter(cr);

            }



            exportSheet.PrintSetup.Landscape = true;
            exportSheet.PrintSetup.PaperSize = 9; //A4

            exportSheet.PrintSetup.UsePage = false; //自動從第一頁起始
            exportSheet.PrintSetup.NoColor = true; //單色

            exportSheet.PrintSetup.Copies = 1;

            exportSheet.PrintSetup.HeaderMargin = 30;
            exportSheet.PrintSetup.FooterMargin = 30;
            exportSheet.RepeatingRows = new CellRangeAddress(0, 3, 0, 8);

            var sPath = $@"{ env.WebRootPath}/{ReportPath}";

            if (System.IO.Directory.Exists(sPath) == false)
            {
                System.IO.Directory.CreateDirectory(sPath);
            }

            var sFile = $@"{sPath}/{ReportFile}";

            if (System.IO.File.Exists(sFile) == false)
            {
                using (FileStream fs = new FileStream(sFile, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

            }

            workbook = null;
            ms.Close();
            ms.Dispose();
            #endregion
        }

        public string GetReportPath()
        {
            return "ReportR000";
        }
        public string GetReportName(string PROG_ID)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            openWith.Add("R030", "Daily Inbound Summary Report");
            openWith.Add("R040", "Daily Outbound Summary Report");
            openWith.Add("R050", "Stock Inquiry Report"); //winform中為"StockInquiryreport"
            openWith.Add("R060", "Stock Movement Pallet Report");

            // 
            // openWith.Add("R070", "Stock Movement Transcation Report");
            // Stock Movement Transcation Report
            // 1234567890123456789012345678901
            openWith.Add("R070", "Stock Movement Transcation");

            openWith.Add("R080", "Stock Counting Difference");
            return openWith[PROG_ID];
        }
        public string GetReportFile(string PROD_ID)
        {
            string str = $@"{GetCompactReportName(PROD_ID)}_{DateTime.Now.ToString("yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-US"))}.xls";
            return str;
        }

        public string GetCompactReportName(string PROG_ID)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            openWith.Add("R030", "DailyInboundSummaryReport");
            openWith.Add("R040", "DailyOutboundSummaryReport");
            openWith.Add("R050", "StockInquiryReport"); //winform中為"StockInquiryreport"
            openWith.Add("R060", "StockMovementPalletReport");
            openWith.Add("R070", "StockMovementTranscationReport");
            openWith.Add("R080", "StockCountingDifference");
            return openWith[PROG_ID];
        }

        public async Task ExportExcelAsync(DataTable dd, string ReportPath, string ReportFile, string ReportName, string ReportDateFrom, string ReportDateTo)
        {

            // READABLE , Note by Mark, 05/10, 大量使用原 WES 的代碼
            HSSFWorkbook workbook = new HSSFWorkbook();

            MemoryStream ms = new MemoryStream();

            //创建一个名称为exportSheet的工作表
            ISheet exportSheet = workbook.CreateSheet(ReportName);


            //数据源
            System.Data.DataTable dt = new System.Data.DataTable();



            dt = dd.Copy();
            System.Data.DataTable tbReport = dt;

            //第一行:
            HSSFCellStyle cs0 = (HSSFCellStyle)workbook.CreateCellStyle();
            //文字置中左
            cs0.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cs0.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            HSSFFont font0 = (HSSFFont)workbook.CreateFont();
            //字體顏色4
            font0.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;
            //字體粗體
            font0.IsBold = true;
            //字體尺寸
            font0.FontHeightInPoints = 12;
            cs0.SetFont(font0);
            //打印时间
            string sPrintTime = string.Format("Print Time: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")));
            exportSheet.CreateRow(0).CreateCell(0).SetCellValue(sPrintTime);
            exportSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
            exportSheet.GetRow(0).GetCell(0).CellStyle = cs0;

            //報表标题
            HSSFCellStyle cs1 = (HSSFCellStyle)workbook.CreateCellStyle();
            //文字置中左
            cs1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cs1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            HSSFFont font1 = (HSSFFont)workbook.CreateFont();
            //字體顏色
            font1.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
            //字體粗體
            font1.IsBold = true;
            //字體尺寸
            font1.FontHeightInPoints = 25;
            cs1.SetFont(font1);
            exportSheet.CreateRow(1).CreateCell(0).SetCellValue(ReportName);
            exportSheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, dt.Columns.Count - 1));
            exportSheet.GetRow(1).GetCell(0).CellStyle = cs1;

            //日期標題

            string strDF = ReportDateFrom.Trim();
            string strDT = ReportDateTo.Trim();
            int R = 0;  //新增行的位置
            int ColumnsC = dt.Columns.Count;//表格列数


            //string strFreeze = string.Empty;
            string strFreeze = "A4:F4"; // DEV BY MARK, 05/10


            if (strDF.Length > 0 && strDT.Trim().Length > 0)
            {
                R = 3; //有时间

                if (ColumnsC == 9)
                {
                    strFreeze = "A4:I4";
                }
                if (ColumnsC == 8)
                {
                    strFreeze = "A4:H4";
                }
                if (ColumnsC == 6)
                {
                    strFreeze = "A4:F4";
                }

            }
            else
            {
                R = 2;//没有时间
                if (ColumnsC == 10)
                {
                    strFreeze = "A3:J3";
                }
                if (ColumnsC == 12)
                {
                    strFreeze = "A3:L3";
                }
            }

            //hxy0916 Inquiry
            if (R == 3)
            {
                string sDate = string.Format("Date: {0} to {1}", ReportDateFrom, ReportDateTo);
                exportSheet.CreateRow(2).CreateCell(0).SetCellValue(sDate);
            }



            if (strDF.Length > 0 && strDT.Trim().Length > 0)
            {
                exportSheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, dt.Columns.Count - 1));
                HSSFCellStyle cs2 = (HSSFCellStyle)workbook.CreateCellStyle();
                cs2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                cs2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left; //靠左
                HSSFFont font2 = (HSSFFont)workbook.CreateFont();
                //字體顏色
                font2.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
                //字體粗體
                font2.IsBold = true;
                //字體尺寸
                font2.FontHeightInPoints = 14;
                cs2.SetFont(font2);
                exportSheet.GetRow(2).GetCell(0).CellStyle = cs2;
            }


            //头部标题
            if (R == 3)
            {
                IRow HeaderRow = exportSheet.CreateRow(3);

                //循环添加标题
                HSSFCellStyle oStyle = this.GetTitleStyle(workbook);

                var debug1 = tbReport.Columns.Count;
                foreach (DataColumn column in tbReport.Columns)
                {
                    HeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    HeaderRow.GetCell(column.Ordinal).CellStyle = oStyle;

                    //欄位寬度
                    //exportSheet.SetColumnWidth(column.Ordinal, 5000);
                }
            }
            else
            {
                IRow HeaderRow = exportSheet.CreateRow(R);

                //循环添加标题
                HSSFCellStyle oStyle = this.GetTitleStyle(workbook);
                foreach (DataColumn column in tbReport.Columns)
                {
                    HeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    HeaderRow.GetCell(column.Ordinal).CellStyle = oStyle;

                    //欄位寬度
                    //exportSheet.SetColumnWidth(column.Ordinal, 5000);
                }
            }




            // 内容
            int paymentRowIndex = 0;
            if (R == 3)
            {
                paymentRowIndex = 4;

            }
            else
            {
                paymentRowIndex = 3;
            }

            //progressBar1.Value = 0;//设置进度栏的当前位置为0
            //progressBar1.Minimum = 1;//设置进度栏的最小值为0
            //progressBar1.Maximum = dt.Rows.Count + 4;//设置进度栏的最大

            HSSFCellStyle contentStyle = this.GetDetailContent(workbook);

            var debug2 = tbReport.Rows.Count;
            var debug3 = tbReport.Columns.Count;
            foreach (DataRow row in tbReport.Rows)
            {

                // DEBUG Exception thrown: 'System.Threading.Tasks.TaskCanceledException' in System.Private.CoreLib.dll
                IRow newRow = exportSheet.CreateRow(paymentRowIndex);

                //循环添加列的对应内容
                foreach (DataColumn column in tbReport.Columns)
                {
                    newRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());


                    // 是否可以區塊處理?
                    newRow.GetCell(column.Ordinal).CellStyle = contentStyle;
                }

                paymentRowIndex++;
                //   progressBar1.Value = paymentRowIndex;
            }

            //列宽自适应，只对英文和数字有效
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                exportSheet.AutoSizeColumn(i);
            }




            //凍結窗格
            if (R == 3)
            {
                exportSheet.CreateFreezePane(1, 4, 1, 4);
                CellRangeAddress cr = CellRangeAddress.ValueOf(strFreeze);
                exportSheet.SetAutoFilter(cr);
            }
            else
            {
                exportSheet.CreateFreezePane(1, 3, 1, 3);
                CellRangeAddress cr = CellRangeAddress.ValueOf(strFreeze);
                exportSheet.SetAutoFilter(cr);

            }



            exportSheet.PrintSetup.Landscape = true;
            exportSheet.PrintSetup.PaperSize = 9; //A4

            exportSheet.PrintSetup.UsePage = false; //自動從第一頁起始
            exportSheet.PrintSetup.NoColor = true; //單色

            exportSheet.PrintSetup.Copies = 1;

            exportSheet.PrintSetup.HeaderMargin = 30;
            exportSheet.PrintSetup.FooterMargin = 30;
            exportSheet.RepeatingRows = new CellRangeAddress(0, 3, 0, 8);

            var sPath = $@"{ env.WebRootPath}/{ReportPath}";

            if (System.IO.Directory.Exists(sPath) == false)
            {
                System.IO.Directory.CreateDirectory(sPath);
            }

            var sFile = $@"{sPath}/{ReportFile}";

            if (System.IO.File.Exists(sFile) == false)
            {
                using (FileStream fs = new FileStream(sFile, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

            }
            workbook = null;

            ms.Close();
            ms.Dispose();

        }


        public string GetM070ThrowMsg_same_priority_change()
        {
            return "same priority change";
        }
        public string GetM070ThrowMsg_Executed_CMD_STS(string CMD_STS)
        {
            return $@"Executed CMD_STS={CMD_STS} can't change";
        }
        public string GetM070ThrowMsg_Executed_CMD_cant_change()
        {
            return $@"Executed CMD can't change";
        }
        public string GetM070ThrowMsg_Not_store_out()
        {
            return "Not store out CMD can't change";
        }
        public string GetM070ThrowMsg_Incorrect_Out_Port(string sSTN_NO)
        {
            return $@"Incorrect Out Port:{ sSTN_NO}";
        }



        public string GetM070BtnText(int index)
        {
            if (index == 1)
            {
                return "Query";
            }
            if (index == 2)
            {
                return "Change Priority";
            }
            if (index == 3)
            {
                return "Change Out Port";
            }
            if (index == 4)
            {
                return "Force Cancel";
            }
            if (index == 5)
            {
                return "Force End";
            }

            return "(Unknown)";
        }
    }

}