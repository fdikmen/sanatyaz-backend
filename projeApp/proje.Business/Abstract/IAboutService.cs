using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IAboutService
    {
        ResultMessage<About> Add(About data);
        ResultMessage<About> Update(About data);
        ResultMessage<About> Delete(int id);
        ResultMessage<About> SoftDelete(int id);
        ResultMessage<ICollection<About>> GetAll(Expression<Func<About, bool>> filter = null);
        ResultMessage<About> Get(Expression<Func<About, bool>> filter);
    }
}
