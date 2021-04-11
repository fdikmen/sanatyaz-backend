using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Concrete
{
    public class LikeManager : ILikeService
    {
        private ILikeRepository likeRepository;
        public LikeManager(ILikeRepository _likeRepository)
        {
            likeRepository = _likeRepository;
        }
        public ResultMessage<Like> Add(Like data)
        {
            return likeRepository.Add(data);
        }

        public ResultMessage<Like> Delete(int id)
        {
            return likeRepository.Delete(id);
        }

        public ResultMessage<Like> Get(Expression<Func<Like, bool>> filter)
        {
            return likeRepository.Get(filter);
        }

        public ResultMessage<ICollection<Like>> GetAll(Expression<Func<Like, bool>> filter = null)
        {
            return likeRepository.GetAll(filter);
        }

        public ResultMessage<Like> SoftDelete(int id)
        {
            return likeRepository.SoftDelete(id);
        }

        public ResultMessage<Like> Update(Like data)
        {
            return likeRepository.Update(data);
        }
    }
}
