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
        private DefaultWait<IWebDriver> wait;

        public PageObjectHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Timeout = TimeSpan.FromSeconds(Configuration.TIMEOUT);
        }

        public void Sleep(int seconds)
        {
            Thread.Sleep(seconds * 300);
        }

        public void AcceptAlert()
        {
            Sleep(Configuration.WAIT);
            driver.SwitchTo().Alert().Accept();
            Sleep(Configuration.WAIT);
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

        public PageObjectHelper SelectByText(IWebElement element, string text)
        {
            Wait(element);
            var select = new SelectElement(element);
            select.SelectByText(text);
            return this;
        }

        public PageObjectHelper SelectByValue (IWebElement element, string value)
        {
            Wait(element);
            var select = new SelectElement(element);
            select.SelectByValue(value);
            return this;
        }

        public void Wait(IWebElement element, int time = 30)
        {
            while (!IsDisplayed(element) && time-- > 0)
                Sleep(Configuration.WAIT);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            wait.Until(x => element);
            Sleep(Configuration.WAIT);
        }
    }
}
