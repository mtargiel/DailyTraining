using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MockTraining;

namespace MockTrainingTests
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IDiscountCalc> discountCalc = new Mock<IDiscountCalc>();
        Mock<IProductFactory> factory = new Mock<IProductFactory>();
        Mock<IDataContext> DbContext = new Mock<IDataContext>();
        Mock<ICalendarDiscountCalculator> CalendardiscountCalc = new Mock<ICalendarDiscountCalculator>();

        [TestMethod]
        public void WhenTypeIsUbraniaThen30PercentDiscount()
        {
            //SETUP
            DbContext.Setup(x => x.GetProductPrice("Szal")).Returns(10);
            var price = DbContext.Object.GetProductPrice("Szal");
            var szal = factory.Object.CreateProduct("Ubrania", price);

            discountCalc.Setup(x => x.Calculate(szal)).Returns(7);

            //EXPECTED
            decimal excpected = 7;

           
            Assert.AreEqual(excpected, discountCalc.Object.Calculate(szal));

        }
        [TestMethod]
        public void WhenTypeIsZolwieButyThenAdd20Percent()
        {

            //SETUP

            DbContext.Setup(x => x.GetProductPrice("Buty ortopedyczne")).Returns(15);
            var price = DbContext.Object.GetProductPrice("Buty ortopedyczne");
            var butyOrtopedyczne = factory.Object.CreateProduct("ZolwieButy", price);

            //EXPECTED
            decimal excpected = 18;


            discountCalc.Setup(x => x.Calculate(butyOrtopedyczne)).Returns(18);
            Assert.AreEqual(excpected, discountCalc.Object.Calculate(butyOrtopedyczne));

        }
        [TestMethod]
        public void WhenDateBetween1912and2412Discount20Percent()
        {
            var DiscountDate = new DateTime(DateTime.Now.Year, 12, 24);
            decimal excpected = 80;



            DbContext.Setup(x => x.GetProductPrice("Buty za mszowe")).Returns(100);
            var price = DbContext.Object.GetProductPrice("Buty za mszowe");

            var produkt = factory.Object.CreateProduct("Buty", price);

            CalendardiscountCalc
                .Setup(x => x.Calculate(DiscountDate, produkt)).Returns(80);

            Assert.AreEqual(excpected, CalendardiscountCalc.Object.Calculate(DiscountDate, produkt));

        }
        [TestMethod]
        public void WhenBlackFridayDiscount50()
        {
            var DiscountDate = new DateTime(2019, 11, 29);

            DbContext.Setup(x => x.GetProductPrice("Czapka uszatka")).Returns(100);
            var price = DbContext.Object.GetProductPrice("Czapka uszatka");

            var produkt = factory.Object.CreateProduct("Czapka", price);

            decimal excpected = 50;


            CalendardiscountCalc
                .Setup(x => x.Calculate(DiscountDate, produkt)).Returns(50);

            Assert.AreEqual(excpected, CalendardiscountCalc.Object.Calculate(DiscountDate, produkt));



        }
    }
}
