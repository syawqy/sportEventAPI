using SportEvent.DAL.Models;
using SportEvent.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.BLL.Interface
{
    public interface IManagerBase<T> where T : ModelBase
    {
        RepositoryBase<T> _rep { get; set; }
        Task<T> CreateAsync(T data, string createdBy);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id, bool activeOnly = true);
    }
}
