using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DateTimeLibrary;

namespace DateTimeTests
{
    [TestClass]
    public class DateTimeTest
    {
        [TestMethod]
        public void FindDifference_16012024and10012024_6returned()
        {
            DateTime start = new DateTime(2024, 01, 16);
            DateTime end = new DateTime(2024, 01, 10);
            int expected = 6;

            var actual = DateTimeClass.FindDifference(start, end);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindDifference_25122023and10012024_19returned()
        {
            DateTime start = new DateTime(2023, 12, 25);
            DateTime end = new DateTime(2024, 01, 10);
            int expected = 16;

            var actual = DateTimeClass.FindDifference(start, end);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsLeapYear_12052020_true_returned()
        {
            DateTime date = new DateTime(2020, 05, 12);
            var expected = true;

            var actual = DateTimeClass.IsLeapYear(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsLeapYear_20121900_false_returned()
        {
            DateTime date = new DateTime(1900, 12, 20);
            var expected = false;

            var actual = DateTimeClass.IsLeapYear(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindDayTimes_1205_noon_returned()
        {
            DateTime date = new DateTime(2024, 01, 16, 12, 05, 0);
            var expected = DayTimes.Noon;

            var actual = DateTimeClass.FindDayTimes(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindDayTimes_030_night_returned()
        {
            DateTime date = new DateTime(2024, 01, 16, 0, 30, 0);
            var expected = DayTimes.Night;

            var actual = DateTimeClass.FindDayTimes(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatDateTime_16012024_string_returned()
        {
            DateTime date = new DateTime(2024, 01, 16, 16, 15, 30);
            var expected = "16:15 16.01.2024";

            var actual = DateTimeClass.FormatDateTime(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatDateTime_01012024_string_returned()
        {
            DateTime date = new DateTime(2024, 01, 01, 02, 59, 30);
            var expected = "02:59 01.01.2024";

            var actual = DateTimeClass.FormatDateTime(date);

            Assert.AreEqual(expected, actual);
        }
    }
}
