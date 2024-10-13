using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDA_automationTests.Framework.PageObjects.Shared.Components
{
    public class DropdownMenu :PomBase
    {
        public void Click()
        {
            RelatedElement.Click();
        }
        public void NextDropDownSelection()
        {
            RelatedElement.SendKeys(Keys.Down);
            RelatedElement.SendKeys(Keys.Enter);
        }
    }
}
