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
    public class ConstantManager : IConstantService
    {
        private IConstantRepository _constantRepository;
        public ConstantManager(IConstantRepository constantRepository)
        {
            _constantRepository = constantRepository;
        }

        public ResultMessage<Constant> Add(Constant data)
        {
            
            return _constantRepository.Add(data);
        }

        public ResultMessage<Constant> Delete(int id)
        {
            return _constantRepository.Delete(id);
        }

        public ResultMessage<Constant> Get(Expression<Func<Constant, bool>> filter)
        {
            return _constantRepository.Get(filter);
        }

        public ResultMessage<ICollection<Constant>> GetAll(Expression<Func<Constant, bool>> filter = null)
        {
            return _constantRepository.GetAll(filter);
        }

        public ResultMessage<Constant> SoftDelete(int id)
        {
            return _constantRepository.SoftDelete(id);
        }

        public ResultMessage<Constant> Update(Constant data)
        {
            return _constantRepository.Update(data);
        }
    }
}
