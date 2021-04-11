using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class AdminRepository : EFBaseRepository<ProjeDbContext,Admin>,IAdminRepository
    {
        //public AdminRepository(ProjeDbContext context):base(context)
        //{

        //}

        //public async Task<Admin> CreateAdmin(Admin admin)
        //{
        //    using (var adminDbContext = new ProjeDbContext())
        //    {
        //        return await adminDbContext.Admins.FirstOrDefaultAsync(x => x.Name == admin.Name && x.Password == admin.Password);
        //    }
        //}
    }
}
