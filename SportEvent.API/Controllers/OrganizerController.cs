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
    public class OrganizerController : ControllerBase
    {
        private OrganizerManager _organizerManager { get; set; }
        private IMapper _mapper { get; set; }
        public OrganizerController(OrganizerManager organizerManager)
        {
            _organizerManager = organizerManager;
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OrganizerDTO, Organizer>();
                    cfg.CreateMap<Organizer, OrganizerDTO>();
                    cfg.CreateMap<ResultDTO<Organizer>, ResultDTO<OrganizerDTO>>();
                });

                _mapper = config.CreateMapper();
            }
        }

        [HttpGet("organizers")]
        public async Task<ObjectResult> GetAllOrganizers(int page, int perPage)
        {
            try
            {
                var data = await _organizerManager.GetAllAsync(page, perPage);
                var dto = _mapper.Map<ResultDTO<OrganizerDTO>>(data);

                return new ObjectResult(dto);
            }catch(Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("organizers/{id}")]
        public async Task<ObjectResult> GetOrganizer(int id)
        {
            try
            {
                var data = await _organizerManager.GetByIdAsync(id);

                var dto = _mapper.Map<OrganizerDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost("organizers")]
        public async Task<ObjectResult> CreateOrganizer(OrganizerDTO organizerDTO)
        {
            try
            {
                var user = "";
                var organizer = _mapper.Map<Organizer>(organizerDTO);

                var data = await _organizerManager.CreateAsync(organizer, user);

                var dto = _mapper.Map<OrganizerDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut("organizers/{id}")]
        public async Task<ObjectResult> UpdateOrganizer(int id, OrganizerDTO organizerDTO)
        {
            try
            {
                var user = "";
                var organizer = _mapper.Map<Organizer>(organizerDTO);
                organizer.Id = id;
                organizer.IsActive = true;

                var data = await _organizerManager.UpdateAsync(organizer, user);

                var dto = _mapper.Map<OrganizerDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpDelete("organizers/{id}")]
        public async Task<ObjectResult> DeleteOrganizer(int id)
        {
            try
            {
                await _organizerManager.DeleteAsync(id);

                return new OkObjectResult(true);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
