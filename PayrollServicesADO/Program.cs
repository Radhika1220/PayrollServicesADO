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
            Console.WriteLine("4.Retrieve Data Using Name ");
            Console.WriteLine("5.Retrieve employee details between the date range");
            Console.WriteLine("6.Performing Aggregate functions");
            Console.WriteLine("*******Using ER Diagram Relationship***************");
            Console.WriteLine("7.Retrieve data from sql server");
            Console.WriteLine("8.Update Salary data in table");
            Console.WriteLine("9.Print the employee details between date range");
            Console.WriteLine("10.Performing Aggregate Functions");
            Console.WriteLine("*******Transcation **********");
            Console.WriteLine("11.Insert into Tables");
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
                case 4:
                    EmployeeModel model1 = new EmployeeModel();
                    model1.name = "Arun";
                    repository.RetrieveDataUsingTheirName(model1);
                    break;
                case 5:
                    EmployeeRepository repository1 = new EmployeeRepository();
                    repository1.RetrieveDataBasedOnDateRange();
                    break;
                case 6:
                    EmployeeRepository repository2 = new EmployeeRepository();
                    repository2.PerformAggregateFunctions("F");
                    break;
                case 7:
                    ERRepository eRRepository = new ERRepository();
                    eRRepository.RetrieveAllData();
                    break;
                case 8:
                    ERRepository eRRepository1 = new ERRepository();
                    eRRepository1.UpdateSalaryQuery();
                    break;
                case 9:
                    ERRepository eRRepository2 = new ERRepository();
                    eRRepository2.DataBasedOnDateRange();
                    break;
                case 10:
                    ERRepository eRRepository3 = new ERRepository();      
                    eRRepository3.PerformAggregateFunctions("F");
                    break;
                case 11:
                    Transaction transaction = new Transaction();
                    transaction.InsertIntoTables();
                    break;
            }
        }
     }
}

