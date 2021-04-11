using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IPromotionService
    {
        ResultMessage<Promotion> Add(Promotion data);
        ResultMessage<Promotion> Update(Promotion data);
        ResultMessage<Promotion> Delete(int id);
        ResultMessage<Promotion> SoftDelete(int id);
        ResultMessage<ICollection<Promotion>> GetAll(Expression<Func<Promotion, bool>> filter = null);
        ResultMessage<Promotion> Get(Expression<Func<Promotion, bool>> filter);
    }
}
