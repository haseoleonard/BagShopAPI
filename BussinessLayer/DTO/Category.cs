using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class Category
    {
        public Category()
        {
        }
        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }
        public Category(int categoryID, string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }
        public int categoryID { get; set; }
        [Required(ErrorMessage ="Category Name Is Required")]
        public string categoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
