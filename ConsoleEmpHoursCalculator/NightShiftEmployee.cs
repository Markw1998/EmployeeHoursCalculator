using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEmpHoursCalculator
{
    class NightShiftEmployee : Employee
    {
        public NightShiftEmployee(string _employeeName, int _empHours) : base(_employeeName, _empHours)
        {

        }

        public override int CalculateBreaks(int hoursWorked)
        {
            int breakTime = hoursWorked * 15;

            //// Calculating the employees additional minutes by dividing the hours by 4 and adding 20 minutes to their break time.
            //// (20 mins extra break for every 4 hours)
            int numberOf = (hoursWorked * 60) / 240;

            int additionalMinutes = numberOf * 30;


            // Break out and return the value
            return breakTime + additionalMinutes;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
