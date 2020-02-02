using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TraningPhonebook.Core;

namespace PhoneBookUI.Models.Contact
{
    public class AddContactModel
    {
        [StringLength(20,ErrorMessage ="لطفا مقدار نام را بین 2 تا 20 حرف وارد نمایید",MinimumLength =2)]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "لطفا مقدار نام خانوادگی را بین 2 تا 30 حرف وارد نمایید", MinimumLength = 2)]
        public string LastName { get; set; }
        [MaxLength(50,ErrorMessage ="لطفا حداکثر 50 حرف وارد نمایید")]
        public string Title { get; set; }
        public string Note { get; set; }
        public IFormFile Image { get; set; }
        public List<ContactType> Type4Display { get; set; }
        public List<AddContactItem> ContactItems { set; get; }
        

    }
}
