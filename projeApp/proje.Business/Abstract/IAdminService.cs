using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IAdminService
    {
        ResultMessage<Admin> Add(Admin data);
        ResultMessage<Admin> Update(Admin data);
        ResultMessage<Admin> Delete(int id);
        ResultMessage<Admin> SoftDelete(int id);
        ResultMessage<ICollection<Admin>> GetAll(Expression<Func<Admin, bool>> filter = null);
        ResultMessage<Admin> Get(Expression<Func<Admin, bool>> filter);
    }
}
