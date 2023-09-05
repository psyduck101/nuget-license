using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NugetUtility
{
    internal class ExcelExport
    {
        public const string LicensesSheet = "Licenses";
        public static void SaveAsExcel(List<LibraryInfo> libraries, string fileName, bool allowDuplicates = false)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(LicensesSheet);

            var dataTable = new DataTable();
            dataTable.Columns.Add(nameof(LibraryInfo.PackageName), typeof(string));
            dataTable.Columns.Add(nameof(LibraryInfo.PackageVersion), typeof(string));
            dataTable.Columns.Add(nameof(LibraryInfo.LicenseType), typeof(string));
            dataTable.Columns.Add(nameof(LibraryInfo.LicenseUrl), typeof(string));

            var filteredList = allowDuplicates ? libraries : libraries.Distinct(new LibraryInfoEqualityComparer()).ToList();
            foreach (var entity in filteredList)
            {
                dataTable.Rows.Add(entity.PackageName, entity.PackageVersion, entity.LicenseType, entity.LicenseUrl);
            }

            worksheet.Cell(1, 1).InsertTable(dataTable);
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(fileName);
        }
    }
}
