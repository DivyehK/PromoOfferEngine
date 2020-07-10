using System;

namespace PromoOfferLib
{
    /// <summary>
    /// SKU Details
    /// </summary>
    public class Product : IProduct
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

    }
}
