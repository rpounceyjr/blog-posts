using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess.Respositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();

        public Author GetAuthorById(int id);

        public Task<Author> CreateAuthor(Author author);
    }
}
