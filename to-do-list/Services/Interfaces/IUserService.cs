using to_do_list.Data.Entities;
using to_do_list.Models;

namespace to_do_list.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
        void Adduser(UserDto user);

        void EditUser(UserDto userUpdated, User userToUpdate);

        void DeleteUser(User toDoItemToDelete);
        Task<bool> SaveChangesAsync();
    }
}
