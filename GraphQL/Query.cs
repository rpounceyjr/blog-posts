﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPostsManagementSystem.DataAccess.Models;
using BlogPostsManagementSystem.DataAccess.Respositories;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace BlogPostsManagementSystem.GraphQL
{
    public class Query
    {
        public async Task<List<Author>> GetAllAuthors([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender)
        {
            List<Author> authors = authorRepository.GetAuthors();
            await eventSender.SendAsync("ReturnedAuthors", authors);

            return authors;
        }

        public async Task<Author> GetAuthorById([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Author author = authorRepository.GetAuthorById(id);
            await eventSender.SendAsync("ReturnedAuthor", author);

            return author;
        }

        public async Task<List<BlogPost>> GetAllBlogPosts([Service] IBlogRepository blogPostRepository, [Service] ITopicEventSender eventSender)
        {
            List<BlogPost> blogPosts = blogPostRepository.GetBlogPosts();
            await eventSender.SendAsync("ReturnedBlogPosts", blogPosts);

            return blogPosts;
        }

        public async Task<BlogPost> GetBlogPostById([Service] IBlogRepository blogPostRepository, [Service] ITopicEventSender eventSender, int id)
        {
            BlogPost blogPost = blogPostRepository.GetBlogPostById(id);
            await eventSender.SendAsync("ReturnedBlogPost", blogPost);

            return blogPost;
        }
    }
}
