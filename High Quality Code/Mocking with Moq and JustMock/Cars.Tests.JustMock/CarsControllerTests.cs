namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;

        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car { Id = 15, Make = string.Empty, Model = "330d", Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car { Id = 15, Make = "BMW", Model = string.Empty, Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car { Id = 15, Make = "BMW", Model = "330d", Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchForCarModelShouldReturnTheCorrectRecord()
        {
            const string SearchPattern = "BMW";
            var searchResult = (IEnumerable<Car>)GetModel(() => this.controller.Search(SearchPattern));

            foreach (var item in searchResult)
            {
                Assert.AreEqual(item.Make, SearchPattern);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PassingInvalidSortParametersShouldThrowAnException()
        {
            var searchResult = (IEnumerable<Car>)GetModel(() => this.controller.Sort("Invalid"));
        }

        [TestMethod]
        public void SelectingSortByMakeShouldCallTheCorrectMethod()
        {
            var searchResult = (IEnumerable<Car>)GetModel(() => this.controller.Sort("make"));
            Mock.Assert(this.carsData);
        }

        [TestMethod]
        public void SelectingSortByYearShouldCallTheCorrectMethod()
        {
            var searchResult = (IEnumerable<Car>)GetModel(() => this.controller.Sort("year"));
            Mock.Assert(this.carsData);
        }

        [TestMethod]
        public void SortByMakeShouldReturnView()
        {
            var sortedData = this.controller.Sort("make");
            var models = (List<Car>)sortedData.Model;

            Assert.AreEqual(1, models[0].Id);
            Assert.AreEqual("Audi", models[0].Make);
            Assert.AreEqual("A4", models[0].Model);
            Assert.AreEqual(2005, models[0].Year);

            Assert.AreEqual(2, models[1].Id);
            Assert.AreEqual("BMW", models[1].Make);
            Assert.AreEqual("325i", models[1].Model);
            Assert.AreEqual(2008, models[1].Year);

            Assert.AreEqual(3, models[2].Id);
            Assert.AreEqual("BMW", models[2].Make);
            Assert.AreEqual("330d", models[2].Model);
            Assert.AreEqual(2007, models[2].Year);

            Assert.AreEqual(4, models[3].Id);
            Assert.AreEqual("Opel", models[3].Make);
            Assert.AreEqual("Astra", models[3].Model);
            Assert.AreEqual(2010, models[3].Year);
        }

        [TestMethod]
        public void SortByYearShouldReturnView()
        {
            var sortedData = (IView)this.controller.Sort("year");
            var models = (List<Car>)sortedData.Model;

            Assert.AreEqual(1, models[0].Id);
            Assert.AreEqual("Audi", models[0].Make);
            Assert.AreEqual("A4", models[0].Model);
            Assert.AreEqual(2005, models[0].Year);

            Assert.AreEqual(3, models[1].Id);
            Assert.AreEqual("BMW", models[1].Make);
            Assert.AreEqual("330d", models[1].Model);
            Assert.AreEqual(2007, models[1].Year);

            Assert.AreEqual(2, models[2].Id);
            Assert.AreEqual("BMW", models[2].Make);
            Assert.AreEqual("325i", models[2].Model);
            Assert.AreEqual(2008, models[2].Year);

            Assert.AreEqual(4, models[3].Id);
            Assert.AreEqual("Opel", models[3].Make);
            Assert.AreEqual("Astra", models[3].Model);
            Assert.AreEqual(2010, models[3].Year);
        }


        private static object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }

    }
}