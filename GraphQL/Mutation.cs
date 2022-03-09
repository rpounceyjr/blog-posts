using System;
using System.Threading.Tasks;
using BlogPostsManagementSystem.DataAccess.Models;
using BlogPostsManagementSystem.DataAccess.Respositories;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace BlogPostsManagementSystem.GraphQL
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor([Service] AuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id, string firstName, string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await authorRepository.CreateAuthor(data);

            await eventSender.SendAsync("AuthorCreated", result);

            return result;
        }
    }
}
