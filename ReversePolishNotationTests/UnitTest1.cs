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
            int res = ReversePolishNotationReader.ReadPolishNotation("4 3 +");

            Assert.AreEqual(res,7);
        }

        [TestMethod]
        public void MultipleOperationsTest()
        {
            int res = ReversePolishNotationReader.ReadPolishNotation("5 1 2 + 4 * + 3 -");

            Assert.AreEqual(res,14);
        }

        [TestMethod]
        public void NonNumberInputTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                int res = ReversePolishNotationReader.ReadPolishNotation("a 2 +");
            });
        }
        [TestMethod]
        public void InsufficientInput()
        {
            //Stack empty
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                int res = ReversePolishNotationReader.ReadPolishNotation("1 +");
            });
        }
    }
}