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
using IBDA_automationTests.Framework.PageObjects.EntryPages.ReservationAndRegistration;
using IBDA_automationTests.Framework.User;
using OpenQA.Selenium.DevTools;
using NLog;

namespace IBDA_automationTests.TestsIBDA.TestFixtures;
internal class NewApplication_00 : OneTimeSetup
{
    /// <summary>
    /// ibda-test.us.edu.pl
    /// Test Automation - First step - New Application
    /// Tests for repairing first step of register devices.
    /// Result - Confirmation of application submission.
    /// </summary>
    ChromeDriver driver;
    ChromeOptions options;
        
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private DateTime currentDateTime = DateTime.Now;
    
    [OneTimeSetUp]
    public void initialSetup()
    {
        options = new ChromeOptions();
        options.AddArgument("--disable-search-engine-choice-screen");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Url = "https://ibda-test.us.edu.pl/front/dashboard";

        //Step 1 - logging
        Logger.Info("------------Rozpoczęto konfigurację testu------------");
        Logger.Info("url: https://ibda-test.us.edu.pl/Identity/Account/Login");
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
    
    [Category("Regression Test")]
    [Test]
    public void IBDADeviceName0000()
    {
        var mainPage = IBDAPageFactory.Create<MainPage>(driver);
        var registrationApplication = IBDAPageFactory.Create<NewApplicationRegistration>(driver);
        var initializationIBDA = IBDAPageFactory.Create<InitializationIBDA>(driver);
        Logger.Info("-------------------Test rozpoczęto-------------------");
        Logger.Info("Test regresyjny IBDADeviceName0000: Dodanie pola z nazwą zestawu");
        var date = currentDateTime.ToString("yyyy-MM-dd HH:mm");
        Logger.Info($"Data rozpoczęcia testu: {date}");
        
        Thread.Sleep(3000);
        string mainPageTitle = driver.Title;
        try
        {
            mainPageTitle.Should().Be("nAxiom");
            Logger.Info($"Wyświetlona strona: {mainPageTitle}");
        }
        catch (AssertionException ex)
        {
            Logger.Info($"Logowanie nie powiodło się : {ex}");
            throw ex;
        }
        //Step 2 - expand rejestration menu
        mainPage.expandRejestracjaButton.Click();
        Thread.Sleep(3000);
        Logger.Info("Rozwinięto menu Rejestracja");
        
        //Step 3 - Click "Nowy Wniosek" button
        mainPage.nowyWniosekRejestracjaButton.Click();
        Thread.Sleep(3000);
        Logger.Info("Wciśnięto przycisk w rozwiniętym menu Rejestracja : 'Nowy wniosek'");

        string deviceName = "";
        string expected = "Add an IBDA set/device name";
        try
        {
            Assert.AreSame(expected, deviceName);
        }
        catch (AssertionException ex)
        {
            Logger.Error(ex, $"Asercja nie przeszła: expected = {expected}, actual = null" );
            throw ex;

        }

    }
    
    [Category("Regression Test")]
    [Test]
    public void IBDADeviceName0001()
    {
        var mainPage = IBDAPageFactory.Create<MainPage>(driver);
        var registrationApplication = IBDAPageFactory.Create<NewApplicationRegistration>(driver);
        var initializationIBDA = IBDAPageFactory.Create<InitializationIBDA>(driver);
        Logger.Info("-------------------Test rozpoczęto-------------------");
        Logger.Info("Test regresyjny IBDADeviceName0001: Dodanie przycisku usuń wniosek");
        var date = currentDateTime.ToString("yyyy-MM-dd HH:mm");
        Logger.Info($"Data rozpoczęcia testu: {date}");
        
        Thread.Sleep(3000);
        string mainPageTitle = driver.Title;
        try
        {
            mainPageTitle.Should().Be("nAxiom");
            Logger.Info($"Wyświetlona strona: {mainPageTitle}");
        }
        catch (AssertionException ex)
        {
            Logger.Info($"Logowanie nie powiodło się : {ex}");
            throw ex;
        }

        //Step 2 - expand rejestration menu
        mainPage.expandRejestracjaButton.Click();
        Thread.Sleep(3000);
        Logger.Info("Rozwinięto menu Rejestracja");
        
        //Step 3 - Click "Nowy Wniosek" button
        mainPage.nowyWniosekRejestracjaButton.Click();
        Thread.Sleep(3000);
        Logger.Info("Wciśnięto przycisk w rozwiniętym menu Rejestracja : 'Nowy wniosek'");

        string deviceName = "";
        string expected = "Delete application button";
        try
        {
            Assert.AreSame(expected, deviceName);
        }
        catch (AssertionException ex)
        {
            Logger.Error(ex, $"Asercja nie przeszła: expected = {expected}, actual = null" );
            throw ex;

        }

    }
    
    [TearDown]
    public void refreshPage()
    {
        driver.Navigate().Refresh();
        Thread.Sleep(3000);
    }

    [OneTimeTearDown]
    public void tearDown()
    {
        driver.Dispose();
        
    }
    
}