using System;
using BlogPostsManagementSystem.DataAccess.Models;
using BlogPostsManagementSystem.GraphQL.Resolvers;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL
{
    public class BlogPostType : ObjectType<BlogPost>
    {
        protected override void Configure(IObjectTypeDescriptor<BlogPost> descriptor)
        {
            descriptor.Field(post => post.Id).Type<IdType>();
            descriptor.Field(post => post.Title).Type<StringType>();
            descriptor.Field(post => post.AuthorId).Type<IntType>();
            descriptor.Field<AuthorResolver>(b => b.GetAuthor(default, default));
        }
    }
}
