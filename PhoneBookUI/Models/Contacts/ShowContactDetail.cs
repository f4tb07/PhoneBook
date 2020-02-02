using PhoneBookUI.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningPhonebook.Core;

namespace PhoneBookUI.Models
{
    public class ShowContactDetail
    {
        public int id { get; set; }
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Image { get; set; }

        public List<ContactType> Type4Display { get; set; }
        public List<ContactItem> ContactItems { set; get; }
        public string FullName()
        {
            return FirstName + "  " + LastName;
        }
    }
}
