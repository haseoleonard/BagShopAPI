using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;

namespace BussinessLayer.Repositories
{
    public class ProductsRepository : RepositoryBase<DataAccessLayer.Product, DTO.Product>, IProductRepository
    {
        public ProductsRepository(LNBagShopDBEntities context) : base(context)
        {
        }

    }
}
