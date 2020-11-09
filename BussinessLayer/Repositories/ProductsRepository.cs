﻿using DataAccessLayer;
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
        public override void Add(ref DTO.Product product)
        {
            DataAccessLayer.Product SourceEntity = Mapper.Map<DTO.Product,DataAccessLayer.Product>( product);
            _context.Products.Add(SourceEntity);
            _context.SaveChanges();
            product = Mapper.Map<DataAccessLayer.Product, DTO.Product>(SourceEntity);
        }
        public DTO.Product UpdateProduct(DTO.Product product)
        {
            DataAccessLayer.Product currentProduct = _context.Products.Find(product.productID);
            if (currentProduct != null)
            {
                currentProduct.productName = product.productName;
                currentProduct.description = product.description;
                if (product.image != null) currentProduct.image = product.image;
                currentProduct.price = product.price;
                currentProduct.quantity = product.quantity;
                currentProduct.categoryID = product.categoryID;
                currentProduct.Category = _context.Categories.Find(product.categoryID);
                currentProduct.statusID = product.status;
            }
            return Mapper.Map<DataAccessLayer.Product,DTO.Product>(currentProduct);
        }
    }
}
