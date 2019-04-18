using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RationalNumbers;

namespace RationalNumbersTest
{
    [TestClass]
    public class RationalNumbersTest
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void InvalidRationalNumberTest()
        {
            RationalNumber value = new RationalNumber(1, 0);
        }

        [DataRow(1, 3, 3, 9)]
        [DataRow(2, -3, -2, 3)]
        [DataRow(1, 2, -2, -4)]
        [DataTestMethod]
        public void NormalizationTest(int numerator, int denominator, int numeratorMult, int denominatorMult)
        {
            RationalNumber number = new RationalNumber(numerator, denominator);
            RationalNumber numberMult = new RationalNumber(numeratorMult, denominatorMult);
            Assert.AreEqual(number, numberMult);
        }

        [DataRow(1, 3, "1r3")]
        [DataRow(1, -3, "-1r3")]
        [DataRow(-1, 3, "-1r3")]
        [DataRow(-1, -3, "1r3")]
        [DataRow(4, 1, "4")]
        [DataTestMethod]
        public void ToStringTest(int numerator, int denominator, string result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            Assert.AreEqual(value.ToString(), result);
        }

        [DataRow(1, 3, 1, 4, 1)]
        [DataRow(1, 5, 1, 2, -1)]
        [DataRow(1, 5, 2, 10, 0)]
        [DataTestMethod]
        public void CompareToTest(int numerator, int denominator, int numerator2, int denominator2, int result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            RationalNumber value2 = new RationalNumber(numerator2, denominator2);
            Assert.AreEqual(value.CompareTo(value2), result);
        }

        [DataRow(1, 3, 1, 4, "7r12")]
        [DataRow(1, 3, -1, 4, "1r12")]
        [DataRow(1, 2, 1, 2, "1")]
        [DataRow(1, 2, 1, 6, "2r3")]
        [DataTestMethod]
        public void AdditionTest(int numerator, int denominator, int numerator2, int denominator2, string result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            RationalNumber value2 = new RationalNumber(numerator2, denominator2);
            Assert.AreEqual((value + value2).ToString(), result);
        }

        [DataRow(1, 3, 1, 4, "1r12")]
        [DataRow(1, 3, -1, 4, "7r12")]
        [DataRow(1, 2, 1, 2, "0")]
        [DataRow(1, 2, 1, 6, "1r3")]
        [DataRow(-2, 5, 3, 5, "-1")]
        [DataTestMethod]
        public void SubtractionTest(int numerator, int denominator, int numerator2, int denominator2, string result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            RationalNumber value2 = new RationalNumber(numerator2, denominator2);
            Assert.AreEqual((value - value2).ToString(), result);
        }

        [DataRow(1, 3, 1, 4, "1r12")]
        [DataRow(1, 3, -1, 4, "-1r12")]
        [DataRow(1, 2, 1, 2, "1r4")]
        [DataRow(4, 3, 1, 6, "2r9")]
        [DataRow(-2, 5, -3, 5, "6r25")]
        [DataRow(1, 3, 0, 5, "0")]
        [DataTestMethod]
        public void MultiplicationTest(int numerator, int denominator, int numerator2, int denominator2, string result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            RationalNumber value2 = new RationalNumber(numerator2, denominator2);
            Assert.AreEqual((value * value2).ToString(), result);
        }

        [DataRow(1, 3, 1, 4, "4r3")]
        [DataRow(1, 3, -1, 4, "-4r3")]
        [DataRow(1, 2, 1, 2, "1")]
        [DataRow(4, 3, 1, 6, "8")]
        [DataRow(-2, 5, -3, 5, "2r3")]
        [DataTestMethod]
        public void DivisionTest(int numerator, int denominator, int numerator2, int denominator2, string result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            RationalNumber value2 = new RationalNumber(numerator2, denominator2);
            Assert.AreEqual((value / value2).ToString(), result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTestWithException()
        {
            RationalNumber value = new RationalNumber(1, 2);
            RationalNumber value2 = new RationalNumber(0, 3);

            value = value / value2;
        }

        [DataRow(1, 3, "-1r3")]
        [DataRow(1, -3, "1r3")]
        [DataRow(-1, 3, "1r3")]
        [DataTestMethod]
        public void NegationTest(int numerator, int denominator, string result)
        {
            RationalNumber value = new RationalNumber(numerator, denominator);
            Assert.AreEqual((-value).ToString(), result);
        }

        [DataRow(1,"1")]
        [DataRow(3,"3")]
        [DataRow(0, "0")]
        [DataTestMethod]
        public void ImplicitOperatorTest(int numerator, string result)
        {
            RationalNumber value = numerator;
            Assert.AreEqual(value.ToString(), result);
        }
    }
}
