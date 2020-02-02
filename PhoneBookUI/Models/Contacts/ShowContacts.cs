using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TraningPhonebook.Core;

namespace PhoneBookUI.Models.Contact
{
    public class ShowContacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Image { get; set; }

        

        

       
    }
}
