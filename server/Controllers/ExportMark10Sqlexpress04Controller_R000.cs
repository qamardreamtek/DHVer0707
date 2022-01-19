using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RadzenDh5.Data;

namespace RadzenDh5
{
    public partial class ExportMark10Sqlexpress04Controller
    {
     

        // P060
        [HttpGet("/export/Mark10Sqlexpress04/vlocdtlmstpltdtlindtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vlocdtlmstpltdtlindtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVLocDtlMstPltDtlInDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VLocDtlMstPltDtlInDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vlocdtlmstpltdtlindtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vlocdtlmstpltdtlindtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVLocDtlMstPltDtlInDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VLocDtlMstPltDtlInDtls, Request.Query), fileName);
        }



        [HttpGet("/export/Mark10Sqlexpress04/vp060s/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vp060s/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVp060sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Vp060s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vp060s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vp060s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVp060sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vp060s, Request.Query), fileName);
        }
        //[HttpGet("/export/Mark10Sqlexpress04/vr030s/csv")]
        //[HttpGet("/export/Mark10Sqlexpress04/vr030s/csv(fileName='{fileName}')")]
        //public FileStreamResult ExportVr030sToCSV(string fileName = null)
        //{
        //    return ToCSV(ApplyQuery(context.Vr030s, Request.Query), fileName);
        //}

        //[HttpGet("/export/Mark10Sqlexpress04/vr030s/excel")]
        //[HttpGet("/export/Mark10Sqlexpress04/vr030s/excel(fileName='{fileName}')")]
        //public FileStreamResult ExportVr030sToExcel(string fileName = null)
        //{
        //    return ToExcel(ApplyQuery(context.Vr030s, Request.Query), fileName);
        //}
        [HttpGet("/export/Mark10Sqlexpress04/vr050s/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vr050s/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVr050sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Vr050s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vr050s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vr050s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVr050sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vr050s, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/vr080s/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vr080s/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVr080sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Vr080s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vr080s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vr080s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVr080sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vr080s, Request.Query), fileName);
        }


        //[HttpGet("/export/Mark10Sqlexpress04/vr060s/csv")]
        //[HttpGet("/export/Mark10Sqlexpress04/vr060s/csv(fileName='{fileName}')")]
        //public FileStreamResult ExportVr060sToCSV(string fileName = null)
        //{
        //    return ToCSV(ApplyQuery(context.Vr060s, Request.Query), fileName);
        //}


        [HttpGet("/export/r080")]
        public FileStreamResult ExporrR080ToExcel(string fileName = null)
        {
            return ToExcelRadzen(ApplyQuery(context.Vr080s, Request.Query), fileName);
        }
        public async Task<IActionResult> OnExportR080()
        {
            // DEV DEBUG ONLY
            string sWebRootFolder = @$"D:\0000A\0503\DH5Ver0428\RadzenDH6\server\wwwroot\";
           
                string sFileName = @"demo.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Demo");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("ID");
                row.CreateCell(1).SetCellValue("Name");
                row.CreateCell(2).SetCellValue("Age");

                row = excelSheet.CreateRow(1);
                row.CreateCell(0).SetCellValue(1);
                row.CreateCell(1).SetCellValue("Kane Williamson");
                row.CreateCell(2).SetCellValue(29);

                row = excelSheet.CreateRow(2);
                row.CreateCell(0).SetCellValue(2);
                row.CreateCell(1).SetCellValue("Martin Guptil");
                row.CreateCell(2).SetCellValue(33);

                row = excelSheet.CreateRow(3);
                row.CreateCell(0).SetCellValue(3);
                row.CreateCell(1).SetCellValue("Colin Munro");
                row.CreateCell(2).SetCellValue(23);

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }


        [HttpGet("/export/Mark10Sqlexpress04/vr060s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vr060s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVr060sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vr060s, Request.Query), fileName);
        }
        //[HttpGet("/export/Mark10Sqlexpress04/vr070s/csv")]
        //[HttpGet("/export/Mark10Sqlexpress04/vr070s/csv(fileName='{fileName}')")]
        //public FileStreamResult ExportVr070sToCSV(string fileName = null)
        //{
        //    return ToCSV(ApplyQuery(context.Vr070s, Request.Query), fileName);
        //}

        [HttpGet("/export/Mark10Sqlexpress04/vr070s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vr070s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVr070sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vr070s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vr040s/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vr040s/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVr040sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Vr040s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vr040s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vr040s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVr040sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vr040s, Request.Query), fileName);
        }
    }
}
