using System;
using TraningPhonebook.Core;

namespace TraningPhonebook.Contracts
{
    public interface IContactItemRepository : IBaseRpository<ContactItem>
    {
        ContactItem FindById(int ContactItemId);
    }

}
