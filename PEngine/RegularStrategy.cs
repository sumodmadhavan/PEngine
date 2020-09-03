using System;
namespace PEngine
{
    /// <summary>
    /// What we call the base strategy
    /// </summary>
    public abstract class RegularStrategy : IPricingStrategy
    {
        public abstract Sku Sku { get; }
        protected abstract double Price { get; }

        public double GetPrice(int count)
        {
            return Price * count;
        }
    }

    public class PricingStrategyC : RegularStrategy
    {
        public override Sku Sku { get; } = 'C';
        protected override double Price { get; } = 20;
    }

    public class PricingStrategyD : RegularStrategy
    {
        public override Sku Sku { get; } = 'D';
        protected override double Price { get; } = 15;
    }
}
