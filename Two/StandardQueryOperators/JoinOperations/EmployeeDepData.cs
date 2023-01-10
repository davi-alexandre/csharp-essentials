using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Two.Collection_Interfaces.JoinOperations
{
    public class Starter
    {
        public static void Start()
        {
            
        }

        private static void GroupJoining()
        {
            IEnumerable<Department> departments = CorporateData.Departments;
            IEnumerable<Employee> employees = CorporateData.Employees;

            // Set up of an ONE-TO-MANY RELATIONSHIP - Department is normalized
            // Represent departments that have a collection of it's employees
            //
            var departmentsOfEmployees = departments.GroupJoin(
                employees,
                department => department.Id,
                employee => employee.DepartmentId,
                (department, employee) => new   // Department, IEnumerable<Employee>
                {
                    department.Id,
                    department.Name,
                    Employees = employee
                });
            //
            // Sets up a collection of employees inside each department
        }
        
        private static void Grouping ()
        {
            IEnumerable<Employee> employees = CorporateData.Employees; // list of employees
            IEnumerable<IGrouping<int, Employee>> employeeGroupList =  // list of groups
                employees.GroupBy(employee => employee.DepartmentId);

            foreach (IGrouping<int, Employee> employeeGroup in employeeGroupList)
            {
                WriteLine("DEPARMENT: ({1}) \t-\t EMPLOYEE COUNT: {0}", 
                    employeeGroup.Count(), employeeGroup.Key);


                foreach (Employee employee in employeeGroup)
                    WriteLine("\t" + employee);

                WriteLine();
            }
        }

        static void Joining()
        {
            IEnumerable<Department> departments = CorporateData.Departments;
            IEnumerable<Employee> employees = CorporateData.Employees;

            // Since an employee can be on only one department
            //      it is ok to think of employees as the link between them
            //
            // But, many employees can be on the same department.
            // Therefore, it isn't optimal to think of departments
            //      by the link they have with each employee
            //      because then Department would not be normalized
            // So, the reverse of the code below doesn't apply.
            //      [as in departments.Join(employees, ...]
            // Better to have departments objects holding collections 
            //      of employees, by coding a ONE-TO-MANY relationship


            // For each employee, join a department where
            //      employee.DepartmentId equals department.Id
            //
            var linkedList = employees.Join(        // outer
                departments,                        // inner
                employee => employee.DepartmentId,  // outerKeySelector
                department => department.Id,        // innerKeySelector
                (employee, department) => new
                {
                    employee.Id,
                    employee.Name,
                    employee.Title,
                    Department = department
                });
            //
            // The last parameter, the anonymous type, is the resultant tem that is selected
            // In this case, it is a class with Employee’s Id, Name, and
            //      Title as well as a Department property with the joined department object.
        }
    }

    #region Objects and Data
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public override string ToString()
        {
            return $"{ Name } ({ Title })";
        }
    }

    public static class CorporateData
    {
        public static readonly Department[] Departments =
        {
            new Department(){
                Name="Corporate", Id=0},
            new Department(){
                Name="Finance", Id=1},
            new Department(){
                Name="Engineering", Id=2},
            new Department(){
                Name="Information Technology", Id=3},
            new Department(){
                Name="Philanthropy", Id=4},
            new Department(){
                Name="Marketing", Id=5}
        };

        public static readonly Employee[] Employees = new Employee[]
        {
            new Employee(){
                Name="Mark Michaelis",
                Title="Chief Computer Nerd",
                DepartmentId = 0},
            new Employee(){
                Name="Michael Stokesbary",
                Title="Senior Computer Wizard",
                DepartmentId=2},
            new Employee(){
                Name="Brian Jones",
                Title="Enterprise Integration Guru",
                DepartmentId=2},
            new Employee(){
                Name="Shane Kercheval",
                Title="Chief Financial Officer",
                DepartmentId=1},
            new Employee(){
                Name="Pat Dever",
                Title="Enterprise Architect",
                DepartmentId = 3},
            new Employee(){
                Name="Kevin Bost",
                Title="Programmer Extraordinaire",
                DepartmentId = 2},
            new Employee(){
                Name="Thomas Heavey",
                Title="Software Architect",
                DepartmentId = 2},
            new Employee(){
                Name="Eric Edmonds",
                Title="Philanthropy Coordinator",
                DepartmentId = 4}
        };
    }
    #endregion
}
