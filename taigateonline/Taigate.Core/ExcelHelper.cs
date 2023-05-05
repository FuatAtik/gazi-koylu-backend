using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Taigate.Core
{
    public class ExcelHelper
    {
        private static byte[] CreateExcel<T>(List<object> tempList, List<dynamic> languageIds, string author, string title)
            where T : class
        {
            var copy = new List<T>();
            var copyLang = new List<int>();
            tempList.ForEach(o => copy.Add((T) o));
            languageIds.ForEach(x=>copyLang.Add(x.Id));
            using (ExcelPackage package = new ExcelPackage())
            {
                //create the excel file and set some properties
                package.Workbook.Properties.Author = author;
                package.Workbook.Properties.Title = title;
                package.Workbook.Properties.Created = DateTime.Now;

                //create a new sheet
                foreach (var language in copyLang)
                {
                    package.Workbook.Worksheets.Add("LanguageId "+language);
                    ExcelWorksheet ws = package.Workbook.Worksheets["LanguageId "+language];
                    ws.Cells.Style.Font.Size = 11;
                    ws.Cells.Style.Font.Name = "Calibri";

                    //put the data in the sheet, starting from column A, row 1
                    var result = copy.AsQueryable().Where($"LanguageId == {language}").Select(e => (object) e).ToDynamicList();
                    var copyResult = new List<T>();
                    result.ForEach(o => copyResult.Add((T) o));

                    if (!copyResult.Any())
                    {
                        var instance = Activator.CreateInstance<T>();
                        PropertyInfo prop = instance.GetType().GetProperty("LanguageId");
                        prop.SetValue(instance, Convert.ToInt32(language), null);
                        copyResult.Add(instance);
                    }
                    ws.Cells.LoadFromCollection(copyResult, true);

                    //set some styling on the header row
                    var header = ws.Cells[1, 1, 1, ws.Dimension.End.Column];
                    header.Style.Font.Bold = true;
                    header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    header.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BFBFBF"));

                    //loop the header row to capitalize the values
                    for (int col = 1; col <= ws.Dimension.End.Column; col++)
                    {
                        var cell = ws.Cells[1, col];
                        cell.Value = cell.Value.ToString().ToUpper();
                    }

                    //loop the properties in list<t> to apply some data formatting based on data type and check for nested lists
                    var listObject = copyResult.First();
                    var columns_to_delete = new List<int>();
                    for (int i = 0; i < listObject.GetType().GetProperties().Count(); i++)
                    {
                        var prop = listObject.GetType().GetProperties()[i];
                        var range = ws.Cells[2, i + 1, ws.Dimension.End.Row, i + 1];

                        //check if the property is a List, if yes add it to columns_to_delete
                        if (prop.PropertyType.IsGenericType &&
                            prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            columns_to_delete.Add(i + 1);
                        }

                        //set the date format
                        if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                        {
                            range.Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        }

                        //set the decimal format
                        if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                        {
                            range.Style.Numberformat.Format = "0.00";
                        }
                    }

                    //remove all lists from the sheet, starting with the last column
                    foreach (var item in columns_to_delete.OrderByDescending(x => x))
                    {
                        ws.DeleteColumn(item);
                    }

                    //auto fit the column width
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();

                    //sometimes the column width is slightly too small (maybe because of font type).
                    //So add some extra width just to be sure
                    for (int col = 1; col <= ws.Dimension.End.Column; col++)
                    {
                        ws.Column(col).Width += 3;
                    }
                }

                //send the excel back as byte array
                return package.GetAsByteArray();
            }
        }

        public static byte[] GenerateExcel(List<object> list,List<dynamic> languageIds, string author, string title, Type objectType)
        {
            var result = typeof(ExcelHelper)
                .GetMethod("CreateExcel", BindingFlags.Static | BindingFlags.NonPublic)
                ?.MakeGenericMethod(objectType ?? throw new InvalidOperationException())
                .Invoke(null, new object[] {list,languageIds, author, title});
            return result as byte[];
        }
    }
}