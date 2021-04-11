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
    public class FormArchiveManager : IFormArchiveService
    {
        private IFormArchiveRepository repository;
        public FormArchiveManager(IFormArchiveRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<FormArchive> Add(FormArchive data)
        {
            return repository.Add(data);
        }

        public ResultMessage<FormArchive> Delete(int id)
        {
            return repository.Delete(id);
        }

        public ResultMessage<FormArchive> Get(Expression<Func<FormArchive, bool>> filter)
        {
            return repository.Get(filter);
        }

        public ResultMessage<ICollection<FormArchive>> GetAll(Expression<Func<FormArchive, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<FormArchive> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<FormArchive> Update(FormArchive data)
        {
            return repository.Update(data);
        }
    }
}
