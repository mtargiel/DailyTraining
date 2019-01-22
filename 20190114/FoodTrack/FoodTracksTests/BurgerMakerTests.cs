using FoodTracks.Model;
using NUnit.Framework;

namespace Tests
{
    public class BurgerMakerTests
    {
        [Test]
        public void T05_None_BurgerMaker_ShouldReturn_None_Burger()
        {
            // Given
            var cook = new Cook();
            // When
            var burger = cook.Create(null);
            var burger2 = burger;
            // Then
            Assert.AreEqual(burger.Meet.Type, MeetType.None);
            Assert.AreEqual(burger.Cheeseness, Cheeseness.None);
            Assert.AreEqual(burger.Addons.Contains(AddonType.None), true);
        }

        [Test]
        public void T06_CheeseburgerMaker_Should_Create_Perfect_Cheesburger()
        {
            // Given
            var cook = new Cook();
            var burgerMaker = new CheeseburgerMaker();
            // When
            var burger = cook.Create(burgerMaker);
            // Then
            Assert.AreEqual(burger.Meet.Type, MeetType.Medium);
            Assert.AreEqual(burger.Cheeseness, Cheeseness.Single);
            Assert.AreEqual(burger.Addons.Contains(AddonType.None), true);
        }

        [Test]
        public void T07_DoubleCheesburgerMaker_Should_Create_Perfect_Double_Cheesburger()
        {
            // Given
            var cook = new Cook();
            var burgerMaker = new DoubleCheeseburgerMaker();
            // When
            var burger = cook.Create(burgerMaker);
            // Then
            Assert.AreEqual(burger.Meet.Type, MeetType.Medium);
            Assert.AreEqual(burger.Cheeseness, Cheeseness.Double);
            Assert.AreEqual(burger.Addons.Contains(AddonType.None), true);
        }

        [Test]
        public void T08_VegeBurgerMaker_Should_Create_Perfect_VegeSomething()
        {
            // Given
            var cook = new Cook();
            var burgerMaker = new VegeBurgerMaker();
            // When
            var burger = cook.Create(burgerMaker);
            // Then
            Assert.AreEqual(burger.Meet.Type, MeetType.None);
            Assert.AreEqual(burger.Cheeseness, Cheeseness.Single);
            Assert.AreEqual(burger.Addons.Contains(AddonType.None), true);
        }

        [Test]
        public void T09_EnglishBurgerMaker_Should_Create_Perfect_English_Burger()
        {
            // Given
            var cook = new Cook();
            var burgerMaker = new EnglishBurgerMaker();
            // When
            var burger = cook.Create(burgerMaker);
            // Then
            Assert.AreEqual(burger.Meet.Type, MeetType.Full);
            Assert.AreEqual(burger.Addons.Contains(AddonType.Halapenio), true);
            Assert.AreEqual(burger.Addons.Contains(AddonType.Egg), true);
            Assert.AreEqual(burger.Cheeseness, Cheeseness.Single);
        }
    }
}