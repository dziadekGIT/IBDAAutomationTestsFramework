using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using IBDA_automationTests.Tests;
using IBDA_automationTests.Framework.Factories;
using IBDA_automationTests.Framework.PageObjects.EntryPages.Login;
using IBDA_automationTests.Framework.PageObjects.EntryPages.Inventory;
using System.Linq;
using FluentAssertions;
using IBDA_automationTests.Framework.PageObjects.EntryPages.MainPage;
using IBDA_automationTests.Framework.PageObjects.EntryPages.ReservationForm;
using IBDA_automationTests.Framework.User;
using OpenQA.Selenium.DevTools;
using NLog;

namespace IBDA_automationTests.TestsIBDA.TestFixtures
{
    internal class IBDA_US : OneTimeSetup
    {
        /// <summary>
        /// ibda-test.us.edu.pl
        /// Test Automation
        /// </summary>
        ChromeDriver driver;
        ChromeOptions options;
        
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        
        [OneTimeSetUp]
        public void initialSetup()
        {
            options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://ibda-test.us.edu.pl/front/dashboard";
            
            //Step 1 - logging
            Logger.Info("Rozpoczęcie konfiguracji testu");
            string loginPageUrl = "https://ibda-test.us.edu.pl/Identity/Account/Login";
            
            var loginPage = IBDAPageFactory.Create<LoginPage>(driver);
            Thread.Sleep(3000);
            
            var username = operatorIBDA.Username;
            var password = operatorIBDA.Password;
            Logger.Info("Utworzono usera : test_operatorIBDA");
            
            loginPage.Username.SetValue(username);
            loginPage.Password.SetValue(password);
            loginPage.LoginButton.Click();
            Logger.Info($"Logowanie użytkownika: {username}");
        }
        
        [Category("Smoke Test")]
        [Test]
        public void IbdaTestInital()
        {
           var mainPage = IBDAPageFactory.Create<MainPage>(driver);
           var newDocument = IBDAPageFactory.Create<NewDocument>(driver);
           
           Thread.Sleep(3000);
           string mainPageTitle = driver.Title;
           mainPageTitle.Should().Be("nAxiom");
           Logger.Info($"Wyświetlona strona: {mainPageTitle}");
           
           
           //Step 2 - expand rejestration menu
           mainPage.expandRejestracjaButton.Click();
           Thread.Sleep(3000);
           Logger.Info("Rozwinięto menu Rejestracja");
           
           //Step 3 - Click "Nowy Wniosek" button
           mainPage.nowyWniosekRejestracjaButton.Click();
           Thread.Sleep(3000);
           Logger.Info("Wciśnięto przycisk w rozwiniętym menu Rejestracja : 'Nowy wniosek'");

           mainPage.zdjecieIbdaDragAndDropField.sendJpg(
               "/Users/epizode/Desktop/US_Projects/AT_framework/IBDA_automationTests/IBDA_automationTests/AutomationTests.png");

           /*
           //Step 4 - Click "Close" Button
           newDocument.closeButton.Click();
           Thread.Sleep(3000);

           //Step 5 - Click "Nowy Wniosek" button.
           mainPage.nowyWniosekRejestracjaButton.Click();
           Thread.Sleep(3000);

           //Step 6 - Click commentary button
           newDocument.commentButton.Click();
           Thread.Sleep(3000);

           //Step 7 - Enter values to commentary field
           newDocument.commentaryField.SetValue("To jest test automatyczny systemu IBDA");
           Thread.Sleep(10000);
           */
        }
        
        [OneTimeTearDown]
        public void tearDown()
        {
            Thread.Sleep(5000);
            driver.Dispose();
            Logger.Info("-------------------Test zakończono-------------------");
        }
    }
}