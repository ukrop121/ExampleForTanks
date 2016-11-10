using OpenQA.Selenium;
using WebdriverFramework.Framework.WebDriver;
using WebdriverFramework.Framework.WebDriver.Elements;
using AutomatedTests.Menus;

namespace AutomatedTests.Forms
{
    /// <summary>
    /// Class describe main form https://www.cars.com/
    /// </summary>
    public class MainForm : BaseForm
    {
        private static readonly By titleLocator = By.XPath("//div[@class='promo-copy container']");
        private Link lkReviewCar = new Link(By.XPath("//li[@tracking-name='header-car-reviews']"), "Review a Car link");
        TopMenu topMenu = new TopMenu();

        /// <summary>
        /// Default constuctor
        /// </summary>
        public MainForm() : base(titleLocator, "MainForm") { }

        /// <summary>
        /// Method navigete to section menu Review a Car
        /// </summary>
        public void NavigateToReviewCar()
        {
            topMenu.OpenMenu(topMenu.sectionBuy);
            lkReviewCar.ClickAndWaitForLoading();
        }
    }
}
