using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IBDA_automationTests.Framework.Extensions
{
    public static class SeleniumExtensions
    {
        /// <summary>
        /// Polls the DOM for a given duration to search for the element.
        /// </summary>
        public static IWebElement GetElement(this IWebDriver driver, string cssSelector, int seconds = 1)
        {
            return driver.DiscoverElement(driver, cssSelector, seconds);
        }

        /// <summary>
        /// Polls the DOM for a given duration to search for the element.
        /// </summary>
        public static IWebElement GetElement(this IWebElement element, string cssSelector, int seconds = 1)
        {
            var driver = element.FindDriver();
            return driver.DiscoverElement(element, cssSelector, seconds);
        }

        /// <summary>
        /// Works the exact same way as Selenium's native FindElements.
        /// </summary>
        public static ReadOnlyCollection<IWebElement> GetElements(this ISearchContext context, string selector)
        {
            return context.FindElements(By.CssSelector(selector));
        }

        private static IWebElement DiscoverElement(this IWebDriver driver, ISearchContext context, string cssSelector, int seconds = 1)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            try
            {
                var finalElement = wait.Until(d =>
                {
                    var elements = context.GetElements(cssSelector);
                    return elements.FirstOrDefault();
                });

                return finalElement;
            }
            catch (WebDriverTimeoutException)
            {
                //Throws custom exception
                throw new TimeoutException(
                    $"Cannot find element by selector '{cssSelector}' after {seconds} seconds.{Environment.NewLine}URL:  " +
                    $"{driver.Url}{Environment.NewLine}Page Title:  {driver.Title}");
            }
        }

        /// <summary>
        /// Gets the driver from an IWebElement.
        /// </summary>
        public static IWebDriver FindDriver(this IWebElement element)
        {
            IWebDriver foundDriver = null;
            if (element is IWrapsDriver wrapper)
            {
                foundDriver = wrapper.WrappedDriver;
            }
            return foundDriver;
        }
    }
}