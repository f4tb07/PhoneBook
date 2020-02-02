using System.Collections.Generic;

namespace TraningPhonebook.Core
{
    public class Contact:BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Image { get; set; }
        
        public List<ContactItem> ContactItems { get; set; }
        public User RelatedUser { get; set; }
    }
}
