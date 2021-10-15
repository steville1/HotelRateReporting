using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRateReporting.Models
{
    public class HotelRateReportingModel
    {
        public Hotel hotel { get; set; }
        public List<HotelRate> hotelRates { get; set; }

        public DataTable AsDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "mytable";

            dataTable.Columns.Add(new DataColumn("ARRIVAL_DATE"));
            dataTable.Columns.Add(new DataColumn("DEPARTURE_DATE"));
            dataTable.Columns.Add(new DataColumn("PRICE", System.Type.GetType("System.Double")));
            dataTable.Columns.Add(new DataColumn("CURRENCY"));
            dataTable.Columns.Add(new DataColumn("RATENAME"));
            dataTable.Columns.Add(new DataColumn("ADULTS", System.Type.GetType("System.Int32")));
            dataTable.Columns.Add(new DataColumn("BREAKFAST_INCLUDED", System.Type.GetType("System.Int32")));
            foreach (var rate in hotelRates)
            {
                object[] values = new object[]
                    {
                        rate.targetDay.Date.ToString("dd.MM.yy"),
                        rate.targetDay.AddDays(rate.los).Date.ToString("dd.MM.yy"),
                        rate.price.numericFloat,
                        rate.price.currency,
                        rate.rateName,
                        rate.adults,
                        rate.rateTags.FirstOrDefault().shape ? 1 : 0
                    };

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }

    public class Hotel
    {
        public int classification { get; set; }
        public int hotelID { get; set; }
        public string name { get; set; }
        public double reviewscore { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public double numericFloat { get; set; }
        public int numericInteger { get; set; }
    }

    public class RateTag
    {
        public string name { get; set; }
        public bool shape { get; set; }
    }

    public class HotelRate
    {
        public int adults { get; set; }
        public int los { get; set; }
        public Price price { get; set; }
        public string rateDescription { get; set; }
        public string rateID { get; set; }
        public string rateName { get; set; }
        public IEnumerable<RateTag> rateTags { get; set; }
        public DateTime targetDay { get; set; }
    }
}
