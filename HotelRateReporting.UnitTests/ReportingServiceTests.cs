using HotelRateReporting.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace HotelRateReporting.UnitTests
{
    public class ReportingServiceTests
    {
        private HotelRateReportingModel _hotelRateReportingModel;
        private DataTable _dataTable;
        [SetUp]
        public void Setup()
        {
            _hotelRateReportingModel = new HotelRateReportingModel
            {
                hotel = new Hotel { classification = 1, hotelID = 1, name = "Test Hotel", reviewscore = 1.2 },
                hotelRates = new List<HotelRate> {
                    new HotelRate {
                        adults=2,
                        los=1,
                        price= new Price {currency = "EUR", numericFloat=325.5, numericInteger=32550},
                        rateDescription = "Test Description",
                        rateID = "_TESTID",
                        rateName = "My Test RateName",
                        rateTags = new List<RateTag>{new RateTag{name = "Myrate", shape = true}},
                        targetDay = DateTime.Now
                        }
                }
            };

            _dataTable = _hotelRateReportingModel.AsDataTable();
        }

        [Test]
        public void DataTable_Rows_Should_Be_Equal_To_HotelRates_Count()
        {
            //assert
            Assert.AreEqual(_hotelRateReportingModel.hotelRates.Count, _dataTable.Rows.Count);
        }

        [Test]
        public void DataTable_Price_DataType_Should_Be_Equal_To_Double()
        {
            //Arrange
            double anyDoubleNumber = 1.2;
            var dtPrice = _dataTable.Rows[0]["PRICE"];

            //Act
            Type expectedDataType = anyDoubleNumber.GetType();
            Type dtPriceType = dtPrice.GetType();

            //assert
            Assert.AreEqual(expectedDataType, dtPriceType);
        }
    }
}