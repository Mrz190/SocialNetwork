using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
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

        public AccountController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("reg")]
        public async Task<ActionResult<UserDto>> CreateUser(MemberForCreationDto memberForCreationDto)
        {

            if (await _userRepository.UserExist(memberForCreationDto.UserName)) return BadRequest("User is already exists");

            var user = _mapper.Map<Entity.AppUser>(memberForCreationDto);

            await _userRepository.AddUser(user);
            await _userRepository.SaveAsync();

            var resultPoint = _mapper.Map<DTOs.UserDto>(user);

            return new UserDto
            {
                UserName = user.UserName,
                City = user.City,
                Country = user.Country
            };
            //await _userRepository.AddUser(user);

            //var userList = await _userRepository.GetUsersAsync();

            //await _userRepository.SaveChangesAsync();


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
