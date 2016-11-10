using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WebdriverFramework.Framework.WebDriver;
using WebdriverFramework.Framework.WebDriver.Elements;
using System.Collections.ObjectModel;
using System.Collections;
using System;

namespace AutomatedTests.Forms
{
    /// <summary>
    /// Class describe form car specification
    /// </summary>
    public class DescribeCarForm : BaseForm
    {
        private static readonly By titleLocator = By.XPath("//h1[@class='mmy-car-title']");
        private Button btOverview = new Button(By.XPath("//a[contains(text(), 'Overview')]"), "Button Overview");
        public Button btCompare = new Button(By.Id("comparesbs"), "Button compare");
        private string xpathNotableFeaturesEngines = "//ul[@class='list-nobullets']//li[contains(text(), 'hp')]";
        private string xpathNotableFeaturesTransmissions = "//ul[@class='list-nobullets']//li[contains(text(), 'speed')]";
        private ReadOnlyCollection<IWebElement> AllNotableFeaturesEngines;
        private ReadOnlyCollection<IWebElement> AllNotableFeaturesTransmissions;
        public string CarFeachuresEngines;
        public string CarFeachuresTransmissions;

        /// <summary>
        /// Default constuctor
        /// </summary>
        public DescribeCarForm() : base(titleLocator, "DescribeCarForm") { }

        /// <summary>
        /// Method navigate to inset Overview and save Notable Features
        /// </summary>
        public void SaveNotableFeatures()
        {
            btOverview.ClickAndWaitForLoading();
            try
            {
                Assert.AreEqual(Browser.GetDriver().Url, btOverview.GetAttribute("href"));
            }
            catch (Exception e)
            {
                btOverview.ClickAndWaitForLoading();
                Assert.AreEqual(Browser.GetDriver().Url, btOverview.GetAttribute("href"));
            }

            AllNotableFeaturesEngines = Browser.GetDriver().FindElements(By.XPath(xpathNotableFeaturesEngines));
            for (int i = 0; i < AllNotableFeaturesEngines.Count; i++)
            {
                CarFeachuresEngines = CarFeachuresEngines + AllNotableFeaturesEngines[i].Text.Replace("hp,", "hp");
            }

            AllNotableFeaturesTransmissions = Browser.GetDriver().FindElements(By.XPath(xpathNotableFeaturesTransmissions));
            for (int i = 0; i < AllNotableFeaturesTransmissions.Count; i++)
            {
                CarFeachuresTransmissions = CarFeachuresTransmissions + AllNotableFeaturesTransmissions[i].Text.Replace("speed", "spd").Replace("manual", "man");
            }
        }
    }
}
