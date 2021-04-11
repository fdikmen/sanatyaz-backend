using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class BlogRepository : EFBaseRepository<ProjeDbContext, Blog>, IBlogRepository
    {
        //public BlogRepository(ProjeDbContext context) : base(context)
        //{

        //}

        public List<Blog> GetAllBlog()
        {            
            using(var context =new ProjeDbContext())
            {
                var blog = context.Blogs
                    .Include(c => c.Comments)
                    .Where(x => !x.isDelete)
                    .ToList();
                return blog;
            }           
        }


        //public async Task<List<Blog>> Active()
        //{
        //    using (var blogDbContext = new ProjeDbContext())
        //    {
        //        return await blogDbContext.Blogs.Where(x => x.isActive).ToListAsync();
        //    }
        //}

        //public async Task<Blog> Active(int id, bool active)
        //{
        //    using (var blogDbContext = new ProjeDbContext())
        //    {
        //        var aktifBlog = await GetBlogById(id);
        //        if (active == true)
        //        {
        //            aktifBlog.isActive = true;
        //            aktifBlog.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifBlog.isActive = false;
        //        }
        //        blogDbContext.Blogs.Update(aktifBlog);
        //        await blogDbContext.SaveChangesAsync();
        //        return aktifBlog;
        //    }
        //}

        //public async Task<Blog> CreateBlog(Blog blog)
        //{
        //    using (var blogDbContext = new ProjeDbContext())
        //    {
        //        blog.isActive = true;
        //        blogDbContext.Blogs.Add(blog);                
        //        await blogDbContext.SaveChangesAsync();
        //        return blog;
        //    }
        //}

        //public async Task DeleteBlog(int id)
        //{
        //    using (var blogDbContext = new ProjeDbContext())
        //    {
        //        var deleteBlog = await GetBlogById(id);
        //        deleteBlog.isDelete = true;
        //        deleteBlog.isActive = false;
        //        blogDbContext.Blogs.Update(deleteBlog);                
        //        await blogDbContext.SaveChangesAsync();
        //    }
        //}



        //public async Task<Blog> GetBlogById(int id)
        //{
        //    using (var blogDbContext = new ProjeDbContext())
        //    {
        //        return await blogDbContext.Blogs.FindAsync(id);
        //    }
        //}

        //public async Task<Blog> UpdateBlog(Blog blog)
        //{
        //    using (var blogDbContext = new ProjeDbContext())
        //    {
        //        blogDbContext.Blogs.Update(blog);                
        //        await blogDbContext.SaveChangesAsync();
        //        return blog;
        //    }
        //}

    }
}
