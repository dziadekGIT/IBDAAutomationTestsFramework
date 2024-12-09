using OpenQA.Selenium.Chrome;

using IBDA_automationTests.Tests;
using IBDA_automationTests.Framework.Factories;
using IBDA_automationTests.Framework.PageObjects.EntryPages.Login;
using IBDA_automationTests.Framework.PageObjects.EntryPages.MainPage;
using IBDA_automationTests.Framework.PageObjects.EntryPages.ReservationAndRegistration;
using NLog;
using OpenQA.Selenium;


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
       var mainPage = IBDAPageFactory.Create<MainPage>(driver);
       var reservationPage = IBDAPageFactory.Create<NewApplicationReservation>(driver);
       
       
       Thread.Sleep(3000);
       
       
       
       //Step 1 - expand rezervation sidebar menu
       try
       {
           mainPage.expandRezerwacjeButton.Click();
           Thread.Sleep(3000);
           Logger.Info("Rozwinięto menu 'Rezerwacje'");
       }
       catch (Exception e)
       {
           Console.WriteLine($"Błąd rozwinięcia rejestracji : {e}");
           Logger.Error($"Błąd rozwinięcia rejestracji : {e}");
           throw;
       }
       
       Thread.Sleep(3000);
       
       //Step 2 - Click on new request
       try
       {
           mainPage.nowyWniosekRezerwacjaButton.Click();
           Logger.Info("Przyciśnięto 'Nowy wniosek'");
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           Logger.Error($"Błąd przycisku 'Nowy wniosek' : {e}");
           throw;
       }
       Thread.Sleep(3000);
       
       //Step 3 - Select IBDA name for reservation
       try
       {
        reservationPage.SearchIbdaNameField.SetValue("IBDA testowa / lab szkolenie 3/Instytut Testowy / Wydział Testowy");
        Logger.Info($"Wprowadzono IBDA testowa / lab szkolenie 3/Instytut Testowy / Wydział Testowy w pole 'Wyszukaj'");
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           Logger.Error($"Błąd wprowadzenia nazwy IBDA w pole 'Wyszukaj' : {e}");
           throw;
       }
       
       Thread.Sleep(3000);
       
       //Step 4 set beginning date of reservation
       try
       {
           reservationPage.reservationDateBegginging.Click();
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.ArrowRight);
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
           Logger.Info("Wprowadzono datę rezerwacji 'OD'");
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           Logger.Error($"Błąd wprowadzenia daty rezerwacji 'OD' : {e}");
           throw;
       }
       Thread.Sleep(3000);
       
       //Step 5 set end date of reservation
       try
       {
           reservationPage.reservationDateEnd.Click();
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.ArrowRight);
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.ArrowRight);
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
           Thread.Sleep(1000);
           driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
           Logger.Info("Wprowadzono datę rezerwacji 'DO'");
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           Logger.Error($"Błąd wprowadzenia daty rezerwacji 'DO' : {e}");
           throw;
       }
       Thread.Sleep(3000);


       try
       {
           reservationPage.researchDecritpionButton.Click();
           Logger.Info("Przejście do zakładnki 'Opis badań'");
           Thread.Sleep(1000);
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           Logger.Error($"Błąd: {e}");
           throw;
       }
       
   
    }
    
    
    
    [OneTimeTearDown]
    public void tearDown()
    {
        Logger.Info("-------------------Test zakończono-------------------");
        driver.Dispose();
    }
    
    
}