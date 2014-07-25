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
	public class Confirmation: AccountFeatures
	{
		public void runScreen4(){
			//Confirm and enroll
			new WebDriverWait (driver1, TimeSpan.FromSeconds (10)).Until (ExpectedConditions.ElementExists ((By.XPath ("//input[contains(@type, 'submit')]"))));
			action.SendKeys (Keys.Shift + Keys.Tab).Perform();
			action.SendKeys (Keys.Enter).Perform();
			setup ("qavip");
			driver1.Quit ();
		}
}
}

