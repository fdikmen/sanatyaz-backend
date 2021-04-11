using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IMailService
    {
        ResultMessage<Mail> Add(Mail data);
        ResultMessage<Mail> Update(Mail data);
        ResultMessage<Mail> Delete(int id);
        ResultMessage<Mail> SoftDelete(int id);
        ResultMessage<ICollection<Mail>> GetAll(Expression<Func<Mail, bool>> filter = null);
        ResultMessage<Mail> Get(Expression<Func<Mail, bool>> filter);
    }
}
