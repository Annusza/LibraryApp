using System;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var user = await _userService.GetById(id);
                return Ok(user);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Can't found user with id = {id}");
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            await _userService.Add(userDto);
            return Created("Created new user", userDto);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            await _userService.Update(userDto);
            return Ok(value: $"Updated user with id = {userDto.Id}");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.Delete(id);
            return Ok(value: $"User with id = {id} deleted");
        }

        [HttpGet("GetUserWithMaxBooksRead")]
        public async Task<IActionResult> GetUserWithMaxBooksRead()
        {
            try
            {
                var user = await _userService.GetUserWithMaxBooksRead();
                return Ok(user);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Error");
            }
        }
    }
}