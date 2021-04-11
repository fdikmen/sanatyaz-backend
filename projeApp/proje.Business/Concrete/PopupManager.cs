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
    public class PopupManager : IPopupService
    {
        private IPopupRepository _popupRepository;

        public PopupManager(IPopupRepository popupRepository)
        {
            _popupRepository = popupRepository;
        }

        public ResultMessage<Popup> Add(Popup data)
        {
            data.isActive = true;
            return _popupRepository.Add(data);
        }

        public ResultMessage<Popup> Delete(int id)
        {
            return _popupRepository.Delete(id);
        }

        public ResultMessage<Popup> Get(Expression<Func<Popup, bool>> filter)
        {
            return _popupRepository.Get(filter);
        }

        public ResultMessage<ICollection<Popup>> GetAll(Expression<Func<Popup, bool>> filter = null)
        {
            return _popupRepository.GetAll(filter);
        }

        public ResultMessage<Popup> SoftDelete(int id)
        {
            return _popupRepository.SoftDelete(id);
        }

        public ResultMessage<Popup> Update(Popup data)
        {
            return _popupRepository.Update(data);
        }
    }
}
