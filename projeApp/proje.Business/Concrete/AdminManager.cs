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
    public class AdminManager : IAdminService
    {
        private IAdminRepository _adminRepository;
        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public ResultMessage<Admin> Add(Admin data)
        {
            return _adminRepository.Add(data);
        }

        public ResultMessage<Admin> Delete(int id)
        {
            return _adminRepository.Delete(id);
        }

        public ResultMessage<Admin> Get(Expression<Func<Admin, bool>> filter)
        {
            return _adminRepository.Get(filter);
        }

        public ResultMessage<ICollection<Admin>> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminRepository.GetAll(filter);
        }

        public ResultMessage<Admin> SoftDelete(int id)
        {
            return _adminRepository.SoftDelete(id);
        }

        public ResultMessage<Admin> Update(Admin data)
        {
            return _adminRepository.Update(data);
        }
    }
}
