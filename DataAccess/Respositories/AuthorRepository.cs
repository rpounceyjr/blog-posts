using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsManagementSystem.DataAccess.Respositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public AuthorRepository(IDbContextFactory<ApplicationDbContext> _dbContextFactory)
        {
            this.dbContextFactory = _dbContextFactory;
            using(var _applicationDbContext = dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            using (var applicationDbContext = dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Add(author);
                await applicationDbContext.SaveChangesAsync();
                return author;
            }
        }

        public Author GetAuthorById(int id)
        {
            using (var applicationDbContext = dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Authors.SingleOrDefault(author => author.Id == id);
            }
        }

        public List<Author> GetAuthors()
        {
            using (var applicationDbContext = dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Authors.ToList();
            }
        }
    }
}
