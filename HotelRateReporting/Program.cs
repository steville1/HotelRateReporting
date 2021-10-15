using HotelRateReporting.Common;
using HotelRateReporting.Models;
using HotelRateReporting.Services;
using System.Data;

namespace HotelRateReporting
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
           string fileName = "hotelrates.json";
           var hotelRateReportingModel = new JsonMapper(fileName).Deserialize<HotelRateReportingModel>(new HotelRateReportingModel());

            DataTable mainHotelTable = hotelRateReportingModel.AsDataTable();

            var reportService = new ReportingService("HotelRateReport");
            reportService.LoadFromDataTable(mainHotelTable);
            reportService.Dispose();
          
        }
    }
}
