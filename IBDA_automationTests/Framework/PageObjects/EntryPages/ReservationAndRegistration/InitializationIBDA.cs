using IBDA_automationTests.Framework.PageObjects.Shared.Fields;
using IBDA_automationTests.Framework.PageObjects.Shared.Components;
namespace IBDA_automationTests.Framework.PageObjects.EntryPages.ReservationAndRegistration;

public class InitializationIBDA : EntryPageBase
{
    //Dane
    public TextField nazwaIBDAfield => Select<TextField>("#Name54");

    public TextField wydzialOkreslonyPrzyRejestracjiField =>
        Select<TextField>("#RegistrationDepartmentId703-control .k-input");

    public TextField laboratoriumOkreslonePrzyRejestracjiField =>
        Select<TextField>("#form-group-RegistrationLaboratoryId55 .k-input");

    public TextField lokalizacjaField => Select<TextField>("#Location56");

    public TextField zrodloFinansowaniaField => Select<TextField>("#form-group-SourceOfFinancing61 .k-input");

    public TextField opisField => Select<TextField>("#Description60");



    //Parametry sprzętu

    public Button rodzajStacjonarnyRadioButton => Select<Button>("#IsMobileEquipment2");

    public Button rodzajNieDoWypozyczeniaRadioButton => Select<Button>("#IsRented4");
    
    //Parametry pracy urządzenia
    public Button pracaWatmosferzeGazowNIE => Select<Button>("#WorkingInAProtectiveGasAtmosphere6");

    public Button pracaWsposobCiaglyNIE => Select<Button>("#WorkContinuously8");

    
    //Możliwości aparatury
    public TextField mozliwosciBadawczeField => Select<TextField>("#ResearchOpportunities74 .k-input");
    public TextField mozliwoscRealizacjiUslugKomercyjnychField => Select<TextField>("#PossibilitiesOfCommercialServices76 .k-input");
    public TextField slowaKluczoweField => Select<TextField>("#Keywords935 .k-input");
    public TextField rodzajNabyciaField => Select<TextField>("#TypeOfAcquisition705 .k-input");
    public TextField dyscyplinaField=> Select<TextField>("#DisciplinesId1367 .k-input");
    
    //Akredytacje
    public Button czyUrzadzeniePosiadaAkredytacjeNIE => Select<Button>("#AnyCertificatesAccreditations10");
    
    
    
    
    //Global
    public Button confirmButton => Select<Button>("#button_transition_88");
    public Button confirmAfterFillFormsButton => Select<Button>("#button_transition_91");
    public Button confirmAfterCheckoutButton => Select<Button>("#button_transition_92");
    
    public Button parametrySprzetuButton => Select<Button>("#k-tabstrip-tab-1");
    public Button parametryPracyUrzadzeniaButton => Select<Button>("#k-tabstrip-tab-2");
    public Button mozliwosciAparaturyButton => Select<Button>("#k-tabstrip-tab-3");
    public Button akredytacjeButton => Select<Button>("#k-tabstrip-tab-4");
}