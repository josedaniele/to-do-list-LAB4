using to_do_list.Data.Entities;
using to_do_list.Models;

namespace to_do_list.Services.Interfaces
{
    public interface IToDoITemService
    {
        List<ToDoItem> GetToDoItems();
        List<ToDoItem> GetToDoItemsByUserId(int userId);
        ToDoItem GetToDoItemById(int itemId);
        void AddToDoItem(ToDoItemDto toDoItem);

        void UpdateToDoItem(ToDoItemDto toDoItemUpdated, ToDoItem toDoItemToUpdate);

        void DeleteToDoItem(ToDoItem toDoItemToDelete);

        Task<bool> SaveChangesAsync();

    }
}
