using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TraningPhonebook.Contracts;
using TraningPhonebook.Core;
using System.Linq;

namespace TraningPhonebook.Infrastrucher.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PhoneBookRepository PhoneDB;

        public UserRepository(PhoneBookRepository _EntityContex) : base(_EntityContex)
        {
           PhoneDB = _EntityContex;
        }

        public override List<User> Find(Delegate Entity2Find)
        {
            return PhoneDB.UserTable.Where(Entity2Find as Func<User, bool>).ToList();
        }
    }
}
