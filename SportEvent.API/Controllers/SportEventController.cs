using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportEvent.BLL;
using SportEvent.BLL.DTO;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private EventSportManager _eventSportManager { get; set; }
        private IMapper _mapper { get; set; }
        public SportEventController(EventSportManager eventSportManager)
        {
            _eventSportManager = eventSportManager;
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EventSportDTO, EventSport>();
                    cfg.CreateMap<EventSport, EventSportDTO>();
                    cfg.CreateMap<ResultDTO<EventSport>, ResultDTO<EventSportDTO>>();
                });

                _mapper = config.CreateMapper();
            }
        }
        [HttpGet("sport-events")]
        public async Task<ObjectResult> GetAllSportEvent(int page, int perPage)
        {
            try
            {
                var data = await _eventSportManager.GetAllAsync(page, perPage);
                var dto = _mapper.Map<ResultDTO<EventSportDTO>>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("sport-events/{id}")]
        public async Task<ObjectResult> GetSportEvent(int id)
        {
            try
            {
                var data = await _eventSportManager.GetByIdAsync(id);

                var dto = _mapper.Map<EventSportDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost("sport-events")]
        public async Task<ObjectResult> CreateSportEvent(EventSportDTO eventSportDTO)
        {
            try
            {
                var user = "";
                var model = _mapper.Map<EventSport>(eventSportDTO);

                var data = await _eventSportManager.CreateAsync(model, user);

                var dto = _mapper.Map<EventSportDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut("sport-events/{id}")]
        public async Task<ObjectResult> UpdateSportEvent(int id, EventSportDTO eventSportDTO)
        {
            try
            {
                var user = "";
                var model = _mapper.Map<EventSport>(eventSportDTO);
                model.Id = id;
                model.IsActive = true;

                var data = await _eventSportManager.UpdateAsync(model, user);

                var dto = _mapper.Map<EventSportDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpDelete("sport-events/{id}")]
        public async Task<ObjectResult> DeleteSportEvent(int id)
        {
            try
            {
                await _eventSportManager.DeleteAsync(id);

                return new OkObjectResult(true);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
