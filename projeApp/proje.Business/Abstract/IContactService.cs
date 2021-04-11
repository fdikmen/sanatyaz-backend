using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IContactService
    {
        ResultMessage<Contact> Add(Contact data);
        ResultMessage<Contact> Update(Contact data);
        ResultMessage<Contact> Delete(int id);
        ResultMessage<Contact> SoftDelete(int id);
        ResultMessage<ICollection<Contact>> GetAll(Expression<Func<Contact, bool>> filter = null);
        ResultMessage<Contact> Get(Expression<Func<Contact, bool>> filter);
    }
}
