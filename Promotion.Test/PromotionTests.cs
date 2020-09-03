using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Test
{
    [TestClass]
    public class PromotionTests
    {
        [TestMethod]
        public void Sku_ImplicitCastFromCharToSku()
        {
            _ = new Sku('A');
            Sku sku = 'B';

            Assert.AreEqual('B', sku);
        }

        [TestMethod]
        public void Sku_ImplicitCastFromSkuToSku()
        {
            _ = new Sku('A');
            var expected = new Sku('B');

            Sku original = expected;

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
        [TestMethod]
        public void Cashier_WhenNoProducts_PriceIsZero()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>();

            var price = cashier.Checkout(products);

            Assert.AreEqual(0, price);
        }

        [TestMethod]
        public void Cashier_OneA_Is50()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(50, price);
        }

        [TestMethod]
        public void Cashier_TwoA_Is100()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void Cashier_ThreeA_Is130()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(130, price);
        }

        [TestMethod]
        public void Cashier_FourA_Is180()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A', 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(180, price);
        }

        [TestMethod]
        public void Cashier_SixA_Is260()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A', 'A', 'A', 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(260, price);
        }

        [TestMethod]
        public void Cashier_OneB_Is30()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(30, price);
        }

        [TestMethod]
        public void Cashier_TwoBIs45()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(45, price);
        }

        [TestMethod]
        public void Cashier_ThreeBIs75()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'B', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(75, price);
        }

        public void Cashier_FourBIs90()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'B', 'B', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(90, price);
        }

        [TestMethod]
        public void Cashier_OneAOneB_Is80()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(80, price);
        }

        [TestMethod]
        public void Cashier_OneATwoB_OutOfOrder_Is95()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'A', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(95, price);
        }

        [TestMethod]
        public void Cashier_OneC_Is20()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'C' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(20, price);
        }

        [TestMethod]
        public void Cashier_TwoC_Is20()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'C', 'C' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(40, price);
        }

        [TestMethod]
        public void Cashier_OneD_Is15()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'D' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(15, price);
        }

        [TestMethod]
        public void Cashier_TwoD_Is30()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'D', 'D' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(30, price);
        }
        /*
        Scenario A
         1 * A 50
         1 * B 30
         1 * C 20
         ========
         Total 100
         */
        [TestMethod]
        public void Cashier_Scenario_A()
        {
            var pricingStrategies = new List<IPricingStrategy>()
            {
                new PricingStategyA(),
                new PricingStrategyB(),
                new PricingStrategyC()
            };
            var cashier = new Cashier(pricingStrategies);
            var products = new List<Sku>() { 'A', 'B','C'};
            var price = cashier.Checkout(products);
            Assert.AreEqual(100, price);
        }
        /*
        Scenario B
         5 * A 130 + 2 * 50
         5 * B 45 + 45  + 30
         1 * C 20
         ========
         Total 370
         */
        [TestMethod]
        public void Cashier_Scenario_B()
        {
            var pricingStrategies = new List<IPricingStrategy>()
            {
                new PricingStategyA(),
                new PricingStrategyB(),
                new PricingStrategyC()
            };
            var cashier = new Cashier(pricingStrategies);
            var products = new List<Sku>() { 'A', 'A','A','A','A', 'B', 'B', 'B', 'B', 'B','C'};
            var price = cashier.Checkout(products);
            Assert.AreEqual(370, price);
        }
        /*
         Scenario C
          3 * A 130 + 2 * 50
          5 * B 45 + 45  + 1 *  30
          1 * C 
          1 * D 30
          ========
          Total 280
          */
        [TestMethod]
        public void Cashier_Scenario_C()
        {
            var pricingStrategies = new List<IPricingStrategy>()
            {
                new PricingStategyA(),
                new PricingStrategyB(),
                new PricingStrategyCandD()
            };
            var cashier = new Cashier(pricingStrategies);
            var products = new List<Sku>() { 'A', 'A','A','B','B','B','B','B','&'};
            var price = cashier.Checkout(products);
            Assert.AreEqual(280, price);
        }

        private static List<IPricingStrategy> GetPricingStrategies()
        {
            return new List<IPricingStrategy>()
            {
                new PricingStategyA(),
                new PricingStrategyB(),
                new PricingStrategyCandD(),
                new PricingStrategyD()
            };
        }
    }
}
