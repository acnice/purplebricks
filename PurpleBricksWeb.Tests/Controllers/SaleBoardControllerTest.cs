using Microsoft.VisualStudio.TestTools.UnitTesting;
using PurpleBricksLibrary;
using PurpleBricksWeb.Models;
using System;

namespace PurpleBricksWeb.Tests.Controllers
{
    [TestClass]
    public class SaleBoardControllerTest
    {
        [TestMethod]
        public void AllUnitPrices()
        {
            var collection =  new UnitPriceDAL().GetAllPrices();
            Assert.AreEqual(10, collection.Count);
        }

        [TestMethod]
        public void UnitPriceByStateBoardSize()
        {
          decimal price = new UnitPriceDAL().GetUnitPrice("NSW", BoardSize.Small);
          Assert.AreEqual(50, price);
        }

        [TestMethod]
        public void GetPriceForNSWWithDiscount()
        {
            SaleBoradModel model = new SaleBoradModel();
            model.PropertyAddress = new PropertyAddress();
            model.PropertyAddress.State = "NSW";
            model.BoardSize = BoardSize.Small;
            model.DateFrom = DateTime.Today;
            model.DateTo = DateTime.Today.AddDays(11);

            decimal expected = model.GetPrice();
            Assert.AreEqual(467.50m, expected);
        }

        [TestMethod]
        public void GetPriceForNSWWithoutDiscount()
        {
            SaleBoradModel model = new SaleBoradModel();
            model.PropertyAddress = new PropertyAddress();
            model.PropertyAddress.State = "NSW";
            model.BoardSize = BoardSize.Small;
            model.DateFrom = DateTime.Today;
            model.DateTo = DateTime.Today.AddDays(5);

            decimal expected = model.GetPrice();
            Assert.AreEqual(250m, expected);
        }

        [TestMethod]
        public void GetPriceForOtherWithDiscount()
        {
            SaleBoradModel model = new SaleBoradModel();
            model.PropertyAddress = new PropertyAddress();
            model.PropertyAddress.State = "TAS";
            model.BoardSize = BoardSize.Small;
            model.DateFrom = DateTime.Today;
            model.DateTo = DateTime.Today.AddDays(11);

            decimal expected = model.GetPrice();
            Assert.AreEqual(148.5m, expected);
        }

        [TestMethod]
        public void GetPriceForOtherWithoutDiscount()
        {
            SaleBoradModel model = new SaleBoradModel();
            model.PropertyAddress = new PropertyAddress();
            model.PropertyAddress.State = "TAS";
            model.BoardSize = BoardSize.Large;
            model.DateFrom = DateTime.Today;
            model.DateTo = DateTime.Today.AddDays(5);

            decimal expected = model.GetPrice();
            Assert.AreEqual(100m, expected);
        }

        [TestMethod]
        public void GetPriceForNoServiceArea()
        {
            SaleBoradModel model = new SaleBoradModel();
            model.PropertyAddress = new PropertyAddress();
            model.PropertyAddress.State = "QLD";
            model.BoardSize = BoardSize.Large;
            model.DateFrom = DateTime.Today;
            model.DateTo = DateTime.Today.AddDays(5);

            decimal expected = model.GetPrice();
            Assert.AreEqual(0m, expected);
        }
    }
}
