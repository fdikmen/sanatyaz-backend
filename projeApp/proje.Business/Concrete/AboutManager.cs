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
    public class AboutManager : IAboutService
    {
        private IAboutRepository _aboutRepository;
        public AboutManager(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public ResultMessage<About> Add(About data)
        {
            data.isActive = true;
            return _aboutRepository.Add(data);
        }

        public ResultMessage<About> Delete(int id)
        {
            return _aboutRepository.Delete(id);
        }

        public ResultMessage<About> Get(Expression<Func<About, bool>> filter)
        {
            return _aboutRepository.Get(filter);
        }

        public ResultMessage<ICollection<About>> GetAll(Expression<Func<About, bool>> filter = null)
        {
            return _aboutRepository.GetAll(filter);
        }

        public ResultMessage<About> SoftDelete(int id)
        {
            return _aboutRepository.SoftDelete(id);
        }

        public ResultMessage<About> Update(About data)
        {
            return _aboutRepository.Update(data);
        }
    }
}
