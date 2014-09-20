namespace BugTracker.Repository.Tests
{
    using System;
    using System.Transactions;

    using BugTracker.Data;
    using BugTracker.Data.Repositories;
    using BugTracker.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DatabaseBugTrackerRepositoryTests
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void FindWhenObjectIsInDbShouldReturnObject()
        {
            // Arrange
            var bug = GetValidTestBug();

            var databaseContext = new BugTrackerDbContext();
            var repo = new EfRepository<Bug>(databaseContext);

            // Act
            databaseContext.Bugs.Add(bug);
            databaseContext.SaveChanges();

            var bugInDb = repo.Find(bug.Id);
            
            // Assert
            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void AddBugWhenBugIsValidShouldAddToDatabase()
        {
            // Arrange
            var bug = GetValidTestBug();

            var databaseContext = new BugTrackerDbContext();
            var repo = new EfRepository<Bug>(databaseContext) { bug };

            // Act
            repo.SaveChanges();

            var bugInDb = databaseContext.Bugs.Find(bug.Id);

            // Assert
            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        private static Bug GetValidTestBug()
        {
            var bug = new Bug { Text = "Test New bug", LogDate = DateTime.Now, Status = Status.Pending };
            return bug;
        }
    }
}