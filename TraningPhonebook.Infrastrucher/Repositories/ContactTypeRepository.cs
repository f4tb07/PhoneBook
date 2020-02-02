using System;
using System.Collections.Generic;
using TraningPhonebook.Contracts;
using TraningPhonebook.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace TraningPhonebook.Infrastrucher.Repositories
{
    public class ContactTypeRepository : BaseRepository<ContactType>, IContactTypeRepository
    {
        private readonly PhoneBookRepository PhoneDB;

        public ContactTypeRepository(PhoneBookRepository _EntityContex) : base(_EntityContex)
        {
            PhoneDB = _EntityContex;
        }

        public override List<ContactType> Find(Delegate Entity2Find)
        {
            return PhoneDB.ContactTypeTable.Where(Entity2Find as Func<ContactType, bool>).ToList();
        }
        public ContactType FindById(int Id4Find)
        {
            Func<ContactType, bool> FindDelegate = C => C.Id == Id4Find;

            return Find(FindDelegate).First();
        }
        public void DeattachTypes()
        {
            foreach (var  _type in PhoneDB.ContactTypeTable)
            {
                PhoneDB.Entry(_type).State = EntityState.Detached;
            }
        }
    }
}
