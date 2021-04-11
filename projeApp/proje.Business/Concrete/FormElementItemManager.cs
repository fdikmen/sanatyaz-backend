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
    public class FormElementItemManager : IFormElementItemService
    {
        private IFormElementItemRepository repository;
        public FormElementItemManager(IFormElementItemRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<FormElementItem> Add(FormElementItem data)
        {
            return repository.Add(data);
        }

        public ResultMessage<FormElementItem> Delete(int id)
        {
            return repository.Delete(id);
        }

        public ResultMessage<FormElementItem> Get(Expression<Func<FormElementItem, bool>> filter)
        {
            return repository.Get(filter);
        }

        public ResultMessage<ICollection<FormElementItem>> GetAll(Expression<Func<FormElementItem, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<FormElementItem> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<FormElementItem> Update(FormElementItem data)
        {
            return repository.Update(data);
        }
    }
}
