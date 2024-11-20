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
using NUnit.Framework.Internal.Execution;

namespace IBDA_automationTests.TestsIBDA.TestFixtures
{
    internal class DeviceRegistration_OperatorIBDA_000 : OneTimeSetup
    {
        /// <summary>
        /// ibda-test.us.edu.pl
        /// Test Automation
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
        
        [Category("Smoke Test")]
        [Test]
        public void DeviceRegistrationOperator()
        { 
           
           var mainPage = IBDAPageFactory.Create<MainPage>(driver);
           var registrationApplication = IBDAPageFactory.Create<NewApplicationRegistration>(driver);
           var initializationIBDA = IBDAPageFactory.Create<InitializationIBDA>(driver);
           Logger.Info("-------------------Test rozpoczęto-------------------");
           var date = currentDateTime.ToString("yyyy-MM-dd HH:mm");
           Logger.Info($"Data rozpoczęcia testu: {date}");
           
           Thread.Sleep(3000);
           string mainPageTitle = driver.Title;
           mainPageTitle.Should().Be("nAxiom");
           Logger.Info($"Wyświetlona strona: {mainPageTitle}");
           
           //Step 2 - expand rejestration menu
           try
           {
           mainPage.expandRejestracjaButton.Click();
           Thread.Sleep(3000);
           Logger.Info("Rozwinięto menu Rejestracja");
           }
           catch (Exception e)
           {
               Logger.Info("Rozwinięcie menu Rejestracja poprzez kliknięcie w tekst 'Rejestracja' nie powiodło się");
               Logger.Error(e);
               throw;
           }

           
           //Step 3 - Click "Nowy Wniosek" button
           mainPage.nowyWniosekRejestracjaButton.Click();
           Thread.Sleep(3000);
           Logger.Info("Wciśnięto przycisk w rozwiniętym menu Rejestracja : 'Nowy wniosek'");
           
           //Step 3.1 - Regression, input Ibda name.
           //registrationApplication.nazwaIbdaClick.Click();
           Thread.Sleep(2000);
           registrationApplication.nazwaIbda.SetValue($"Test automatyczny : {date}");
           Thread.Sleep(3000);
           Logger.Info($"Wprowadzono nazwę wniosku w pole 'Nazwa IBDA' : Test automatyczny : {date} ");
           
           //Step 4 - Send png file to "Zdjęcia IBDA" form
           registrationApplication.zdjecieIbdaDragAndDropField.sendJpg(
               "/Users/epizode/Desktop/US_Projects/AT_framework/IBDA_automationTests/IBDA_automationTests/AutomationTests.png");
           Thread.Sleep(3000);
           Logger.Info("Wysłano png do pola 'Zdjęcia IBDA");
           
           //Step 5 - Save form
           registrationApplication.saveButton.Click();
           Thread.Sleep(10000);
           Logger.Info("Zapisano wniosek przyciskiem 'Zapisz'");
           
           //Step 6 - Confirmation and IBDA Init
           registrationApplication.confirmButton.Click();
           Thread.Sleep(10000);
           Logger.Info("Wniosek zatwierdzono i rozpoczęto inicjalizacjię IBDA");
           
           //Step 7 - Fill first page
           initializationIBDA.nazwaIBDAfield.SetValue($"Test automatyczny : {date}");
           Thread.Sleep(5000);
           Logger.Info($"Wprowadzono nazwę wniosku w pole 'Nazwa IBDA' : Test automatyczny : {date} ");
           
           initializationIBDA.wydzialOkreslonyPrzyRejestracjiField.SetValue("Wydział Testowy");
           Thread.Sleep(3000);
           Logger.Info($"Wprowadzono wydział w pole 'Wydział określony przy rejestracji' : Wydział Testowy ");
           initializationIBDA.wydzialOkreslonyPrzyRejestracjiField.PressEnter();
           Thread.Sleep(5000);
           
           
           initializationIBDA.laboratoriumOkreslonePrzyRejestracjiField.SetValue("Test_Laboratorium");
           Thread.Sleep(3000);
           Logger.Info($"Wprowadzono wydział w pole 'Laboratorium określone przy rejestracji' : Test_Laboratorium ");
           Logger.Info($"W polu Lokalizacja (Adres) automatycznie uzupełnił się adres na : Bankowa 12");
           initializationIBDA.laboratoriumOkreslonePrzyRejestracjiField.PressEnter();
           Thread.Sleep(5000);
           //initializationIBDA.lokalizacjaField.SetValue("Bankowa 12");
           //Thread.Sleep(3000);
           //initializationIBDA.lokalizacjaField.PressEnter();
           Thread.Sleep(5000);
           initializationIBDA.zrodloFinansowaniaField.SetValue("inne");
           Logger.Info($"W polu 'Źródło finansowania' wybrano : 'inne'");
           Thread.Sleep(5000);
           initializationIBDA.zrodloFinansowaniaField.PressEnter();
           Thread.Sleep(3000);
           
           initializationIBDA.opisField.SetValue($"Test automatyczny : {date}");
           Logger.Info($"W pole 'Opis' wpisano : 'Test automatyczny : {date}'");
           Thread.Sleep(3000);
           initializationIBDA.opisField.PressEnter();
           Thread.Sleep(5000);
           
           initializationIBDA.parametrySprzetuButton.Click();
           Logger.Info($"Kliknięto w zakładkę : Parametry sprzętu");
           Thread.Sleep(5000);
           
           initializationIBDA.rodzajStacjonarnyRadioButton.Click();
           Logger.Info($"Wybrano z przycisków typu radio button - Rodzaj sprzętu : Stacjonarny");
           Thread.Sleep(5000);
           
           initializationIBDA.rodzajNieDoWypozyczeniaRadioButton.Click();
           Logger.Info($"Wybrano z przycisków typu radio button - Czy sprzęt może być wypożyczony : Nie");
           Thread.Sleep(5000);
           
           initializationIBDA.parametryPracyUrzadzeniaButton.Click();
           Logger.Info($"Kliknięto w zakładkę : Parametry pracy urządzenia");
           Thread.Sleep(5000);
           
           initializationIBDA.pracaWatmosferzeGazowNIE.Click();
           Logger.Info($"Wybrano z przycisków typu radio button - Praca w atmosferze gazów : Nie");
           Thread.Sleep(5000);
           
           initializationIBDA.pracaWsposobCiaglyNIE.Click();
           Logger.Info($"Wybrano z przycisków typu radio button - Praca w spsób ciągły : Nie");
           Thread.Sleep(5000);
           
           initializationIBDA.mozliwosciAparaturyButton.Click();
           Logger.Info($"Kliknięto w zakładkę : Możliwości aparatury");
           Thread.Sleep(5000);
           
           
           initializationIBDA.mozliwosciBadawczeField.SetValue("Test");
           Logger.Info($"W polu 'Możliwości badawcze' wybrano : 'Test'");
           Thread.Sleep(5000);
           initializationIBDA.mozliwosciBadawczeField.PressEnter();
           Thread.Sleep(3000);
           
           initializationIBDA.mozliwoscRealizacjiUslugKomercyjnychField.SetValue("brak");
           Logger.Info($"W polu 'Możliwości realizacji usług komercyjnych' wybrano : 'brak'");
           Thread.Sleep(5000);
           initializationIBDA.mozliwoscRealizacjiUslugKomercyjnychField.PressEnter();
           Thread.Sleep(3000);
           
           initializationIBDA.slowaKluczoweField.SetValue("Test");
           Logger.Info($"W polu 'Słowa kluczowe' wybrano : 'Test'");
           Thread.Sleep(5000);
           initializationIBDA.slowaKluczoweField.PressEnter();
           Thread.Sleep(3000);
           
           initializationIBDA.rodzajNabyciaField.SetValue("Darowizna");
           Logger.Info($"W polu 'Rodzaj nabycia' wybrano : 'Darowizna'");
           Thread.Sleep(5000);
           initializationIBDA.rodzajNabyciaField.PressEnter();
           Thread.Sleep(3000);
           
           initializationIBDA.dyscyplinaField.SetValue("Informatyka");
           Logger.Info($"W polu 'Dyscyplina' wybrano : 'Informatyka'");
           Thread.Sleep(5000);
           initializationIBDA.dyscyplinaField.PressEnter();
           Thread.Sleep(3000);
           
           initializationIBDA.akredytacjeButton.Click();
           Logger.Info($"Kliknięto w zakładkę : Akredytacje");
           Thread.Sleep(5000);
           
           initializationIBDA.czyUrzadzeniePosiadaAkredytacjeNIE.Click();
           Logger.Info($"Wybrano z przycisków typu radio button - Urządzenie posiada akredytacje lub certyfikacje? : Nie");
           Thread.Sleep(5000);
           
           
           initializationIBDA.confirmButton.Click();
           Thread.Sleep(3000);
           Logger.Info($"Kliknięto 'Zatwierdź'");
           initializationIBDA.confirmAfterFillFormsButton.Click();
           Thread.Sleep(3000);
           Logger.Info($"Kliknięto 'Zatwierdź' potwiedzająć wprowadzenie danych");
           initializationIBDA.confirmAfterCheckoutButton.Click();
           Logger.Info($"Kliknięto 'Zatwierdź' zamykając możliwość edycji i przekazując dokument dalej");
           Thread.Sleep(4000);
           

        }
        
        [OneTimeTearDown]
        public void tearDown()
        {
            Logger.Info("-------------------Test zakończono-------------------");
            driver.Dispose();
        }
    }
}