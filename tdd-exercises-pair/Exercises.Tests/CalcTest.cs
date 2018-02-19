using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDExercises.Tests
{
    [TestClass]
    public class CalcTest
    {


        [TestMethod]
        public void SumTestNull()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(0, calc.Add(""));
        }



        [TestMethod]
        public void SumTest()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(33, calc.Add("33"));


        }


        [TestMethod]
        public void SumTest1Plus2()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(3, calc.Add("1,2"));


        }

        [TestMethod]
        public void SumTestMultiNum()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(13, calc.Add("1,2,4,6"));


        }


        [TestMethod]
        public void SumTestNewLine()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(6, calc.Add("1\n2,3"));


        }


        [TestMethod]
        public void SumTestCrazySymbols()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(3, calc.Add("//;\n1;2"));


        }

    }
}
