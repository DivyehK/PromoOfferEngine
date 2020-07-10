using System;

namespace PromoOfferLib
{
    /// <summary>
    /// SKU Details
    /// </summary>
    public interface IProduct
    {
        string Id { get; set; }
        int Price { get; set; }

        int Count { get; set; }
    }
}
