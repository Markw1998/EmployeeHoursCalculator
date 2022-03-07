using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEmpHoursCalculator
{
    internal class Employee
    {
        public string EmpName { get; set; }
        public int EmpHours { get; set; }
        public int EmpBreakTime { get; set; }

        //public int EmpShiftType { get; set; }

        public Employee(string _employeeName, int _empHours)
        {
            this.EmpName = _employeeName;
            this.EmpHours = _empHours;
            this.EmpBreakTime = 0;

        }

        //// Calculating the employees additional minutes by dividing the hours by 4 and adding 20 minutes to their break time.
        //// (20 mins extra break for every 4 hours)
        public virtual int CalculateBreaks(int hoursWorked)
        {
            int breakTime = hoursWorked * 10;

            int numberOf = (hoursWorked * 60) / 240;

            int additionalMinutes = numberOf * 20;


            // Break out and return the value
            return breakTime + additionalMinutes;
        }

        public override string ToString()
        {
            return String.Format($"Employee name: {EmpName}\nEmployee working hours: {EmpHours}\nEmployee break entitlement: {CalculateBreaks(EmpHours)} minutes \n\n ");
        }
    }
}
