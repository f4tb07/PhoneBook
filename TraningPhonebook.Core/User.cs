using System.Collections.Generic;

namespace TraningPhonebook.Core
{
    public class User : BaseClass
    {
        public int ProfileContact { get; set; }
        public string PersonelId { get; set; }
        public string Password { get; set; }
        public List<Contact> ContactList { get; set; }
        //public List<ContactType> TypeList { get; set; }
    }
}
