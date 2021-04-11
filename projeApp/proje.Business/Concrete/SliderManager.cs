using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.DataAccess.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private ISliderRepository _sliderRepository;

        public SliderManager(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public ResultMessage<Slider> Add(Slider data)
        {
            data.isActive = true;
            return _sliderRepository.Add(data);
        }

        public ResultMessage<Slider> Delete(int id)
        {
            return _sliderRepository.Delete(id);
        }

        public ResultMessage<Slider> Get(Expression<Func<Slider, bool>> filter)
        {
            return _sliderRepository.Get(filter);
        }

        public ResultMessage<ICollection<Slider>> GetAll(Expression<Func<Slider, bool>> filter = null)
        {
            return _sliderRepository.GetAll(filter);
        }

        public ResultMessage<Slider> SoftDelete(int id)
        {
            return _sliderRepository.SoftDelete(id);
        }

        public ResultMessage<Slider> Update(Slider data)
        {
            return _sliderRepository.Update(data);
        }
    }
}
