using OpenQA.Selenium;

namespace IBDA_automationTests.Framework.PageObjects.Shared.Fields
{
    public class TextField :PomBase
    {
        public void SetValue(string text)
        {
            RelatedElement.SendKeys(text);
        }
        public void PressEnter()
        {
            RelatedElement.SendKeys(Keys.Enter); 
        }
    }
}