using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TraningPhonebook.Core;

namespace PhoneBookUI.Models.Contact
{
    public class UpdateContactModel

    {
       
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "لطفا مقدار نام را بین 2 تا 20 حرف وارد نمایید", MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "لطفا مقدار نام خانوادگی را بین 2 تا 30 حرف وارد نمایید", MinimumLength = 2)]
        public string LastName { get; set; }
        [MaxLength(50, ErrorMessage = "لطفا حداکثر 50 حرف وارد نمایید")]
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] CurrentImage { get; set; }
        public IFormFile Image { get; set; }
        public List<ContactType> Type4Display { get; set; }
        public List<UpdateContacrItemModel> ContactItemsModel { set; get; }
        public TraningPhonebook.Core.Contact CreateContact()
        {
            TraningPhonebook.Core.Contact result = new TraningPhonebook.Core.Contact 
            {
                Id=this.Id,

                FirstName=this.FirstName,
                LastName=this.LastName,
                Image=this.CurrentImage,
                Title=this.Title,
                Note=this.Note,
                ContactItems = CreateContactItemList()
            };
            return result;
            
            
        }
        private List<ContactItem> CreateContactItemList()
        {
            List<ContactItem> result = new List<ContactItem>(ContactItemsModel.Count);
            foreach (var item in ContactItemsModel)
            {
                var newitem = new ContactItem();
                newitem.Id = item.ContactItemId;
                newitem.ItemType = Type4Display.Where(t => t.Id == item.TypeId).First();
                newitem.Scope = item.Scope;
                newitem.Value = item.Value;
                result.Add(newitem);
            }
            return result;
        }
    }
}
