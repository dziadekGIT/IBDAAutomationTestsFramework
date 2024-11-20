using IBDA_automationTests.Framework.PageObjects.Shared.Components;
using IBDA_automationTests.Framework.PageObjects.Shared.Fields;
namespace IBDA_automationTests.Framework.PageObjects.EntryPages.ReservationAndRegistration;

public class NewApplicationRegistration : EntryPageBase
{
    public Button saveButton => Select<Button>(
        "#button_23");
    public Button confirmButton => Select<Button>(
        "#button_transition_87");
    public DragAndDrop zdjecieIbdaDragAndDropField => Select<DragAndDrop>(
        "input[type='file']");

    public Button nazwaIbdaClick => Select<Button>("#Name54");
    public TextField nazwaIbda => Select<TextField>("div.col.form-control-container input.k-input-inner");
    
    
    
}