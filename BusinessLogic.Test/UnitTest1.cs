using System.Linq;
using DataAccess.Context;
using DataAccess.Models;
using NUnit.Framework;

namespace BusinessLogic.Test
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
                var endPoint = new ServiceEndpoint(context);
                var user = new User
                {
                    Name = "Mark"
                };
                var resultsOne = endPoint.ExecuteCreate(user);

                user.Id = 0;
                user.Name = null;
                var resultTwo = endPoint.ExecuteUpdate(user);

                var userTwo = new User();
            }
        }


        [Test]
        public void Test2()
        {
            using (var context = new AngularCoreContext())
            {
                var endPoint = new ServiceEndpoint(context);
                var post = new BlogPost
                {
                    Name = "Hello",
                    Content = "World"
                };
                endPoint.ExecuteCreate(post);

                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var endPoint = new ServiceEndpoint(context);
                var post = new BlogPost
                {
                    Id = 1,
                    Name = "Foo",
                    Content = "Bar"
                };
                endPoint.ExecuteUpdate(post, p => p.Name);

                context.SaveChanges();
            }
            
            using (var context = new AngularCoreContext())
            {
                var endPoint = new ServiceEndpoint(context);
                var result = endPoint.ExecuteRead<BlogPost, TestDto>(p => new TestDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Content = p.Content
                });

                var post = result.Results.First();
                
                context.SaveChanges();
            }
        }

        private class TestDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
        }
    }
}