using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromoOfferLib
{
    /// <summary>
    /// Cart Details Implementation
    /// </summary>
    public class Cart:ICart
    {
        public Cart(IList<IProduct> products)
        {
            this.Products = products;
        }
        private IList<IProduct> Products { get; set; }

        public int CalculateTotalPrice()
        {
            var dict = new Dictionary<int, IProduct>();
            int totalPrice = 0;
            foreach (var c in this.Products)
            {
                if (totalPrice == -1)
                {
                    return -1;
                }
                totalPrice +=  DiscountRule.BulkBuy(c);
            }
            return totalPrice += DiscountRule.ComboBuy(this.Products);

        }
        

    }
}
