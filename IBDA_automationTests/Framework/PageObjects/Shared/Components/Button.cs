using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V129.IndexedDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDA_automationTests.Framework.PageObjects.Shared.Components
{
    public class Button : PomBase
    {
        public void Click()
        {
            RelatedElement.Click();
        }
    }
}