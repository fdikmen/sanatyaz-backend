using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IBlogService
    {
        ResultMessage<Blog> Add(Blog data);
        ResultMessage<Blog> Update(Blog data);
        ResultMessage<Blog> Delete(int id);
        ResultMessage<Blog> SoftDelete(int id);
        ResultMessage<ICollection<Blog>> GetAll(Expression<Func<Blog, bool>> filter = null);
        ResultMessage<Blog> Get(Expression<Func<Blog, bool>> filter);
        List<Blog> GetAllBlog();
    }
}
