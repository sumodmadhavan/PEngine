using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PromotionEngineMain.Entity;

namespace PromotionEngineMain
{
public class PromotionEngineMain
{
    public static int CheckOut(List<SKUInputClass> sKUInputClass)
    {
        int unitPrice = 0;
        PromotionEngineMain promotionEngineMain = new PromotionEngineMain();

        Root ruleEngine = promotionEngineMain.LoadPromoData();//load the promotype config to ruleEngine object

        unitPrice = promotionEngineMain.GetUnitPrice(sKUInputClass, ruleEngine);// calculate unit price based on input
        return unitPrice;
    }


    #region Private Methods

    //Ideally we can apply a strategy Pattern but it just complicate the current problem statement.
    private int GetUnitPrice(List<SKUInputClass> sKUInputClass, Root ruleEngine)
    {
        int unitPrice = 0;
        //calculate Unit Price
        string promoType = string.Empty;
        //O(n) in Time.    
        foreach (SKUInputClass skuCls in sKUInputClass)
        {
            //SkuDataItem obj= ruleEngine.skuData.Where(s => s.id == skuCls.Id);//returns price of one item
            var priceUnit = ruleEngine.skuData.Where(s => s.id == skuCls.Id)
                            .Select(s => s.price).FirstOrDefault();//returns price of one item
            var skuDataItem = ruleEngine.skuData.Where(s => s.id == skuCls.Id).FirstOrDefault(); //Worse case O(n2)

            SkuDataItem skuDataItem = skuDataItem as SkuDataItem;

            if (skuCls.Count == 1)//count is just one, assign actual price
            {
                unitPrice += Convert.ToInt32(skuDataItem.price);
            }
            else if (skuDataItem.isOfferApplicable)//check if offer exists
            {
                if (skuCls.Count == skuDataItem.offer.count)//offer count matches the input count, assign offerprice
                {
                    unitPrice += skuDataItem.offer.offerPrice;
                }
                else if (skuCls.Count < skuDataItem.offer.count)// offer count is high, take orginal price
                {
                    unitPrice += Convert.ToInt32(skuDataItem.price) * skuCls.Count;
                }
                else if ((skuCls.Count % skuDataItem.offer.count) == 0)// input count is disivible by offercount, no balance
                {
                    int offerNum = skuCls.Count / skuDataItem.offer.count;//divide and take the actual number
                    unitPrice += offerNum * skuDataItem.offer.offerPrice;//multiply with the price and assign
                }
                else if (!((skuCls.Count % skuDataItem.offer.count) == 0))// calculate the balance as well
                {
                    int offerNum = skuCls.Count / skuDataItem.offer.count;//divide and take the actual number
                    unitPrice += offerNum * skuDataItem.offer.offerPrice;//multiply with the price and assign

                    int balance = skuCls.Count - (offerNum * skuDataItem.offer.count);// calculate the balance here
                    unitPrice += balance * Convert.ToInt32(skuDataItem.price);//multiply with the price and assign
                }
            }
        }
        return unitPrice;
    }

    /// <summary>
    /// Get the PromoTypes Configuration from the Json file - real time it can be pulled from a database
    /// deserialize the Json data to corresponding entites
    /// </summary>
    /// <returns></returns>
    private Root LoadPromoData()
    {
        Root ruleEngine = new Root();
        string dirPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        string filePath = "Data//PromoTypes.json";

        string fullPath = Path.Combine(dirPath, filePath);

        using (StreamReader r = new StreamReader(fullPath))
        {
            string json = r.ReadToEnd();

            JObject jsonObj = JObject.Parse(json);
            ruleEngine = JsonConvert.DeserializeObject<Root>(json);//deseriealize to class objects
        }
        return ruleEngine;
    }

    #endregion
}
}
