using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebdriverFramework.Framework.WebDriver;
using WebdriverFramework.Framework.WebDriver.Elements;
using System.Collections.ObjectModel;

namespace AutomatedTests.Forms
{
    /// <summary>
    /// Class describe Car Reveiw form
    /// </summary>
    public class CarReviewForm : BaseForm
    {
        private static readonly By titleLocator = By.XPath("//div[@class='col41']//h1[contains(text(), 'Car Reviews')]");
        private Button btGo = new Button(By.Name("&lid=reviewsSearch"), "Button Go by selected car");
        private IWebElement MakeFirstCar;
        private IWebElement ModelFirstCar;
        private IWebElement YearFirstCar;
        private string stMake;
        private string stYear;
        private string stModel;
        public static string FirstCarMake;
        public static string FirstCarModel;
        public static string FirstCarYear;
        private string cbMakeXPath = "//select[@id='makeid']//option";
        private string cbModelXPath = "//select[@id='modelid']//option";
        private string cbYearXPath = "//select[@id='year']//option";

        Random random = new Random();

        /// <summary>
        /// Default constuctor
        /// </summary>
        public CarReviewForm() : base(titleLocator, "Car Review Form") { }

        /// <summary>
        /// Select car by make, model and year
        /// </summary>
        public void SelectAuto()
        {
            stYear = "0";

            while (Convert.ToInt32(stYear) < 1997)
            {
                ReadOnlyCollection<IWebElement> AllcbMake = Browser.GetDriver().FindElements(By.XPath(cbMakeXPath));
                MakeFirstCar = AllcbMake[random.Next(1, AllcbMake.Count)];
                stMake = MakeFirstCar.Text;
                MakeFirstCar.Click();
                ReadOnlyCollection<IWebElement> AllcbModel = Browser.GetDriver().FindElements(By.XPath(cbModelXPath));
                ModelFirstCar = AllcbModel[random.Next(1, AllcbModel.Count)];
                stModel = ModelFirstCar.Text;
                ModelFirstCar.Click();
                ReadOnlyCollection<IWebElement> AllcbYear = Browser.GetDriver().FindElements(By.XPath(cbYearXPath));
                YearFirstCar = AllcbYear[random.Next(0, AllcbYear.Count)];
                stYear = YearFirstCar.Text;
                YearFirstCar.Click();
            }

            btGo.ClickAndWaitForLoading();
        }

        public void SaveFirstCarFeature()
        {
            FirstCarMake = stMake;

            if (stMake == "ForTwo")
            {
                FirstCarMake = stMake.ToLower();
            }
            else if (stMake.Contains("Type"))
            {
                FirstCarMake = stMake.Replace("Type ", "");
            }
            else if (stMake.Contains("X-Type"))
            {
                FirstCarMake = stMake.ToUpper();
            }
            else if (stMake.Contains("Aero 8"))
            {
                FirstCarMake = stMake.Replace(" ", "");
            }
            else if (stMake.Contains("e-Hybrid"))
            {
                FirstCarMake = stMake.Replace("e", "E");
            }

            FirstCarModel = stModel;
            FirstCarYear = stYear;
        }
    }
}
