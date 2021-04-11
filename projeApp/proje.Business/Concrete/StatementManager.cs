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
    public class StatementManager : IStatementService
    {
        private IStatementRepository statementRepository;
        public StatementManager(IStatementRepository _statementRepository)
        {
            statementRepository = _statementRepository;
        }
        public ResultMessage<Statement> Add(Statement data)
        {
            return statementRepository.Add(data);
        }

        public ResultMessage<Statement> Delete(int id)
        {
            return statementRepository.Delete(id);
        }

        public ResultMessage<Statement> Get(Expression<Func<Statement, bool>> filter)
        {
            return statementRepository.Get(filter);
        }

        public ResultMessage<ICollection<Statement>> GetAll(Expression<Func<Statement, bool>> filter = null)
        {
            return statementRepository.GetAll(filter);
        }

        public ResultMessage<Statement> SoftDelete(int id)
        {
            return statementRepository.SoftDelete(id);
        }

        public ResultMessage<Statement> Update(Statement data)
        {
            return statementRepository.Update(data);
        }
    }
}
