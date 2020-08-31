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

        Root root = promotionEngineMain.LoadPromoData();//load the promotype config to root object

        unitPrice = promotionEngineMain.GetUnitPrice(sKUInputClass, root);// calculate unit price based on input
        return unitPrice;
    }


    #region Private Methods

    private int GetUnitPrice(List<SKUInputClass> sKUInputClass, Root root)
    {
        int unitPrice = 0;
        //calculate Unit Price
        string promoType = string.Empty;

        foreach (SKUInputClass skuCls in sKUInputClass)
        {
            //SkuDataItem obj= root.skuData.Where(s => s.id == skuCls.Id);//returns price of one item
            var priceUnit = root.skuData.Where(s => s.id == skuCls.Id)
                            .Select(s => s.price).FirstOrDefault();//returns price of one item
            var obj = root.skuData.Where(s => s.id == skuCls.Id).FirstOrDefault();

            SkuDataItem skuDataItem = (SkuDataItem)obj;

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
        Root root = new Root();
        string dirPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        string filePath = "Data//PromoTypes.json";

        string fullPath = Path.Combine(dirPath, filePath);

        using (StreamReader r = new StreamReader(fullPath))
        {
            string json = r.ReadToEnd();

            JObject jsonObj = JObject.Parse(json);
            root = JsonConvert.DeserializeObject<Root>(json);//deseriealize to class objects
        }
        return root;
    }

    #endregion
}
}
