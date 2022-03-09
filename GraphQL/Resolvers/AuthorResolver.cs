using System;
using System.Linq;
using BlogPostsManagementSystem.DataAccess.Models;
using BlogPostsManagementSystem.DataAccess.Respositories;
using HotChocolate;
using HotChocolate.Resolvers;

namespace BlogPostsManagementSystem.GraphQL.Resolvers
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository authorService;

        public AuthorResolver([Service] IAuthorRepository authorService)
        {
            this.authorService = authorService;
        }

        public Author GetAuthor(BlogPost blog, IResolverContext context)
        {
            return authorService.GetAuthors().Where(author => author.Id == blog.AuthorId).FirstOrDefault();
        }
    }
}
