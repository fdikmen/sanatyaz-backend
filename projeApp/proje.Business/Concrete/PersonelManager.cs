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
    public class PersonelManager:IPersonelService
    {
        private IPersonelRepository personelRepository;
        public PersonelManager(IPersonelRepository _personelRepository)
        {
            personelRepository = _personelRepository;
        }

        public ResultMessage<Personel> Add(Personel data)
        {
            return personelRepository.Add(data);
        }

        public ResultMessage<Personel> Delete(int id)
        {
            return personelRepository.Delete(id);
        }

        public ResultMessage<Personel> Get(Expression<Func<Personel, bool>> filter)
        {
            return personelRepository.Get(filter);
        }

        public ResultMessage<ICollection<Personel>> GetAll(Expression<Func<Personel, bool>> filter = null)
        {
            return personelRepository.GetAll(filter);
        }

        public ResultMessage<Personel> SoftDelete(int id)
        {
            return personelRepository.SoftDelete(id);
        }

        public ResultMessage<Personel> Update(Personel data)
        {
            return personelRepository.Update(data);
        }
    }
}
