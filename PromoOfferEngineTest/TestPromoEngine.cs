using NUnit.Framework;
using PromoOfferLib;
using System.Collections.Generic;

namespace PromoOfferEngineTest
{
    public class TestPromoEngine
    {
        private ICart _icart1;
        private ICart _icart2;
        private ICart _icart3;

        [SetUp]
        public void Setup()
        {
            _icart1 = new Cart(new List<IProduct> { new Product { Id = "A", Count = 1, Price = 50 },
                                            new Product { Id = "B", Count = 1, Price = 30},
                                            new Product { Id = "C", Count = 1, Price = 20 },
                                            new Product { Id = "D", Count = 0, Price = 30 }});

            _icart2 = new Cart(new List<IProduct> { new Product { Id = "A", Count = 5, Price = 50 },
                                            new Product { Id = "B", Count = 5, Price = 30 },
                                            new Product { Id = "C", Count = 1, Price = 20 } ,
                                            new Product { Id = "D", Count = 0, Price = 30 }});

            _icart3 = new Cart(new List<IProduct> { new Product { Id = "A", Count = 3, Price = 50 },
                                            new Product { Id = "B", Count = 5, Price = 30 },
                                            new Product { Id = "C", Count = 0, Price = 20 },
                                            new Product { Id = "D", Count = 1, Price = 30 }});

        }

        [Test]
        public void TestCase1()
        {
            var total = _icart1.CalculateTotalPrice();
            Assert.AreEqual(100, total);
        }

        [Test]
        public void TestCase2()
        {
            var total = _icart2.CalculateTotalPrice();
            Assert.AreEqual(370, total);
        }

        [Test]
        public void TestCase3()
        {
            var total = _icart3.CalculateTotalPrice();
            Assert.AreEqual(280, total);
        }
    }
}