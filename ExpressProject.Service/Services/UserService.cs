using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using ExpressProject.Service.Interfaces;
using System.Collections.Generic;

namespace ExpressProject.Service.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Users.GetAll();
        }
    }
}
