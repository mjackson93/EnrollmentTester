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
	public abstract class Eurydice {
		internal static IWebDriver driver = new FirefoxDriver(); // TODO change into
		internal static Actions action = new Actions(driver);
		// method
		internal static int IMPLICIT_WAIT_SECONDS = 10;


		public static void setup(String dnp) {
			driver.Navigate().GoToUrl("https://" + dnp + ".orpheusdev.net/Users/Account/LogOn");
		}

		public static IWebDriver getDriver() {
			return driver;
		}

		public static Actions getAction() {
			return action;
		}
	}
}

