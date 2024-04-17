using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckSkillsASP.Controllers
{
    [Authorize]
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

        [HttpPatch("{id}")]
        public async Task<ActionResult> ParticalyUpdateUser(int id, JsonPatchDocument<UserForUpdatingDto> updateDto)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(i => i.Id.ToString() == id.ToString());
                if (user == null) throw new Exception("User not found");

                var userToPatch = _mapper.Map<UserForUpdatingDto>(user);
                updateDto.ApplyTo(userToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                    return BadRequest("-------");
                }

                // Применить изменения к пользователю
                _mapper.Map(userToPatch, user);

                // Сохранить изменения в базе данных
                await _userManager.UpdateAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong while processing the request: {ex.Message}");
            }

        }
    }
}
