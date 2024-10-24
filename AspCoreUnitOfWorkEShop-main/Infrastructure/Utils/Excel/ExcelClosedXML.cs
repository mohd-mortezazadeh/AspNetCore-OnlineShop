using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//https://www.infoworld.com/article/3538413/how-to-export-data-to-excel-in-aspnet-core-30.html
//https://closedxml.readthedocs.io/en/latest/introToStyling.html
//https://github.com/ClosedXML/ClosedXML/wiki/Using-Colors

namespace Infrastructure.Excel
{
    public class ExcelClosedXML<T> : Controller where T : class
    {
        public IActionResult ExportToExcel(List<T> lst, string WorksheetTitle, string fileName)
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            fileName = fileName + ".xlsx";

            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add(WorksheetTitle);
            worksheet.RightToLeft = true;

            int column = 1;
            var obj = lst.FirstOrDefault();

            if (lst.Count == 0)
            {
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }



            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                var displayName = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute),
                false).Cast<DisplayAttribute>().FirstOrDefault()?.Name;

                if (displayName == null)
                {
                    continue;
                }

                worksheet.Cell(1, column).Value = displayName;
                worksheet.Cell(1, column).Style.Fill.SetBackgroundColor(XLColor.Blue);
                worksheet.Cell(1, column).GetRichText().SetFontColor(XLColor.White);
                worksheet.Columns().Width = 30;
                ++column;
            }

            int index = 1;
            column = 1;

            foreach (var item in lst)
            {
                column = 1;
                foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
                {
                    var displayName = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute),
                        false).Cast<DisplayAttribute>().FirstOrDefault()?.Name;

                    if (displayName == null)
                    {
                        continue;
                    }

                    var val = propertyInfo.GetValue(item);
                    worksheet.Cell(index + 1, column).Value = index;
                    ++column;
                }

                ++index;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, contentType, fileName);
            }
        }

    }
}
