using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestPromotionProj
{
    [TestClass]
    public class SkuTests
    {
        [TestMethod]
        public void Sku_ImplicitCastFromCharToSku()
        {
            var sku = new Sku('A');
            sku = 'B';

            Assert.AreEqual('B', sku);
        }

        [TestMethod]
        public void Sku_ImplicitCastFromSkuToSku()
        {
            var original = new Sku('A');
            var expected = new Sku('B');

            original = expected;

            Assert.AreEqual(expected, original);
        }

        [TestMethod]
        public void Sku_ExplicitCastFromSkuToChar()
        {
            var sku = new Sku('A');

            Assert.AreEqual('A', (char)sku);
        }

        [TestMethod]
        public void Sku_ExplicitCastFromCharToSku()
        {
            var sku = new Sku('A');

            Assert.AreEqual(sku, (Sku)'A');
        }

        [TestMethod]
        public void Sku_CharAndSkuHaveSameHashCode()
        {
            var sku = new Sku('A');
            var chr = 'A';

            Assert.AreEqual(chr.GetHashCode(), sku.GetHashCode());
        }

        [TestMethod]
        public void Sku_SkuAndSkuHaveSameHashCode()
        {
            var sku1 = new Sku('A');
            var sku2 = new Sku('A');

            Assert.AreEqual(sku1.GetHashCode(), sku2.GetHashCode());
        }

        [TestMethod]
        public void Sku_CanCreateNewSkuFromExisting()
        {
            var sku1 = new Sku('A');
            var sku2 = new Sku(sku1);

            Assert.AreEqual(sku1, sku2);
        }

        [TestMethod]
        public void Sku_CanUseEqualsOperator()
        {
            Sku sku1 = 'A';
            Sku sku2 = 'A';

            Assert.IsTrue(sku1 == sku2);
        }

        [TestMethod]
        public void Sku_TwoDifferentSkusAreUnEqual()
        {
            Sku sku1 = 'A';
            Sku sku2 = 'B';

            Assert.AreNotEqual(sku1, sku2);
        }
    }
}
