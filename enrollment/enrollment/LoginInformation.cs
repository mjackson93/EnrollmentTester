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
		public LoginInformation ()
		{
		}

		public void runScreen2(String street, String city, String state, int zipcode, String email){
			IWebDriver driver1 = getDriver();
			//SECOND SCREEN
			driver1.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
			//Street Address
			driver1.FindElement(By.Id("Street")).SendKeys(street);
			//City
			driver1.FindElement(By.Id("City")).SendKeys(city);
			//State
			//Changing the number in the for loop will change the state:
			//Quick reference: AK1 AL2 AZ3 AR4 CA5 CO6 CT7 DC8 DE9 FL10 GA11 HI12 
			//IA13 ID14 IL15 IN16 KS17 KY18 LA19 MA20 MD21 ME22 MI23 MN24 MO25 MS26 
			//MT27 NC28 ND29 NE30 NH31 NJ32 NM33 NV34 NY35 OH36 OK37 OR38 PA39 PR40 
			//RI41 SC42 SD43 TN44 TX45 UT46 VA47 VI48 VT49 WA50 WI51 WV52 WY53
			driver1.FindElement(By.ClassName("k-input")).Click();
			action.SendKeys(state);
			/*int STATE = 1;
			for (int i = 0; i < STATE; i++)
			{
				action.SendKeys(Keys.ArrowDown).Perform();
			}*/
			action1.SendKeys(Keys.Enter).Perform();
			//Zipcode
			driver1.FindElement(By.Id("ZipCode")).SendKeys(zipcode.ToString());
			//Email/Confirm
			driver1.FindElement(By.Id("Email")).SendKeys(email);
			driver1.FindElement(By.Id("ConfirmEmail")).SendKeys(email);
			//Verify
			driver1.FindElement(By.Name("#")).Click();
		}
	}
}

