using System;
namespace PromotionEngineMain.Entity
{
    public class SkuDataItem
    {
        public string id { get; set; }
        public int price { get; set; }
        public bool isOfferApplicable { get; set; }
        public Offer offer { get; set; }
        public string comboOffer { get; set; }
    }
}
