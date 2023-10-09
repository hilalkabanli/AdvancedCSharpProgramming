﻿using HRAdministrationAPI;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SchoolHRAdministraion
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster

    }
    class Program
    {

        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();
            SeedData(employees);
            //foreach(IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}
            //Console.WriteLine($"total annual salaries (including bonus): {totalSalaries}");

            Console.WriteLine($"total annual salaries (including bonus): {employees.Sum(e => e.Salary)}");


            Console.ReadKey();
        }
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomas", 40000);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Brenda", "Mullins", 50000);
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Devlin", "Brown", 60000);
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Damien", "Jones", 80000);
            employees.Add(headMaster);
            //IEmployee teacher1 = new Teacher
            //{
            //    Id = 1,
            //    FirstName = "Bob",
            //    LastName = "Fisher",
            //    Salary = 40000,
            //};
            //employees.Add(teacher1);
            //IEmployee teacher2 = new Teacher
            //{
            //    Id = 2,
            //    FirstName = "Brad",
            //    LastName = "Pitt",
            //    Salary = 40000,
            //};
            //employees.Add(teacher1);
            //IEmployee headOfDepartment = new HeadOfDepartment
            //{
            //    Id = 3,
            //    FirstName = "Brenda",
            //    LastName = "Mullis",
            //    Salary = 50000,
            //};
            //employees.Add(headOfDepartment);
            //IEmployee deputyHeadMaster = new DeputyHeadMaster
            //{
            //    Id = 4,
            //    FirstName = "Devlin",
            //    LastName = "Brown",
            //    Salary = 60000,
            //};
            //employees.Add(deputyHeadMaster);
            //IEmployee headMaster = new HeadMaster
            //{
            //    Id = 5,
            //    FirstName = "Damien",
            //    LastName = "Jones",
            //    Salary = 80000,
            //};
            //employees.Add(headMaster);
        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }
    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }

    }
    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }

    }
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }

    }
    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                //case EmployeeType.Teacher:
                //    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                //    break;
                //case EmployeeType.HeadOfDepartment:
                //    employee = new HeadOfDepartment { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //case EmployeeType.DeputyHeadMaster:
                //    employee = new DeputyHeadMaster { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //case EmployeeType.HeadMaster:
                //    employee = new HeadMaster { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //default:
                //    break;
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;

            }
            else
            {
                throw new NullReferenceException();
            }
            return employee;
        }
    }
}