using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckSkillsASP.Controllers
{
    [Route("")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IMapper mapper, IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpPost("reg")]
        public async Task<ActionResult<User>> CreateUser(MemberForCreationDto memberForCreationDto)
        {

            if (await _userRepository.UserExist(memberForCreationDto.UserName)) return BadRequest("User is already exists");

            var user = _mapper.Map<Entity.AppUser>(memberForCreationDto);

            //user.UserName = memberForCreationDto.UserName.ToLower();

            //await _userRepository.AddUser(user);

            //var userList = await _userRepository.GetUsersAsync();

            //await _userRepository.SaveChangesAsync();

            return Ok();

            //var resultPoint = _mapper.Map<DTOs.MemberDto>(user);

            //return CreatedAtRoute("GetPointOfInterest",
            //    new User
            //    {
            //        UserName = user.UserName,
            //        City = user.City,
            //        Country = user.Country
            //    },
            //    resultPoint);
        }
    }
}
