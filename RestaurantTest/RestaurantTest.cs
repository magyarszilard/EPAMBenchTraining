using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantTest
{
    [TestClass]
    public class RestaurantTest
    {
        [TestMethod]
        public void HotDogHappinessTest()
        {
            IFood food = new HotDog();

            double happiness = food.CalculateHappiness(100);

            Assert.AreEqual(happiness, 102);
        }

        [TestMethod]
        public void HotDogWithKetchupHappinessTest()
        {
            IFood food = new HotDog();
            food = new Ketchup(food);

            double happiness = food.CalculateHappiness(100);

            Assert.AreEqual(happiness, 104);
        }
        [TestMethod]
        public void HotDogWithMustardHappinessTest()
        {
            IFood food = new HotDog();
            food = new Mustard(food);

            double happiness = food.CalculateHappiness(100);

            Assert.AreEqual(happiness, 101);
        }

        [TestMethod]
        public void ChipsHappinessTest()
        {
            IFood food = new Chips();

            double happiness = food.CalculateHappiness(100);

            Assert.AreEqual(happiness, 105);
        }

        [TestMethod]
        public void ChipsWithKetchupHappinessTest()
        {
            IFood food = new Chips();
            food = new Ketchup(food);

            double happiness = food.CalculateHappiness(100);

            Assert.AreEqual(happiness, 110.25);
        }
        [TestMethod]
        public void ChipsWithMustardHappinessTest()
        {
            IFood food = new Chips();
            food = new Mustard(food);

            double happiness = food.CalculateHappiness(100);

            Assert.AreEqual(happiness, 101);
        }
    }
}
