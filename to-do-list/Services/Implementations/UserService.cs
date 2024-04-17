using AutoMapper;
using to_do_list.Context;
using to_do_list.Data.Entities;
using to_do_list.Models;
using to_do_list.Services.Interfaces;

namespace to_do_list.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ToDoListContext _context;
        private readonly IMapper _mapper;
        public UserService(ToDoListContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.id_user == id);
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
        public void EditUser(UserDto userUpdated, User userToUpdate)
        {
            User userEdited = _mapper.Map(userUpdated, userToUpdate);
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
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


    }
}
