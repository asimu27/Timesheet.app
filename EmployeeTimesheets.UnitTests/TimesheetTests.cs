using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace EmployeeTimesheets.UnitTests
{
    [TestFixture]
    public class TimesheetTests
    {
        [Test]
        [TestCase(51.0)]
        [TestCase(100.5)]
        public void GetStaffHourlyRate_HourlyRateGreaterThan50_ReturnsErrorMessage(double testValue)
        {
            var timesheets = new Timesheets();

            var result = timesheets.SetStaffHourlyRate(testValue);

            Assert.That(result, Is.EqualTo("The Hourly Rate cannot exceed 50 "));
        }

        [Test]
        [TestCase(25)]
        [TestCase(1)]
        [TestCase(50)]
        [TestCase(49.9)]
        public void GetStaffHourlyRate_HourlyRateGreaterThan1AndLessThanOrEqualTo50_ReturnsAcceptedValueMessage(double testValue)
        {
            var timesheets = new Timesheets();

            var result = timesheets.SetStaffHourlyRate(testValue);

            Assert.That(result, Is.EqualTo("Value within range"));
        }

        [Test]
        [TestCase(0)]
        public void GetStaffHourlyRate_HourlyRateLessThan1_ReturnInvalidErrorMessage(double testValue)
        {
            var timesheet = new Timesheets();

            var result = timesheet.SetStaffHourlyRate(testValue);

            Assert.That(result, Is.EqualTo("Invalid Hourly rate"));

        }

        [Test]
        [TestCase(2,3,4,1,4,2,3)]
        public void GetTotalHoursForWeek(double hrsForSunday, double hrsForMonday, 
            double hrsForTuesday, double hrsForWednesday, double hrsForThursday, 
            double hrsForFriday, double hrsForSaturday)
        {
            var timesheet = new Timesheets();
            var setRatePerHour = timesheet.SetStaffHourlyRate(40);
            var result = timesheet.CalculateHoursForWeek(hrsForSunday,hrsForMonday,hrsForTuesday,
                hrsForWednesday,hrsForThursday,hrsForFriday, hrsForSaturday);
            Assert.That(result, Is.EqualTo(19));

        }

        [Test]
        [TestCase(2, 3, 4, 1, 4, 2, 3)]
        public void GetTotalCostForTheWeek(double hrsForSunday, double hrsForMonday,
            double hrsForTuesday, double hrsForWednesday, double hrsForThursday,
            double hrsForFriday, double hrsForSaturday)
        {
            var timesheet = new Timesheets();
            var setRatePerHour = timesheet.SetStaffHourlyRate(40);
            var setPenaltyForSunday = timesheet.Apply_PenaltyRateOf2Percent_OnSunday();
            var setPenaltyRateForSaturday = timesheet.Apply_PenaltyRateOfOneAndHalfPercent_OnSaturday();
            var hrsForWeek = timesheet.CalculateHoursForWeek(hrsForSunday, hrsForMonday, hrsForTuesday,
                hrsForWednesday, hrsForThursday, hrsForFriday, hrsForSaturday); 
            
            var result = timesheet.CalculateCostForTheWeek();

            Assert.That(result, Is.EqualTo(763.39999999999998d));
            
        }

        [Test]
        [TestCase(2, 3, 4, 1, 4, 2, 3)]
        public void ApplyPenaltyRates_OnSunday(double hrsForSunday, double hrsForMonday,
            double hrsForTuesday, double hrsForWednesday, double hrsForThursday,
            double hrsForFriday, double hrsForSaturday)
        {
            var timesheet = new Timesheets();
            var setRatePerHour = timesheet.SetStaffHourlyRate(40);
            var hrsForWeek = timesheet.CalculateHoursForWeek(hrsForSunday, hrsForMonday, hrsForTuesday,
                hrsForWednesday, hrsForThursday, hrsForFriday, hrsForSaturday);

            var costForTheWeek = timesheet.CalculateCostForTheWeek();
            var result = timesheet.Apply_PenaltyRateOf2Percent_OnSunday();
            Assert.That(result, Is.EqualTo(0.80000000000000004d));
        }

        [Test]
        [TestCase(2, 3, 4, 1, 4, 2, 3)]
        public void ApplyPenaltyRates_OnSaturday(double hrsForSunday, double hrsForMonday,
            double hrsForTuesday, double hrsForWednesday, double hrsForThursday,
            double hrsForFriday, double hrsForSaturday)
        {
            var timesheet = new Timesheets();
            var setRatePerHour = timesheet.SetStaffHourlyRate(40);
            var hrsForWeek = timesheet.CalculateHoursForWeek(hrsForSunday, hrsForMonday, hrsForTuesday,
                hrsForWednesday, hrsForThursday, hrsForFriday, hrsForSaturday);

            var costForTheWeek = timesheet.CalculateCostForTheWeek();
            var result = timesheet.Apply_PenaltyRateOfOneAndHalfPercent_OnSaturday();
            Assert.That(result, Is.EqualTo(0.59999999999999998d));
        }
    }
}
