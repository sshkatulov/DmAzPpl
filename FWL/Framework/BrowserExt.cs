using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;

namespace FWL.Framework
{
    public class BrowserExt
    {
        public static Browser browser = AqualityServices.Browser;

        public static void Initiate(string url, int width = 0, int height = 0)
        {
            if (width == 0 || height == 0)
            {
                browser.Maximize();
            }
            else
            {
                browser.SetWindowSize(width, height);
            }
            browser.GoTo(url);
            browser.WaitForPageToLoad();
        }

        public static void Quit() => browser?.Quit();

        public static byte[] GetScreenshot() => browser.GetScreenshot();

        public static string GetCurrentWindow() => browser.Driver.CurrentWindowHandle;

        public static string OpenNewWindow(string url)
        {
            browser.ExecuteScript($"window.open('{url}','_blank');");
            var windows = browser.Driver.WindowHandles;
            browser.Driver.SwitchTo().Window(windows[1]);
            browser.WaitForPageToLoad();
            return browser.Driver.CurrentWindowHandle;
        }

        public static void SwitchToWindow(string window) => browser.Driver.SwitchTo().Window(window);
    }
}