using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace automatizacionSelenium
{
    public class YoutubeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SearchVideo()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://youtube.com");

            driver.Manage().Window.Maximize();

            IWebElement searchElement = driver.FindElement(By.CssSelector("input#search"));
            searchElement.SendKeys("cypress js en español");
            searchElement.SendKeys(Keys.Enter);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement videoElement = driver.FindElement(By.XPath("//*[@id=\"video-title\"]"));
            videoElement.Click();

            driver.Quit();
        }

        [Test]
        public void DeleteHistory()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://youtube.com");

            IWebElement historyButton = driver.FindElement(By.CssSelector("a#endpoint[href=\"/feed/history\"]"));
            historyButton.Click();
            IWebElement deleteHistoryButton = driver.FindElement(By.CssSelector("button[aria-label=\"Borrar todo el historial de reproducciones\"]"));
            deleteHistoryButton.Click();
            IWebElement confirmDelete = driver.FindElement(By.CssSelector("button[aria-label=\"Borrar historial de reproducciones\"]"));
            confirmDelete.Click();
            driver.Quit();
        }
    }
}