using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IConstantService
    {
        ResultMessage<Constant> Add(Constant data);
        ResultMessage<Constant> Update(Constant data);
        ResultMessage<Constant> Delete(int id);
        ResultMessage<Constant> SoftDelete(int id);
        ResultMessage<ICollection<Constant>> GetAll(Expression<Func<Constant, bool>> filter = null);
        ResultMessage<Constant> Get(Expression<Func<Constant, bool>> filter);
    }
}
