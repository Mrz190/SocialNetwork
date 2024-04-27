using AutoMapper;
using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace CheckSkillsASP.Controllers
{
    [Route("account")]
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
            try
            {
                if (await _userRepository.UserExist(regDto.NickName)) return BadRequest($"User with nickname {regDto.NickName} already exists");

                var user = _mapper.Map<AppUser>(regDto);
                user.UserName = regDto.Username.ToLower();

                user.IsActive = true;

                var result = await _userManager.CreateAsync(user, regDto.Password);
                if (!result.Succeeded) throw new Exception();

                var roleExists = await _userManager.IsInRoleAsync(user, "Member");
                if (!roleExists)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (!roleResult.Succeeded) throw new Exception();
                }

                return new UserDto
                {
                    UserName = user.UserName,
                    Token = await _tokenService.CreateToken(user),
                    City = user.City,
                    Country = user.Country,
                    IsActive = true
                };
            }
            catch (Exception ex)
            {
                return BadRequest("Error while trying to create new user");
            }
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
        [HttpDelete("delete")]
        public async Task<ActionResult<UserDto>> DeleteUser(string acceptedPassword)
        {
            try
            {
                // Retrieve the JWT token from the request
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                // Decode the JWT token to access the payload
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                // Access the payload data (claims) from the token
                var userId = Int32.Parse(jsonToken.Claims.First(claim => claim.Type == "nameid").Value);
                var nickName = jsonToken.Claims.First(claim => claim.Type == "unique_name").Value;

                nickName = "deactivated_" + nickName;

                var user = await _userRepository.GetUserByIdAsync(userId);

                if (user == null)
                {
                    throw new Exception();
                }

                if (!await _userManager.CheckPasswordAsync(user, acceptedPassword))
                {
                    return BadRequest("Password is not valid");
                }

                user.IsActive = false;
                user.NickName = nickName;

                await _userManager.UpdateAsync(user);

                return Ok($"Account was deactivated");
            }
            catch
            {
                return BadRequest("Something was happend while proccessing your request :(");
            }
        }

        [HttpPut("editNickName")]
        public async Task<IActionResult> EditNickName(string newNickname)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var userId = Int32.Parse(jsonToken.Claims.First(claim => claim.Type == "nameid").Value);

                var user = await _userRepository.GetUserByIdAsync(userId);

                if (user == null)
                {
                    throw new Exception();
                }

                bool isValidNick = await _userRepository.CheckNickName(newNickname);

                if (isValidNick == false) throw new Exception();

                user.NickName = newNickname;

                await _userManager.UpdateAsync(user);

                return Ok("Your nickname was successfully updated.");
            }
            catch
            {
                return BadRequest("Something was happend while proccessing your request :(");
            }
        }
    }
}