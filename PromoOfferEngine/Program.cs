using System;
using System.Collections.Generic;
using PromoOfferLib;

namespace PromoOfferEngine
{
    /// <summary>
    /// Calculate Total Price for the Products after applying Discounts
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var list = GetData();
            var price = CalculateTotalPrice(list);
            if (price == -1)
            {
                Console.WriteLine("Error in Calculation");
                Console.ReadLine();
            }
            Console.WriteLine("Total Price After Disount is ::{0}", price);
            Console.ReadLine();
        }

        private static IList<IProduct> GetData()
        {
            var case1 = new List<IProduct> {new Product { Id = "A", Count = 1, Price = 50 },
                                            new Product { Id = "B", Count = 1, Price = 30},
                                            new Product { Id = "C", Count = 1, Price = 20 },
                                            new Product { Id = "D", Count = 0, Price = 30 }
                                          };
            var case2 = new List<IProduct> {new Product { Id = "A", Count = 5, Price = 50 },
                                            new Product { Id = "B", Count = 5, Price = 30 },
                                            new Product { Id = "C", Count = 1, Price = 20 } ,
                                            new Product { Id = "D", Count = 0, Price = 30 }
                                          };

            var case3 = new List<IProduct> {new Product { Id = "A", Count = 3, Price = 50 },
                                            new Product { Id = "B", Count = 5, Price = 30 },
                                            new Product { Id = "C", Count = 0, Price = 20 },
                                            new Product { Id = "D", Count = 1, Price = 30 }
                                           };

            
            return case1;
            //return case2;
            //return case3;
        }

        public static int CalculateTotalPrice(IList<IProduct> pr)
        {
            var cart = new Cart(pr);
            return cart.CalculateTotalPrice();
        }
    }
}
