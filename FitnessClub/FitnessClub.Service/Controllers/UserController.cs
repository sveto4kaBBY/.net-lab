using System;
using AutoMapper;
using FitnessClub.FitnessClub.BL.Users.Entity;
using FitnessClub.FitnessClub.BL.Users.Manager;
using FitnessClub.FitnessClub.BL.Users.Provider;
using FitnessClub.FitnessClub.Service.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FitnessClub.FitnessClub.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _usersManager;
        private readonly IUserProvider _usersProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(IUserManager usersManager, IUserProvider usersProvider,
            IMapper mapper, ILogger logger)
        {
            _usersManager = usersManager;
            _usersProvider = usersProvider;
            _mapper = mapper;
            _logger = logger;
        }

        
        [HttpPost]
        public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
        {
            try
            {
                var createUserModel = _mapper.Map<CreateUser>(request);
                var userModel = _usersManager.CreateUser(createUserModel);
                return Ok(userModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during user registration.");
                return BadRequest(ex.Message);
            }
        }

       
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _usersProvider.GetUsers(new FilterUser());
                return Ok(new UsersListResponse
                {
                    Users = users.Select(u => _mapper.Map<UserModel>(u)).ToList()
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while retrieving users.");
                return StatusCode(500, "Internal server error.");
            }
        }

       
        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredUsers([FromBody] FilterUser filter)
        {
            try
            {
                var userFilterModel = _mapper.Map<FilterUser>(filter);
                var users = _usersProvider.GetUsers(userFilterModel);
                return Ok(new UsersListResponse
                {
                    Users = users.Select(u => _mapper.Map<UserModel>(u)).ToList()
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while filtering users.");
                return StatusCode(500, "Internal server error.");
            }
        }

       
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserInfo(int id)
        {
            try
            {
                var user = _usersProvider.GetUserInfo(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<UserModel>(user));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while retrieving user info.");
                return StatusCode(500, "Internal server error.");
            }
        }

        
        [HttpPut]
        public IActionResult UpdateUserInfo([FromBody] UserModel request)
        {
            try
            {
                var userModel = _usersManager.UpdateUser(request);
                return Ok(userModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while updating user info.");
                return BadRequest(ex.Message);
            }
        }

       
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _usersManager.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while deleting user.");
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginUser request)
        {
            
            try
            {
               
                var result = _usersManager.Login(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during login.");
                return Unauthorized();
            }
        }

        
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout([FromBody] LogoutUser request)
        {
            try
            {
                if (request.Id == 0) 
                {
                    throw new ArgumentException("Invalid user ID.");
                }
                
                _usersManager.Logout(request.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during logout.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
