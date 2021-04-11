using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IMenuService
    {
        ResultMessage<Menu> Add(Menu data);
        ResultMessage<Menu> Update(Menu data);
        ResultMessage<Menu> Delete(int id);
        ResultMessage<Menu> SoftDelete(int id);
        ResultMessage<ICollection<Menu>> GetAll(Expression<Func<Menu, bool>> filter = null);
        ResultMessage<Menu> Get(Expression<Func<Menu, bool>> filter);
        List<Menu> GetAllMenu();
    }
}
