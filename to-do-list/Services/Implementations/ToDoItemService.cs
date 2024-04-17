using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            return _context.ToDoItems
                .Include(a => a.User)
                .ToList();
        }
        public List<ToDoItem> GetToDoItemsByUserEmail(string email)
        {
            return _context.ToDoItems.Where(tdi => tdi.User.email == email).ToList();
        }

        public ToDoItem GetToDoItemById(int itemId)
        {
            return _context.ToDoItems
                .Include(a => a.User)
                .SingleOrDefault(tdi => tdi.id_todo_item == itemId);
        }

        public void AddToDoItem(ToDoItemDto toDoItem)
        {
            if (toDoItem == null)
            {
                throw new ArgumentNullException(nameof(toDoItem));
            }
            ToDoItem? newToDoItem = _mapper.Map<ToDoItem>(toDoItem);
            _context.ToDoItems.Add(newToDoItem);
        }
        public void UpdateToDoItem(EditToDoItemDto toDoItemUpdated, ToDoItem toDoItemToUpdate)
        {
            ToDoItem toDoItemEdited = _mapper.Map(toDoItemUpdated, toDoItemToUpdate);
            _context.ToDoItems.Update(toDoItemEdited);
        }

        public void DeleteToDoItem(ToDoItem toDoItemToDelete)
        {
            if (toDoItemToDelete == null)
            {
                throw new ArgumentNullException(nameof(toDoItemToDelete));
            }
            _context.Remove(toDoItemToDelete);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
