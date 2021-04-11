
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
    public class PromotionManager : IPromotionService
    {
        private IPromotionRepository _promotionRepository;

        public PromotionManager(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public ResultMessage<Promotion> Add(Promotion data)
        {
            data.isActive = true;
            return _promotionRepository.Add(data);
        }

        public ResultMessage<Promotion> Delete(int id)
        {
            return _promotionRepository.Delete(id);
        }

        public ResultMessage<Promotion> Get(Expression<Func<Promotion, bool>> filter)
        {
            return _promotionRepository.Get(filter);
        }

        public ResultMessage<ICollection<Promotion>> GetAll(Expression<Func<Promotion, bool>> filter = null)
        {
            return _promotionRepository.GetAll(filter);
        }

        public ResultMessage<Promotion> SoftDelete(int id)
        {
            return _promotionRepository.SoftDelete(id);
        }

        public ResultMessage<Promotion> Update(Promotion data)
        {
            return _promotionRepository.Update(data);
        }
    }
}
