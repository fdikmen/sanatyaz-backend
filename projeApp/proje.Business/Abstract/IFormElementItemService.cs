using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IFormElementItemService
    {
        ResultMessage<FormElementItem> Add(FormElementItem data);
        ResultMessage<FormElementItem> Update(FormElementItem data);
        ResultMessage<FormElementItem> Delete(int id);
        ResultMessage<FormElementItem> SoftDelete(int id);
        ResultMessage<ICollection<FormElementItem>> GetAll(Expression<Func<FormElementItem, bool>> filter = null);
        ResultMessage<FormElementItem> Get(Expression<Func<FormElementItem, bool>> filter);
    }
}
