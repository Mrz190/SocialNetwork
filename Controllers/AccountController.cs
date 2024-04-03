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
        private readonly ITokenService _tokenService;

        public AccountController(IMapper mapper, IUserRepository userRepository, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        //[HttpPost("reg")]
        //public async Task<ActionResult<UserDto>> CreateUser(RegDto regDto)
        //{

        //    if (await _userRepository.UserExist(regDto.NickName)) return BadRequest($"User with nickname {regDto.NickName} is already exists");

        //    var user = _mapper.Map<AppUser>(regDto);

        //    user.UserName = regDto.Username.ToLower();

        //    var result = await _userManager.CreateAsync(user, regDto.Password);
        //    if (!result.Succeeded) return BadRequest(result.Errors.ToString());


        //    var roleUser = await _userManager.AddToRoleAsync(user, "Member");
        //    if (!roleUser.Succeeded) return BadRequest(roleUser.Errors);

        //    return new UserDto
        //    {
        //        UserName = user.UserName,
        //        Token = await _tokenService.CreateToken(user),
        //        City = user.City,
        //        Country = user.Country
        //    };
        //}



        [HttpPost("reg")]
        public async Task<ActionResult<UserDto>> CreateUser(RegDto regDto)
        {
            if (await _userRepository.UserExist(regDto.NickName))
                return BadRequest($"User with nickname {regDto.NickName} already exists");

            var user = _mapper.Map<AppUser>(regDto);
            user.UserName = regDto.Username.ToLower();

            var result = await _userManager.CreateAsync(user, regDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors.ToString());

            // Проверяем, существует ли роль "Member"
            var roleExists = await _userManager.IsInRoleAsync(user, "Member");
            if (!roleExists)
            {
                // Если роль "Member" не существует, добавляем её
                var roleResult = await _userManager.AddToRoleAsync(user, "Member");
                if (!roleResult.Succeeded)
                    return BadRequest(roleResult.Errors.ToString());
            }

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                City = user.City,
                Country = user.Country
            };
        }




        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                                         .SingleOrDefaultAsync(i => i.UserName == loginDto.UserName);

            if (user == null) return BadRequest("Invalid login/password.");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return BadRequest("Invalid password.");

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                City = user.City,
                Country = user.Country
            };
        }
    }
}
