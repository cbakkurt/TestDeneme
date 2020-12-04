using AutoMapper;
using CicekSepeti.API.DTO;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> Get()
        {
            _logger.LogInformation("testlog123");
            var users = await _userService.GetAllUsers();

            var userDTOs = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            
            return Ok(userDTOs);
        }
    }
}