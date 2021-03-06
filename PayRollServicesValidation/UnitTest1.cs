using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollServicesADO;
using System.Collections.Generic;

namespace PayRollServicesValidation
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepository employeeRepository;
        EmployeeModel model;
        Transaction transaction;
        [TestInitialize]
        public void SetUp()
        {
            employeeRepository = new EmployeeRepository();
            model = new EmployeeModel();
            transaction = new Transaction();
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
        /// <summary>
        /// UC6-Aggregate Functions
        /// </summary>
        [TestMethod]
        [TestCategory("Using SQL Query for Male")]
        public void TestMethodForAggregateFunction_GroupByFemale()
        {
            string expected = "M 240000 55000 70000 60000 4";
           string Gender="M";
            string actual = employeeRepository.PerformAggregateFunctions(Gender);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("Using SQL Query for Female")]
        public void TestMethodForAggregateFunction_GroupByMale()
        {
            string expected = "F 30050000 50000 30000000 15025000 2";
            string Gender = "F";
            string actual = employeeRepository.PerformAggregateFunctions(Gender);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// Using ER Diagram Relationship -Retrieve the data using inner join
        /// </summary>
        
        [TestMethod]
        public void TestMethodForRetrieveDataUsingInnerJoin()
        {
            ERRepository eRRepository = new ERRepository();
            int expected = 4;
            var actual = eRRepository.RetrieveAllData();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Update the basicpay column and returns the data
        /// </summary>
        [TestMethod]
        public void TestMethodForUpdateQueryUsingErDiagramRelationShip()
        {
            ERRepository eRRepository = new ERRepository();
            int expected = 1;
            int actual = eRRepository.UpdateSalaryQuery();
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// Retruns the emploee details between date range
        /// </summary>
        [TestMethod]
        public void TestMethodForDateRangeUsingERDiagramRelationShip()
        {
            ERRepository eRRepository = new ERRepository();
            int expected = 2;
            int actual = eRRepository.DataBasedOnDateRange();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Performing aggreagte functions(sum,count,ab=vg,min,max)
        /// </summary>
        [TestMethod]
        public void TestMethodForPerformingAggregateFnUsingERDiagramRelationship()
        {
            ERRepository eRRepository = new ERRepository();
         
            string expected = "F 3135000 60000 3000000 1045000";
            string Gender = "F";
            string actual = eRRepository.PerformAggregateFunctions(Gender);
            Assert.AreEqual(expected, actual);
        }
        //------------------------Transcation Operation------------
        /// <summary>
        /// Insert the values in multiple tables(Using transcation)
        /// </summary>
        [TestMethod]
        public void TestMethodForInsertTheValuesInMultipleTables()
        {
            int expected = 1;
            int actual = transaction.InsertIntoTables();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Cascading Delete
        /// </summary>
        [TestMethod]
        public void TestMethodForCascadingDelete()
        {
            int expected = 1;
            int actual = transaction.DeleteUsingCasadeDelete();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodAddingNewColumnInEmployeeTable()
        {
            string expected = "IsActive Column Added";
            var actual = transaction.AddIsActiveColumn();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Maintain the list and set the IsActive for 0(non-employees)
        /// </summary>
        [DataTestMethod]
        public void TestMethodForAuditPurpose()
        {
            int expected = 1;
            Transaction transaction = new Transaction();
            int actual = transaction.MaintainListforAudit(1);
            Assert.AreEqual(actual, expected);
        }
        ///                                            *************Multi threading ***********
        /// <summary>
        /// UC1-Calcualting the time without using thread
        /// </summary>
        [TestMethod]
        public void TestMethodForWithoutUsingThread()
        {
            string query = null;
            bool expected = true;
            bool actual = transaction.ImplementingWithoutUsingThread(query);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC2-Calcualting the time using thread
        /// </summary>
        [TestMethod]
        public void TestMethodUsingThread()
        {
            string query = null;
            bool expected = true;
            bool actual = transaction.ImplementingUsingThread(query);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// UC3-->Using Synchronization(lock)--without thread
        /// </summary>
        [TestMethod]
        public void TestMethodForWithoutThreadUsingSynchronization()
        {
            string query = null;
            bool expected = true;
            bool actual = transaction.ImplementingWithoutUsingThread_Lock(query);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// UC3-->Using Synchronization(lock)--Using thread
        /// </summary>
        [TestMethod]
        public void TestMethod_For_With_Thread_Using_Synchronization()
        {
            string query = null;
            bool expected = true;
            bool actual = transaction.ImplementingWithUsingThread_Lock(query);
            Assert.AreEqual(expected, actual);
        }
    }
}
