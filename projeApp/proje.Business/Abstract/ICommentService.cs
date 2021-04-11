using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface ICommentService
    {
        ResultMessage<Comment> Add(Comment data);
        ResultMessage<Comment> Update(Comment data);
        ResultMessage<Comment> Delete(int id);
        ResultMessage<Comment> SoftDelete(int id);
        ResultMessage<ICollection<Comment>> GetAll(Expression<Func<Comment, bool>> filter = null);
        ResultMessage<Comment> Get(Expression<Func<Comment, bool>> filter);
    }
}
