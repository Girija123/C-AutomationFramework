using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWebAutomation
{
    public class BagTests
    {

        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com";
            Assert.That(driver.Title, Is.EqualTo("Swag Labs"));
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Name("login-button")).Click();
            Assert.That(driver.FindElement(By.ClassName("title")).Text, Is.EqualTo("PRODUCTS"));
        }

        [Test]
        public void VerifyAddProductToBag()
        {
            driver.FindElement(By.XPath("//div[text()='Sauce Labs Backpack']/ancestor::div[@class='inventory_item_label']/following::div[@class='pricebar'][1]/button[text()='Add to cart']")).Click();
            Assert.That(driver.FindElement(By.ClassName("shopping_cart_badge")).Text, Is.EqualTo("1"));
            driver.FindElement(By.CssSelector(".shopping_cart_link")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".title")).Text, Is.EqualTo("YOUR CART"));
            Assert.That(driver.FindElement(By.CssSelector(".inventory_item_name")).Text, Is.EqualTo("Sauce Labs Backpack"));
        }

        [Test]
        public void VerifyRemoveProductFromBag()
        {

        }

        [TearDown]
        public void TearDown() 
        {
            driver.Quit();
        }
    }
}
