using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResultMessage<User> Add(User data)
        {
            return _userRepository.Add(data);
        }

        public ResultMessage<User> Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public ResultMessage<User> Get(Expression<Func<User, bool>> filter)
        {
            return _userRepository.Get(filter);
        }

        public ResultMessage<ICollection<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userRepository.GetAll(filter);
        }

        public ResultMessage<User> SoftDelete(int id)
        {
            return _userRepository.SoftDelete(id);
        }

        //public async Task<User> Login(string eMail,string password)
        //{
        //    return await _userRepository.Login(eMail,password);
        //}

        public ResultMessage<User> Update(User data)
        {
            return _userRepository.Update(data);
        }
    }
}
