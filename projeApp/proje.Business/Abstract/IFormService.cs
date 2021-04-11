using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IFormService
    {
        ResultMessage<Form> Add(Form data);
        ResultMessage<Form> Update(Form data);
        ResultMessage<Form> Delete(int id);
        ResultMessage<Form> SoftDelete(int id);
        ResultMessage<ICollection<Form>> GetAll(Expression<Func<Form, bool>> filter = null);
        ResultMessage<Form> Get(Expression<Func<Form, bool>> filter);
        List<Form> GetAllForm();
    }
}
