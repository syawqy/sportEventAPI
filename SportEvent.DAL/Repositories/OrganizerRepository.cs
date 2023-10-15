using Microsoft.EntityFrameworkCore;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.DAL.Repositories
{
    public class OrganizerRepository : RepositoryBase<Organizer>
    {
        public OrganizerRepository(DbContext dbContext) : base(dbContext) { }
    }
}
