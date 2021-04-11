using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class CommentRepository :EFBaseRepository<ProjeDbContext,Comment>, ICommentRepository
    {
        //public CommentRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<Comment> CreateComment(Comment comment)
        //{
        //    using (var commentDbContext=new ProjeDbContext())
        //    {
        //        commentDbContext.Comments.Add(comment);
        //        await commentDbContext.SaveChangesAsync();
        //        return comment;
        //    }
        //}

        //public async Task DeleteComment(int id)
        //{
        //    using (var commentDbContext=new ProjeDbContext())
        //    {
        //        var deleteComment = await GetCommentById(id);
        //        deleteComment.isDelete = true;
        //        commentDbContext.Comments.Update(deleteComment);
        //        //menuDbContext.Menus.Remove(deleteMenu);
        //        await commentDbContext.SaveChangesAsync();
        //    }
            
        //}

        //public async Task<List<Comment>> GetAllComment()
        //{
        //    using (var commentDbContext = new ProjeDbContext())
        //    {
        //        return await commentDbContext.Comments.Where(x => !x.isDelete).ToListAsync();
        //    }
        //}

        //public async Task<Comment> GetCommentById(int id)
        //{
        //    using (var commentDbContext = new ProjeDbContext())
        //    {
        //        return await commentDbContext.Comments.FindAsync(id);
        //    }
        //}        

        //public async Task<Comment> UpdateComment(Comment comment)
        //{
        //    using(var commentDbContext = new ProjeDbContext())
        //    {                
        //        commentDbContext.Comments.Update(comment);
        //        await commentDbContext.SaveChangesAsync();
        //        return comment;
        //    }
        //}
    }
}
