using AutoMapper;
using to_do_list.Context;
using to_do_list.Data.Entities;
using to_do_list.Models;
using to_do_list.Services.Interfaces;

namespace to_do_list.Services.Implementations
{
    public class ToDoItemService: IToDoITemService
    {
        private readonly ToDoListContext _context;
        private readonly IMapper _mapper;
        public ToDoItemService(ToDoListContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ToDoItem> GetToDoItems()
        {
            return _context.ToDoItems.ToList();
        }

        public User GetToDoItemById(int itemId)
        {
            return _context.ToDoItems.SingleOrDefault(tdi => tdi.id_todo_item == itemId);
        }

        public void Adduser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            User? userEntity = _mapper.Map<User>(user);
            _context.Add(user);
        }
        public void EditUser(UserDto userUpdated, int id)
        {
            User userToEdit = _context.Users.SingleOrDefault(u => u.id_user == id);
            User userEdited = _mapper.Map(userUpdated, userToEdit);
            _context.Users.Update(userEdited);
        }

        public void DeleteUser(User userToDeleteDto)
        {
            if (userToDeleteDto == null)
            {
                throw new ArgumentNullException(nameof(userToDeleteDto));
            }
            _context.Remove(userToDeleteDto);
        }
    }
}
