using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace proje.DataAccess.Concrete
{
    public class MailRepository : EFBaseRepository<ProjeDbContext, Mail>, IMailRepository
    {
    }
}
