using IBDA_automationTests.Framework.PageObjects.Shared.Components;
using IBDA_automationTests.Framework.PageObjects.Shared.Fields;

namespace IBDA_automationTests.Framework.PageObjects.EntryPages.ReservationAndRegistration;

public class NewApplicationReservation :EntryPageBase
{
    public Button saveButton => Select<Button>(
        "#button_134");
    public Button closeButton => Select<Button>(
        "#button_135");
    public Button commentButton => Select<Button>(
        "#button_113");
    public Button commentaryInputSelect => Select<Button>(
        "#main-container > app-form-body > nax-form-body-desktop > div:nth-child(2) > form > div > div > nax-aside > div > aside > div > nax-aside-form-comments > section > footer > kendo-textarea");
    public TextField commentaryField => 
        Select<TextField>("textarea[aria-multiline=\"true\"]");

    public TextField SearchIbdaNameField => 
        Select<TextField>("input[placeholder*='Wprowadź przynajmniej 3 znaki']");

    public Button reservationDateBegginging => 
        Select<Button>("#DateAndHourStart1182 > button > kendo-icon-wrapper > kendo-svgicon");

    public Button reservationDateEnd =>
        Select<Button>("#DateAndHourEnd1183 > button > kendo-icon-wrapper > kendo-svgicon");

    public Button researchDecritpionButton => Select<Button>(
        "li > .k-link > span.ng-star-inserted");

}