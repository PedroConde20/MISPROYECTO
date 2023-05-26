using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class SaleDetail
    {
        public int SaleID { get; set; }
        public short WineID { get; set; }
        public int Quantiy { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
       // public string ProductName { get; set;  }


        public SaleDetail(short wineID, int quantiy, double price, string productDescription)
        {
            WineID = wineID;
            Quantiy = quantiy;
            Price = price;
            ProductDescription = productDescription;
            //ProductName = productName;
        }
    }
}
