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
    public class FormElementManager : IFormElementService
    {
        private IFormElementRepository _formElementRepository;
        public FormElementManager(IFormElementRepository formElementRepository)
        {
            _formElementRepository = formElementRepository;
        }
        public ResultMessage<FormElement> Add(FormElement data)
        {
            return _formElementRepository.Add(data);
        }

        public ResultMessage<FormElement> Delete(int id)
        {
            return _formElementRepository.Delete(id);
        }

        public ResultMessage<FormElement> Get(Expression<Func<FormElement, bool>> filter)
        {
            return _formElementRepository.Get(filter);
        }

        public ResultMessage<ICollection<FormElement>> GetAll(Expression<Func<FormElement, bool>> filter = null)
        {
            return _formElementRepository.GetAll(filter);
        }

        public List<FormElement> GetAllFormElement()
        {
            return _formElementRepository.GetAllFormElement();
        }

        public ResultMessage<FormElement> SoftDelete(int id)
        {
            return _formElementRepository.SoftDelete(id);
        }

        public ResultMessage<FormElement> Update(FormElement data)
        {
            return _formElementRepository.Update(data);
        }
    }
}
