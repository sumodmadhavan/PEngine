using System;
namespace PEngine
{
    public interface IPricingStrategy
    {
        Sku Sku { get; }
        double GetPrice(int count);
    }
}
