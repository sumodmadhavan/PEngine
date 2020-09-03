using System;
namespace PEngine
{
    public class PricingStategyA : SaleStrategy
    {
        public override Sku Sku { get; } = 'A';
        protected override double PricePerOne { get; } = 50;
        protected override double PricePerX { get; } = 130;
        protected override int X { get; } = 3;
    }
}
