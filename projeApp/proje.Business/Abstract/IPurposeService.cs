using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IPurposeService
    {
        ResultMessage<Purpose> Add(Purpose data);
        ResultMessage<Purpose> Update(Purpose data);
        ResultMessage<Purpose> Delete(int id);
        ResultMessage<Purpose> SoftDelete(int id);
        ResultMessage<ICollection<Purpose>> GetAll(Expression<Func<Purpose, bool>> filter = null);
        ResultMessage<Purpose> Get(Expression<Func<Purpose, bool>> filter);
    }
}
