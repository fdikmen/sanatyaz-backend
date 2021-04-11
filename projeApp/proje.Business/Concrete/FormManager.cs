using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje.Business.Concrete
{
    public class FormManager : IFormService
    {
        private IFormRepository _formRepository;
        public FormManager(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public ResultMessage<Form> Add(Form data)
        {
            //data.isActive = true;
            return _formRepository.Add(data);
        }

        public ResultMessage<Form> Delete(int id)
        {
            return _formRepository.Delete(id);
        }

        public ResultMessage<Form> Get(Expression<Func<Form, bool>> filter)
        {
            return _formRepository.Get(filter);
        }

        public ResultMessage<ICollection<Form>> GetAll(Expression<Func<Form, bool>> filter = null)
        {
            return _formRepository.GetAll(filter);
        }

        public List<Form> GetAllForm()
        {
            return _formRepository.GetAllForm();
        }

        public ResultMessage<Form> SoftDelete(int id)
        {
            return _formRepository.SoftDelete(id);
        }

        public ResultMessage<Form> Update(Form data)
        {
            return _formRepository.Update(data);
        }
    }
}
