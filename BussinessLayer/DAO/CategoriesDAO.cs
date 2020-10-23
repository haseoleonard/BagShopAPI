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
    public class CategoriesDAO
    {
        public IEnumerable<DTO.Category> GetCategories()
        {
            List<DTO.Category> categories = new List<DTO.Category>();
            using(var db = new LNBagShopDBEntities())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
                var mapper = config.CreateMapper();
                foreach(DataAccessLayer.Category category in db.Categories.ToList())
                {
                    categories.Add(mapper.Map <DataAccessLayer.Category, DTO.Category>(category));
                }
                return categories;
            }
        }

        public DTO.Category GetCategory(int id)
        {
            using(var db = new LNBagShopDBEntities())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
                var mapper = config.CreateMapper();
                return mapper.Map<DataAccessLayer.Category, DTO.Category>(db.Categories.Find(id));
            }
        }
    }
}
