using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DataAccess.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            using (var context = new AngularCoreContext())
            {
                context.Users.Add(new User
                {
                    Name = "Mark Lisoway",
                    OtherName = "Some Other Name"
                });
                context.SaveChanges();
            }

            using (var context = new AngularCoreContext())
            {
                var user = new User
                {
                    Id = 1,
                    Name = "Hello World"
                };
                user.Name = "A New Name";
                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var user = context.Users.First();
            }

            using (var context = new AngularCoreContext())
            {
                var updatedUser = new User
                {
                    Id = 1
                };

                var userEntry = context.Attach(updatedUser);
                context.Entry(updatedUser)
                    .Property(user => user.Name).IsModified = false;
                
                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var user = context.Users.First();
                Assert.AreEqual("Mark Lisoway", user.Name);
            }
        }

        [Test]
        public void Test2()
        {
            using (var context = new AngularCoreContext())
            {
                var blog = new Blog
                {
                    Name = "My New Blog",
                    Posts = new List<BlogPost>()
                };
                
                var postOne = new BlogPost
                {
                    Name = "Post 1",
                    Content = "Hello World"
                };
                
                var postTwo = new BlogPost
                {
                    Name = "Post 2",
                    Content = "Another line of content"
                };
                
                blog.Posts.Add(postOne);
                blog.Posts.Add(postTwo);

                context.Blogs.Add(blog);

                context.SaveChanges();
            }

            using (var context = new AngularCoreContext())
            {
                var blog = context.Blogs
                    .Include(b => b.Posts)
                    .First();
            }

            using (var context = new AngularCoreContext())
            {
                var blog = new Blog
                {
                    Id = 1,
                    Posts = new List<BlogPost>()
                };
                
                blog.Posts.Add(new BlogPost
                {
                    Name = "Third Post",
                    Content = "FooBar"
                });

                context.Attach(blog);
                context.Entry(blog)
                    .Collection(b => b.Posts).IsModified = true;

                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var blog = context.Blogs
                    .Include(b => b.Posts)
                    .First();
            }
            
            using (var context = new AngularCoreContext())
            {
                var post = new BlogPost
                {
                    Id = 2
                };

                context.BlogPosts.Remove(post);
                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var blog = context.Blogs
                    .Include(b => b.Posts)
                    .First();
            }
            
            using (var context = new AngularCoreContext())
            {
                var postsToRemove = new List<BlogPost>
                {
                    new BlogPost
                    {
                        Id = 1
                    },
                    new BlogPost
                    {
                        Id = 3
                    }
                };
                context.BlogPosts.RemoveRange(postsToRemove);
                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var blog = context.Blogs
                    .Include(b => b.Posts)
                    .First();
            }
        }
    }
}