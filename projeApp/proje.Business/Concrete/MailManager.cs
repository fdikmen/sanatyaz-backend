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
    public class MailManager : IMailService
    {
        private IMailRepository mailRepository;
        public MailManager(IMailRepository _mailRepository)
        {
            mailRepository = _mailRepository;
        }
        public ResultMessage<Mail> Add(Mail data)
        {
            return mailRepository.Add(data);
        }

        public ResultMessage<Mail> Delete(int id)
        {
            return mailRepository.Delete(id);
        }

        public ResultMessage<Mail> Get(Expression<Func<Mail, bool>> filter)
        {
            return mailRepository.Get(filter);
        }

        public ResultMessage<ICollection<Mail>> GetAll(Expression<Func<Mail, bool>> filter = null)
        {
            return mailRepository.GetAll(filter);
        }

        public ResultMessage<Mail> SoftDelete(int id)
        {
            return mailRepository.SoftDelete(id);
        }

        public ResultMessage<Mail> Update(Mail data)
        {
            return mailRepository.Update(data);
        }
    }
}
