using System;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebdriverFramework.Framework.WebDriver;
using WebdriverFramework.Framework.WebDriver.Elements;
using System.Collections.ObjectModel;
using AutomatedTests.Tests;

namespace AutomatedTests.Forms
{
    /// <summary>
    /// Class describe compare form
    /// </summary>
    public class CompareForm : BaseForm
    {
        private static readonly By titleLocator = By.Id("search");
        private Button btCompare = new Button(By.XPath("//span[@class= 'bttntxtprpl']"), "Button Compare");
        private ComboBox cbMake = new ComboBox(By.XPath(String.Format("//select[@id='division']//option[contains(text(), '{0}')]", CarReviewForm.FirstCarMake)), "Combobox Make");
        private ComboBox cbModel = new ComboBox(By.XPath(String.Format("//select[@id='model']//option[contains(text(), '{0}')]", CarReviewForm.FirstCarModel)), "Combobox Model");
        private ComboBox cbYear = new ComboBox(By.XPath(String.Format("//select[@id='year']//option[contains(text(), '{0}')]", CarReviewForm.FirstCarYear)), "Combobox Year");
        private ReadOnlyCollection<IWebElement> CompareAllAvailableEngines;
        private ReadOnlyCollection<IWebElement> CompareAllAvailableTransmissions;
        private string XPathAvailableEngines = "//td[@class='dataRowCell'][contains(text(), 'hp')]";
        private string XPathAvailableTransmissions = "//td[@class='dataRowCell'][contains(text(), 'spd')]";
        Random random = new Random();

        /// <summary>
        /// Default constuctor
        /// </summary>
        public CompareForm() : base(titleLocator, "CompareForm") { }

        public void Compare(string carFeachureEngines, string carFeachuresTransmissions)
        {
            cbYear.ClickAndWaitForLoading();
            cbMake.ClickAndWaitForLoading();
            cbModel.ClickAndWaitForLoading();
            btCompare.ClickAndWaitForLoading();

            CompareAllAvailableEngines = Browser.GetDriver().FindElements(By.XPath(XPathAvailableEngines));
            CompareAllAvailableTransmissions = Browser.GetDriver().FindElements(By.XPath(XPathAvailableTransmissions));
            string compareFeachuresEngines = "";
            string compareTransmissions = "";

            for (int i = 0; i < CompareAllAvailableEngines.Count; i++)
            {
                compareFeachuresEngines += CompareAllAvailableEngines[i].Text.Replace("\r\n", "");
            }

            for (int i = 0; i < CompareAllAvailableTransmissions.Count; i++)
            {
                compareTransmissions += CompareAllAvailableTransmissions[i].Text.Replace("\r\n", "");
            }

            Assert.AreEqual(carFeachureEngines, compareFeachuresEngines);
            Assert.AreEqual(carFeachuresTransmissions, compareTransmissions);

        }
    }
}
