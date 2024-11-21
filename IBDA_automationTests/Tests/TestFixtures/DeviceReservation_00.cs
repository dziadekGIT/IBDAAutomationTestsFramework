
using OpenQA.Selenium.Chrome;

using IBDA_automationTests.Tests;
using IBDA_automationTests.Framework.Factories;
using IBDA_automationTests.Framework.PageObjects.EntryPages.Login;
using NLog;


namespace IBDA_automationTests.TestsIBDA.TestFixtures;

public class DeviceReservation_00 : OneTimeSetup
{
    /// <summary>
    /// ibda-test.us.edu.pl
    /// Test Automation - Device reservation
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

    [Test]
    public void Test()
    {
        Assert.Pass();
        
    }

    [Test]
    public void Test2()
    {
        
        Console.WriteLine("test2");
        
    }
    [OneTimeTearDown]
    public void tearDown()
    {
        Logger.Info("-------------------Test zakończono-------------------");
        driver.Dispose();
    }
    
    
}