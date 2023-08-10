using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"The sum of numbers is {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"The average of number is {numbers.Average()}");
            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("Order by Ascending:");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in descending order and print to the console

            Console.WriteLine("Order by Descending");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6:");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Take 4");
            var orderNums = numbers.OrderBy(x => x).ToArray();

            foreach (var number in orderNums.Take(4))
            {

                Console.WriteLine(number);

            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Add age to index 4 in descending order");
            numbers.Select((number, index) => index == 4 ? 30 : number)
                 .OrderByDescending(x => x)
                 .ToList()
                 .ForEach(x => Console.WriteLine(x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employess First Name C and S:");
            var FiltertedEmployees = employees.Where(person => person.FirstName.StartsWith('C') | person.FirstName.StartsWith('S')).Orderby(person => person);

            foreach(var person in FiltertedEmployees) 
            { 
              Console.WriteLine(person.FirstName);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employess over 26");
            var employeesOver26 = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            foreach (var person in employeesOver26) 
            {
              Console.WriteLine($"Name: {person.FullName} |  Age: {person.Age}");
            
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var specialFilteredEmployees = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);

            Console.WriteLine($"Total of years that was experience: {specialFilteredEmployees.Sum(x => x.YearsOfExperience )}");
            Console.WriteLine($"Avg years of experience: {specialFilteredEmployees.Average(x => x.YearsOfExperience )}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Leroy", "Hawkins", 30, 2)).ToList();
            Console.WriteLine("Added employee:");

            foreach (var person in employees) 
            { 
             Console.Write($"{person.FirstName} | Age: {person.Age}");
            
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
