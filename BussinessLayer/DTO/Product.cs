using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public long price { get; set; }
        public int quantity { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public bool status { get; set; }
    }
}
