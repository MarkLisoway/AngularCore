using BusinessLogic.CoreEntity.TypedCoreEntity;
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
            var one = BoolType.NotSet;

            var two = BoolType.True;

            var val = one.CompareTo(two);
        }

    }

}
