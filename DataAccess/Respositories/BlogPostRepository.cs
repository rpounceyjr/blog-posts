using System;
using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsManagementSystem.DataAccess.Respositories
{
    public class BlogPostRepository : IBlogRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public BlogPostRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
            using(var applicationDbContext = dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database.EnsureCreated();
            }
        }

        public BlogPost GetBlogPostById(int id)
        {
            using(var applicationDbContext = dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.BlogPosts.SingleOrDefault(post => post.Id == id);
            }
        }

        public List<BlogPost> GetBlogPosts()
        {
            using (var applicationDbContext = dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.BlogPosts.ToList();
            }
        }
    }
}
