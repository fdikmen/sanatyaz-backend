using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IFormElementService
    {
        ResultMessage<FormElement> Add(FormElement data);
        ResultMessage<FormElement> Update(FormElement data);
        ResultMessage<FormElement> Delete(int id);
        ResultMessage<FormElement> SoftDelete(int id);
        ResultMessage<ICollection<FormElement>> GetAll(Expression<Func<FormElement, bool>> filter = null);
        ResultMessage<FormElement> Get(Expression<Func<FormElement, bool>> filter);
        List<FormElement> GetAllFormElement();
    }
}
