using Microsoft.EntityFrameworkCore;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
