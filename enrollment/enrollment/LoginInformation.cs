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
	public class LoginInformation : IdentityVerification
	{
		internal void username(String user){
			//Username
			driver1.FindElement (By.Id ("Username")).SendKeys (user);
			//Verify
			driver1.FindElement (By.Name ("#")).Click ();
		}

		internal void password(String pass){
			//Password
			driver1.FindElement (By.Id ("Password")).SendKeys (pass);
			//Confirm
			driver1.FindElement (By.Id ("ConfirmPassword")).SendKeys (pass);
			//Verify
			new WebDriverWait (driver1, TimeSpan.FromSeconds (10)).Until (ExpectedConditions.ElementExists ((By.XPath ("//span[contains(text(),'Password strength indicator:')]/span[contains(text(),'Average')]"))));
			driver1.FindElement (By.XPath ("//form[contains(@action, 'UpdatePassword')]//button[text()='Verify']")).Click ();
		}

		internal void passphrase(String phrase){
			//Phrase
			driver1.FindElement (By.Id ("Passphrase")).SendKeys (phrase);
			//Verify
			driver1.FindElement (By.XPath ("(//button[@name='#'])[3]")).Click ();
		}

		internal void securityimage(){
			//Click on image
			driver1.FindElement (By.XPath ("//div[@class='sg-slider k-widget k-listview k-selectable']/img[1]")).Click ();
			//Verify
			driver1.FindElement (By.XPath ("(//button[@name='#'])[4]")).Click ();
		}

		internal void securityquestion(String question){
			//Confirm
			driver1.FindElement (By.Id ("Questions_0__Answer")).SendKeys (question);
			//Verify
			driver1.FindElement (By.XPath ("(//button[@name='#'])[5]")).Click ();
			//Continue
			driver1.FindElement (By.XPath ("//button[text()='Continue']")).Click ();
		}

		public void runScreen2(String user, String pass, String phrase, String question){
			username (user);
			password (pass);
			passphrase (phrase);
			securityimage ();
			securityquestion (question);
		}
	}
}

