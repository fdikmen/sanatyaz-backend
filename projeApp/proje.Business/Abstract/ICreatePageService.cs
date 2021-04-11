using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface ICreatePageService
    {
        ResultMessage<CreatePage> Add(CreatePage data);
        ResultMessage<CreatePage> Update(CreatePage data);
        ResultMessage<CreatePage> Delete(int id);
        ResultMessage<CreatePage> SoftDelete(int id);
        ResultMessage<ICollection<CreatePage>> GetAll(Expression<Func<CreatePage, bool>> filter = null);
        ResultMessage<CreatePage> Get(Expression<Func<CreatePage, bool>> filter);
    }
}
