using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class Category
    {
        public Category(int categoryID, string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
