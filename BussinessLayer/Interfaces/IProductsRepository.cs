using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IProductRepository:IRepositoryBase<DataAccessLayer.Product,DTO.Product>
    {
        DTO.Product UpdateProduct(DTO.Product product);
    }
}
