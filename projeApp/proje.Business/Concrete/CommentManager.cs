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
    public class CommentManager : ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public ResultMessage<Comment> Add(Comment data)
        {
            
            return _commentRepository.Add(data);
        }

        public ResultMessage<Comment> Delete(int id)
        {
            return _commentRepository.Delete(id);
        }

        public ResultMessage<Comment> Get(Expression<Func<Comment, bool>> filter)
        {
            return _commentRepository.Get(filter);
        }

        public ResultMessage<ICollection<Comment>> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentRepository.GetAll(filter);
        }

        public ResultMessage<Comment> SoftDelete(int id)
        {
            return _commentRepository.SoftDelete(id);
        }

        public ResultMessage<Comment> Update(Comment data)
        {
            return _commentRepository.Update(data);
        }
    }
}
