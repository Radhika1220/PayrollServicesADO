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
        [TestCategory("UpdateQuery")]
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
        [TestCategory("UpdateQuery")]
        public void TestUpdateQueryUsingStoredProcedure()
        {
            int expected = 1;
            model.empId = 1;
            model.name = "Radhika";
            model.BasicPay = 30000000;
            int actual = employeeRepository.UpdateSalaryUsingStoredProcedure(model);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// UC4-Retrieve data using their name
        /// </summary>
        [TestMethod]
        [TestCategory("RetrieveDataUsingName")]
        public void TestMethodForRetrieveDataBasedOnName()
        {
            model.name = "Arun";
            var actual = employeeRepository.RetrieveDataUsingTheirName(model);
            Assert.AreEqual(model.name, actual.name);
        }
        /// <summary>
        /// UC5-Reeturn the count of details between the date range
        /// </summary>
        [TestMethod]
        public void TestMethodForDateRange()
        {
            int expected = 4;
            var actual = employeeRepository.RetrieveDataBasedOnDateRange();
            Assert.AreEqual(actual, expected);
        }
    }
}
