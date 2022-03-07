using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEmpHoursCalculator
{
    //Split Shift Employee Class
    class SplitShiftEmployee : Employee
    {
        public SplitShiftEmployee(string _employeeName, int _empHours) : base(_employeeName, _empHours)
        {
        }
        //Calculates Breaks Based of Split Shift
        public override int CalculateBreaks(int hoursWorked)
        {
            int breakTime = hoursWorked * 10;

            //// Calculating the employees additional minutes by dividing the hours by 3 and adding 20 minutes to their break time.
            //// (20 mins extra break for every 3 hours)
            int numberOf = (hoursWorked * 60) / 180;

            int additionalMinutes = numberOf * 20;


            // Break out and return the value
            return breakTime + additionalMinutes;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
