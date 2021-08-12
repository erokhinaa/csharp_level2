using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Communication.CompanyService
{
    public partial class Employee : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Employee() { } // Конструктор по умолчанию

        public Employee(int id, string lastname, string firstname, string secondname, string position)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;

            Works = true;
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, EmployeeCategory category)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;

            Works = true;
            Category = category;
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, EmployeeCategory category, Department department)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;

            Works = true;
            Category = category;
            this.department = department;
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, EmployeeCategory category, Department department, bool works)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;

            Works = works;
            Category = category;
            this.department = department;
        }

    }
}
