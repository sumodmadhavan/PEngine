using System;
using System.Collections.Generic;
using NUnit.Framework;
using PromotionEngineMain.Entity;
using PromotionEngineMain;
namespace PromotionEngineUnitTests
{
    //Test cases for Scenario A , B and C
    [TestFixture]
    public class PromotionEngineUnitTests
    {

        /*
        Scenario A
         1 * A 50
         1 * B 30
         1 * C 20
         ========
         Total 100
         */
        [Test]
        public void SKU_One_Each_ScenarioA()
        {
            //Assign
            List<SKUInputClass> lstSKUClass = new List<SKUInputClass>();
            SKUInputClass sKUClass = new SKUInputClass();

            sKUClass = new SKUInputClass()
            {
                Id = "A",
                Count = 1
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "B",
                Count = 1
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "C",
                Count = 1
            };
            lstSKUClass.Add(sKUClass);
            //Act
            int output = PromotionEngineMain.PromotionEngineMain.CheckOut(lstSKUClass);

            //Assert
            Assert.AreEqual(100, output);
            

        }
        /*
        Scenario B
         5 * A 130 + 2 * 50
         5 * B 45 + 45  + 30
         1 * C 20
         ========
         Total 370
         */

        [Test]
        public void SKU_Offer_ScenarioB()
        {
           //Assign
            List<SKUInputClass> lstSKUClass = new List<SKUInputClass>();
            SKUInputClass sKUClass = new SKUInputClass();

            sKUClass = new SKUInputClass()
            {
                Id = "A",
                Count = 5
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "B",
                Count = 5
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "C",
                Count = 1
            };
            lstSKUClass.Add(sKUClass);

            //Act
            int output = PromotionEngineMain.PromotionEngineMain.CheckOut(lstSKUClass);

            //Assert
            Assert.AreEqual(370, output);
            

        }
        /*
        Scenario C
        3 * A 130
        5 * B 45 + 45 +1 * 30
        1 * C -
        1 * D 30
        ========
        Total 370
        */
       /[Test]
        public void SKU_Offer_ScenarioC()
        {
            //Assign
            List<SKUInputClass> lstSKUClass = new List<SKUInputClass>();
            SKUInputClass sKUClass = new SKUInputClass();

            sKUClass = new SKUInputClass()
            {
                Id = "A",
                Count = 5
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "B",
                Count = 5
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "C",
                Count = 1
            };
            lstSKUClass.Add(sKUClass);

            sKUClass = new SKUInputClass()
            {
                Id = "D",
                Count = 1
            };
            lstSKUClass.Add(sKUClass);

            //Act
            int output = PromotionEngineMain.PromotionEngineMain.CheckOut(lstSKUClass);

            //Assert
            Assert.AreEqual(280, output);
            

        }
    }
}
