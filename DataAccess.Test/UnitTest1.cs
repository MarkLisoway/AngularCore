using System.Linq;
using DataAccess.Context;
using DataAccess.Models;
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
                    Name = "Mark Lisoway"
                });
                context.SaveChanges();
            }

            using (var context = new AngularCoreContext())
            {
                var user = context.Users.First();
                Assert.AreEqual("Mark Lisoway", user.Name);
            }
        }
    }
}