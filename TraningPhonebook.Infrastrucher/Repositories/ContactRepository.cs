using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraningPhonebook.Contracts;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Repositories
{
    public class ContactRepository : BaseRepository<Contact>,IContactRepository
    {
        private readonly PhoneBookRepository PhoneDB;
        public ContactRepository(PhoneBookRepository _EntityContex) : base(_EntityContex)
        {
            PhoneDB = _EntityContex;
        }

        public override List<Contact> Find(Delegate Entity2Find)
        {

           return PhoneDB.ContactTable.Where(Entity2Find as Func<Contact, bool>).ToList();
        }
        
        public Contact FindById(int id)
        {
            var FindedContact =PhoneDB.ContactTable.Where(C=>C.Id==id).ToList().First();
            FindedContact.ContactItems = GetContactItemsById(id);
            return FindedContact;
            
        }
        public byte[] GetImageById(int id)
        {
            var FindedContact = PhoneDB.ContactTable.Where(C => C.Id == id).ToList().First();
            byte[] findimage = FindedContact.Image;
            PhoneDB.Entry(FindedContact).State = EntityState.Detached;
            return findimage;
            
        }
        private List<ContactItem> GetContactItemsById(int id)
        {
            //List<ContactType> contact_type = PhoneDB.ContactTypeTable.ToList();
            //List<ContactItem> contact_item = PhoneDB.ContactItemTable.ToList();
            //var query = contact_type.Join(contact_item, ct => ct, ci => ci.ItemType, (ct, ci) => new 
            //{
            //    typename = ct.Name,
            //    itemval = ci.Value,
            //    itemscope = ci.Scope,
            //    itemrelatedcontact=ci.RelatedContact

            //});
            //return query.Where(ci => ci.itemrelatedcontact.Id == id).ToList();
            //// return PhoneDB.ContactTable.Include(C => C.ContactItems ).Where(C => C.Id == id).First().ContactItems;
            return PhoneDB.ContactItemTable.Where(ci => ci.RelatedContact.Id == id).Include(ci => ci.ItemType).ToList();

            //return PhoneDB.ContactTable.jo
            // return PhoneDB.ContactTypeTable.Include(CT=>CT.ContactItem).Where(c=>c.ContactItem.co)
        }
    }
}
