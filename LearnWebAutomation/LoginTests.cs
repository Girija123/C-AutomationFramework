using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace LearnWebAutomation
{
    public class Tests
    {

        public IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com";
        }

        [Test]
        public void VerifyLoginWithValidData()
        {
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Name("login-button")).Click();
            Assert.That(driver.FindElement(By.ClassName("title")).Text, Is.EqualTo("PRODUCTS"));
            Assert.True(driver.FindElement(By.ClassName("title")).Displayed);

            }

        [Test]
        public void VerifyLoginWithInValidData() {

            driver.FindElement(By.Id("user-name")).SendKeys("standard_user_inv");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce_inv");
            driver.FindElement(By.Name("login-button")).Click();
            Assert.That(driver.FindElement(By.XPath("//h3[@data-test='error']")).Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}