using Microsoft.AspNetCore.Mvc;
using to_do_list.Data.Entities;
using to_do_list.Models;
using to_do_list.Services.Implementations;
using to_do_list.Services.Interfaces;

namespace to_do_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoITemService _toDoItemService;
        private readonly IUserService _userService;
        public ToDoItemController(IToDoITemService toDoItemService, IUserService userService)
        {
            _toDoItemService = toDoItemService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetToDoItems()
        {
            return Ok(_toDoItemService.GetToDoItems());
        }
        [HttpGet("Item", Name = nameof(GetToDoItemById))]
        public IActionResult GetToDoItemById(int id)
        {

            var toDoItem = _toDoItemService.GetToDoItemById(id);
            if (toDoItem == null)
                return NotFound("Item no encontrado");
            return Ok(toDoItem);
        }
        [HttpGet("{email}", Name = nameof(GetToDoItemsByUserEmail))]
        public IActionResult GetToDoItemsByUserEmail(string email)
        {
            if(_userService.GetUserByEmail(email) == null)
            {
                return NotFound("Usuario no encontrado");
            }
            var ToDoItems = _toDoItemService.GetToDoItemsByUserEmail(email);
            return Ok(ToDoItems);
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoItem(ToDoItemDto toDoItemForCreation)
        {

            if (toDoItemForCreation == null)
            {
                return BadRequest();
            }
            _toDoItemService.AddToDoItem(toDoItemForCreation);

            await _toDoItemService.SaveChangesAsync();

            return Ok(toDoItemForCreation);
        }
        [HttpPut("{id_item}")]
        public async Task<IActionResult> EditToDoItem(int id_item, EditToDoItemDto toDoItemEdited)
        {
            ToDoItem toDoItemToUpdate = _toDoItemService.GetToDoItemById(id_item);
            if (toDoItemToUpdate == null)
                return NotFound("ToDoItem no encontrado");
            if (toDoItemEdited == null)
            {
                return BadRequest();
            }
            _toDoItemService.UpdateToDoItem(toDoItemEdited,toDoItemToUpdate);
            await _toDoItemService.SaveChangesAsync();
            return Ok(toDoItemEdited);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            ToDoItem toDoItemToDelete = _toDoItemService.GetToDoItemById(id);

            if (toDoItemToDelete == null)
            {
                return NotFound("ToDoItem no encontrado");
            }
            _toDoItemService.DeleteToDoItem(toDoItemToDelete);

            await _toDoItemService.SaveChangesAsync();

            return NoContent();
        }
    }
}
