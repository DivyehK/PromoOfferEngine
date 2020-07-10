using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoOfferLib
{
    public static class DiscountRule
    {
        #region ReadOnlyFields
        private static readonly int _productAbulkcount = 3;
        private static readonly int _productAbulkprice = 130;

        private static readonly int _productBbulkcount = 2;
        private static readonly int _productBbulkprice = 45;

        private static readonly int _comboAbulkcount = 1;
        private static readonly int _comboAbulkprice = 30;

        #endregion

        public static int BulkBuy(IProduct p)
        {
            if (p.Id == "A")
            {
                return CalculatePostBulDiscountPrice(p, _productAbulkcount, _productAbulkprice);
            }
            else if (p.Id == "B")
            {
                return CalculatePostBulDiscountPrice(p, _productBbulkcount, _productBbulkprice);
            }
            return 0;
        }

        public static int ComboBuy(IList<IProduct> pr)
        {
            var p1 = pr.Where(x => x.Id == "C").FirstOrDefault();
            var p2 = pr.Where(x => x.Id == "D").FirstOrDefault();
            return CalculatePostComboDiscountPrice(_comboAbulkcount, _comboAbulkprice, p1, p2);
        }

        private static int CalculatePostBulDiscountPrice(IProduct p, int promocount, int bulkprice)
        {
            try
            {
                if (p.Count < promocount)
                {
                    return p.Count * p.Price;
                }
                int buycnt = p.Count / promocount;
                int rem = p.Count % promocount;
                return buycnt * bulkprice + rem * p.Price;
            }
            catch
            {
                return -1;
            }
        }

        private static int CalculatePostComboDiscountPrice(int promocount, int comboprice, IProduct p1, IProduct p2)
        {
            try
            {
                //check if both item count is same and count is greater than min promo offer count
                if (p1.Count >= promocount && p2.Count >= promocount && p1.Count == p2.Count)
                {
                    return p1.Count * comboprice;
                }
                //check if count is different for any of them and calculate
                else if (p1.Count >= promocount && p2.Count >= promocount && p1.Count != p2.Count)
                {
                    if (p1.Count <= p2.Count)
                    {
                        int combovalue = p1.Count * comboprice;
                        return combovalue + p2.Price * (p2.Count - p1.Count);
                    }
                    else
                    {
                        int combovalue = p2.Count * comboprice;
                        return combovalue + p2.Price * (p1.Count - p2.Count);
                    }
                }
                else
                {
                    //check if any item is empty in list
                    return p1.Count == 0 ? p2.Count * p2.Price : p1.Count * p1.Price;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
