using AutoMapper;
using SportEvent.BLL.DTO;
using SportEvent.DAL.Interface;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.BLL
{
    public class UserManager : ManagerBase<User>
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public UserManager(IUnitOfWork unitOfWork) : base(unitOfWork.userRepository)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<User> Login(LoginDTO loginDTO)
        {
            try
            {
                var data = await _rep.GetSingleAsync(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password);
                return data;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException($"Failed when login ", e);
            }
        }
    }
}
