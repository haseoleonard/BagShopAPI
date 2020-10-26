using BussinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Validation
{
    public class ValidationService 
    {
        public static bool isValidProduct(Product product)
        {
            bool foundErr = true;
            if (product.productID < 0 || product.productID > int.MaxValue)
                foundErr = false;
            if (product.productName == null || product.productName.Trim().Length == 0)
                foundErr = false;
            if (product.description == null || product.description.Trim().Length == 0)
                foundErr = false;
            if (product.price < 0 || product.price > long.MaxValue)
                foundErr = false;
            if (product.quantity < 0 || product.quantity > int.MaxValue)
                foundErr = false;
            if (product.categoryID < 0 || product.categoryID > int.MaxValue)
                foundErr = false;
            return foundErr;
        }
    }
}
