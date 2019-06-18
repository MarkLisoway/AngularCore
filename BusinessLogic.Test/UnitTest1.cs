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
    }
}