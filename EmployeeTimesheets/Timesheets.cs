using System;

namespace EmployeeTimesheets
{
    public class Timesheets
    {
        const double saturdayPenaltyRate = 0.015;
        const double sundayPenaltyRate = 0.02;
        double totalHoursForTheWeek = 0.0;
        double TotalPayOnSunday { get; set; }
        double TotalPayOnSaturday { get; set; }
        double costForTheWeek;
        double PenaltyPayOnSunday { get; set; }
        double PenaltyPayOnSaturday { get; set; }
        double HoursOnSunday { get; set; }
        double HoursOnMonday { get; set; }
        double HoursOnTuesday { get; set; }
        double HoursOnWednesday { get; set; }
        double HoursOnThursday { get; set; }
        double HoursOnFriday { get; set; }
        double HoursOnSaturday { get; set; }
        double RateperHour { get; set; }

        public string GetStaffName(string staffName)
        {

            staffName = Console.ReadLine();

            return staffName;
        }
        
        public string SetStaffHourlyRate(double ratePerHour)
        {
            RateperHour = ratePerHour;
            if (ratePerHour > 50)
                return "The Hourly Rate cannot exceed 50 ";

            if (ratePerHour >= 1 && ratePerHour <= 50)
            {
                return "Value within range";
            }
            
            return "Invalid Hourly rate";
        }

        public double CalculateHoursForWeek(double hoursOnSunday, double hoursOnMonday,
            double hoursOnTuesday, double hoursOnWednesday, double hoursOnThursday, 
            double hoursOnFriday, double hoursOnSaturday)
        {
            HoursOnSunday = hoursOnSunday;
            HoursOnMonday = hoursOnMonday;
            HoursOnTuesday = hoursOnTuesday;
            HoursOnWednesday = hoursOnWednesday;
            HoursOnThursday = hoursOnThursday;
            HoursOnFriday = hoursOnFriday;
            HoursOnSaturday = hoursOnSaturday;
            
            totalHoursForTheWeek = Convert.ToDouble(hoursOnSaturday) + Convert.ToDouble(HoursOnSunday) + Convert.ToDouble(HoursOnMonday)
             + Convert.ToDouble(hoursOnTuesday) + Convert.ToDouble(hoursOnWednesday)
             + Convert.ToDouble(hoursOnThursday) + Convert.ToDouble(hoursOnFriday);

            return totalHoursForTheWeek;
        }

        public double CalculateCostForTheWeek()
        {
            TotalPayOnSunday = (PenaltyPayOnSunday * HoursOnSunday) + (HoursOnSunday * RateperHour);
            TotalPayOnSaturday = (PenaltyPayOnSaturday * HoursOnSaturday) + (HoursOnSaturday * RateperHour);
            costForTheWeek = TotalPayOnSunday + (HoursOnMonday * RateperHour) +
                 (HoursOnTuesday * RateperHour) + (HoursOnWednesday * RateperHour) +
                 (HoursOnThursday * RateperHour) + (HoursOnFriday * RateperHour) +
                 TotalPayOnSaturday;

            return costForTheWeek;
        }

        public double Apply_PenaltyRateOf2Percent_OnSunday()
        {
            PenaltyPayOnSunday = sundayPenaltyRate * RateperHour;
            return PenaltyPayOnSunday;
        }

        public double Apply_PenaltyRateOfOneAndHalfPercent_OnSaturday()
        {
            PenaltyPayOnSaturday = saturdayPenaltyRate * RateperHour;

            return PenaltyPayOnSaturday;
        }
    }
}
