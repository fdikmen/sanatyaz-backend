using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface ILikeService
    {
        ResultMessage<Like> Add(Like data);
        ResultMessage<Like> Update(Like data);
        ResultMessage<Like> Delete(int id);
        ResultMessage<Like> SoftDelete(int id);
        ResultMessage<ICollection<Like>> GetAll(Expression<Func<Like, bool>> filter = null);
        ResultMessage<Like> Get(Expression<Func<Like, bool>> filter);
    }
}
