using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEmpHoursCalculator
{
    public class Validator
    {
        //Validation Class, Used to return a key value pair for validating the hours worked input
        public static KeyValuePair<bool, int> ValidateHoursWorked(string hrsWorked)
        {

            bool success = int.TryParse(hrsWorked, out int hoursWorked);

            if (success)
            {
                return new KeyValuePair<bool, int>(success, hoursWorked);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter a valid input");
            Console.ResetColor();

            return new KeyValuePair<bool, int>(success, hoursWorked);

        }
    }

}
