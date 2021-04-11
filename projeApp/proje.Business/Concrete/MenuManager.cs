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
    public class MenuManager : IMenuService
    {
        private IMenuRepository _menuRepository;

        public MenuManager(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public ResultMessage<Menu> Add(Menu data)
        {
            data.isActive = true;
            return _menuRepository.Add(data);
        }

        public ResultMessage<Menu> Delete(int id)
        {
            return _menuRepository.Delete(id);
        }

        public ResultMessage<Menu> Get(Expression<Func<Menu, bool>> filter)
        {
            return _menuRepository.Get(filter);
        }

        public ResultMessage<ICollection<Menu>> GetAll(Expression<Func<Menu, bool>> filter = null)
        {
            return _menuRepository.GetAll(filter);
        }

        public List<Menu> GetAllMenu()
        {
            return _menuRepository.GetAllMenu();
        }

        public ResultMessage<Menu> SoftDelete(int id)
        {
            return _menuRepository.SoftDelete(id);
        }

        public ResultMessage<Menu> Update(Menu data)
        {
            return _menuRepository.Update(data);
        }
    }
}
