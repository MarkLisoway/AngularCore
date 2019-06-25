using System.Collections.Generic;
using BusinessLogic.CoreEntity.TypedCoreEntity;
using NUnit.Framework;

namespace BusinessLogic.Test.CoreEntity
{

    public class BoolTypeTests
    {

        //**************************************************
        //* Private
        //**************************************************

        //--------------------------------------------------
        private static IDictionary<string, BoolType> _boolTypeFromString;



        //**************************************************
        //* Setup
        //**************************************************

        //--------------------------------------------------
        [OneTimeSetUp]
        public void SetupBoolTypeDictionary()
        {
            _boolTypeFromString = new Dictionary<string, BoolType>
            {
                ["true"] = BoolType.True,
                ["false"] = BoolType.False,
                ["notSet"] = BoolType.NotSet,
                ["null"] = BoolType.Null,
                ["unknown"] = BoolType.Unknown
            };
        }



        //**************************************************
        //* Tests
        //**************************************************

        //--------------------------------------------------
        [TestCase("true", true, 0)]
        [TestCase("true", false, 1)]
        [TestCase("false", true, -1)]
        [TestCase("false", false, 0)]
        [TestCase("notSet", true, -1)]
        [TestCase("notSet", false, -1)]
        [TestCase("null", true, -1)]
        [TestCase("null", false, -1)]
        [TestCase("unknown", true, -1)]
        [TestCase("unknown", false, -1)]
        public static void BoolCompareToReturnsCorrectValue(
            string leftStringBool,
            bool rightBool,
            int expectedComparisonValue)
        {
            var leftBoolType = _boolTypeFromString[leftStringBool];

            var comparisonValue = leftBoolType.CompareTo(rightBool);

            Assert.AreEqual(expectedComparisonValue, comparisonValue);
        }

        //--------------------------------------------------
        // Left true
        [TestCase("true", "true", 0)]
        [TestCase("true", "false", 1)]
        [TestCase("true", "notSet", 1)]
        [TestCase("true", "null", 1)]
        [TestCase("true", "unknown", 1)]
        // Left false
        [TestCase("false", "true", -1)]
        [TestCase("false", "false", 0)]
        [TestCase("false", "notSet", 1)]
        [TestCase("false", "null", 1)]
        [TestCase("false", "unknown", 1)]
        // Left not set
        [TestCase("notSet", "true", -1)]
        [TestCase("notSet", "false", -1)]
        [TestCase("notSet", "notSet", 0)]
        [TestCase("notSet", "null", 0)]
        [TestCase("notSet", "unknown", 0)]
        // Left null
        [TestCase("null", "true", -1)]
        [TestCase("null", "false", -1)]
        [TestCase("null", "notSet", 0)]
        [TestCase("null", "null", 0)]
        [TestCase("null", "unknown", 0)]
        // Left unknown
        [TestCase("unknown", "true", -1)]
        [TestCase("unknown", "false", -1)]
        [TestCase("unknown", "notSet", 0)]
        [TestCase("unknown", "null", 0)]
        [TestCase("unknown", "unknown", 0)]
        public static void BoolTypeCompareToReturnsCorrectValues(
            string leftStringBool,
            string rightStringBool,
            int expectedComparisonValue)
        {
            var leftBoolType = _boolTypeFromString[leftStringBool];
            var rightBoolType = _boolTypeFromString[rightStringBool];

            var comparisonValue = leftBoolType.CompareTo(rightBoolType);

            Assert.AreEqual(expectedComparisonValue, comparisonValue);
        }

    }

}
