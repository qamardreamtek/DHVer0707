using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using RadzenDh5.Data;
using CaotunSpring.DH.Tools;

namespace RadzenDh5
{
    public partial class ExportV2Controller : Controller
    {
        private readonly Mark10Sqlexpress04Context context;

        protected readonly DhGlobalsService DhGlobals;
        public ExportV2Controller(Mark10Sqlexpress04Context context, DhGlobalsService DhGlobals)
        {
            this.context = context;
            this.DhGlobals = DhGlobals;
        }





        [HttpGet("/exportV2/Mark10Sqlexpress04/vr070s/excel")]
        public FileStreamResult ExportVr070sToExcel(string dt1, string dt2)
        {
            var f1 = DhGlobals.GetReportFile("R070");
            return ToExcel(ApplyQueryR070(dt1, dt2), f1);
        }
        public IQueryable ApplyQueryR070(string dt1, string dt2)
        {
            string strSQL = DhGlobals.GetR070StrSQL(dt1, dt2);
            var items = context.Vr070s.FromSqlRaw(strSQL);
            return items;
        }





        public FileStreamResult ToCSV(IQueryable query, string fileName = null)
        {
            var columns = GetProperties(query.ElementType);

            var sb = new StringBuilder();

            foreach (var item in query)
            {
                var row = new List<string>();

                foreach (var column in columns)
                {
                    row.Add($"{GetValue(item, column.Key)}".Trim());
                }

                sb.AppendLine(string.Join(",", row.ToArray()));
            }


            var result = new FileStreamResult(new MemoryStream(UTF8Encoding.Default.GetBytes($"{string.Join(",", columns.Select(c => c.Key))}{System.Environment.NewLine}{sb.ToString()}")), "text/csv");
            result.FileDownloadName = (!string.IsNullOrEmpty(fileName) ? fileName : "Export") + ".csv";

            return result;
        }

        public static void ApplyAutofilter(string fileName, string sheetName, string reference)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, true))
            {
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);
                var arrSheets = sheets as Sheet[] ?? sheets.ToArray();

                string relationshipId = arrSheets.First().Id.Value;
                var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);

                var autoFilter = new AutoFilter() { Reference = reference };
                OpenXmlElement preceedingElement = GetPreceedingElement(worksheetPart);
                worksheetPart.Worksheet.InsertAfter(autoFilter, preceedingElement);

                worksheetPart.Worksheet.Save();
            }
        }

        public static OpenXmlElement GetPreceedingElement(WorksheetPart worksheetPart)
        {
            List<Type> elements = new List<Type>()
    {
        typeof(Scenarios),
        typeof(ProtectedRanges),
        typeof(SheetProtection),
        typeof(SheetCalculationProperties),
        typeof(SheetData)
    };

            OpenXmlElement preceedingElement = null;
            foreach (var item in worksheetPart.Worksheet.ChildElements.Reverse())
            {
                if (elements.Contains(item.GetType()))
                {
                    preceedingElement = item;
                    break;
                }
            }

            return preceedingElement;
        }
        public FileStreamResult ToExcel(IQueryable query, string fileName = null)
        {
            var columns = GetProperties(query.ElementType);
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {



                // --------------------------



                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                GenerateWorkbookStylesPartContent(workbookStylesPart);


                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheetname = "";

                try
                {
                    var chars = fileName.Substring(1, fileName.IndexOf('_') - 1).ToCharArray();
                    foreach (char c in chars)
                    {
                        if (Char.IsUpper(c))
                            sheetname += " " + c;
                        else
                            sheetname += c;
                    }
                    sheetname = fileName.Substring(0, 1) + sheetname;
                }
                catch { sheetname = "sheet1"; }
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "fixed sheetname 12345" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());


                // NOTE by Mark,  04/28
                // 1. 做樣式
                // 2. 新加 row, 有一個 A1 cell, 給值設樣式
                // 3. Merge A1: K1

                // 是不是加了空白 row? Y
                // EXPORT EXCEL
                //
                // 為了文字置右, 結合了這兩個 技術帖 實現了
                //https://stackoverflow.com/questions/11116176/cell-styles-in-openxml-spreadsheet-spreadsheetml
                //https://gist.github.com/zhangw/4601021
                //       var stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                //   var stylesPart = workbookPart.AddNewPart<sheetData>();

                //   var s1 = new Stylesheet();
                var s1 = document.WorkbookPart.WorkbookStylesPart.Stylesheet;


                // blank font list
                s1.Fonts = new Fonts();
                s1.Fonts.Count = 1;
                s1.Fonts.AppendChild(new Font());

                // create fills
                s1.Fills = new Fills();

                // create a solid red fill
                var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                //      solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") }; // red fill
                //https://stackoverflow.com/questions/23201134/transparent-argb-hex-value
                solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFFFFFF") }; // white fill
                solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };


                s1.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
                s1.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
                                                                                                                          //s1.Fills.AppendChild(new Fill { PatternFill = solidRed });

                s1.Fills.AppendChild(new Fill { PatternFill = solidRed });
                s1.Fills.Count = 3;

                // blank border list
                s1.Borders = new Borders();
                s1.Borders.Count = 1;
                s1.Borders.AppendChild(new Border());

                // blank cell format list
                s1.CellStyleFormats = new CellStyleFormats();
                s1.CellStyleFormats.Count = 1;
                s1.CellStyleFormats.AppendChild(new CellFormat());

                // cell format list
                s1.CellFormats = new CellFormats();
                // empty one for index 0, seems to be required
                s1.CellFormats.AppendChild(new CellFormat());
                // cell format references style format 0, font 0, border 0, fill 2 and applies the fill
                s1.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Right });
                s1.CellFormats.Count = 2;

                s1.Save();
                //                document.WorkbookPart.WorkbookStylesPart.Stylesheet.Save();


                // NOTE by Mark, 新建row 1,2,3

                sheetData.AppendChild(new Row(new Cell { CellValue = new CellValue("AAA Print Time: 2021-04-18 20:20:27"), DataType = new EnumValue<CellValues>(CellValues.String), StyleIndex = 1 }));
                sheetData.AppendChild(new Row(new Cell { CellValue = new CellValue("BBB Daily Inbound Summary Report"), DataType = new EnumValue<CellValues>(CellValues.String), StyleIndex = 1 }));
                sheetData.AppendChild(new Row(new Cell { CellValue = new CellValue("CCC Date: 2020-04-18 to 2021-04-18"), DataType = new EnumValue<CellValues>(CellValues.String), StyleIndex = 1 }));

                // 再來 overwrite

                //    var obj = worksheetPart.Worksheet.Elements<SheetData>().First();
                MergeCells mergeCells1 = new MergeCells();
                mergeCells1.Append(new MergeCell() { Reference = new StringValue("A1:K1") });
                worksheetPart.Worksheet.InsertAfter(mergeCells1, worksheetPart.Worksheet.Elements<SheetData>().First());

                //MergeCells mergeCells2 = new MergeCells();
                //mergeCells2.Append(new MergeCell() { Reference = new StringValue("A2:K2") });
                //worksheetPart.Worksheet.InsertAfter(mergeCells2, worksheetPart.Worksheet.Elements<SheetData>().First());


                //MergeCells mergeCells3 = new MergeCells();
                //mergeCells3.Append(new MergeCell() { Reference = new StringValue("A3:K3") });
                //worksheetPart.Worksheet.InsertAfter(mergeCells3, worksheetPart.Worksheet.Elements<SheetData>().First());










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


        public FileStreamResult ToExcelR060(IQueryable query)
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
                GenerateWorkbookStylesPartContent(workbookStylesPart);

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet111" };
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
            result.FileDownloadName = "Export123.xlsx";

            return result;
        }

        public static object GetValue(object target, string name)
        {
            return target.GetType().GetProperty(name).GetValue(target);
        }

        public static IEnumerable<KeyValuePair<string, Type>> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && IsSimpleType(p.PropertyType)).Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType));
        }

        public static bool IsSimpleType(Type type)
        {
            var underlyingType = type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                Nullable.GetUnderlyingType(type) : type;

            var typeCode = Type.GetTypeCode(underlyingType);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.String:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
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

        private static void GenerateWorkbookStylesPartContent(WorkbookStylesPart workbookStylesPart1)
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
    }
}
