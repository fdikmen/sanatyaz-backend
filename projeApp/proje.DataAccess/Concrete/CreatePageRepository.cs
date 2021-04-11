using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace proje.DataAccess.Concrete
{
    public class CreatePageRepository:EFBaseRepository<ProjeDbContext,CreatePage>,ICreatePageRepository
    {
    }
}
