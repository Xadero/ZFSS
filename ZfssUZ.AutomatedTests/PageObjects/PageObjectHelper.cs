using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    class PageObjectHelper
    {
        private readonly IWebDriver driver;
        private OpenQA.Selenium.Support.UI.DefaultWait<IWebDriver> wait;

        public PageObjectHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromSeconds(0.1);
            wait.Timeout = TimeSpan.FromSeconds(Configuration.TIMEOUT);
        }

        public static void Sleep(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public bool IsDisplayed(IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public bool IsEnabled(IWebElement webElement)
        {
            try
            {
                return webElement.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public PageObjectHelper Click(IWebElement element)
        {
            Wait(element);
            element.Click();
            return this;
        }

        public PageObjectHelper SetText(IWebElement element, string text)
        {
            Wait(element);
            element.Clear();
            element.SendKeys(text);
            return this;
        }

        public PageObjectHelper SelectFromDdlByText(IWebElement element, string text)
        {
            Wait(element);
            var select = new SelectElement(element);
            select.SelectByText(text);
            return this;
        }

        public PageObjectHelper SelectFromDdlByValue(IWebElement element, string value)
        {
            Wait(element);
            var select = new SelectElement(element);
            select.SelectByValue(value);
            return this;
        }

        public void Wait(IWebElement element, int time = 60)
        {
            while (!IsDisplayed(element) && time-- > 0)
                Sleep(1);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            wait.Until(x => element);
            Sleep(Configuration.WAIT);
        }


        public PageObjectHelper ClickOnWebElementIfDisplayed(IWebElement element, int time = 20)
        {
            Sleep(Configuration.WAIT);
            while (!IsDisplayed(element) && time-- > 0)
                Sleep(1);

            if (IsDisplayed(element))
                Click(element);

            return this;
        }


        public void WaitForElementWithText(IWebElement element, int timeToWait)
        {
            while (!IsDisplayed(element) && timeToWait-- > 0)
                Sleep(1);

            if (IsDisplayed(element))
            {
                Wait(element);
                while (string.IsNullOrEmpty(element.Text) && timeToWait-- > 0)
                    Sleep(1);
            }
        }

        public bool GoToWindowWithTitle(string title)
        {
            var availableWindows = new List<string>(driver.WindowHandles);
            if (availableWindows.Count == 1)
            {
                driver.SwitchTo().Window(availableWindows[0]);
                if (driver.Title.Contains(title))
                {
                    Sleep(2);
                    return true;
                }
            }
            else if (availableWindows.Count > 1)
            {
                foreach (string window in availableWindows)
                {
                    driver.SwitchTo().Window(window);
                    if (driver.Title.Contains(title))
                    {
                        Sleep(2);
                        return true;
                    }
                }
            }

            return false;
        }

        public void WaitForElement(IWebElement element, int time = 60)
        {
            while (!IsDisplayed(element) && time-- > 0)
            {
                Sleep(1);
            }
        }
    }
}
