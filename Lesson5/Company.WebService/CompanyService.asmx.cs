using Person.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Company.WebService
{
    /// <summary>
    /// Summary description for CompanyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CompanyService : System.Web.Services.WebService
    {
        private string ConnectionString = "Data Source=DESKTOP-QTQ7ASM\\SQLEXPRESS; Initial Catalog=Company; User ID=user1; Password=user; TRUSTED_CONNECTION = TRUE";
                     
        [WebMethod]
        public int Add(Employee employee)
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

        [WebMethod]
        public ObservableCollection<Employee> Load()
        {
            ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
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

                    return Employees;
                }
            }
        }

        [WebMethod]
        public int Update(Employee employee)
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
                                          where ID = '{employee.ID}'; begin transaction commit;";

                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();

                return res;
            }
        }

        [WebMethod]
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
    }
}
