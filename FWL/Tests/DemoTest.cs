using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using FWL.Framework;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FWL.Tests
{
    public class DemoTest
    {
        [Test]
        public void RunTest()
        {
            var browser = AqualityServices.Browser;

            browser.Maximize();
            browser.GoTo(Config.Get(ConfigString.BaseUrl));
            browser.WaitForPageToLoad();

            var searchTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.Name("search"), "Search");

            searchTextBox.SendKeys("Selenium" + Keys.Enter);
            browser.WaitForPageToLoad();

            var heading = AqualityServices.Get<IElementFactory>().GetLabel(By.Id("firstHeading"), "Heading");

            Assert.AreEqual("Selenium", heading.GetText(), "Heading should be as expected");

            browser.Quit();
        }
    }
}