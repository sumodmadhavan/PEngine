﻿using System;
namespace PEngine
{
    /// <summary>
    /// concrete strategy B
    /// </summary>
    public class PricingStrategyB : SaleStrategy
    {
        public override Sku Sku { get; } = 'B';
        protected override double PricePerOne { get; } = 30;
        protected override double PricePerX { get; } = 45;
        protected override int X { get; } = 2;
    }
}
