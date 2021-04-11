using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class UserRepository : EFBaseRepository<ProjeDbContext, User>, IUserRepository
    {
        //public UserRepository(ProjeDbContext context):base(context)
        //{

        //}
        //public async Task<User> CreateUser(User user)
        //{
        //    using(var userDbContext=new ProjeDbContext())
        //    {
        //        //aynı kayıt eklenememesi için
        //        var mail=await userDbContext.Users.FirstOrDefaultAsync(x=>x.userEMail==user.userEMail);                
        //        if (mail == null)
        //        {
        //            userDbContext.Users.Add(user);
        //            await userDbContext.SaveChangesAsync();
        //            return user;
        //        }
        //        return null;                
        //    }
        //}

        //public async Task DeleteUser(int id)
        //{
        //    using(var userDbContext=new ProjeDbContext())
        //    {
        //        var deleteUser=await GetUserById(id);
        //        deleteUser.isDelete = true;
        //        userDbContext.Users.Update(deleteUser);
        //        //userDbContext.Users.Remove(deleteUser);
        //        await userDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<User>> GetAllUser()
        //{
        //    using(var userDbContext=new ProjeDbContext())
        //    {
        //        return await userDbContext.Users.Where(x=>!x.isDelete).ToListAsync();
        //    }
        //}

        //public async Task<User> GetUserById(int id)
        //{
        //    using(var userDbContext=new ProjeDbContext())
        //    {
        //        return await userDbContext.Users.FindAsync(id);
        //    }
        //}        

        //public async Task<User> UpdateUser(User user)
        //{
        //    using(var userDbContext=new ProjeDbContext())
        //    {
        //        var mail = await userDbContext.Users.FirstOrDefaultAsync(x => x.userEMail == user.userEMail);                
        //        if(mail==null)
        //        {
        //            userDbContext.Users.Update(user);
        //            await userDbContext.SaveChangesAsync();
        //            return user;
        //        }
        //        return null;
        //    }
        //}
        
        //public async Task<User> Login(string eMail,string password)
        //{
        //    using(var userDbContext=new ProjeDbContext())
        //    {                
        //        return await userDbContext.Users.FirstOrDefaultAsync(x => x.userEMail == eMail && x.userPassword==password);
        //    }
        //}

    }
}
