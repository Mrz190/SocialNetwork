using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IConfiguration _config;


        public AccountController(IMapper mapper, IUserRepository userRepository, UserManager<AppUser> userManager, ITokenService tokenService, IConfiguration config)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
            _tokenService = tokenService;
            _config = config;
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

            var roleExists = await _userManager.IsInRoleAsync(user, "Member");
            if (!roleExists)
            {
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

        [HttpDelete("DropThemAll")]
        public async Task<ActionResult> DeleteAll()
        {
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                await _userManager.DeleteAsync(user);
            }

            return Ok("Users was successfully deactivated!");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id, string acceptedPassword)
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

            return Ok($"Account was deactivated");
        }


        [HttpGet("checking")]
        public async Task<IActionResult> CheckingJWT(string JWT_key)
        {
            var _validate = new ValidateToken();

            bool checkJWT = _validate.ValidateToken_(JWT_key);
            if (checkJWT == true) return Ok("Yeap");

            return BadRequest("Nope");
        }
    }
}