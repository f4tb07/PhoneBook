namespace TraningPhonebook.Core
{
    public class ContactItem:BaseClass
    {
        public ContactType ItemType { get; set; }
        public string Value { get; set; }
        public bool Scope { get; set; }
        public Contact RelatedContact { get; set; }
    }
}
