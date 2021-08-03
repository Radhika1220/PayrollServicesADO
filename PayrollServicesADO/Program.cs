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
            Console.WriteLine("Enter 1-To Retrieve all Data from Sql server\nEnter 2-To Update Salary to 3000000\n");
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
            }
        }
    }
}
