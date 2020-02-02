using System;
using System.Collections.Generic;
using System.Text;
using TraningPhonebook.Core;

namespace TraningPhonebook.Contracts
{
    public interface IContactRepository:IBaseRpository<Contact>
    {
        Contact FindById(int id);
        byte[] GetImageById(int id);


    }

}
