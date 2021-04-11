using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proje.DataAccess.Concrete
{
    public class FormElementRepository : EFBaseRepository<ProjeDbContext, FormElement>, IFormElementRepository
    {
        public List<FormElement> GetAllFormElement()
        {
            using (var context = new ProjeDbContext())
            {
                var formElement = context.FormElements
                    .Include(c => c.FormElementItems)
                    .Include(d => d.FormArchives)
                    .Where(x => !x.isDelete)
                    .ToList();
                return formElement;

            }

        }
    }
}
