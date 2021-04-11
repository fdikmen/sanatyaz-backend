using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Concrete
{
    public class PurposeManager : IPurposeService
    {
        private IPurposeRepository purposeRepository;
        public PurposeManager(IPurposeRepository _purposeRepository)
        {
            purposeRepository = _purposeRepository;
        }
        public ResultMessage<Purpose> Add(Purpose data)
        {
            return purposeRepository.Add(data);
        }

        public ResultMessage<Purpose> Delete(int id)
        {
            return purposeRepository.Delete(id);
        }

        public ResultMessage<Purpose> Get(Expression<Func<Purpose, bool>> filter)
        {
            return purposeRepository.Get(filter);
        }

        public ResultMessage<ICollection<Purpose>> GetAll(Expression<Func<Purpose, bool>> filter = null)
        {
            return purposeRepository.GetAll(filter);
        }

        public ResultMessage<Purpose> SoftDelete(int id)
        {
            return purposeRepository.SoftDelete(id);
        }

        public ResultMessage<Purpose> Update(Purpose data)
        {
            return purposeRepository.Update(data);
        }
    }
}
