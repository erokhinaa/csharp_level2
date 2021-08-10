using Person.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Company
{
    public class Database
    {
        // private string pcname = Environment.MachineName; 
        //private string ConnectionString = $@"Data Source={pcname}\SQLEXPRESS; Initial Catalog=Company; User ID=user1; Password=user; TRUSTED_CONNECTION = TRUE";
        private string ConnectionString = "Data Source=DESKTOP-QTQ7ASM\\SQLEXPRESS; Initial Catalog=Company; User ID=user1; Password=user; TRUSTED_CONNECTION = TRUE";

        //public List<Employee> Employees { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public int AddToDB(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var Works = employee.Works ? 1 : 0;
                string sqlExpression = $@"insert into Employees (ID, LastName, FirstName, SecondName, Position, Categoryid, Departmentid, Works) 
                                                         values ({employee.ID}, '{employee.LastName}', '{employee.FirstName}', '{employee.SecondName}', '{employee.Position}', '{((int)Data.EmployeeCategory.FullTime)}', '{((int)Data.Department.IT)}', {Works});";

                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
            
                return res;
            }
        }

        public void LoadFromDB()
        {
            Employees = new ObservableCollection<Employee>();
            string sqlExpression = "select ID, LastName, FirstName, SecondName, Position, Categoryid, Departmentid, Works, Comment from Employees;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee()
                            {
                                ID = (int)reader.GetValue(0),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                SecondName = reader["SecondName"].ToString(),
                                Position = reader["Position"].ToString(),
                                Category = (Data.EmployeeCategory)reader.GetInt32(5),
                                department = (Data.Department)reader.GetInt32(6),
                                Works = reader.GetBoolean(7),
                                Comment = reader["Comment"].ToString()
                            };

                        Employees.Add(employee);
                        }                        
                    }
                }                
            }
        }

        public int UpdateDB(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var Works = employee.Works ? 1 : 0;
                string sqlExpression = $@"update Employees set 
                                                LastName = '{employee.LastName}', 
                                                FirstName = '{employee.FirstName}', 
                                                SecondName = '{employee.SecondName}', 
                                                Position = '{employee.Position}', Categoryid = '{((int)Data.EmployeeCategory.FullTime)}', 
                                                Departmentid = '{((int)Data.Department.IT)}', 
                                                Works = '{Works}', 
                                                Comment = '{employee.Comment}'
                                          where ID = '{employee.ID}'; begin transaction commit;" ;

                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();

                return res;
            }
        }

        // Тестовый метод для очистки таблицы Employees перед запуском приложения
        public void DeleteFromEmployees()
        {
            string sqlExpression = "delete from Employees; begin transaction commit;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();                
            }
        }

        public Database()
        {
            // Загружаем данные из БД
            LoadFromDB();
            /*
            Employees = new ObservableCollection<Employee>();
            Employees.Add(new Employee(1, "Иванов","Иван","Иванович","Программист", Data.EmployeeCategory.FullTime,Data.Department.IT));
            Employees.Add(new Employee(2, "Александров", "Александр", "Александрович", "Программист", Data.EmployeeCategory.FullTime, Data.Department.IT));
            Employees.Add(new Employee(3, "Андреев", "Андрей", "Андреевич", "Тестировщик", Data.EmployeeCategory.FullTime, Data.Department.IT));
            Employees.Add(new Employee(4, "Петров", "Петр", "Петрович", "Администратор", Data.EmployeeCategory.FullTime, Data.Department.IT));
            Employees.Add(new Employee(5, "Олегов", "Олег", "Олегович", "Начальник отдела", Data.EmployeeCategory.FullTime, Data.Department.IT));
            
            Employees.Add(new Employee(1, "Иванов", "Иван", "Иванович", "Программист"));
            Employees.Add(new Employee(2, "Александров", "Александр", "Александрович", "Программист"));
            Employees.Add(new Employee(3, "Андреев", "Андрей", "Андреевич", "Тестировщик"));
            Employees.Add(new Employee(4, "Петров", "Петр", "Петрович", "Администратор"));
            Employees.Add(new Employee(5, "Олегов", "Олег", "Олегович", "Начальник отдела"));
            */
        }
    }
}
