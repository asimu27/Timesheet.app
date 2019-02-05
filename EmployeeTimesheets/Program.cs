using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimesheets
{
    class Program
    {
        static void Main(string[] args)
        {
            const double saturdayPenaltyRate = 0.015;
            const double sundayPenaltyRate = 0.02;

            Console.WriteLine("Enter Employee's Name");
            var empName = Console.ReadLine();

            Console.WriteLine("Enter Employee's Hourly Rate");
            double empHourlyRate = 0;
            while (true)
            {
                empHourlyRate = Convert.ToDouble(Console.ReadLine());

                if (empHourlyRate < 50)
                    break ;
            }
            Console.WriteLine("Record " + empName + "'s" + " timesheet for the week");
            Console.Write("Hours worked on Sunday :");
            var hoursOnSunday = Convert.ToDouble(Console.ReadLine());
            var penaltyPayOnSunday = sundayPenaltyRate * empHourlyRate;
            var totalPayOnSunday = (penaltyPayOnSunday * hoursOnSunday) + (hoursOnSunday * empHourlyRate);

            Console.Write("Hours worked on Monday :");
            var hoursOnMonday = Convert.ToDouble(Console.ReadLine());

            Console.Write("Hours worked on Tuesday :");
            var hoursOnTuesday = Convert.ToDouble(Console.ReadLine());

            Console.Write("Hours worked on Wednesday :");
            var hoursOnWednesday = Convert.ToDouble(Console.ReadLine());

            Console.Write("Hours worked on Thursday :");
            var hoursOnThursday = Convert.ToDouble(Console.ReadLine());

            Console.Write("Hours worked on Friday :");
            var hoursOnFriday = Convert.ToDouble(Console.ReadLine());

            Console.Write("Hours worked on Saturday :");
            var hoursOnSaturday = Convert.ToDouble(Console.ReadLine());
            var penaltyPayOnSaturday = saturdayPenaltyRate * empHourlyRate;
            var totalPayOnSaturday = (penaltyPayOnSaturday * hoursOnSaturday) + (hoursOnSaturday * empHourlyRate);

            Console.WriteLine("Total pay on saturday = " + totalPayOnSaturday);

            var totalHoursForTheWeek = Convert.ToDouble(hoursOnSaturday) + Convert.ToDouble(hoursOnSunday) + Convert.ToDouble(hoursOnMonday)
             + Convert.ToDouble(hoursOnTuesday) + Convert.ToDouble(hoursOnWednesday)
             + Convert.ToDouble(hoursOnThursday) + Convert.ToDouble(hoursOnFriday);

            var costForTheWeek = totalPayOnSunday + (hoursOnMonday * empHourlyRate) +
                 (hoursOnTuesday * empHourlyRate) + (hoursOnWednesday * empHourlyRate) +
                 (hoursOnThursday * empHourlyRate) + (hoursOnFriday * empHourlyRate) +
                 totalPayOnSaturday;

            Console.WriteLine(empName + " 's " + "total hours for the week" + Convert.ToDouble(totalHoursForTheWeek));
            Console.Write(empName + " 's " + "cost for the week is: " + Convert.ToDouble(costForTheWeek));


        }
    }
}
