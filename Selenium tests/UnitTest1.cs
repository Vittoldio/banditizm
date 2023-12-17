using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium_tests
{
    public class UnitTest1
    {
        [Fact]
        public void LoginSucces()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Login";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("adminuser@localhost");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("aUpass1!");
            var submitButton = webDriver.FindElement(By.XPath("//*[@id='account']/div[5]/button"));
            submitButton.Click();
        }

        [Fact]
        public void LoginFail1()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Login";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("adminuser@localhost");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("WrongPass");
            var submitButton = webDriver.FindElement(By.XPath("//*[@id='account']/div[5]/button"));
            submitButton.Click();



        }
        [Fact]
        public void LoginFail2()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Login";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("adminuser");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("WrongPass");
            var submitButton = webDriver.FindElement(By.XPath("//*[@id='account']/div[5]/button"));
            submitButton.Click();



        }
        [Fact]
        public void AnouthorizedAccesEnrollment()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Admin/CreateEnroll";
            
         }
        [Fact]
        public void RegisterFailSameUsername()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Register";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("adminuser@localhost");
            var nameField = webDriver.FindElement(By.Id("Input_Name"));
            nameField.SendKeys("Marek");
            var surnameField = webDriver.FindElement(By.Id("Input_Surname"));
            surnameField.SendKeys("Balant");
            var birthField = webDriver.FindElement(By.Id("Input_BirthDate"));
            birthField.SendKeys("12.01.1999");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("WrongPass1!");
            var password2Field = webDriver.FindElement(By.Id("Input_ConfirmPassword"));
            password2Field.SendKeys("WrongPass1!");
            var submitButton = webDriver.FindElement(By.XPath("/ html / body / div / main / div / div / form / button"));
            submitButton.Click();

        }
        [Fact]
        public void RegisterSucces()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Register";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("adminuser2@localhost");
            var nameField = webDriver.FindElement(By.Id("Input_Name"));
            nameField.SendKeys("Marek");
            var surnameField = webDriver.FindElement(By.Id("Input_Surname"));
            surnameField.SendKeys("Balant");
            var birthField = webDriver.FindElement(By.Id("Input_BirthDate"));
            birthField.SendKeys("12.01.1999");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("WrongPass1!");
            var password2Field = webDriver.FindElement(By.Id("Input_ConfirmPassword"));
            password2Field.SendKeys("WrongPass1!");
            var submitButton = webDriver.FindElement(By.XPath("/ html / body / div / main / div / div / form / button"));
            submitButton.Click();

        }

        [Fact]
        public void UnlogedUserNavigation()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Courses";
            webDriver.Url = "https://localhost:44317/Reviews";
            webDriver.Url = "https://localhost:44317/Identity/Account/Register";
            webDriver.Url = "https://localhost:44317/Identity/Account/Login";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage/ChangePassword";
        }

        [Fact]
        public void StudentNavigation() {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Login";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("normaluser@localhost");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("nUpass1!");
            var submitButton = webDriver.FindElement(By.XPath("//*[@id='account']/div[5]/button"));
            submitButton.Click();
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage/ChangePassword";
            webDriver.Url = "https://localhost:44317/Lessons";
            webDriver.Url = "https://localhost:44317/Courses";
            webDriver.Url = "https://localhost:44317/Reviews";
            webDriver.Url = "https://localhost:44317/Materials";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage/ChangePassword";
            webDriver.Url = "https://localhost:44317/Languages";
            webDriver.Url = "https://localhost:44317/Admin";
            webDriver.Url = "https://localhost:44317/Admin/CreateEnroll";
            webDriver.Url = "https://localhost:44317/Admin/AddRole";

        }
        [Fact]
        public void AdminNav()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://localhost:44317/Identity/Account/Login";
            var emailField = webDriver.FindElement(By.Id("Input_Email"));
            emailField.SendKeys("adminuser@localhost");
            var passwordField = webDriver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys("aUpass1!");
            var submitButton = webDriver.FindElement(By.XPath("//*[@id='account']/div[5]/button"));
            submitButton.Click();
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage/ChangePassword";
            webDriver.Url = "https://localhost:44317/Lessons";
            webDriver.Url = "https://localhost:44317/Courses";
            webDriver.Url = "https://localhost:44317/Reviews";
            webDriver.Url = "https://localhost:44317/Materials";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage";
            webDriver.Url = "https://localhost:44317/Identity/Account/Manage/ChangePassword";
            webDriver.Url = "https://localhost:44317/Languages";
            webDriver.Url = "https://localhost:44317/Admin";
            webDriver.Url = "https://localhost:44317/Admin/CreateEnroll";
            webDriver.Url = "https://localhost:44317/Admin/AddRole";
        }

    
        

}

}

