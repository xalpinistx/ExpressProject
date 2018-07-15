using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using ExpressProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
