using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TraningPhonebook.Core;

namespace TraningPhonebook.Contracts
{
     public interface IBaseRpository<Tentity> where Tentity:BaseClass,new() //where TEntity2Find:Delegate
    {
        void Add(Tentity NewEntity);
        void Delete(Tentity DeletedEntity);
        void Update(Tentity DeletedEntity);
        List<Tentity> Find(Delegate  Entity2Find);
        IQueryable<Tentity> GetAll();
    }
}
