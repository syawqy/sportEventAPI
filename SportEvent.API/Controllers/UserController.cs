using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportEvent.BLL;
using SportEvent.BLL.DTO;
using SportEvent.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager _userManager { get; set; }
        private IMapper _mapper { get; set; }
        private IConfiguration _config;
        public UserController(UserManager userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>();
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<CreateUserDTO, User>();
                    cfg.CreateMap<User, CreateUserDTO>();
                    cfg.CreateMap<ResultDTO<User>, ResultDTO<UserDTO>>();
                });

                _mapper = config.CreateMapper();
            }
        }

        [HttpGet("users/{id}")]
        public async Task<ObjectResult> GetUser(int id)
        {
            try
            {
                var data = await _userManager.GetByIdAsync(id);

                var dto = _mapper.Map<UserDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost("users")]
        public async Task<ObjectResult> CreateUser(CreateUserDTO userDTO)
        {
            try
            {
                var user = "";

                if(userDTO.Password != userDTO.RepeatPassword)
                {
                    throw new Exception("Password doesn't match");
                }

                var model = _mapper.Map<User>(userDTO);

                var data = await _userManager.CreateAsync(model, user);

                var dto = _mapper.Map<CreateUserDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut("users/{id}")]
        public async Task<ObjectResult> UpdateUser(int id, UserDTO userDto)
        {
            try
            {
                var user = "";
                var model = _mapper.Map<User>(userDto);
                model.Id = id;
                model.IsActive = true;

                var data = await _userManager.UpdateAsync(model, user);

                var dto = _mapper.Map<UserDTO>(data);

                return new ObjectResult(dto);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<ObjectResult> DeleteUser(int id)
        {
            try
            {
                await _userManager.DeleteAsync(id);

                return new OkObjectResult(true);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost("users/login")]
        public async Task<ObjectResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var data = _userManager.Login(loginDTO);

                if(data == null)
                {
                    return new BadRequestObjectResult(new
                    {
                        Message = "Username / Password doesn't match"
                    });
                }

                var token = GenerateJSONWebToken();

                return new OkObjectResult(true);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(e.Message);
            }
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
