using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_UI.PageObject
{
    public abstract class BasePage
    {
        public IWebDriver driver = null;
        private WebDriverWait wait;
        private IWebElement element;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool SummaryDisplayed(string by)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.XPath(by))));
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void inputData(IWebElement element, string data)//убрать в другой класс
        {
            element.Clear();
            element.SendKeys(data);
        }

        internal void AnswerToReceiveUpdates(IWebElement element, string answer) //убрать в другой класс
        {

            if (answer.Equals("y"))
            {
                driver.FindElement((By)element).SendKeys("y");
            }
            else
            {
                driver.FindElement((By)element).SendKeys("n");
            }
        }
    }
}
