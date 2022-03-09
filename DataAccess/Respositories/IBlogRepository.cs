using System;
using System.Collections.Generic;
using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess.Respositories
{
    public interface IBlogRepository
    {
        public List<BlogPost> GetBlogPosts();

        public BlogPost GetBlogPostById(int id);
    }
}
