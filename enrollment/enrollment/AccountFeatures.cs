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
		public AccountFeatures ()
		{
		}

		public void runScreen3(String answer, String username, String password, String passphrase, String securityquestion) {
			new WebDriverWait (driver1, TimeSpan.FromSeconds (100)).Until (ExpectedConditions.ElementExists ((By.Id ("Questions_0__Answer"))));
			//Last Deposit
			driver1.FindElement (By.Id ("Questions_0__Answer")).SendKeys ("100");
			//Verify
			new WebDriverWait (driver1, TimeSpan.FromSeconds (10)).Until (ExpectedConditions.ElementExists ((By.Name ("#"))));
			driver1.FindElement (By.XPath ("(//button[@name='#'])[2]")).Click ();
			//Verify
			driver1.FindElement (By.XPath ("//div/div[4]/button")).Click ();
			//Username
			driver1.FindElement (By.Id ("Username")).SendKeys ("017804");
			//Verify
			driver1.FindElement (By.Name ("#")).Click ();
			//Password
			driver1.FindElement (By.Id ("Password")).SendKeys ("123qweasdqwe123");
			//Confirm
			driver1.FindElement (By.Id ("ConfirmPassword")).SendKeys ("123qweasdqwe123");
			//Verify
			new WebDriverWait (driver1, TimeSpan.FromSeconds (10)).Until (ExpectedConditions.ElementExists ((By.XPath ("//span[contains(text(),'Password strength indicator:')]/span[contains(text(),'Average')]"))));
			driver1.FindElement (By.XPath ("//form[contains(@action, 'UpdatePassword')]//button[text()='Verify']")).Click ();
			//Phrase
			driver1.FindElement (By.Id ("Passphrase")).SendKeys ("cat");
			//Verify
			driver1.FindElement (By.XPath ("(//button[@name='#'])[3]")).Click ();
			driver1.FindElement (By.XPath ("//div[@class='sg-slider k-widget k-listview k-selectable']/img[1]")).Click ();
			//Verify
			driver1.FindElement (By.XPath ("(//button[@name='#'])[4]")).Click ();
			//Confirm
			driver1.FindElement (By.Id ("Questions_0__Answer")).SendKeys ("100");
			//Verify
			driver1.FindElement (By.XPath ("(//button[@name='#'])[5]")).Click ();
			//Continue
			driver1.FindElement (By.XPath ("//button[text()='Continue']")).Click ();
			//Toggleboxes
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-2')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-3')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-4')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-5')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-6')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-7')]")).Click();
			//Continue
			driver1.FindElement (By.XPath ("//button[text()='Continue']")).Click ();
			driver1.FindElement (By.XPath ("//button[text()='Continue']")).Click ();

		}
	}
}

