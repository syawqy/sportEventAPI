using SportEvent.DAL.Interface;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.BLL
{
    public class EventSportManager : ManagerBase<EventSport>
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public EventSportManager(IUnitOfWork unitOfWork) : base(unitOfWork.eventSportRepository)
        {
            _unitOfWork = unitOfWork;

        }
    }
}
