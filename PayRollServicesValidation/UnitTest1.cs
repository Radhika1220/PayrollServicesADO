using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollServicesADO;

namespace PayRollServicesValidation
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepository employeeRepository;
        EmployeeModel model;
        [TestInitialize]
        public void SetUp()
        {
            employeeRepository = new EmployeeRepository();
            model = new EmployeeModel();
        }
        /// <summary>
        /// UC3-update the salary query 
        /// </summary>
        [TestMethod]
        public void TestUpdateQuery()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            int expected = 1;
            int actual = employeeRepository.UpdateSalary(employeeModel);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// UC4-Update the query using stored procedure
        /// </summary>
        [TestMethod]
        public void TestUpdateQueryUsingStoredProcedure()
        {
            int expected = 1;
            model.empId = 1;
            model.name = "Radhika";
            model.BasicPay = 30000000;
            int actual = employeeRepository.UpdateSalaryUsingStoredProcedure(model);
            Assert.AreEqual(actual, expected);
        }
    }
}
