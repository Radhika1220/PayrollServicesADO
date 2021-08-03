using System;

namespace PayrollServicesADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a object for employeerepository
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            Console.WriteLine("1:To Retrieve all Data from Sql server");
             Console.WriteLine ("2:To Update Salary to 3000000");
            Console.WriteLine("3.Update the Salary Using Stored Procedure");
            //Calling the method
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    repository.GetAllEmployee();
                    break;
                case 2:
                    repository.UpdateSalary(model);
                    repository.GetAllEmployee();
                    break;
                case 3:
                    model.empId = 1;
                    model.name = "Radhika";
                    model.BasicPay = 300000;
                    repository.UpdateSalaryUsingStoredProcedure(model);
                    EmployeeRepository repo = new EmployeeRepository();
                    repo.GetAllEmployee();
                    break;
             
            }
        }
        }
    }

