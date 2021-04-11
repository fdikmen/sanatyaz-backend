using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class ConstantRepository : EFBaseRepository<ProjeDbContext, Constant>, IConstantRepository
    {
        //public ConstantRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<Constant> CreateConstant(Constant constant)
        //{
        //    using(var constantDbContext = new ProjeDbContext())
        //    {
        //        constantDbContext.Constants.Add(constant);
        //        await constantDbContext.SaveChangesAsync();
        //        return constant;
        //    }
        //}

        //public async Task<List<Constant>> GetAllConstant()
        //{
        //    using(var constantDbContext = new ProjeDbContext())
        //    {
        //        return await constantDbContext.Constants.ToListAsync();
        //    }
        //}

        //public async Task<Constant> GetConstantById(int id)
        //{
        //    using(var constantDbContext =new ProjeDbContext())
        //    {
        //        return await constantDbContext.Constants.FindAsync(id);
        //    }
        //}

        //public async Task<Constant> UpdateConstant(Constant constant)
        //{
        //    using(var constantDbContext=new ProjeDbContext())
        //    {                
        //        constantDbContext.Constants.Update(constant);
        //        await constantDbContext.SaveChangesAsync();
        //        return constant;
        //    }
        //}
    }
}
