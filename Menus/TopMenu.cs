using OpenQA.Selenium;
using WebdriverFramework.Framework.WebDriver.Elements;

namespace AutomatedTests.Menus
{
    public class TopMenu
    {
        private const string TmpMenuLnk = "//a[contains(@class,'navbar-item-link nav-item-menu')][contains(@data-linkname,'{0}')]";

        public string sectionBuy = "header-buy";
        public string sectionSellTrade = "header-sell";
        public string sectionServiceRepair = "header-service";
        public string sectionHeaderNews = "header-news";

        /// <summary>
        /// open top menu item using click
        /// </summary>
        /// <param name="name"></param>
        public void OpenMenu(string name)
        {
            new Link(By.XPath(string.Format(TmpMenuLnk, name)), "Menu item " + name).ClickAndWaitForLoading();
        }
    }
}


