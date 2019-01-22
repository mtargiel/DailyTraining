using FoodTracks.Model;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class CashRegisterTests
    {
        [Test]
        public void T10_Cheap_Burger_Should_Cost_0()
        {
            // Given
            var cook = new Cook();
            var cheepBurger = cook.Create(null);
            var cashRegister = new CashRegister();
            // When
            var price = cashRegister.HowMuch(cheepBurger);
            // Then
            Assert.AreEqual(price, 0);
        }

        [Test]
        public void T10_Cheese_Burger_Should_Cost_10()
        {
            // Given
            var cook = new Cook();
            var burger = cook.Create(new CheeseburgerMaker());
            var cashRegister = new CashRegister();
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, 10);
        }

        [Test]
        public void T10_Double_Cheese_Burger_Should_Cost_20()
        {
            // Given
            var cook = new Cook();
            var burger = cook.Create(new DoubleCheeseburgerMaker());
            var cashRegister = new CashRegister();
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, 20);
        }

        [Test]
        public void T11_Vege_Burger_Should_Cost_5()
        {
            // Given
            var cook = new Cook();
            var burger = cook.Create(new VegeBurgerMaker());
            var cashRegister = new CashRegister();
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, 5);
        }

        [Test]
        public void T12_English_Burger_Should_Cost_25()
        {
            // Given
            var cook = new Cook();
            var burger = cook.Create(new EnglishBurgerMaker());
            var cashRegister = new CashRegister();
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, 25);
        }

        [Test]       
        public void T13_Cheap_Burger_On_11_11_2019_Should_Cost_Minus_15()
        {
            // Given
            var cook = new Cook();
            var burger = cook.Create(null);
            var cashRegister = new CashRegister(new TodayIs1111DiscountCalculator());
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, -15);
            //Your task is to tell me why this is alway (almost) red.
        }

        [Test]
        public void T13_Bis_Cheap_Burger_On_11_11_2019_Should_Cost_Minus_15()
        {
            var mock = new Mock<IDiscountCalculator>();
            mock.Setup(x => x.ChanceForWin()).Returns(1);
            mock.SetupGet(x=>x.discountDateTime).Returns()
            // Given
            var cook = new Cook();
            var burger = cook.Create(null);
            var cashRegister = new CashRegister(new TodayIs1111DiscountCalculator());
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, -15);
        }
        [Test]
        public void T14_Bis_Cheap_Burger_50percent_Chanse_that_Win_next_discount()
        {
            var mock = new Mock<IDiscountCalculator>();
            mock.Setup(x => x.ChanceForWin()).Returns(1);
            mock.Setup(x => x.Calculate()).Returns(-10);
            // Given
            var cook = new Cook();
            var burger = cook.Create(new DoubleCheeseburgerMaker());
            var cashRegister = new CashRegister(mock.Object);
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, 5    );
        }
        [Test]
        public void T15_IF_burger_have_50percent_discount_you_dont_win_discount()
        {            
            var mock = new Mock<IDiscountCalculator>();
            mock.Setup(x => x.ChanceForWin()).Returns(0);
            mock.Setup(x => x.Calculate()).Returns(-10);
            // Given
            var cook = new Cook();
            var burger = cook.Create(new DoubleCheeseburgerMaker());
            var cashRegister = new CashRegister(mock.Object);
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Assert.AreEqual(price, 10    );
        }
    }
}