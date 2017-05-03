using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Furniture.Models;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace BankCredit.DAL
{
    public class DataAccessEmployee
    {

        public string connString;
        public List<Employee> productList;


        public DataAccessEmployee()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";

            productList = new List<Employee>();


        }

        internal void Raport()
        {
            productList = RetrieveEmployee();
            string path = @"D:\Facultate\Anul 3\SemII\PS\Assigment\Assigment2\Send2\Tomus_AlexandraFurniture\BankCredit-master\XML\Employee.xml";
            var stoc = productList.ToList();

            // var stoc = productList.Where(book => book.ID == 2 || book.FullName.Equals("1")).ToList();

            try
            {
                if (!File.Exists(path))
                {

                    using (StreamWriter sw = File.CreateText(path))
                    {
                     
                        sw.WriteLine("<?xml version=" +"\""+ "1.0" +"\""+ " encoding=" +"\""+ "UTF-8" + "\"" + "?>");
                   
                        sw.WriteLine("<Employees>");
                        foreach (Employee b in stoc)
                        {
                            sw.WriteLine(" <Employee>");
                            sw.WriteLine("  <ID>" + b.ID + "</ID>");
                            sw.WriteLine("  <FullName>" + b.FullName + "</FullName>");
                            sw.WriteLine("  <Date>" + b.DateOfBirth + "</Date>");
                            sw.WriteLine(" </Employee>");

                        }
                        sw.WriteLine("</Employees>");
                    }

                  
                

                }
                else
                {
                    File.Delete(path);
                    Raport();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Eroare generare raport!");
            }

            MessageBox.Show("Raport generat cu succes!");
        }


    public List<Employee> RetrieveEmployee()
       {
            List<Employee> employeeList = new List<Employee>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = reader.GetInt32("Id");
                        employee.UserName = reader.GetString("UserName");
                        // employee.Password = reader.GetString("Password");
                        employee.firstName = reader.GetString("FirstName");
                        employee.lastName = reader.GetString("LastName");
                        // employee.IsAdmin = reader.GetBoolean("isAdmin");
                        //s employee.DateOfBirth = reader.GetDateTime("DateOfBirth");
                        employeeList.Add(employee);
                    }
                }
            }

            return employeeList;
        }



        public void AddEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Users(UserName, Password, FirstName, LastName, IsAdmin, DateOfBirth) VALUES(@username, @password, @firstname, @lastname, @isadmin, @birthdate)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", employee.UserName);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@firstname", employee.firstName);
                cmd.Parameters.AddWithValue("@lastname", employee.lastName);
                cmd.Parameters.AddWithValue("@isadmin", employee.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", employee.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Users WHERE username = @username";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", employee.UserName);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@firstname", employee.firstName);
                cmd.Parameters.AddWithValue("@lastname", employee.lastName);
                cmd.Parameters.AddWithValue("@isadmin", employee.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", employee.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Users SET password = @password, firstname = @firstname, lastname = @lastname WHERE username = @username";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", employee.UserName);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@firstname", employee.firstName);
                cmd.Parameters.AddWithValue("@lastname", employee.lastName);
                cmd.Parameters.AddWithValue("@isadmin", employee.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", employee.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }




    }
}


