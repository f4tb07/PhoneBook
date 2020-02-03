using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraningPhonebook.Contracts;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Repositories
{
    public class ContactItemsRepository : BaseRepository<ContactItem>, IContactItemRepository
    {
        private readonly PhoneBookRepository PhoneDB;

        public ContactItemsRepository(PhoneBookRepository _EntityContex) : base(_EntityContex)
        {
            PhoneDB = _EntityContex;
        }

        public override List<ContactItem> Find(Delegate Entity2Find)
        {
            return PhoneDB.ContactItemTable.Where(Entity2Find as Func<ContactItem, bool>).ToList();
        }

        public ContactItem FindById(int ContactItemId)
        {
            return PhoneDB.ContactItemTable.Where(ci => ci.Id == ContactItemId).Include(ci=>ci.RelatedContact).First();
        }
    }
}
