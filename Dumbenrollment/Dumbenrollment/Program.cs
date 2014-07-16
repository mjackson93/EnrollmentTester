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

namespace Dumbenrollment
{
	[TestFixture()]
	class MainClass
	{
		[Test()]
		public static void TestCaseData(){
			//Use google search
			IWebDriver driver = new FirefoxDriver();
			Actions action = new Actions(driver);

			driver.Manage().Cookies.DeleteAllCookies();
			driver.Navigate().GoToUrl("https://qa.orpheusdev.net/Users/Account/LogOn");

			//Click on Register
			driver.FindElement(By.LinkText("Register")).Click();
			//SSN
			new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("Ssn"))));
			driver.FindElement(By.Id("Ssn")).SendKeys("113355779");
			//Account Number
			driver.FindElement(By.Id("AccountNumber")).SendKeys("0000145123");
			//Birth Month 
			//Changing the number in the for loop will change the month:  
			//January=1, February=2, March=3, etc...
			driver.FindElement(By.ClassName("k-input")).Click(); 
			int MONTH = 10;
			for (int i = 0; i < MONTH; i++)
			{
				action.SendKeys(Keys.ArrowDown).Perform();
			}
			action.SendKeys(Keys.Enter).Perform();
			//Birth day
			driver.FindElement(By.Id("Birthdate_Day")).SendKeys("03");
			//Birth year
			driver.FindElement(By.Id("Birthdate_Year")).SendKeys("1961");
			//Verify
			driver.FindElement(By.Name("#")).Click();
			//SECOND SCREEN
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
			//Street Address
			driver.FindElement(By.Id("Street")).SendKeys("1020 THAT WAY");
			//City
			driver.FindElement(By.Id("City")).SendKeys("PALMER");
			//State
			//Changing the number in the for loop will change the state:
			//Quick reference: AK1 AL2 AZ3 AR4 CA5 CO6 CT7 DC8 DE9 FL10 GA11 HI12 
			//IA13 ID14 IL15 IN16 KS17 KY18 LA19 MA20 MD21 ME22 MI23 MN24 MO25 MS26 
			//MT27 NC28 ND29 NE30 NH31 NJ32 NM33 NV34 NY35 OH36 OK37 OR38 PA39 PR40 
			//RI41 SC42 SD43 TN44 TX45 UT46 VA47 VI48 VT49 WA50 WI51 WV52 WY53
			driver.FindElement(By.ClassName("k-input")).Click();
			int STATE = 1;
			for (int i = 0; i < STATE; i++)
			{
				action.SendKeys(Keys.ArrowDown).Perform();
			}
			action.SendKeys(Keys.Enter).Perform();
			//Zipcode
			driver.FindElement(By.Id("ZipCode")).SendKeys("99645");
			//Verify
			driver.FindElement(By.Name("#")).Click();
			//THIRD SCREEN
			new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.Id("Questions_0__Answer"))));
			//Last Deposit
			driver.FindElement(By.Id("Questions_0__Answer")).SendKeys("100");
			//Verify
			new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Name("#"))));
			driver.FindElement(By.XPath("(//button[@name='#'])[2]")).Click();
			//Verify
			driver.FindElement(By.XPath("//div/div[4]/button")).Click();
			//Username
			driver.FindElement(By.Id("Username")).SendKeys("captaing");
			//Verify
			driver.FindElement(By.Name("#")).Click();
			//Password
			driver.FindElement(By.Id("Password")).SendKeys("Allrights123!@#");
			//Confirm
			driver.FindElement(By.Id("ConfirmPassword")).SendKeys("Allrights123!@#");
			//Verify
			new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//span[contains(text(),'Password strength indicator:')]/span[contains(text(),'Strong')]"))));
			driver.FindElement(By.XPath("//form[contains(@action, 'UpdatePassword')]//button[text()='Verify']")).Click();
			//Phrase
			driver.FindElement(By.Id("Passphrase")).SendKeys("cat");
			//Verify
			driver.FindElement(By.XPath("(//button[@name='#'])[3]")).Click();
			driver.FindElement(By.XPath("//div[@class='sg-slider k-widget k-listview k-selectable']/img[1]")).Click();
			//Verify
			driver.FindElement(By.XPath("(//button[@name='#'])[4]")).Click();
			//Confirm
			driver.FindElement(By.Id("Questions_0__Answer")).SendKeys("100");
			//Verify
			driver.FindElement(By.XPath("(//button[@name='#'])[5]")).Click();
			//Continue
			driver.FindElement(By.XPath("//button[text()='Continue']")).Click();
			//Toggleboxes
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-2')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-3')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-4')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-5')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-6')]")).Click();
			//driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-7')]")).Click();
			//Continue
			driver.FindElement(By.XPath("//button[text()='Continue']")).Click();
			//Confirm and enroll
			driver.FindElement(By.XPath("//form[contains(@action, 'Confirmation')]/div[4]/input")).Click(); 

		}

		public static void Main (string[] args)
		{

		}
	}
}
