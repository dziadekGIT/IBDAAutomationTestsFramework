using IBDA_automationTests.Framework.PageObjects.Shared.Components;
using IBDA_automationTests.Framework.PageObjects.Shared.Fields;


namespace IBDA_automationTests.Framework.PageObjects.EntryPages.Login
{
    public class LoginPage : EntryPageBase
    {
        
        public TextField Username => Select<TextField>("#Input_UserName");
        public TextField Password => Select<TextField>("#Input_Password");
        public Button LoginButton => Select<Button>("#btn-login");
        
    }
}