using Microsoft.EntityFrameworkCore;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<EventSport> EventSport { get; set; }
    }
}
