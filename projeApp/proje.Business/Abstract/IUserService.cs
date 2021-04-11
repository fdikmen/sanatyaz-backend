using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IUserService
    {
        ResultMessage<User> Add(User data);
        ResultMessage<User> Update(User data);
        ResultMessage<User> Delete(int id);
        ResultMessage<User> SoftDelete(int id);
        ResultMessage<ICollection<User>> GetAll(Expression<Func<User, bool>> filter = null);
        ResultMessage<User> Get(Expression<Func<User, bool>> filter);
    }
}
