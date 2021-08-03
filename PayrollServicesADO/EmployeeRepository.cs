using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PayrollServicesADO
{
    public class EmployeeRepository
    {
        /// <summary>
        /// UC1-Sql server connection
        /// </summary>
        //Connecting to Database
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Services;Integrated Security=True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        /// <summary>
        /// UC2-Retrieve the data(select query)
        /// </summary>
        public void GetAllEmployee()
        {     
            try
            {
                //Creating object for employeemodel and access the fields
                EmployeeModel employeeModel = new EmployeeModel();
                //Retrieve query
                string query = @"select * from employee_payroll";

                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                //Open the connection
                this.sqlconnection.Open();
                //ExecuteReader: Returns data as rows.
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        employeeModel.empId = Convert.ToInt32(reader["empId"]);
                        employeeModel.name = reader["name"].ToString();
                        employeeModel.BasicPay = Convert.ToDouble(reader["BasicPay"]);
                        employeeModel.startDate = reader.GetDateTime(3);
                        employeeModel.emailId = reader["emailId"].ToString();
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.Department = reader["Department"].ToString();
                        employeeModel.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                        employeeModel.Address = reader["Address"].ToString();
                        employeeModel.Deductions = Convert.ToDouble(reader["Deductions"]);
                        employeeModel.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
                        employeeModel.IncomeTax = Convert.ToDouble(reader["IncomeTax"]);
                        employeeModel.NetPay = Convert.ToDouble(reader["NetPay"]);
                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11} {12}", employeeModel.empId, employeeModel.name, employeeModel.BasicPay, employeeModel.startDate, employeeModel.emailId, employeeModel.Gender, employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.IncomeTax, employeeModel.NetPay);
                        Console.WriteLine("\n");
                    }

                }
                else
                {
                    Console.WriteLine("No data found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        /// <summary>
        /// UC3-Update the salary data using query for particular data
        /// </summary>
        /// <param name="model"></param>
        public void UpdateSalary(EmployeeModel model)
        {
            try
            { 
                    sqlconnection.Open();
                   string query = @"update employee_payroll set BasicPay=3000000 where name='Radhika'";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                   
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Salary Updated Successfully ");
                    }
                    else
                    {
                        Console.WriteLine("Unsuccessfull");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconnection.Close();

            }
         
        }
    }
}
