using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckSkillsASP.Controllers
{
    public class AccountController : BaseController
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

            //user.IsActive = true;

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                City = user.City,
                Country = user.Country,
                IsActive = true
            };
        }




        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                                         .SingleOrDefaultAsync(i => i.NickName == loginDto.NickName);

            if (user == null) return BadRequest("Invalid nickname/password.");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return BadRequest("Invalid password.");

            return new UserDto
            {
                UserName = user.UserName,
                NickName = user.NickName,
                Token = await _tokenService.CreateToken(user),
                City = user.City,
                Country = user.Country
            };
        }

        [HttpDelete("DropAll")]
        public async Task<ActionResult> DeleteAll()
        {
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                await _userManager.DeleteAsync(user);
            }

            return Ok("Users was successfully deactivated!");
        }
    }
}