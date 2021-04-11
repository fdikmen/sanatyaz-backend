using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace proje.DataAccess.Concrete
{
    public class FormElementItemRepository: EFBaseRepository<ProjeDbContext,FormElementItem>,IFormElementItemRepository
    {
    }
}
