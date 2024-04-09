using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace CheckSkillsASP.Controllers
{
    [Route("usersController")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var usersList = await _userRepository.GetUsersAsync();
            return Ok(usersList);
        }

        [HttpGet("{nickname}", Name = "nickname")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersByNickName(string nickname)
        {
            var usersList = await _userRepository.GetUserByNickNameAsync(nickname);

            if (usersList == null)
                return NotFound($"No user with the nickname {nickname}");

            return Ok(usersList);
        }

        [HttpGet("name/{name}", Name = "name")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersByName(string name)
        {
            var usersList = await _userRepository.GetUsersByNameAsync(name);

            if (usersList == null)
                return NotFound($"No user with the name {name}");

            return Ok(usersList);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, string acceptedPassword)
        {
            var user = _userRepository.GetUserByIdAsync(id);
            
            if (user == null)
            {
                 return BadRequest($"User with id {id} cannot be found");
            }

            //if(!await _userManager.CheckPasswordAsync(user.Result, acceptedPassword))
            //{
            //    return BadRequest("Password is not valid");
            //}

            var result = await _userManager.DeleteAsync(user.Result);

            return Ok($"Acccount was deactivated");
            }
    }
}
