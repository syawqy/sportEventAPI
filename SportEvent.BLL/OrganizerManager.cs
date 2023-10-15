using SportEvent.DAL.Interface;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.BLL
{
    public class OrganizerManager : ManagerBase<Organizer>
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public OrganizerManager(IUnitOfWork unitOfWork) : base(unitOfWork.organizerRepository)
        {
            _unitOfWork = unitOfWork;

        }
    }
}
