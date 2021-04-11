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
    public class CreatePageManager : ICreatePageService
    {
        private ICreatePageRepository createPageRepository;
        public CreatePageManager(ICreatePageRepository _createPageRepository)
        {
            createPageRepository = _createPageRepository;
        }
        public ResultMessage<CreatePage> Add(CreatePage data)
        {
            return createPageRepository.Add(data);
        }

        public ResultMessage<CreatePage> Delete(int id)
        {
            return createPageRepository.Delete(id);
        }

        public ResultMessage<CreatePage> Get(Expression<Func<CreatePage, bool>> filter)
        {
            return createPageRepository.Get(filter);
        }

        public ResultMessage<ICollection<CreatePage>> GetAll(Expression<Func<CreatePage, bool>> filter = null)
        {
            return createPageRepository.GetAll(filter);
        }

        public ResultMessage<CreatePage> SoftDelete(int id)
        {
            return createPageRepository.SoftDelete(id);
        }

        public ResultMessage<CreatePage> Update(CreatePage data)
        {
            return createPageRepository.Update(data);
        }
    }
}
