using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PayrollServicesADO
{
    public class EmployeeRepository
    {
        //Connecting to Database
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Services;Integrated Security=True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        //GetAllEmployee method
        public void GetAllEmployee()
        {
            try
            {
                SqlConnection sqlconnection1 = new SqlConnection(connectionString);
                using (sqlconnection1)
                {
                    //Creating object for employeemodel and access the fields
                    EmployeeModel employeeModel = new EmployeeModel();
                    //Retrieve query
                    string query = @"select * from employee_payroll";
                    this.sqlconnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    //Open the connection
                    //this.sqlconnection.Open();
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
        public int UpdateSalary(EmployeeModel model)
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
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
            finally
            {
                sqlconnection.Close();

            }

        }
        /// <summary>
        /// UC4--->Update the query using stored procedure
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSalaryUsingStoredProcedure(EmployeeModel model)
        {
            int result;
            try
            {
                using (this.sqlconnection)
                {
                    //EmployeeModel displayModel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("dbo.UpdateEmployeeDetails", this.sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("empId", model.empId);
                    command.Parameters.AddWithValue("empName", model.name);
                    command.Parameters.AddWithValue("BasicPay", model.BasicPay);
                    sqlconnection.Open();
                    result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated Successfully using stored procedure");

                    }
                    else
                    {
                        Console.WriteLine("Not Updated!!!");
                        return default;
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        /// <summary>
        /// UC4-Retrieve data using their name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public EmployeeModel RetrieveDataUsingTheirName(EmployeeModel model)
        {
            int result = 0;
            try
            {
                using (this.sqlconnection)
                {
                    //Passing the procedure and connection string
                    SqlCommand sqlCommand = new SqlCommand("dbo.spRetrieveDataUsingName", this.sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", model.name);
                    //Open  SQL Connection
                    sqlconnection.Open();
                    //SQL reader
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result++;

                            model.empId = Convert.ToInt32(reader["empId"]);
                            model.name = reader["name"].ToString();
                            model.BasicPay = Convert.ToDouble(reader["BasicPay"]);
                            model.startDate = reader.GetDateTime(3);
                            model.emailId = reader["emailId"].ToString();
                            model.Gender = reader["Gender"].ToString();
                            model.Department = reader["Department"].ToString();
                            model.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                            model.Address = reader["Address"].ToString();
                            model.Deductions = Convert.ToDouble(reader["Deductions"]);
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
                            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"]);
                            model.NetPay = Convert.ToDouble(reader["NetPay"]);
                            Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11} {12}", model.empId, model.name, model.BasicPay, model.startDate, model.emailId, model.Gender, model.Department, model.PhoneNumber, model.Address, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay);
                            Console.WriteLine("\n");
                        }
                        //Closing the reader object
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Closing the sql connection
                sqlconnection.Close();
            }
            return model;
        }
        /// <summary>
        /// UC5-Retrieve employee details based on date range
        /// </summary>
        /// <returns></returns>
        public int RetrieveDataBasedOnDateRange()
        {
            int count = 0;
            try
            {
                using (sqlconnection)
                {
                    //query execution
                    string query = @"select * from employee_payroll where startDate between('2021-05-01') and getdate()";
                    //passing the query and connection
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    //open sql connection
                    sqlconnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Calling the display method
                            DisplayEmployeeDetails(reader);
                            count++;
                        }
                    }
                    //close reader
                    reader.Close();
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
            return count;

        }
        /// <summary>
        ///DisplayEmployeeDetails method 
        /// </summary>
        /// <param name="reader"></param>
        public void DisplayEmployeeDetails(SqlDataReader reader)
        {
            //Creating object for Employeemodel which has fields
            EmployeeModel model = new EmployeeModel();


            model.empId = Convert.ToInt32(reader["empId"]);
            model.name = reader["name"].ToString();
            model.BasicPay = Convert.ToDouble(reader["BasicPay"]);
            model.startDate = reader.GetDateTime(3);
            model.emailId = reader["emailId"].ToString();
            model.Gender = reader["Gender"].ToString();
            model.Department = reader["Department"].ToString();
            model.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
            model.Address = reader["Address"].ToString();
            model.Deductions = Convert.ToDouble(reader["Deductions"]);
            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"]);
            model.NetPay = Convert.ToDouble(reader["NetPay"]);

            Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11} {12}", model.empId, model.name, model.BasicPay, model.startDate, model.emailId, model.Gender, model.Department, model.PhoneNumber, model.Address, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay);
            Console.WriteLine("\n");

        }
        /// <summary>
        /// UC6-Performing aggregate functions
        /// </summary>
        /// <param name="Gender"></param>
        /// <returns></returns>
        public string PerformAggregateFunctions(string Gender)
        {
            string result = null;
            try
            {
                string query = @"select sum(BasicPay) as TotalSalary,min(BasicPay) as MinSalary,max(BasicPay) as MaxSalary,Round(avg(BasicPay),0) as AvgSalary,Gender,Count(*) from employee_payroll where Gender =" + "'" + Gender + "'" + " group by Gender";
                SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);
                sqlconnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Total Salary {0}", reader[0]);
                        Console.WriteLine("Min Salary {0}", reader[1]);
                        Console.WriteLine("Max Salary {0}", reader[2]);
                        Console.WriteLine("Average Salary {0}", reader[3]);
                        Console.WriteLine("Grouped By Gender {0}", reader[4]);
                        Console.WriteLine("No of employess {0}", reader[5]);
                        result += reader[4] + " " + reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[5];
                    }
                }
                else
                {
                    result = "empty";
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
            return result;
        }
    }
}

