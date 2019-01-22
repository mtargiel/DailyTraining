using System;
using StringCalc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalcTests
{
    [TestClass]
    public class CalculatorTests
    {
        public void TestAddMethodInputResultCheck(string input, int result)
        {
            var calculator = new Calculator();
            int expected = result;
            Assert.AreEqual(expected, calculator.add(input));
        }
        [TestMethod]
        public void CalcWhenInput1And2Return3()
        {
            TestAddMethodInputResultCheck("1,2",3);
        }

        [TestMethod]
        public void CalcWhenInputEmptyStringReturn0()
        {
            TestAddMethodInputResultCheck("", 0);

        }
        [TestMethod]
        public void CalcWhenInputOneNumberReturnOneNumber()
        {
            TestAddMethodInputResultCheck("1", 1);

        }
        [TestMethod]
        public void CalcWhenInputNumers4And5And9Result18()
        {
            TestAddMethodInputResultCheck("4,5,9", 18);
        }
        [TestMethod]
        public void CalcWhenInputNumersWithLines1And2And3Return6()
        {
            TestAddMethodInputResultCheck("1\n2,3", 6);
        }

        [TestMethod]
        public void CalcWhenInputNumbersWithDelimiterResutl3()
        {
            TestAddMethodInputResultCheck("//;\n1;2", 3);
        }
        [TestMethod]
        public void CalcWhenInputNumbersWithDelimiterResutl6()
        {
            TestAddMethodInputResultCheck("//[*][%]\n1*2%3", 6);
        }
        [TestMethod]
        public void CalcWhenInputNumbersWithDelimiterResutl5()
        {
            TestAddMethodInputResultCheck("//[****][%%%]\n*2%3", 5);
        }
        [TestMethod]
        public void CalcWhenInputNumbersWithDelimiterResutl4()
        {
            TestAddMethodInputResultCheck("//[****][%%%]\n******2%%%2", 4);
        }
        [TestMethod]
        public void CalcWhenInputNumbersWithDelimiterResutl2()
        {
            TestAddMethodInputResultCheck("////////1/////1*****", 2);
        }
        [TestMethod]
        public void CalcWhenInput1001And1Result1()
        {
            TestAddMethodInputResultCheck("1001,1", 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "negatives not allowed")]
        public void TestNegativeNumbersException()
        {
            var calc = new Calculator();

            calc.add("-1,-2");
        }
    }
}
