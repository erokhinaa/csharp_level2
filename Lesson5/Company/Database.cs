using Person.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Database
    {
        public List<Employee> Employees { get; set; }
        public object Persons { get; set; }

        public Database()
        {
            Employees = new List<Employee>();
            /*Employees.Add(new Employee(1, "Иванов","Иван","Иванович","Программист",true,Data.EmployeeCategory.FullTime,Data.Department.IT));
            Employees.Add(new Employee(2, "Александров", "Александр", "Александрович", "Программист", true, Data.EmployeeCategory.FullTime, Data.Department.IT));
            Employees.Add(new Employee(3, "Андреев", "Андрей", "Андреевич", "Тестировщик", true, Data.EmployeeCategory.FullTime, Data.Department.IT));
            Employees.Add(new Employee(4, "Петров", "Петр", "Петрович", "Администратор", true, Data.EmployeeCategory.FullTime, Data.Department.IT));
            Employees.Add(new Employee(5, "Олегов", "Олег", "Олегович", "Начальник отдела", true, Data.EmployeeCategory.FullTime, Data.Department.IT));
            */
            Employees.Add(new Employee(1, "Иванов", "Иван", "Иванович", "Программист"));
            Employees.Add(new Employee(2, "Александров", "Александр", "Александрович", "Программист"));
            Employees.Add(new Employee(3, "Андреев", "Андрей", "Андреевич", "Тестировщик"));
            Employees.Add(new Employee(4, "Петров", "Петр", "Петрович", "Администратор"));
            Employees.Add(new Employee(5, "Олегов", "Олег", "Олегович", "Начальник отдела"));

        }
    }
}
