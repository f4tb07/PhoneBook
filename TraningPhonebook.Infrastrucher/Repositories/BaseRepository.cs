using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraningPhonebook.Contracts;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Repositories
{
    public abstract class BaseRepository<Tentity> : IBaseRpository<Tentity> where Tentity:BaseClass , new()
    {
        private readonly DbContext EntityContex;

        public BaseRepository(DbContext _EntityContex)
        {
            EntityContex = _EntityContex;
        }

        public void Add(Tentity NewEntity)
        {
            EntityContex.Add(NewEntity);
            EntityContex.SaveChanges();
        }
        public void Update(Tentity UpdatedEntity)
        {
            
            EntityContex.Update(UpdatedEntity);
            EntityContex.SaveChanges();
        }


        public void Delete(Tentity DeletedEntity)
        {
            EntityContex.Remove(DeletedEntity);
            EntityContex.SaveChanges();
        }

        public abstract List<Tentity> Find(Delegate Entity2Find);
        

        public IQueryable<Tentity> GetAll()
        {
            return EntityContex.Set<Tentity>().AsQueryable();
           
        }
    }
}
