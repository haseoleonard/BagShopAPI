using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using BussinessLayer.DTO;

namespace BussinessLayer.Repositories
{
    public class CategoriesRepository:RepositoryBase<DataAccessLayer.Category,DTO.Category>,ICategoriesRepository
    {
        public CategoriesRepository(LNBagShopDBEntities context):base(context)
        {

        }

        public DTO.Category updateCategory(DTO.Category category)
        {
            DataAccessLayer.Category currentCategory = _context.Categories.Find(category.categoryID);
            if(currentCategory!=null)
            {
                currentCategory.categoryName = category.categoryName;
                _context.SaveChanges();
            }
            return ConvertToDestinationType(currentCategory);
        }
    }
}
