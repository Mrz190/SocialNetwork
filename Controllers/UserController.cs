using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckSkillsASP.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var usersList = await _userRepository.GetUsersAsync();
            return Ok(usersList);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
