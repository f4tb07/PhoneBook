using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhoneBookUI.Models;
using PhoneBookUI.Models.Contact;
using TraningPhonebook.Contracts;
using TraningPhonebook.Core;
//this is for github test push
namespace PhoneBookUI.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactTypeRepository Types;
        private readonly IContactRepository ContactsRep;
        private readonly IContactItemRepository ContactItemsRep;
        private ShowContactDetail SelectedContactModel;
        private int SelectedContactId;

        public ContactsController(IContactTypeRepository _ContactType,IContactRepository _ContactsRep,IContactItemRepository _ContactItemRep )
        {
            Types = _ContactType;
            ContactsRep = _ContactsRep;
            ContactItemsRep = _ContactItemRep;
        }

        public IActionResult Add()
        {
            AddContactModel model = new AddContactModel();
            model.Type4Display = Types.GetAll().ToList();
            model.ContactItems = new List<AddContactItem>();
            model.ContactItems.Add(new AddContactItem { Scope=true});
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddContactModel InputContact)
        {
            
            if(ModelState.IsValid && CheckFullNameWithTitleIsEmpty(InputContact))
            {
                Contact Contact4Add = new Contact { FirstName = InputContact.FirstName,
                    LastName = InputContact.LastName,
                    Title = InputContact.Title,
                    Note = InputContact.Note,
                    ContactItems = new List<ContactItem>(InputContact.ContactItems.Select(ci => new ContactItem 
                    { 
                        Value = ci.Value,
                        Scope = ci.Scope,
                        ItemType= Types.FindById(ci.TypeId)
                    })) 
                };
                if (InputContact.Image!=null && InputContact.Image.Length > 0)
                {
                    using (var MemStream = new MemoryStream())
                    {
                        InputContact.Image.CopyTo(MemStream);
                        Contact4Add.Image = MemStream.ToArray();
                    }
                    
                }
                ContactsRep.Add(Contact4Add);
                return RedirectToAction();
            }
            AddContactModel model4disply = new AddContactModel();
            model4disply.Type4Display = Types.GetAll().ToList();
            model4disply.ContactItems = new List<AddContactItem>();
            model4disply.ContactItems.Add(new AddContactItem { Scope = true });
            return View(model4disply);
        }

        public IActionResult ShowPrivatePhoneBook()
        {
            var AllContacts = ContactsRep.GetAll().ToList();
            var ShowContactList = new List<ShowContacts>(AllContacts.Count);
            foreach (var item in AllContacts)
            {

                ShowContactList.Add(new ShowContacts
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Id = item.Id,
                    Image = item.Image,
                    Title = item.Title


                }) ;
            }
            return View(ShowContactList);
        }
        public FileStreamResult  ShowContactImage(byte[] inputStream)
        {
            using(Stream Byte2MemStream = new MemoryStream(inputStream))
            {
                FileStreamResult Mem2FileStream = new FileStreamResult(Byte2MemStream, "jpg");
                return Mem2FileStream;
            }
        }
        public IActionResult ShowDetail(int id)
        {
           
            SelectedContactModel = new ShowContactDetail();
            var FindedContact = ContactsRep.FindById(id);
            SelectedContactModel.id = id;
            SelectedContactModel.ContactItems = FindedContact.ContactItems;
            SelectedContactModel.FirstName = FindedContact.FirstName;
            SelectedContactModel.LastName = FindedContact.LastName;
            SelectedContactModel.Note = FindedContact.Note;
            SelectedContactModel.Title = FindedContact.Title;
            SelectedContactModel.Image = FindedContact.Image;
            SelectedContactModel.Type4Display = Types.GetAll().ToList();
            return View(SelectedContactModel);
        }

        public IActionResult Update(int id)
        {
            var FindedContact = ContactsRep.FindById(id);
            UpdateContactModel UpdateModel = new UpdateContactModel();
            
                UpdateModel.Id = id;
                UpdateModel.FirstName = FindedContact.FirstName;
                UpdateModel.LastName = FindedContact.LastName;
                UpdateModel.CurrentImage = FindedContact.Image;
                UpdateModel.Note = FindedContact.Note;
                //UpdateModel.ContactItems = FindedContact.ContactItems;
                UpdateModel.Title = FindedContact.Title;
                
                UpdateModel.Type4Display = Types.GetAll().ToList();
                UpdateModel.ContactItemsModel = new List<UpdateContacrItemModel>();
            foreach (var item in FindedContact.ContactItems)
            {
                
                UpdateModel.ContactItemsModel.Add(new UpdateContacrItemModel
                {
                    ContactItemId=item.Id,
                    TypeId = item.ItemType.Id,
                    TypeName=item.ItemType.Name,
                    Value=item.Value,
                    Scope=item.Scope
                });
            } 
            return View(UpdateModel);
        }
        [HttpPost]
        public IActionResult Update(UpdateContactModel InputContact4Update)
        {

            if (ModelState.IsValid && CheckFullNameWithTitleIsEmpty(InputContact4Update))
            {

                Contact Contact4Update = InputContact4Update.CreateContact();
               // if (ContactsRep.GetImageById(Contact4Update.Id) != Contact4Update.Image)
               // {
                    if (InputContact4Update.Image != null && InputContact4Update.Image.Length > 0)
                    {
                        using (var MemStream = new MemoryStream())
                        {
                            InputContact4Update.Image.CopyTo(MemStream);
                            Contact4Update.Image = MemStream.ToArray();
                        }

                    }
                    else
                    {
                        Contact4Update.Image = ContactsRep.GetImageById(Contact4Update.Id);
                    }
                // }
                //Types.DeattachTypes();
                ContactsRep.Update(Contact4Update);
                return RedirectToAction();
            }
            AddContactModel model4disply = new AddContactModel();
            model4disply.Type4Display = Types.GetAll().ToList();
            model4disply.ContactItems = new List<AddContactItem>();
            model4disply.ContactItems.Add(new AddContactItem { Scope = true });
            return View(model4disply);
        }

        public IActionResult ReadyForDelete(int id)
        {
            SelectedContactModel = new ShowContactDetail();
            var FindedContact = ContactsRep.FindById(id);
            SelectedContactModel.id = id;
            SelectedContactModel.ContactItems = FindedContact.ContactItems;
            SelectedContactModel.FirstName = FindedContact.FirstName;
            SelectedContactModel.LastName = FindedContact.LastName;
            SelectedContactModel.Note = FindedContact.Note;
            SelectedContactModel.Title = FindedContact.Title;
            SelectedContactModel.Image = FindedContact.Image;
            SelectedContactModel.Type4Display = Types.GetAll().ToList();
            return View("Delete",SelectedContactModel);
        }
        public IActionResult Delete(int id)
        {
            var FindedContact = ContactsRep.FindById(id);
            ContactsRep.Delete(FindedContact);
            // return View("ShowPrivatePhoneBook");
            return RedirectToAction("ShowPrivatePhoneBook");
        }
        public IActionResult DeleteContactItem(int id)
        {
            var FindedContactItem = ContactItemsRep.FindById(id);
            int RelatedContactId = FindedContactItem.RelatedContact.Id;
            ContactItemsRep.Delete(FindedContactItem);
            return RedirectToAction("Update",new { id = RelatedContactId });
        }

        private bool CheckFullNameWithTitleIsEmpty(AddContactModel Contact4Check)
        {
            return !(string.IsNullOrEmpty(Contact4Check.FirstName) &&
                   string.IsNullOrEmpty(Contact4Check.LastName) &&
                   string.IsNullOrEmpty(Contact4Check.Title));
        }
        private bool CheckFullNameWithTitleIsEmpty(UpdateContactModel Contact4Check)
        {
            return !(string.IsNullOrEmpty(Contact4Check.FirstName) &&
                   string.IsNullOrEmpty(Contact4Check.LastName) &&
                   string.IsNullOrEmpty(Contact4Check.Title));
        }

    }
}