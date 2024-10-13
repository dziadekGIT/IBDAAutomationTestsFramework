using OpenQA.Selenium;
using IBDA_automationTests.Framework.PageObjects;

namespace IBDA_automationTests.Framework.Factories
{
    public static class IBDAPageFactory
    {
        /// <summary>
        /// Creates an entry page.
        /// </summary>
        public static TPage Create<TPage>(IWebDriver driver) where TPage : PomBase, new()
        {
            var page = new TPage()
            {
                Driver = driver
            };

            return page;
        }
    }
}