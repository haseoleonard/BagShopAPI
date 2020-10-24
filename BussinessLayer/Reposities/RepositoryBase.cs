using AutoMapper;
using BussinessLayer.Mapping;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class RepositoryBase<TS,TD> : IRepositoryBase<TS,TD>
        where TS : class
        where TD : class
    {
        protected readonly LNBagShopDBEntities _context;
        public RepositoryBase(LNBagShopDBEntities context)
        {
            _context = context;
        }
        public TD ConvertToDestinationType(TS entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TS, TD>(entity);
        }
        public TS ConvertToSourceType(TD entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TD, TS>(entity);
        }
        public TD Add(TD entity)
        {
            TS returnEntity = _context.Set<TS>().Add(ConvertToSourceType(entity));
            return ConvertToDestinationType(returnEntity);
        }

        public IEnumerable<TD> Find(Expression<Func<TD, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TD> getAll()
        {
            List<TD> returnList = new List<TD>();
            foreach(TS entity in _context.Set<TS>().ToList())
            {
                returnList.Add(ConvertToDestinationType(entity));
            }
            return returnList;
        }

        public TD getByID(int id)
        {
            return ConvertToDestinationType(_context.Set<TS>().Find(id));
        }

        public void Remove(int id)
        {
            _context.Set<TS>().Remove(ConvertToSourceType(getByID(id)));
        }
    }
}
