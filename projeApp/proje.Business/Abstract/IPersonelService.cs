using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IPersonelService
    {
        ResultMessage<Personel> Add(Personel data);
        ResultMessage<Personel> Update(Personel data);
        ResultMessage<Personel> Delete(int id);
        ResultMessage<Personel> SoftDelete(int id);
        ResultMessage<ICollection<Personel>> GetAll(Expression<Func<Personel, bool>> filter = null);
        ResultMessage<Personel> Get(Expression<Func<Personel, bool>> filter);
    }
}
