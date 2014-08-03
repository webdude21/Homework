namespace PhonebookConsoleTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phonebook.Contracts;
    using Phonebook.Repositories;

    [TestClass]
    public class PhonebookRepositoryTests
    {
        private readonly IPhonebookRepository phonebookRepository;

        private readonly IEnumerable<string> testPhoneNumbers;

        private const string TestName = "Kalina";

        public PhonebookRepositoryTests()
        {
            this.testPhoneNumbers = new SortedSet<string> { "0899 777 235", " 02 / 981 11 11", "(+359) 899777236" };
            this.phonebookRepository = new PhonebookRepository();
        }

        [TestMethod]
        public void AddingNewPhoneContactNameShouldReturnTrue()
        {
            var isNewEntry = this.phonebookRepository.AddPhone(TestName, this.testPhoneNumbers);
            Assert.AreEqual(isNewEntry, true);
        }

        [TestMethod]
        public void AddingAnExistingContactNameShouldReturnFalseRegardlessOfTheNameCasing()
        {
            this.phonebookRepository.AddPhone("Kalina", this.testPhoneNumbers);
            var isNewEntry = this.phonebookRepository.AddPhone("KALINA", this.testPhoneNumbers);
            Assert.AreEqual(isNewEntry, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CallingListWithInvalidRangeShouldThrowAnException()
        {
            this.phonebookRepository.ListEntries(10, 10);
        }

        [TestMethod]
        public void CallingListWithValidRangeShouldReturnACorrectListOfPhoneRecords()
        {

            var kalinaContact = new PhoneContact(TestName) { PhoneEntries = (SortedSet<string>)this.testPhoneNumbers };
            this.phonebookRepository.AddPhone(TestName, this.testPhoneNumbers);
            var listResult = this.phonebookRepository.ListEntries(0, 1);
            CollectionAssert.AreEquivalent(new[] { kalinaContact }, new[] { listResult });
        }
    }
}