using System;

namespace PayrollServicesADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a object for employeerepository
            EmployeeRepository repository = new EmployeeRepository();
            //Calling the method
            repository.GetAllEmployee();
        }
    }
}
