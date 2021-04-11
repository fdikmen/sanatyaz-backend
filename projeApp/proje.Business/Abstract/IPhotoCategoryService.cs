using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IPhotoCategoryService
    {
        ResultMessage<PhotoCategory> Add(PhotoCategory data);
        ResultMessage<PhotoCategory> Update(PhotoCategory data);
        ResultMessage<PhotoCategory> Delete(int id);
        ResultMessage<PhotoCategory> SoftDelete(int id);
        ResultMessage<ICollection<PhotoCategory>> GetAll(Expression<Func<PhotoCategory, bool>> filter = null);
        ResultMessage<PhotoCategory> Get(Expression<Func<PhotoCategory, bool>> filter);
    }
}
