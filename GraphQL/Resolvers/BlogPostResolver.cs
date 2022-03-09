using System;
using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.DataAccess.Models;
using BlogPostsManagementSystem.DataAccess.Respositories;
using HotChocolate;
using HotChocolate.Resolvers;

namespace BlogPostsManagementSystem.GraphQL.Resolvers
{
    public class BlogPostResolver
    {
        private readonly IBlogRepository blogPostRepository;

        public BlogPostResolver([Service] IBlogRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public IEnumerable<BlogPost> GetBlogPosts(Author author, IResolverContext context)
        {
            return blogPostRepository.GetBlogPosts().Where(post => post.AuthorId == author.Id);
        }
    }
}
