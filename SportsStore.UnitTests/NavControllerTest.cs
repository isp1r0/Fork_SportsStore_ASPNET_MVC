using SportsStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using SportsStore.Domain.Abstract;
using System.Web.Mvc;
using Moq;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace SportsStore.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for NavControllerTest and is intended
    ///to contain all NavControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NavControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void Can_Create_Categories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m=>m.Products).Returns (new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = new Category { CategoryID=0,Name = "Apples"}},
                new Product {ProductID = 2, Name = "P2", Category = new Category { CategoryID=0,Name = "Apples"}},
                new Product {ProductID = 3, Name = "P3", Category = new Category { CategoryID=1,Name = "Plums"}},
                new Product {ProductID = 4, Name = "P4", Category = new Category { CategoryID=2,Name = "Oranges"}},
            }.AsQueryable());

            // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = new Category { CategoryID=0,Name = "Apples"}},
                new Product {ProductID = 2, Name = "P2", Category = new Category { CategoryID=0,Name = "Apples"}},
                new Product {ProductID = 3, Name = "P3", Category = new Category { CategoryID=2,Name = "Plums"}},
                new Product {ProductID = 4, Name = "P4", Category = new Category { CategoryID=3,Name = "Oranges"}},
            }.AsQueryable());

            // // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            // Arrange - define the category to selected
            string categoryToSelect = "Apples";

            // Action
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;


            // Assert
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
