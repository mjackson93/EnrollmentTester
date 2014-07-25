using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace enrollment
{

	[TestFixture()]
	public class Program : Eurydice2
	{
		[Test()]
		public void TestCase() {
			int number = 17818;

			String testssn = "0000" + number.ToString();
			String testaccountnumber = "00000" + number.ToString();
			String testusername = "0" + number.ToString();

			runScreen1 (testssn, testaccountnumber, 1, 1, 1999, "a", "a", "Alaska", 11111, "a@a.com", "100");
			runScreen2 (testusername, "123qweasdqwe123", "cat", "cat");
			runScreen3 ();
			runScreen4 ();
		}



        /* UnenrollUser
         * ------------
         * Goes to the QA tools site and un-enrolls the given user by username via the Kill Bill tool.
         */
        [TestCase("test0123")]
        public void UnenrollUser(String username)
        {
            IWebDriver driver = new FirefoxDriver();
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl("https://qatools.orpheusdev.net/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.XPath("//select [contains(@id, 'cnnId')]")));
            driver.FindElement(By.XPath("//select [contains(@id, 'cnnId')]")).Click();
            for (int i = 0; i < 3; i++) action.SendKeys(Keys.Down).Perform();
            action.SendKeys(Keys.Enter).Perform();
            driver.FindElement(By.XPath("//input [contains(@name, 'param')]")).SendKeys(username);
            driver.FindElement(By.XPath("//button [contains(@id, 'button3')]")).Click();
        }

		public static void Main(){}

	}

}