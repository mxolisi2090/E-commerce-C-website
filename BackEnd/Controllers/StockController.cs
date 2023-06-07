using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class StockController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public int addComp(int itemId,string name, string description, double price, string supplier, int avaiblestock, int soldstock, int onspecial, string image, string Status, int capacity, double stockPrice)
        {
            Stock stock = new Stock
            {
                ItemId= itemId,
                Name = name,
                Description = description,
                Price = (decimal)price,
                Supplier = supplier,
                AvaibleStock = avaiblestock,
                Sold = soldstock,
                onSpecial = onspecial,
                Image = image,
                Status = Status,
                maxAmountStock = capacity,
                Stockprice = (decimal)stockPrice,
            };

            if (stock == null) return -1;

            db.Stocks.InsertOnSubmit(stock);

            try
            {
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return -1;
            }
            return 1;
        }

        [HttpGet]
        public List<Stock> getSock()
        {

            var allitems = (from U in db.Stocks select U);
            List<Stock> reports = new List<Stock>();

            foreach (Stock item in allitems)
            {
                reports.Add(item);
            }
            return reports;
        }

        [HttpGet]
        public List<int> getTopFive(string val,string val1)
        {
            var allitems = (from U in db.Stocks select U);
           
            var reports = new List<int>();
            var names = new List<int>();
           

            foreach (var item in allitems)
            {
                reports.Add(item.Sold);

            }

            var result = reports.OrderByDescending(x => x).Take(5);

            return result.ToList();
        }


        [HttpGet]
        public List<string> getSockItemId(int sold, string val,string val1)
        {
            string me = "";
            string you = "";
            List<int> topfive = getTopFive(me, you);
            var names = new List<string>();

            foreach (var a in topfive)
            {
                var allitems = (from U in db.Stocks
                                where U.Sold.Equals(a)
                                select U).FirstOrDefault();

                
                names.Add(allitems.Name);
            }
            


            return names;
        }

        [HttpGet]
        public Stock getSockItemId(int ItemId,int val)
        {

            var allitems = (from U in db.Stocks
                            where U.ItemId.Equals(ItemId)
                            select U).FirstOrDefault();

           
            return allitems;
        }

        [HttpGet]
        public Stock getSock(int stockId)
        {

            var CartItem = (from b in db.Stocks
                            where b.StockId.Equals(stockId)
                            select b).FirstOrDefault();
            
            return CartItem;
        }

        [HttpGet]
        public int AddStock(int stockId,int available,int capacity)
        {

            var CartItem = (from b in db.Stocks
                            where b.StockId.Equals(stockId)
                            select b).FirstOrDefault();

            if (CartItem == null)
                return -1;


            CartItem.AvaibleStock += available;
            CartItem.maxAmountStock = capacity;
            try
            {
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return -2;
            }
        }

       

    }
}