﻿using Microsoft.EntityFrameworkCore;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.DAL.Repositories
{
    public class EventSportRepository : RepositoryBase<EventSport>
    {
        public EventSportRepository(DbContext dbContext) : base(dbContext) { }
    }
}
