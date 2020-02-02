using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TraningPhonebook.Core;

namespace PhoneBookUI.Models.Contact
{
    public class UpdateContacrItemModel
    {
        public int ContactItemId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        [Required(ErrorMessage ="لطفا مقدار را وارد کنید"),StringLength(50,MinimumLength =3,ErrorMessage ="لطفا مقدار را بین 3 تا 50 حرف یا رقم وارد نمایید")]
        public string Value { get; set; }
        public bool Scope { get; set; }
    }
}
