using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZaszloArusAPI_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaszloArusAPI_EF.Models.Tests
{
    [TestClass()]
    public class ProductTests
    {
 
        [TestMethod()]
        public void getPriceTest1()
        {
            Product product = new Product();
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            int eladottDarab = 10;
            int elvartEredmeny = 40000;
            Assert.AreEqual(elvartEredmeny, product.getPrice(eladottDarab));
        }

        [TestMethod()]
        public void getPriceTest2()
        {
            Product product = new Product();
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            int eladottDarab = 20;
            int elvartEredmeny = 76000;
            Assert.AreEqual(elvartEredmeny, product.getPrice(eladottDarab));
        }

        [TestMethod()]
        public void getPriceTest3()
        {
            Product product = new Product();
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            int eladottDarab = 25;
            int elvartEredmeny = 95000;
            Assert.AreEqual(elvartEredmeny, product.getPrice(eladottDarab));
        }
        [TestMethod()]
        public void getPriceTest4()
        {
            Product product = new Product();
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            int eladottDarab = 50;
            int elvartEredmeny = 180000;
            Assert.AreEqual(elvartEredmeny, product.getPrice(eladottDarab));
        }

        [TestMethod()]
        public void getPriceExceptionTest1()
        {
            Product product = new Product();
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            int eladottDarab = 500;
            try
            {
                int visszaAdottEredmeny = product.getPrice(eladottDarab);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "Nincs készleten");
                return;
            }
            Assert.Fail();
        }
        [TestMethod()]
        public void getPriceExceptionTest2()
        {
            Product product = new Product();
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            int eladottDarab = -2;
            Exception kivetel = null;
            try
            {
                int visszaAdottEredmeny = product.getPrice(eladottDarab);
            }
            catch (Product.RosszDarabException ex)
            {
                kivetel = ex;
            }
            Assert.AreNotEqual(null, kivetel);
        }

        [TestMethod()]
        public void getPriceTest5()
        {
            List<Sale> sales = new List<Sale>();
            Sale sale = new Sale();
            sale.ProductId = 1;
            sale.Qty = 1;
            sales.Add(sale);
            Product product = new Product();
            product.Id = 1;
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            product.Sales = sales;
            int eladottDarab = 1;
            int elvartEredmeny = product.getPrice(eladottDarab);
            Assert.AreEqual(product.getPrice(eladottDarab),
                sales[0].getPriceQty(product.Price));
        }

        [TestMethod()]
        public void getPriceTest6()
        {
            List<Sale> sales = new List<Sale>();
            Sale sale = new Sale();
            sale.ProductId = 1;
            sale.Qty = 25;
            sale.Pricetag = 95000;
            sales.Add(sale);
            Product product = new Product();
            product.Id = 1;
            product.Name = "Magyar zászló";
            product.Price = 4000;
            product.Qty = 200;
            product.Sales = sales;
            int eladottDarab = 25;
            int elvartEredmeny = product.getPrice(eladottDarab);
            Assert.AreEqual(product.getPrice(eladottDarab),
                sales[0].getPricetag());
        }


    }
}