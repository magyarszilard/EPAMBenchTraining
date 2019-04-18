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
            Assert.AreEqual(food.CalculateHappiness(100), 102);
        }

        [TestMethod]
        public void HotDogWithKetchupHappinessTest()
        {
            IFood food = new HotDog();
            food = new Ketchup(food);
            Assert.AreEqual(food.CalculateHappiness(100), 104);
        }
        [TestMethod]
        public void HotDogWithMustardHappinessTest()
        {
            IFood food = new HotDog();
            food = new Mustard(food);
            Assert.AreEqual(food.CalculateHappiness(100), 101);
        }

        [TestMethod]
        public void ChipsHappinessTest()
        {
            IFood food = new Chips();
            Assert.AreEqual(food.CalculateHappiness(100), 105);
        }

        [TestMethod]
        public void ChipsWithKetchupHappinessTest()
        {
            IFood food = new Chips();
            food = new Ketchup(food);
            Assert.AreEqual(food.CalculateHappiness(100), 110.25);
        }
        [TestMethod]
        public void ChipsWithMustardHappinessTest()
        {
            IFood food = new Chips();
            food = new Mustard(food);
            Assert.AreEqual(food.CalculateHappiness(100), 101);
        }
    }
}
