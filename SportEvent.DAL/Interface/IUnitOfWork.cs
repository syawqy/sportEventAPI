using Microsoft.EntityFrameworkCore.Storage;
using SportEvent.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.DAL.Interface
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        DataContext GetContext();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

        UserRepository userRepository { get; }
        OrganizerRepository organizerRepository { get; }
        EventSportRepository eventSportRepository { get; }
    }
}
