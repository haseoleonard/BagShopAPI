using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using BussinessLayer.Repositories;

namespace BussinessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LNBagShopDBEntities _context;
        private IProductRepository _products;
        private ICategoriesRepository _categories;
        private IOrdersRepository _orders;
        private IOrderDetailsRepository _orderDetails;
        public UnitOfWork(LNBagShopDBEntities context)
        {
            _context = context;
        }
        
        public IProductRepository Products
        {
            get
            {
                if (this._products == null)
                {
                    this._products = new ProductsRepository(_context);
                }
                return this._products;
            }
        }

        public ICategoriesRepository Categories
        {
            get
            {
                if (this._categories == null)
                {
                    this._categories = new CategoriesRepository(_context);
                }
                return this._categories;
            }
        }

        public IOrdersRepository Orders
        {
            get
            {
                if (this._orders == null)
                {
                    this._orders = new OrdersRepository(_context);
                }
                return this._orders;
            }
        }
        public IOrderDetailsRepository OrderDetails
        {
            get
            {
                if (this._orderDetails == null)
                {
                    this._orderDetails = new OrderDetailsRepository(_context);
                }
                return this._orderDetails;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
