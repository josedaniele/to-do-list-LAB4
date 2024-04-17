using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using to_do_list.Data.Entities;
using to_do_list.Models;
using to_do_list.Services.Interfaces;

namespace to_do_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
                return Ok(_userService.GetUsers());
        }

        [HttpGet("{email}", Name = nameof(GetUserByEmail))]
        public IActionResult GetUserByEmail(string email)
        {

                var user = _userService.GetUserByEmail(email);
                if (user == null)
                    return NotFound("Usuario no encontrado");
                return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userForCreation)
        {

            if (_userService.GetUserByEmail(userForCreation.email) != null)
            {
                return Conflict("Este Email ya esta en uso");
            }
            if (userForCreation == null)
            {
                return BadRequest();
            }
            _userService.Adduser(userForCreation);

            await _userService.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetUserByEmail), new { email = userForCreation.email }, userForCreation);
        }
        [HttpPut("{email}")]
        public async Task<IActionResult> EditUSer(string email,UserDto userEdited)
        {
            User userToUpdate = _userService.GetUserByEmail(email);
            if (userToUpdate == null)
                return NotFound("Usuario no encontrado");
            if (userEdited == null)
            {
                return BadRequest();
            }
            _userService.EditUser(userEdited, userToUpdate);
            await _userService.SaveChangesAsync();
            return Ok(userEdited);
        }
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
 
                User userToDelete = _userService.GetUserByEmail(email);

                if (userToDelete == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                _userService.DeleteUser(userToDelete);

                await _userService.SaveChangesAsync();

            return NoContent();
        }
    }
}
