using AutoMapper;
using BussinessLayer.DTO;
using BussinessLayer.Mapping;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DAO
{
    public class ProductsDAO
    {
        
        public List<DTO.Product> GetProducts()
        {
            List<DTO.Product> products = new List<DTO.Product>();
            using(var db = new LNBagShopDBEntities())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
                var mapper = config.CreateMapper();
                foreach(DataAccessLayer.Product product in db.Products.ToList())
                {
                    products.Add(mapper.Map<DataAccessLayer.Product, DTO.Product>(product));
                }                
                return products;
            }
        }
        public DTO.Product GetProduct(int id)
        {
            using(var db = new LNBagShopDBEntities())
            {
                DTO.Product product = null;
                DataAccessLayer.Product dbProduct = db.Products.Find(id);
                if (dbProduct != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile(new MappingProfile());
                    });
                    var mapper = config.CreateMapper();
                    product = mapper.Map<DataAccessLayer.Product, DTO.Product>(dbProduct);
                }
                return product;
            }
        }
    }
}
