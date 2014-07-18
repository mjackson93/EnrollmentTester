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
	public class IdentityVerification : Eurydice
	{
		internal IWebDriver driver1 = getDriver();
		public Actions action1 = getAction();
		public IdentityVerification ()
		{

		}

		public void runScreen1(String ssn, String accountnumber, int month, int day, int year){
			//SSN
			setup ("qavip");
			//Click on Register
			driver1.FindElement(By.LinkText("Register")).Click();
			new WebDriverWait(driver1, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("Ssn"))));
			driver1.FindElement(By.Id("Ssn")).SendKeys(ssn);
			//Account Number
			driver1.FindElement(By.Id("AccountNumber")).SendKeys(accountnumber);
			//Birth Month 
			//Changing the number in the for loop will change the month:  
			//January=1, February=2, March=3, etc...
			driver1.FindElement(By.ClassName("k-input")).Click(); 
			for (int i = 0; i < month; i++)
			{
				action.SendKeys(Keys.ArrowDown).Perform();
			}
			action1.SendKeys(Keys.Enter).Perform();
			//Birth day
			driver1.FindElement(By.Id("Birthdate_Day")).SendKeys(day.ToString());
			//Birth year
			driver1.FindElement(By.Id("Birthdate_Year")).SendKeys(year.ToString());
			//Verify
			new WebDriverWait(driver1, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Name("#"))));
			driver1.FindElement(By.Name("#")).Click();
		}
	}
}

