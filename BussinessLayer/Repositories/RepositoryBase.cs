using AutoMapper;
using BussinessLayer.Mapping;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;

namespace BussinessLayer.Repositories
{
    public class RepositoryBase<TS,TD> : IRepositoryBase<TS,TD>
        where TS : class
        where TD : class
    {
        protected readonly LNBagShopDBEntities _context;
        protected IMapper Mapper;
        public RepositoryBase(LNBagShopDBEntities context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            Mapper = config.CreateMapper();
        }
        public TD ConvertToDestinationType(TS entity)
        {
            return Mapper.Map<TS, TD>(entity);
        }
        public TS ConvertToSourceType(TD entity)
        {
            return Mapper.Map<TD, TS>(entity);
        }
        public void Add(ref TD entity)
        {
            TS SourceEntity = ConvertToSourceType(entity);
            _context.Set<TS>().Add(SourceEntity);
            _context.SaveChanges();
            entity = ConvertToDestinationType(SourceEntity);
        }

        public IEnumerable<TD> Find(Expression<Func<TS, bool>> expression)
        {
            var totalResult = _context.Set<TS>().Where(expression);
            List<TD> returnList = new List<TD>();
            foreach(TS ts in totalResult)
            {
                returnList.Add(ConvertToDestinationType(ts));
            }
            return returnList;
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
            _context.Set<TS>().Remove(_context.Set<TS>().Find(id));
        }
    }
}
