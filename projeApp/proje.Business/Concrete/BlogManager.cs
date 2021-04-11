using Microsoft.Extensions.Primitives;
using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogRepository _blogRepository;
        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ResultMessage<Blog> Add(Blog data)
        {
            data.isActive = true;
            return _blogRepository.Add(data);
        }

        public ResultMessage<Blog> Delete(int id)
        {
            return _blogRepository.Delete(id);
        }

        public ResultMessage<Blog> Get(Expression<Func<Blog, bool>> filter)
        {
            return _blogRepository.Get(filter);
        }

        public ResultMessage<ICollection<Blog>> GetAll(Expression<Func<Blog, bool>> filter = null)
        {
            return _blogRepository.GetAll(filter);
        }

        public List<Blog> GetAllBlog()
        {
            return _blogRepository.GetAllBlog();
        }

        public ResultMessage<Blog> SoftDelete(int id)
        {
            return _blogRepository.SoftDelete(id);
        }

        public ResultMessage<Blog> Update(Blog data)
        {
            return _blogRepository.Update(data);
        }
    }
}
