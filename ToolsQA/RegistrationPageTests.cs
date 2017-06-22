using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Models;
using ToolsQA.Pages.RegistrationPage;

namespace ToolsQA
{
    [TestFixture]
    public class RegistrationPageTests
    {
        public IWebDriver driver;
        TearDown cleaner = new TearDown();

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            cleaner.SaveLogs();
            this.driver.Quit();
        }

        public void FillRegistrationWithExcelData(string testName)
        {
            var user = AccessExcelData.GetUserData(testName);
            var regPage = new RegistrationPage(this.driver);
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            try
            {
                IWebElement actualError = driver.FindElement(By.XPath(user.ErrorLocator));
                StringAssert.Contains(user.ErrorMessage, actualError.Text);
            }
            catch (Exception)
            {
                cleaner.TakeScreenShot(this.driver);
                Assert.IsTrue(false);
            }
        }

        public void SubmitRegistrationWithExcelData(string testName)
        {
            var user = AccessExcelData.GetUserData(testName);
            var regPage = new RegistrationPage(this.driver);
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SubmitRegistrationForm();
            try
            {
                IWebElement actualError = driver.FindElement(By.XPath(user.ErrorLocator));
                StringAssert.Contains(user.ErrorMessage, actualError.Text);

            }
            catch (Exception)
            {
                cleaner.TakeScreenShot(this.driver);
                Assert.IsTrue(false);
            }
        }

        [Test]
        [Property("RegistrationPage", 1)]
        public void RequiredFieldsErrors()
        {
            RegistrationPage page = new RegistrationPage(this.driver);
            page.NavigateTo();
            page.SubmitRegistrationForm();
            string errorMsg = "This field is required";
            page.AssertNamesErrorMessage(errorMsg);
            page.AssertHobbiesErrorMessage(errorMsg);
            page.AssertPhoneErrorMessage(errorMsg);
            page.AssertUsernameErrorMessage(errorMsg);
            page.AssertPasswordErrorMessage(errorMsg);
            page.AssertConfirmPasswordErrorMessage(errorMsg);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithDataFromExcel()
        {
            SubmitRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithoutFirstName()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);

        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithoutLastName()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithOutNames()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithOutHobby()
        {
            SubmitRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithOutPhoneNumber()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithInvalidPhoneNumber()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegistrateWithWrongPhoneNumberErrorsChange()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetUserData("RegistrateWithWrongPhoneNumberErrorsChange");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.AssertPhoneErrorMessage("This field is required");
            regPage.Phone.SendKeys("2525");
            regPage.UserName.Click();
            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithoutUsername()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithoutEmail()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithoutEmailErrorsChange()
        {
            RegistrationPage page = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetUserData(TestContext.CurrentContext.Test.MethodName);
            page.NavigateTo();
            page.FillRegistrationForm(user);
            page.AssertEmailErrorMessage("* Invalid email address");
            page.Email.Clear();
            page.UserName.Click();
            page.AssertEmailErrorMessage("This field is required");
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithInvalidEmail()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);

        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithoutPassword()
        {
            FillRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithoutConfirmPassword()
        {
            SubmitRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithMismatchedPassword()
        {
            SubmitRegistrationWithExcelData(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void UniqueUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetUserData(TestContext.CurrentContext.Test.MethodName);
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SubmitRegistrationForm();
            regPage.AssesrtSuccessMessage("Thank you for your registration");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SubmitRegistrationForm();
            regPage.AssertRegistrationErrorMessage(": Username already exists");

        }

        [Test]
        [Property("RegistrationPage", 1)]
        [Property("TestDataFromExcel", 1)]
        public void RegisterWithSameEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetUserData(TestContext.CurrentContext.Test.MethodName);
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SubmitRegistrationForm();
            regPage.AssesrtSuccessMessage("Thank you for your registration");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.UserName.SendKeys(DateTime.Now.Millisecond.ToString());
            regPage.SubmitRegistrationForm();
            regPage.AssertRegistrationErrorMessage(": E-mail address already exists");

        }
    }
}
