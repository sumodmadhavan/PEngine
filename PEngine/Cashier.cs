using System;
using System.Collections.Generic;
using System.Linq;
namespace PEngine
{
    public class Cashier
    {
        private List<IPricingStrategy> _pricingStrategies;

        public Cashier(List<IPricingStrategy> pricingStrategies)
        {
            _pricingStrategies = pricingStrategies;
        }

        public double Checkout(IList<Sku> products)
        {
            double result = 0;
            double tempResult = 0;
            foreach (var strat in _pricingStrategies)
            {
                var prods = products.Where(p => p == strat.Sku);
                tempResult = strat.GetPrice(prods.Count());
                Console.WriteLine(strat.Sku + "'s total :- " + tempResult);
                result = result + tempResult;
            }

            return result;
        }
    }
}
