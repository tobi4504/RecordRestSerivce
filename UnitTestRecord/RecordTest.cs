using EntityLibary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RecordsRESTService.Interface;
using RecordsRESTService.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;
using System.Text.Json;
using OpenQA.Selenium.Support.UI;

namespace UnitTestRecord
{
    [TestClass]
    public class RecordTest
    {
         
        static string DriverDirectory = "C:\\Drivers";
        const string URL = "file:///C:/Users/tobia/OneDrive/Skrivebord/RecordsHtml/index.html";
        static IWebDriver driver = new ChromeDriver(DriverDirectory);
        static IWebElement GetAllElements;
        static IWebElement resultElement;
    

        private List<Record> records;
        private IRecords mock = new MockRecords();

        [TestInitialize]
        public void StartUp()
        {
            records = mock.GetRecords().ToList();
            //ClearElement.Click();

        }

        [ClassInitialize]
        public static void TestClassSetUp(TestContext context)
        {
            driver.Navigate().GoToUrl(URL);
            GetAllElements = driver.FindElement(By.Id("getAllButton"));
            resultElement = driver.FindElement(By.Id("recordList"));

            //resultElement = driver.FindElement(By.Id("Result"));
            //ClearElement = driver.FindElement(By.Id("clear"));
        }
        [TestMethod]
        public void TestGetAllRecords()
        {
            CollectionAssert.AreEqual(mock.GetRecords().ToList(), records);

        }      
        [TestMethod]
        public void TestWewbsiteGetAll()
        {
           
            
            Thread.Sleep(1000);
            GetAllElements.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           
            Thread.Sleep(1000);
            //List<Record> SelinumRecords = new List<Record>();

            //IWebElement  SelinumRecords = wait.Until()
       

            string result = resultElement.Text;
            Assert.IsTrue(result != null);
            
        }
    }
}
