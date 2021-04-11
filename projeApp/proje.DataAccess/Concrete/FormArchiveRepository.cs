using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System.Collections.Generic;
using System.Linq;

namespace proje.DataAccess.Concrete
{
    public class FormArchiveRepository : EFBaseRepository<ProjeDbContext, FormArchive>, IFormArchiveRepository
    {
        
    }
}
