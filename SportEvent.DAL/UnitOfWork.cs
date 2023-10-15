using Microsoft.EntityFrameworkCore.Storage;
using SportEvent.DAL.Interface;
using SportEvent.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext dbContext;
        public UserRepository userRepository { get; }
        public OrganizerRepository organizerRepository { get; }
        public EventSportRepository eventSportRepository { get; }

        public UnitOfWork(DataContext dataContext)
        {
            dbContext = dataContext;

            userRepository = new UserRepository(dbContext);
            organizerRepository = new OrganizerRepository(dbContext);
            eventSportRepository = new EventSportRepository(dbContext);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public DataContext GetContext()
        {
            return dbContext;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return dbContext.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await dbContext.Database.BeginTransactionAsync();
        }
    }
}
