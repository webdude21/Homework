namespace Cars.Tests.JustMock
{
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Tests.JustMock.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarRepositoryTests
    {
        private readonly IDatabase carsData;

        private CarsController controller;

        public CarRepositoryTests(CarsController controller)
            : this(new JustMockDatabase(), controller)
        {
        }

        public CarRepositoryTests(IDatabase database, CarsController controller)
        {
            this.carsData = database;
            this.Controller = controller;
        }

        public IDatabase CarsData
        {
            get
            {
                return this.carsData;
            }
        }

        public CarsController Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}