﻿using System.Linq.Expressions;
using NUnit.Framework;

namespace Cashes.Tests
{
    [TestFixture]
    public class CashTests
    {
        [Test]
        public void TestDollarMultiplication()
        {
            var five = Money.Dollar(5);
            Assert.AreEqual(Money.Dollar(10), five.Times(2));
            Assert.AreEqual(Money.Dollar(15), five.Times(3));
        }

        [Test]
        public void TestEquality()
        {
            Assert.IsTrue(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.IsFalse(Money.Dollar(5).Equals(Money.Dollar(6)));

            Assert.IsFalse(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Test]
        public void TestCurrency()
        {
            Assert.AreEqual("USD", Money.Dollar(1).Currency);
            Assert.AreEqual("CHF", Money.Franc(1).Currency);
        }

        [Test]
        public void TestEqualityWithCurrency()
        {
            Assert.IsTrue(new Money(15, "USD").Equals(new Money(15, "USD")));
        }

        [Test]
        public void TestSimpleAddition()
        {
            Money five = Money.Dollar(5);
            IExpression sum = five.Plus(five);
            Bank bank = new Bank();
            Money reduced = bank.Reduce(sum, "USD");
            Assert.AreEqual(Money.Dollar(10), reduced);
        }

        [Test]
        public void TestPlusReturnsSum()
        {
            Money five = Money.Dollar(5);
            IExpression result = five.Plus(five);
            Sum sum = (Sum)result;
            Assert.AreEqual(five, sum.Augend);
            Assert.AreEqual(five, sum.Addend);
        }

        [Test]
        public void TestReduceSum()
        {
            IExpression sum = new Sum(Money.Dollar(8), Money.Franc(10));
            Bank bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            Assert.AreEqual(Money.Dollar(18), result);
        }

        [Test]
        public void TestReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.Dollar(4), "USD");
            Assert.AreEqual(Money.Dollar(4), result);
        }
    }
}