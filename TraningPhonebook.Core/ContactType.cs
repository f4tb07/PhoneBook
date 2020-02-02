using System;
using System.Collections.Generic;
using System.Text;

namespace TraningPhonebook.Core
{

    public class ContactType : BaseClass
    {
        public string Name { get; set; }
        public byte[] Icon { get; set; }
        public List<ContactItem> ContactItem { get; set; }
        public int ContactItemId { get; set; }

    }
}
