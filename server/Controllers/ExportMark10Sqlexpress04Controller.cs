using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;

namespace RadzenDh5
{
    public partial class ExportMark10Sqlexpress04Controller : ExportController
    {
        private readonly Mark10Sqlexpress04Context context;


        private static void GenerateWorkbookStylesPartContentRadzen(WorkbookStylesPart workbookStylesPart1)
        {
            Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac x16r2 xr" } };
            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            stylesheet1.AddNamespaceDeclaration("x16r2", "http://schemas.microsoft.com/office/spreadsheetml/2015/02/main");
            stylesheet1.AddNamespaceDeclaration("xr", "http://schemas.microsoft.com/office/spreadsheetml/2014/revision");

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)1U, KnownFonts = true };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 11D };
            Color color1 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);

            fonts1.Append(font1);

            Fills fills1 = new Fills() { Count = (UInt32Value)2U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            fills1.Append(fill1);
            fills1.Append(fill2);

            Borders borders1 = new Borders() { Count = (UInt32Value)1U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            borders1.Append(border1);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)2U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)14U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true };

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };

            StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();

            StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");

            StylesheetExtension stylesheetExtension2 = new StylesheetExtension() { Uri = "{9260A510-F301-46a8-8635-F512D64BE5F5}" };
            stylesheetExtension2.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");

            OpenXmlUnknownElement openXmlUnknownElement4 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<x15:timelineStyles defaultTimelineStyle=\"TimeSlicerStyleLight1\" xmlns:x15=\"http://schemas.microsoft.com/office/spreadsheetml/2010/11/main\" />");

            stylesheetExtension2.Append(openXmlUnknownElement4);

            stylesheetExtensionList1.Append(stylesheetExtension1);
            stylesheetExtensionList1.Append(stylesheetExtension2);

            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            stylesheet1.Append(stylesheetExtensionList1);

            workbookStylesPart1.Stylesheet = stylesheet1;
        }
        private static bool IsNumeric(TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }
        public FileStreamResult ToExcelRadzen(IQueryable query, string fileName = null)
        {
            var columns = GetProperties(query.ElementType);
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                GenerateWorkbookStylesPartContentRadzen(workbookStylesPart);

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                var headerRow = new Row();

                foreach (var column in columns)
                {
                    headerRow.Append(new Cell()
                    {
                        CellValue = new CellValue(column.Key),
                        DataType = new EnumValue<CellValues>(CellValues.String)
                    });
                }

                sheetData.AppendChild(headerRow);

                foreach (var item in query)
                {
                    var row = new Row();

                    foreach (var column in columns)
                    {
                        var value = GetValue(item, column.Key);
                        var stringValue = $"{value}".Trim();

                        var cell = new Cell();

                        var underlyingType = column.Value.IsGenericType &&
                            column.Value.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                            Nullable.GetUnderlyingType(column.Value) : column.Value;

                        var typeCode = Type.GetTypeCode(underlyingType);

                        if (typeCode == TypeCode.DateTime)
                        {
                            if (!string.IsNullOrWhiteSpace(stringValue))
                            {
                                cell.CellValue = new CellValue() { Text = ((DateTime)value).ToOADate().ToString(System.Globalization.CultureInfo.InvariantCulture) };
                                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                cell.StyleIndex = (UInt32Value)1U;
                            }
                        }
                        else if (typeCode == TypeCode.Boolean)
                        {
                            cell.CellValue = new CellValue(stringValue.ToLower());
                            cell.DataType = new EnumValue<CellValues>(CellValues.Boolean);
                        }
                        else if (IsNumeric(typeCode))
                        {
                            cell.CellValue = new CellValue(stringValue);
                            cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(stringValue);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }

                        row.Append(cell);
                    }

                    sheetData.AppendChild(row);
                }


                workbookPart.Workbook.Save();
            }

            if (stream?.Length > 0)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = (!string.IsNullOrEmpty(fileName) ? fileName : "Export") + ".xlsx";

            return result;
        }




        public ExportMark10Sqlexpress04Controller(Mark10Sqlexpress04Context context)
        {
            this.context = context;
        }

        [HttpGet("/export/Mark10Sqlexpress04/alarmdefs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/alarmdefs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAlarmDefsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AlarmDefs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/alarmdefs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/alarmdefs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAlarmDefsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AlarmDefs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/alarmlogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/alarmlogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAlarmLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AlarmLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/alarmlogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/alarmlogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAlarmLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AlarmLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/cmdmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/cmdmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCmdMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.CmdMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/cmdmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/cmdmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCmdMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.CmdMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/cmdmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/cmdmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCmdMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.CmdMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/cmdmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/cmdmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCmdMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.CmdMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/ctrlhs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/ctrlhs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCtrlHsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.CtrlHs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/ctrlhs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/ctrlhs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCtrlHsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.CtrlHs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equcmds/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equcmds/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquCmdsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquCmds, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equcmds/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equcmds/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquCmdsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquCmds, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equcmddetaillogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equcmddetaillogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquCmdDetailLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquCmdDetailLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equcmddetaillogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equcmddetaillogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquCmdDetailLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquCmdDetailLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equcmdhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equcmdhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquCmdHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquCmdHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equcmdhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equcmdhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquCmdHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquCmdHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equcodedefs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equcodedefs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquCodeDefsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquCodeDefs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equcodedefs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equcodedefs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquCodeDefsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquCodeDefs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equmodelogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equmodelogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquModeLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquModeLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equmodelogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equmodelogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquModeLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquModeLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equmplccmdhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equmplccmdhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquMplcCmdHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquMplcCmdHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equmplccmdhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equmplccmdhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquMplcCmdHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquMplcCmdHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equplcdata/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equplcdata/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquPlcDataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquPlcData, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equplcdata/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equplcdata/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquPlcDataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquPlcData, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equstslogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equstslogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquStsLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquStsLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equstslogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equstslogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquStsLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquStsLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/equtrnlogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/equtrnlogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEquTrnLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EquTrnLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/equtrnlogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/equtrnlogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEquTrnLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EquTrnLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/groupdtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/groupdtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGroupDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GroupDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/groupdtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/groupdtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGroupDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GroupDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/groupdtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/groupdtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGroupDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GroupDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/groupdtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/groupdtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGroupDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GroupDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/groupmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/groupmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGroupMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GroupMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/groupmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/groupmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGroupMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GroupMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/groupmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/groupmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGroupMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GroupMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/groupmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/groupmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGroupMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GroupMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/groupwrts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/groupwrts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGroupWrtsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GroupWrts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/groupwrts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/groupwrts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGroupWrtsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GroupWrts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/groupwrthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/groupwrthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGroupWrtHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GroupWrtHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/groupwrthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/groupwrthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGroupWrtHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GroupWrtHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/gtinmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/gtinmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGtinMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GtinMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/gtinmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/gtinmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGtinMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GtinMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/gtinmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/gtinmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGtinMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.GtinMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/gtinmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/gtinmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGtinMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.GtinMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/indtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/indtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/indtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/indtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/indtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/indtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/indtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/indtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/inmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/inmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/inmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/inmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/inmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/inmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/inmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/inmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/insnos/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/insnos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInSnosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InSnos, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/insnos/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/insnos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInSnosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InSnos, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/insnohis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/insnohis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInSnoHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InSnoHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/insnohis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/insnohis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInSnoHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InSnoHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/locdtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/locdtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/locdtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/locdtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/locdtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/locdtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/locdtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/locdtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/locmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/locmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/locmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/locmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/locmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/locmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/locmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/locmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/msglangs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/msglangs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMsgLangsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MsgLangs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/msglangs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/msglangs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMsgLangsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MsgLangs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/outdtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/outdtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOutDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.OutDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/outdtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/outdtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOutDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.OutDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/outdtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/outdtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOutDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.OutDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/outdtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/outdtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOutDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.OutDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/outmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/outmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOutMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.OutMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/outmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/outmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOutMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.OutMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/outmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/outmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOutMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.OutMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/outmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/outmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOutMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.OutMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/outsnos/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/outsnos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOutSnosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.OutSnos, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/outsnos/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/outsnos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOutSnosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.OutSnos, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/outsnohis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/outsnohis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOutSnoHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.OutSnoHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/outsnohis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/outsnohis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOutSnoHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.OutSnoHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pclogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pclogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPcLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PcLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pclogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pclogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPcLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PcLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pcsnos/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pcsnos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPcSnosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PcSnos, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pcsnos/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pcsnos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPcSnosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PcSnos, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pckdtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pckdtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPckDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PckDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pckdtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pckdtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPckDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PckDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pckdtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pckdtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPckDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PckDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pckdtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pckdtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPckDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PckDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pckmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pckmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPckMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PckMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pckmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pckmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPckMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PckMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pckmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pckmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPckMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PckMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pckmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pckmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPckMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PckMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pcksnos/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pcksnos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPckSnosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PckSnos, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pcksnos/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pcksnos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPckSnosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PckSnos, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pcksnohis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pcksnohis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPckSnoHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PckSnoHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pcksnohis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pcksnohis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPckSnoHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PckSnoHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/picdtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/picdtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPicDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PicDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/picdtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/picdtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPicDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PicDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/picdtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/picdtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPicDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PicDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/picdtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/picdtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPicDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PicDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/picmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/picmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPicMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PicMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/picmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/picmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPicMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PicMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/picmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/picmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPicMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PicMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/picmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/picmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPicMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PicMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/picsnos/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/picsnos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPicSnosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PicSnos, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/picsnos/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/picsnos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPicSnosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PicSnos, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/picsnohis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/picsnohis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPicSnoHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PicSnoHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/picsnohis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/picsnohis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPicSnoHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PicSnoHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pltdtls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pltdtls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPltDtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PltDtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pltdtls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pltdtls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPltDtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PltDtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/pltdtlhis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/pltdtlhis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPltDtlHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PltDtlHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/pltdtlhis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/pltdtlhis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPltDtlHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PltDtlHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/progmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/progmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProgMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProgMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/progmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/progmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProgMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProgMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/progmsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/progmsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProgMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProgMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/progmsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/progmsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProgMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProgMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/progwrts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/progwrts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProgWrtsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProgWrts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/progwrts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/progwrts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProgWrtsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProgWrts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/progwrthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/progwrthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProgWrtHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProgWrtHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/progwrthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/progwrthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProgWrtHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProgWrtHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/rptr030s/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/rptr030s/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRptR030sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.RptR030s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/rptr030s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/rptr030s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRptR030sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.RptR030s, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/skumsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/skumsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSkuMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SkuMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/skumsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/skumsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSkuMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SkuMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/skumsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/skumsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSkuMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SkuMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/skumsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/skumsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSkuMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SkuMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/skusuts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/skusuts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSkuSutsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SkuSuts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/skusuts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/skusuts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSkuSutsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SkuSuts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/skusuthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/skusuthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSkuSutHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SkuSutHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/skusuthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/skusuthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSkuSutHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SkuSutHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/snoctls/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/snoctls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSnoCtlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SnoCtls, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/snoctls/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/snoctls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSnoCtlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SnoCtls, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/stnmsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/stnmsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStnMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.StnMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/stnmsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/stnmsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStnMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.StnMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/translates/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/translates/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTranslatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Translates, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/translates/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/translates/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTranslatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Translates, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/txlogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/txlogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTxLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.TxLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/txlogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/txlogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTxLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.TxLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/txsnos/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/txsnos/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTxSnosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.TxSnos, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/txsnos/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/txsnos/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTxSnosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.TxSnos, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/userlogs/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/userlogs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportUserLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.UserLogs, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/userlogs/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/userlogs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportUserLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.UserLogs, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/usermsts/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/usermsts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportUserMstsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.UserMsts, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/usermsts/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/usermsts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportUserMstsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.UserMsts, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/usermsthis/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/usermsthis/csv(fileName='{fileName}')")]
        public FileStreamResult ExportUserMstHisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.UserMstHis, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/usermsthis/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/usermsthis/excel(fileName='{fileName}')")]
        public FileStreamResult ExportUserMstHisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.UserMstHis, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/vtablelists/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vtablelists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVTableListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VTableLists, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vtablelists/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vtablelists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVTableListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VTableLists, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/vuserprogbygroups/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vuserprogbygroups/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVUserProgByGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VUserProgByGroups, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vuserprogbygroups/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vuserprogbygroups/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVUserProgByGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VUserProgByGroups, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/vuserroles/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vuserroles/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVUserRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VUserRoles, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vuserroles/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vuserroles/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVUserRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VUserRoles, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/vr030s/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/vr030s/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVr030sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Vr030s, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/vr030s/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/vr030s/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVr030sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Vr030s, Request.Query), fileName);
        }
        [HttpGet("/export/Mark10Sqlexpress04/xxxes/csv")]
        [HttpGet("/export/Mark10Sqlexpress04/xxxes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportXxxesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Xxxes, Request.Query), fileName);
        }

        [HttpGet("/export/Mark10Sqlexpress04/xxxes/excel")]
        [HttpGet("/export/Mark10Sqlexpress04/xxxes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportXxxesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Xxxes, Request.Query), fileName);
        }
    }
}
