namespace TryConvertDemo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using TryConvertLibrary.Core;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<int,string> dict = new Dictionary<int, string>() 
            {
                { 1, "value1" },
                { 2, "value2" }
            };

            string text = TryConvert.ToString(dict);

            string t1 = TryConvert.ToCapitalize("test");

            string t2 = TryConvert.ToCapitalizeWords("test.hallo.Test", "hallo");

            Tuple<int, string, Guid> tuple = new Tuple<int, string, Guid>(1, "Gerhard", Guid.NewGuid());
            string t3 = TryConvert.ToString(tuple);

            var employee = new Employee()
            {
                Id = 5,
                Birthday = new DateTime(1960,6,28),
                Firstname = "Gerhard",
                Age = 61,
                Salary = 1600
            };

            Person person = TryConvert.ToMap<Employee, Person>(employee);

            Employee employeeB = new EmployeeDto
            {
                Id = 1,
                Firstname = "Gerhard",
                Lastname = "Ahrens"
            };

            Debug.WriteLine($"{employeeB.Firstname}; Typ:{employeeB.GetType().Name}");

            EmployeeDto employeeC = new Employee
            {
                Id = 1,
                Firstname = "Gerhard",
                Lastname = "Ahrens", 
                IsActive = true
            };

            Debug.WriteLine($"{employeeC.Firstname}; Typ:{employeeC.GetType().Name}");

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }
    }

    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public static implicit operator EmployeeDto(Employee value)
        {
            return new EmployeeDto
            {
                Id = value.Id,
                Firstname = value.Firstname,
                Lastname = value.Lastname
            };
        }

        public static implicit operator Employee(EmployeeDto value)
        {
            return new Employee
            {
                Id = value.Id,
                Firstname = value.Firstname,
                Lastname = value.Lastname,
                IsActive = false
            };
        }
    }
    public class Employee
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
    }
}
