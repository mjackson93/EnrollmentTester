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
	public class AccountFeatures : LoginInformation
	{
		public void runScreen3() {
			//Toggleboxes
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-2')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-3')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-4')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-5')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-6')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-7')]")).Click();
			//Continue
			new WebDriverWait (driver1, TimeSpan.FromSeconds (10)).Until (ExpectedConditions.ElementExists ((By.XPath ("//div[contains(@data-viewmodel, 'wizard/viewmodels/step')]/div[2]/button"))));
			driver1.FindElement (By.XPath ("//div[contains(@data-viewmodel, 'wizard/viewmodels/step')]/div[2]/button")).Click ();
		}
	}
}

