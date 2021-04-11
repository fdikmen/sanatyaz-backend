using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface IPopupService
    {
        ResultMessage<Popup> Add(Popup data);
        ResultMessage<Popup> Update(Popup data);
        ResultMessage<Popup> Delete(int id);
        ResultMessage<Popup> SoftDelete(int id);
        ResultMessage<ICollection<Popup>> GetAll(Expression<Func<Popup, bool>> filter = null);
        ResultMessage<Popup> Get(Expression<Func<Popup, bool>> filter);
    }
}
