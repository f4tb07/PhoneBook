using System;
using System.Collections.Generic;
using TraningPhonebook.Core;

namespace TraningPhonebook.Contracts
{
    public interface IContactTypeRepository : IBaseRpository<ContactType>
    {
        ContactType FindById(int Type2Find);
        void DeattachTypes();
    }

}
