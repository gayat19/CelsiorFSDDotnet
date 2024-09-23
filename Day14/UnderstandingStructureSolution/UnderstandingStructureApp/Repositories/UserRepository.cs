using UnderstandingStructureApp.Exceptions;
using UnderstandingStructureApp.Interfaces;
using UnderstandingStructureApp.Models;

namespace UnderstandingStructureApp.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        Dictionary<string, User> _users = new()
        {
            {"ramu", new User{Username="ramu",Password="1234"} },
            {"somu", new User{Username="somu",Password="1234"} },
            {"tom", new User{Username="tom",Password="1234"} }
        };
        public User Add(User item)
        {
            if(!_users.ContainsKey(item.Username))
            {
                _users.Add(item.Username, item);
            }
            throw new DuplicateUsernameException();
        }

        public User Delete(string key)
        {
            var user = Get(key);
            if (user != null)
            {
                _users.Remove(key);
                return user;
            }
           throw new UserNotFoundException();
        }

        public User Get(string key)
        {
            var user = _users[key];
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

        public List<User> GetAll()
        {
           if(_users.Count == 0)
            {
                throw new NoUsersFoundException();
            }
            return _users.Values.ToList();
        }

        public User Update(User Item)
        {
            var user = Get(Item.Username);
            if (user != null)
            {
                _users[Item.Username] = Item;
                return user;
            }
           throw new UserNotFoundException();
        }
    }
}
