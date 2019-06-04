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
                
                var userTwo = new User
                {
                    Id = 1,
                    Name = "Tim"
                };
                var resultTwo = endPoint.ExecuteCreate(userTwo);
                
                var userThree = new User();
                var resultThree = endPoint.ExecuteCreate(userThree);
                
                Assert.AreEqual(true, resultsOne.Success);
                Assert.IsNotNull(resultsOne.Results);
                Assert.IsNotNull(resultsOne.Results.Id);
                Assert.IsNotNull(resultsOne.Results.Name);
                Assert.IsEmpty(resultsOne.Errors);
                
                Assert.AreEqual(false, resultTwo.Success);
                Assert.IsNull(resultTwo.Results);
                Assert.IsNotEmpty(resultTwo.Errors);
                Assert.AreEqual(1, resultTwo.Errors.Count);
                
                Assert.AreEqual(false, resultThree.Success);
                Assert.IsNull(resultThree.Results);
                Assert.IsNotEmpty(resultThree.Errors);
                Assert.AreEqual(1, resultThree.Errors.Count);
            }
        }
    }
}