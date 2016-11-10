using System;
using OpenQA.Selenium;
using AutomatedTests.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebdriverFramework.Framework.WebDriver;
using System.Collections.ObjectModel;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using WebdriverFramework.Framework.WebDriver.Elements;

namespace AutomatedTests.Tests
{
    [TestClass]
    public class TC_01_Cars : BaseTest
    {
        public static string CarFeachuresEngines;
        public static string CarFeachuresTransmissions;

        [TestInitialize]
        public void TestInitialize()
        {
            Log.TestName(GetType().Name);
            Browser.Quit();
            Environment.SetEnvironmentVariable("browser", "Firefox");
            base.InitBeforeTest();
            Browser.WindowMaximise();
        }

        [TestMethod]
        public override void RunTest()
        {
            int step = 1;

            // Go to https://www.cars.com/ and navigate to Review Car
            Log.LogStep(step++, "Go to https://www.cars.com/ and navigate to Review Car");
            var mainForm = new MainForm();
            mainForm.NavigateToReviewCar();

            var firstCarReviewForm = new CarReviewForm();

            // Select first car and go to page with this car
            Log.LogStep(step++, "Select first car and go to page with this car");
            firstCarReviewForm.SelectAuto();
            firstCarReviewForm.SaveFirstCarFeature();

            var describeFirstCarForm = new DescribeCarForm();

            while (!describeFirstCarForm.btCompare.IsPresent())
            {
                Browser.GetDriver().Navigate().Back();
                Browser.WaitForPageToLoad();
                Browser.GetDriver().Navigate().Refresh();
                firstCarReviewForm.SelectAuto();
                firstCarReviewForm.SaveFirstCarFeature();
            }

            // Save Notable Features for first car and go back by select car
            Log.LogStep(step++, "Save Notable Features for first car and go back by select car");
            describeFirstCarForm.SaveNotableFeatures();
            CarFeachuresEngines = describeFirstCarForm.CarFeachuresEngines;
            CarFeachuresTransmissions = describeFirstCarForm.CarFeachuresTransmissions;
            Browser.GetDriver().Navigate().Back();
            Browser.GetDriver().Navigate().Back();

            var secondCarReviewForm = new CarReviewForm();

            // Select second car and go to page with this car
            Log.LogStep(step++, "Select second car and go to page with this car");
            secondCarReviewForm.SelectAuto();

            var describeSecondCarForm = new DescribeCarForm();

            while (!describeSecondCarForm.btCompare.IsPresent())
            {
                Browser.GetDriver().Navigate().Back();
                Browser.WaitForPageToLoad();
                Browser.GetDriver().Navigate().Refresh();
                secondCarReviewForm.SelectAuto();
            }

            // Save Notable Features for second car
            Log.LogStep(step++, "Save Notable Features for second car");
            describeSecondCarForm.SaveNotableFeatures();
            CarFeachuresEngines = describeSecondCarForm.CarFeachuresEngines + CarFeachuresEngines;
            CarFeachuresTransmissions = describeSecondCarForm.CarFeachuresTransmissions + CarFeachuresTransmissions;

            try
            {
                describeSecondCarForm.btCompare.ClickAndWaitForLoading();
            }
            catch (Exception e)
            {
                Browser.GetDriver().Navigate().Refresh();
            }

            var compareForm = new CompareForm();

            // Compare cars
            Log.LogStep(step++, "Compare cars");
            compareForm.Compare(CarFeachuresEngines, CarFeachuresTransmissions);
        }
    }
}

