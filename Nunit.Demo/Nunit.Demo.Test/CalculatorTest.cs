﻿using NUnit.Framework;
using System;

namespace Nunit.Demo.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        Calculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [TearDown]
        public void Teardown()
        {
            calc.Dispose();
        }

        [Test, Order(2)]
        public void Test_Addition_With_Valid_Intigers()
        {
            var result = calc.Addition(3, 5);
            Assert.AreEqual(8, result);
        }

        [Test, Order(1)]
        public void Test_Subtraction_Argument_Exception() {
            Assert.Catch<SystemException>(() => calc.Subtraction(4, 5));
            Assert.Throws<ArgumentException>(() => calc.Subtraction(4, 5));
        }

        [TestCase(1,2,3), Order(3)]
        [TestCase(2, 3, 5)]
        [TestCase(3, 4, 7)]
        public void Test_Addition_Multiple(int first, int second, int expectedresult)
        {
            var calculated = calc.Addition(first, second);
            Assert.AreEqual(expectedresult, calculated);
        }

        [Ignore("Ignore test")]
        public void Test_To_Ignore()
        {
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 4, 8)]
        [TestCase(-2, 4, -8)]
        [TestCase(-2, -4, 8)]
        public void Test_Multiplication(int first, int second, int expectedResult)
        {
            var calculated = calc.Multiplication(first, second);
            Assert.AreEqual(expectedResult, calculated);
        }


        [TestCase(1, 1, 1)]
        public void Test_Division(int first, int second, double expectedResult)
        {
            var calculated = calc.Division(first, second);
            Assert.AreEqual(expectedResult, calculated);
        }

        [TestCase(8, 3, 5)]
        [TestCase(11, 4, 7)]
        public void Test_Addition_Subtraction(int first, int second, int expectedresult)
        {
            var calculated = calc.Subtraction(first, second);
            Assert.AreEqual(expectedresult, calculated);
        }

        [Test, ]
        public void Test_Division_Argument_Exception()
        {
            Assert.Catch<SystemException>(() => calc.Division(4, 0));
            Assert.Throws<ArgumentException>(() => calc.Division(4, 0));
        }
    }
}
