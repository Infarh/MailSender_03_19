using System;
using System.Linq;
using MailSender.lib.Entityes;
using MailSender.lib.Services;
using MailSender.lib.Services.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Services
{
    [TestClass]
    public class EmailsDataInMemoryTests
    {
        [AssemblyInitialize]
        public static void TestAssemblyInitialize(TestContext Context)
        {
            
        }

        [ClassInitialize]
        public static void TestClassInitialize(TestContext Context)
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void TestClassCleanup()
        {

        }

        [AssemblyCleanup]
        public static void TestAssemblyCleanup()
        {

        }

        [TestMethod]
        public void Creation()
        {
            var emails_data = new EmailsDataInMemory();
        }


        [TestMethod, Description("Описание теста"), Timeout(1000)]
        public void Add_New_Email_With_ID_Eq_1()
        {
            // A-A-A

            // Arrange
            var emails_data = new EmailsDataInMemory();
            var email = new Email();
            var expected_id = 1;
            var expected_count = 1;

            // Act
            emails_data.Add(email);
            var db_email = emails_data.GetById(1);
            var actual_id = db_email.Id;
            var actual_count = emails_data.GetAll().Count();

            // Assert
            Assert.AreEqual(expected_id, actual_id);
            Assert.AreEqual(expected_count, actual_count);

            //StringAssert.
            //CollectionAssert.
        }
    }
}
