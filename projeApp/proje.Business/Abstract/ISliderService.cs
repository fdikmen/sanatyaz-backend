using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Abstract
{
    public interface ISliderService
    {
        ResultMessage<Slider> Add(Slider data);
        ResultMessage<Slider> Update(Slider data);
        ResultMessage<Slider> Delete(int id);
        ResultMessage<Slider> SoftDelete(int id);
        ResultMessage<ICollection<Slider>> GetAll(Expression<Func<Slider, bool>> filter = null);
        ResultMessage<Slider> Get(Expression<Func<Slider, bool>> filter);
    }
}
