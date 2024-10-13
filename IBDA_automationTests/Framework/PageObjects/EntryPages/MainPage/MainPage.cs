using IBDA_automationTests.Framework.PageObjects.Shared.Components;
using IBDA_automationTests.Framework.PageObjects.Shared.Fields;


namespace IBDA_automationTests.Framework.PageObjects.EntryPages.MainPage;

public class MainPage : EntryPageBase
{
    public Button expandRejestracjaButton => Select<Button>(
        "body > app-root > app-main > div.d-flex.vh-100 > nax-aside > div > aside > div > nax-aside-menu > nax-aside-menu-desktop > div.flex-fill.sidebar-nav.position-relative.ps > ul > li:nth-child(3) > nax-aside-menu-item-desktop > div > a > span");

    public Button nowyWniosekRejestracjaButton => Select<Button>(
        "body > app-root > app-main > div.d-flex.vh-100 > nax-aside > div > aside > div > nax-aside-menu > nax-aside-menu-desktop > div.flex-fill.sidebar-nav.position-relative.ps > ul > li:nth-child(3) > nax-aside-menu-item-desktop > div > ul > li:nth-child(1) > nax-aside-menu-item-desktop > div > a > span > span");

    public DragAndDrop zdjecieIbdaDragAndDropField => Select<DragAndDrop>(
        "input[type='file']");
}