using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversePolishNotation;

namespace ReversePolishNotationTests
{
    [TestClass]
    public class ReversePolishNotationTests
    {
        [TestMethod]
        public void AddTest()
        {
            double res = ReversePolishNotationReader.ReadPolishNotation("4 3 +");

            Assert.AreEqual(res,7);
        }

        [TestMethod]
        public void MultipleOperationsTest()
        {
            double res = ReversePolishNotationReader.ReadPolishNotation("5 1 2 + 4 * + 3 -");

            Assert.AreEqual(res,14);
        }

        [TestMethod]
        public void NonNumberInputTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                double res = ReversePolishNotationReader.ReadPolishNotation("a 2 +");
            });
        }
        [TestMethod]
        public void InsufficientInputTest()
        {
            //Stack empty
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                double res = ReversePolishNotationReader.ReadPolishNotation("1 +");
            });
        }

        [TestMethod]
        public void PowerTest()
        {
            double res = ReversePolishNotationReader.ReadPolishNotation("2 4 pow");
            Assert.AreEqual(res,16);
        }

        [TestMethod]
        public void RootTest()
        {
            double res = ReversePolishNotationReader.ReadPolishNotation("4 2 root");
            Assert.AreEqual(res,2);
        }

        [TestMethod]
        public void ModuloTest()
        {
            double res = ReversePolishNotationReader.ReadPolishNotation("3 3 %");
            Assert.AreEqual(res,0);
        }

        [TestMethod]
        public void FactorialTest()
        {
            double res = ReversePolishNotationReader.ReadPolishNotation("5 !");
            Assert.AreEqual(res,120);
        }
    }
}