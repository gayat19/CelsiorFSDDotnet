using UnderstandingStructureApp.Interfaces;
using UnderstandingStructureApp.Models;

namespace UnderstandingStructureApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<string, User> _userRepository;

        public LoginService(IRepository<string,User> userRepository)
        {
            _userRepository = userRepository;   
        }
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var mysuer = _userRepository.Get(username);
            if (mysuer == null || !ComparePassword(mysuer.Password, oldPassword)) throw new Exception("Unable to validate user");
            if (!ComparePassword(newPassword, oldPassword))
            {
                mysuer.Password = newPassword;
                return true;
            }
            throw new Exception("Old and new password cannot be the same");
        }

        public bool Login(string username, string password)
        {
            var mysuer = _userRepository.Get(username);
            return ComparePassword(mysuer.Password, password);
        }
        bool ComparePassword(string oldPassword, string newPassword)
        {
            return oldPassword == newPassword;
        }
    }
}
