namespace PhonebookConsoleTests
{
    using System;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phonebook;

    [TestClass]
    public class PhonebookManagerTests
    {
        private readonly PhonebookManager phoneBookManager;

        public PhonebookManagerTests()
        {
            this.phoneBookManager = new PhonebookManager("+359", new PhonebookRepositorySlow(), new StringBuilder());
        }

        [TestMethod]
        public void AddingANewPhoneNumberShouldReturnTheCorrectMessage()
        {
            const string TestCommand = "AddPhone(Kalina, 0899 777 235, 02 / 981 11 11)";
            var expectedMessage = "Phone entry created" + System.Environment.NewLine;
            var actualResultMessage = this.TestCommandRunner(TestCommand);
            Assert.AreEqual(expectedMessage, actualResultMessage);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SendingInvalidCommandShouldThrowAnException()
        {
            this.TestCommandRunner("non existing command");
        }

        public string TestCommandRunner(string currentCommandLine)
        {
            this.phoneBookManager.ExecuteCommand(currentCommandLine);
            return this.phoneBookManager.ReportResult;
        }
    }
}