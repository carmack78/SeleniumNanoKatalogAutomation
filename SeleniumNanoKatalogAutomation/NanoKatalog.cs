using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumNanoKatalogAutomation
{
    class NanoKatalog
    {
        // Web Driver 4 Chrome Browser
        IWebDriver Driver4Chrome = null;

        // Start Page
        const string WebStartPage = "https://www.nanokatalog.com/kategori/ram-ve-bellek-karti";

        // Right-Bottom Banner
        IWebElement BannerCloseButton = null;

        // Search Items
        IWebElement BellekTipi = null;
        IWebElement Bellek16GB = null;
        IWebElement Bellek32GB = null;
        IWebElement Bellek2400Mhz = null;
        IWebElement Bellek2666Mhz = null;
        IWebElement BellekSODIMM = null;
        IWebElement FiyatSirala = null;
        IWebElement Kingston16GB = null;
        IWebElement Kingston16GBQuantity = null;
        IWebElement HemenAlButton = null;

        // Login Items
        IWebElement LoginEmail = null;
        IWebElement LoginPassword = null;
        IWebElement LoginRememberMe = null;
        IWebElement LoginButton = null;

        // Payment Items
        IWebElement CargoSelection = null;
        IWebElement PaymentButton = null;

        // Screenshots
        string SSSearchBefore = null;
        string SSSearchAfter = null;
        string SSBasketBefore = null;
        string SSBasketAfter = null;
        string SSLoginBefore = null;
        string SSLoginAfter = null;
        string SSCargoBefore = null;
        string SSCargoAfter = null;
        string SSCreditCardBefore = null;

        // Reporting
        ExtentReports Report;
        ExtentTest Test;
        Status TestStatus;

        [OneTimeSetUp]
        public void OneTimeCreate()
        {
            // Driver Setup
            Driver4Chrome = new ChromeDriver(@"C:\Selenium");
            Driver4Chrome.Navigate().GoToUrl(WebStartPage);
            Driver4Chrome.Manage().Window.Maximize();
            
            // Report Setup - Create report directory and HTML report into it
            Report = new ExtentReports();
            string AppDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(AppDirectory + "\\Test_Execution_Reports");
            var HtmlReporter = new ExtentHtmlReporter(AppDirectory + "\\Test_Execution_Reports\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
            Report.AddSystemInfo("Environment", "Test");
            Report.AddSystemInfo("Test Automation Developer", "Taylan Inan");
            Report.AttachReporter(HtmlReporter);
        }

        [SetUp]
        public void TestStart()
        {
            Test = Report.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test()]
        public void TestLogin()
        {
        }

        [Test()]
        public void TestSearch()
        {
            const int ClickWait = 3000;

            // Wait for the page to fully load
            Thread.Sleep(ClickWait);

            BannerCloseButton = Driver4Chrome.FindElement(By.ClassName("_close-button"));
            BannerCloseButton.Click();

            SSSearchBefore = TakeScreenShot(Driver4Chrome, "screenshot_search_before");

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            BellekTipi = Driver4Chrome.FindElement(By.XPath("//*[@id=\"node2630\"]/a"));
            BellekTipi.Click();

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            Bellek16GB = Driver4Chrome.FindElement(By.XPath("//*[@id=\"node2627\"]/a"));
            Bellek16GB.Click();

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            Bellek32GB = Driver4Chrome.FindElement(By.XPath("//*[@id=\"node2681\"]/a"));
            Bellek32GB.Click();

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            Bellek2400Mhz = Driver4Chrome.FindElement(By.XPath("//*[@id=\"node2628\"]/a"));
            Bellek2400Mhz.Click();

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            Bellek2666Mhz = Driver4Chrome.FindElement(By.XPath("//*[@id=\"node2680\"]/a"));
            Bellek2666Mhz.Click();

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            BellekSODIMM = Driver4Chrome.FindElement(By.XPath("//*[@id=\"node2682\"]/a"));
            BellekSODIMM.Click();

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            FiyatSirala = Driver4Chrome.FindElement(By.Id("searchprice"));
            var FiyatItem = new SelectElement(FiyatSirala);
            FiyatItem.SelectByValue("asc");

            SSSearchAfter = TakeScreenShot(Driver4Chrome, "screenshot_search_after");

            // Wait for the page to refresh
            Thread.Sleep(ClickWait);
            NewsletterClose();

            Kingston16GB = Driver4Chrome.FindElement(By.XPath("//*[@id=\"Item_101587\"]/div/div[3]/a[2]"));
            Driver4Chrome.Navigate().GoToUrl(Kingston16GB.GetAttribute("href"));

            // Wait for the page to fully load
            Thread.Sleep(ClickWait);

            SSBasketBefore = TakeScreenShot(Driver4Chrome, "screenshot_basket_before");

            Kingston16GBQuantity = Driver4Chrome.FindElement(By.Id("quantity_101587"));
            Kingston16GBQuantity.Clear();
            Kingston16GBQuantity.SendKeys("2");

            SSBasketAfter = TakeScreenShot(Driver4Chrome, "screenshot_basket_after");

            HemenAlButton = Driver4Chrome.FindElement(By.Id("QuickOrder_101587"));
            HemenAlButton.Click();

            // Wait for the page to fully load
            Thread.Sleep(ClickWait);

            Driver4Chrome.Navigate().GoToUrl("https://www.nanokatalog.com/uye-girisi?next=order2");

            // Wait for the page to fully load
            Thread.Sleep(ClickWait);

            SSLoginBefore = TakeScreenShot(Driver4Chrome, "screenshot_login_before");

            LoginEmail = Driver4Chrome.FindElement(By.Id("email"));
            LoginEmail.Clear();
            LoginEmail.SendKeys("taylaninan@yahoo.com");

            LoginPassword = Driver4Chrome.FindElement(By.Id("pass"));
            LoginPassword.Clear();
            LoginPassword.SendKeys("XXXXXXXX");

            LoginRememberMe = Driver4Chrome.FindElement(By.ClassName("checkbox"));
            LoginRememberMe.Click();

            SSLoginAfter = TakeScreenShot(Driver4Chrome, "screenshot_login_after");

            var SubmitButtons = Driver4Chrome.FindElements(By.Name("Submit"));
            LoginButton = SubmitButtons[1];
            LoginButton.Click();

            // Wait for the page to fully load
            Thread.Sleep(ClickWait);

            SSCargoBefore = TakeScreenShot(Driver4Chrome, "screenshot_cargo_before");

            CargoSelection = Driver4Chrome.FindElement(By.XPath("//*[@id=\"_order-cargo-details-content\"]/div/div[2]/ul/li[1]/div"));
            CargoSelection.Click();

            SSCargoAfter = TakeScreenShot(Driver4Chrome, "screenshot_cargo_after");

            PaymentButton = Driver4Chrome.FindElement(By.XPath("//*[@id=\"_order-panel-cart-body\"]/div[2]/div/div[4]/button"));
            PaymentButton.Click();

            // Wait for the page to fully load
            Thread.Sleep(ClickWait);

            SSCreditCardBefore = TakeScreenShot(Driver4Chrome, "screenshot_creditcard_before");
        }

        [TearDown]
        public void TestFinish()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    TestStatus = Status.Fail;
                    Test.Log(TestStatus, "Test ended with " + TestStatus + " – " + errorMessage);
                    break;

                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    TestStatus = Status.Skip;
                    Test.Log(TestStatus, "Test ended with " + TestStatus);
                    break;

                default:
                    TestStatus = Status.Pass;
                    string screenShotPath = TakeScreenShot(Driver4Chrome, TestContext.CurrentContext.Test.Name);

                    Test.Log(TestStatus, "Test ended with " + TestStatus);
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSSearchBefore));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSSearchAfter));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSBasketBefore));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSBasketAfter));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSLoginBefore));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSLoginAfter));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSCargoBefore));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSCargoAfter));
                    Test.Log(TestStatus, "Snapshot below: " + Test.AddScreenCaptureFromPath(SSCreditCardBefore));
                    break;
            }

            // Right-Bottom Banner
            BannerCloseButton = null;

            // Search Items
            BellekTipi = null;
            Bellek16GB = null;
            Bellek32GB = null;
            Bellek2400Mhz = null;
            Bellek2666Mhz = null;
            BellekSODIMM = null;
            Kingston16GB = null;
            Kingston16GBQuantity = null;
            HemenAlButton = null;

            // Login Items
            LoginEmail = null;
            LoginPassword = null;
            LoginRememberMe = null;
            LoginButton = null;

            // Payment Items
            CargoSelection = null;
            PaymentButton = null;

            // Screenshot Items
            SSSearchBefore = null;
            SSSearchAfter = null;
            SSBasketBefore = null;
            SSBasketAfter = null;
            SSLoginBefore = null;
            SSLoginAfter = null;
            SSCargoBefore = null;
            SSCargoAfter = null;
            SSCreditCardBefore = null;
        }

        [OneTimeTearDown]
        public void OneTimeDispose()
        {
            Report.Flush();

            Thread.Sleep(10000);

            if (Driver4Chrome != null)
            {
                Driver4Chrome.Dispose();
                Driver4Chrome.Quit();
            }
        }

        public void NewsletterClose()
        {
            // Newsletter
            IWebElement NewsletterCloseButton = null;

            try
            {
                NewsletterCloseButton = Driver4Chrome.FindElement(By.ClassName("mc-closeModal"));
            }
            catch (NoSuchElementException Exception)
            {
                NewsletterCloseButton = null;
            }
            finally
            {
                if (NewsletterCloseButton != null)
                {
                    if (NewsletterCloseButton.Enabled && NewsletterCloseButton.Displayed)
                    {
                        NewsletterCloseButton.Click();
                    }
                }
            }

            NewsletterCloseButton = null;
        }

        private bool IsTextPresentById(string Id, string Message)
        {
            bool TextFound = false;
            var Texts = Driver4Chrome.FindElements(By.Id(Id));

            if (Texts.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var Text in Texts)
                {
                    if (Text.Text.Contains(Message))
                    {
                        TextFound = true;
                    }
                }
            }

            return TextFound;
        }

        private string TakeScreenShot(IWebDriver Driver, string ScreenShotName)
        {
            string localpath = "";

            Thread.Sleep(500);

            ITakesScreenshot ts = (ITakesScreenshot)Driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Screenshots\\");
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Screenshots\\" + ScreenShotName + ".png";
            localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath);

            return localpath;
        }
    }
}
