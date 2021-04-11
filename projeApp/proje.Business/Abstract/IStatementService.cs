using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IStatementService
    {
        ResultMessage<Statement> Add(Statement data);
        ResultMessage<Statement> Update(Statement data);
        ResultMessage<Statement> Delete(int id);
        ResultMessage<Statement> SoftDelete(int id);
        ResultMessage<ICollection<Statement>> GetAll(Expression<Func<Statement, bool>> filter = null);
        ResultMessage<Statement> Get(Expression<Func<Statement, bool>> filter);
    }
}
