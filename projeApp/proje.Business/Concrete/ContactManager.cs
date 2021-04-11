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
    public class ContactManager : IContactService
    {
        private IContactRepository repository;
        public ContactManager(IContactRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Contact> Add(Contact data)
        {
            return repository.Add(data);
        }

        public ResultMessage<Contact> Delete(int id)
        {
            return repository.Delete(id);
        }

        public ResultMessage<Contact> Get(Expression<Func<Contact, bool>> filter)
        {
            return repository.Get(filter);
        }

        public ResultMessage<ICollection<Contact>> GetAll(Expression<Func<Contact, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<Contact> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Contact> Update(Contact data)
        {
            return repository.Update(data);
        }
    }
}
