using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRateReporting.Services
{
    public class ReportingService
    {
        private string _name { get; set; }
        private ExcelPackage _excelPackage;
        private ExcelWorksheet _excelWorksheet;

        public ReportingService(string name)
        {
            _name = name;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _excelPackage = new ExcelPackage(new FileInfo($"{_name}_{DateTime.Now.ToString("ddMMyy-HHmm")}.xlsx"));
            _excelWorksheet = _excelPackage.Workbook.Worksheets.Add("Report");
        }

        public void LoadFromDataTable(DataTable dt)
        {
            _excelWorksheet.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Medium9);
            _excelWorksheet.Cells[2, 3, dt.Rows.Count + 1, 3].Style.Numberformat.Format = "#,##0.00";
            _excelWorksheet.Cells[_excelWorksheet.Dimension.Address].AutoFitColumns();
            _excelPackage.Save();
        }

        public void Dispose()
        {
            _excelPackage.Dispose();
        }
    }
}
