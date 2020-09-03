using System;
namespace PEngine
{
    /// <summary>
    /// Defining the pricing interface.
    /// </summary>
    public interface IPricingStrategy
    {
        Sku Sku { get; }
        double GetPrice(int count);
    }
}
