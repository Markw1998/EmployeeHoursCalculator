using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEmpHoursCalculator
{
    internal class Program
    {
        static List<Employee> EmployeesList = new List<Employee>();
        static void Main(string[] args)
        {
            GetInfo();
        }


        //Get Employee's information and store it
        private static void GetInfo()
        {
            Employee newEmp = new Employee();

            Console.WriteLine("Please enter employee name:");
            newEmp.EmpName = Console.ReadLine();

            Console.WriteLine("How many hours is this employee working?");
            newEmp.EmpHours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please specify your shift:");
            Console.WriteLine("1. Day Shift");
            Console.WriteLine("2. Night Shift");
            Console.WriteLine("3. Split Shift");

            Console.Write("Enter here: ");
            newEmp.EmpShiftType = Convert.ToInt32(Console.ReadLine());

            newEmp.EmpBreakTime = CalculateBreaks(newEmp);

            EmployeesList.Add(newEmp);

            ContinueOption();

        }

        private static void ContinueOption()
        {
            Console.WriteLine("Would you like to add another employee? (Y/N)");
            string userInput = Console.ReadLine().ToUpper();

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

        private static int CalculateBreaks(Employee emp)
        {

            switch (emp.EmpShiftType)
            {

                case 1:
                    
                    int breakTime = emp.EmpHours * 10;

                    int additionalMinutes = emp.EmpHours / 4;

                    for (int i = 0; i < additionalMinutes; i++)
                    {
                        breakTime += 20;
                    }

                    return emp.EmpBreakTime = breakTime;


                case 2:
                    int breakTimeTwo = emp.EmpHours * 15;

                    int additionalMinutesTwo = emp.EmpHours / 4;

                    for (int i = 0; i < additionalMinutesTwo; i++)
                    {
                        breakTimeTwo += 30;
                    }

                    return emp.EmpBreakTime = breakTimeTwo;


                case 3:
                    int breakTimeThree = emp.EmpHours * 10;

                    int additionalMinutesThree = emp.EmpHours / 3;

                    for (int i = 0; i < additionalMinutesThree; i++)
                    {
                        breakTimeThree += 20;
                    }

                    return emp.EmpBreakTime = breakTimeThree;

                default:
                    return 0;
            }
        }

        private static void DisplayEmployees()
        {
            Console.Clear();

            Console.WriteLine("Please see each inputted employees information below:");

            foreach (var employee in EmployeesList)
            {
                Console.WriteLine($"Employee name: {employee.EmpName} ");
                Console.WriteLine($"Employee working hours: {employee.EmpHours} ");
                Console.WriteLine($"Employee break entitlement: {employee.EmpBreakTime} minutes \n\n");

            }
        }
    }
}
