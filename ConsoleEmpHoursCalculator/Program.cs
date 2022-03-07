using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEmpHoursCalculator
{
    internal class Program
    {
        //Instantiating a List of type Employee to track employees
        static List<Employee> EmployeesList = new List<Employee>();

        static void Main(string[] args)
        {
            //Begin the Application by getting the information
            GetInfo();
        }

        //Get Employee's information and store it
        private static void GetInfo()
        {

            Console.WriteLine("Please enter employee name:");
            string empName = Console.ReadLine();

            Console.WriteLine("\nHow many hours is this employee working?");
            string empHours = Console.ReadLine();
            KeyValuePair<bool, int> empHoursValidated = Validator.ValidateHoursWorked(empHours);

            while (!empHoursValidated.Key)
            {
               Console.WriteLine("\nHow many hours is this employee working?");
               empHours = Console.ReadLine();
               empHoursValidated = Validator.ValidateHoursWorked(empHours);

            }

            Console.Clear();

            Console.WriteLine("Please specify your shift:");
            Console.WriteLine("1. Day Shift");
            Console.WriteLine("2. Night Shift");
            Console.WriteLine("3. Split Shift\n");

            Console.Write("Enter here: ");
            int EmpShiftType = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            {

                switch (EmpShiftType)
                {
                    case 1:
                        Employee dayEmp = new Employee(empName, empHoursValidated.Value);

                        dayEmp.CalculateBreaks(empHoursValidated.Value);

                        //Adding the employee to the list.
                        EmployeesList.Add(dayEmp);


                        break;
                    case 2:
                        Employee nightEmp = new NightShiftEmployee(empName, empHoursValidated.Value);

                        nightEmp.CalculateBreaks(empHoursValidated.Value);

                        //Adding the employee to the list.
                        EmployeesList.Add(nightEmp);


                        break;

                    case 3:

                        Employee splitEmp = new SplitShiftEmployee(empName, empHoursValidated.Value);

                        splitEmp.CalculateBreaks(empHoursValidated.Value);

                        //Adding the employee to the list.
                        EmployeesList.Add(splitEmp);

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid input");
                        Console.ResetColor();
                        GetInfo();
                        Console.Clear();
                        break;
                }

                //Calling ContinueOption function to check if user wants to continue
                ContinueOption();
            }

        }

        //Checks Users Input if they want to continue adding employees
        private static void ContinueOption()
        {
            Console.WriteLine("Would you like to add another employee? (Y/N)");
            string userInput = Console.ReadLine().ToUpper();

            //If Y then go back to GetInfo function and create another employee, else if N - Call the DsiplayEmployees function, else invalid input.
            if (userInput == "Y")
            {
                GetInfo();
            }
            else if (userInput == "N")
            {
                DisplayEmployees();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter Y or N as a valid value");
                Console.ResetColor();

                ContinueOption();
            }
        }

        //Calculate the breaks in minutes based off the users Shift.
        //private static int CalculateBreaks(Employee emp)
        //{

        //    switch (emp.EmpShiftType)
        //    {
        //        //Day shift
        //        case 1:
        //            // Getting the employees are and multiplyiong by 10 minutes. (10 mins break for every hour)
        //            int breakTime = emp.EmpHours * 10;

        //            //// Calculating the employees additional minutes by dividing the hours by 4 and adding 20 minutes to their break time.
        //            //// (20 mins extra break for every 4 hours)
        //            int numberOf = (emp.EmpHours * 60) / 240;

        //            int additionalMinutes = numberOf * 20;


        //            // Break out and return the value
        //            return emp.EmpBreakTime = breakTime + additionalMinutes;

        //        //Night shift
        //        case 2:
        //            // Getting the employees are and multiplyiong by 15 minutes. (15 mins break for every hour)
        //            int breakTimeTwo = emp.EmpHours * 15;


        //            // Calculating the employees additional minutes by dividing the hours by 4 and adding 30 minutes to their break time.
        //            // (30 mins extra break for every 4 hours)

        //            for (int i = 0; i < emp.EmpHours / 4; i++)
        //            {
        //                breakTimeTwo += 30;
        //            }

        //            // Break out and return the value
        //            return emp.EmpBreakTime = breakTimeTwo;

        //        //Split shift
        //        case 3:
        //            // Getting the employees are and multiplyiong by 10 minutes. (10 mins break for every hour)
        //            int breakTimeThree = emp.EmpHours * 10;

        //            // Calculating the employees additional minutes by dividing the hours by 3 and adding 20 minutes to their break time.
        //            // (20 mins extra break for every 3 hours)
        //            for (int i = 0; i < emp.EmpHours / 3; i++)
        //            {
        //                breakTimeThree += 20;
        //            }
        //            // Break out and return the value
        //            return emp.EmpBreakTime = breakTimeThree;

        //        default:
        //            return 0;
        //    }


        //Display all employees entered information including break times in minutes
        private static void DisplayEmployees()
        {
            //Clear the console
            Console.Clear();

            //Output the information
            Console.WriteLine("Please see each inputted employees information below:\n");

            //Loop through each employee in the list and display their information
            foreach (var employee in EmployeesList)
            {
                Console.WriteLine(employee.ToString()); ;
            }
        }
    }
}
