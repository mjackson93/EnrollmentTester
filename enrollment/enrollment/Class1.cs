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
    public class Eurydice2
    {
        //internal static IWebDriver driver = new FirefoxDriver(); // TODO change into
        //internal static Actions action = new Actions(driver);
        // method
        public static int IMPLICIT_WAIT_SECONDS = 10;
        public static IWebDriver driver2 = new FirefoxDriver();
        public static Actions action1 = new Actions(driver2);

        internal static void setup(String dnp)
        {
            driver2.Navigate().GoToUrl("https://" + dnp + ".orpheusdev.net/Users/Account/LogOn");
        }

        //public static IWebDriver getDriver()
        //{
        //    return driver;
        //}

        //public static Actions getAction()
        //{
        //    return action;
        //}

       

        //Identity Verification Page
        internal void part1(String ssn, String accountnumber, int month, int day, int year)
        {
            //SSN
            //driver2 = getDriver();
            setup("qavip");
            //Click on Register
            driver2.FindElement(By.LinkText("Register")).Click();
            new WebDriverWait(driver2, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("Ssn"))));
            driver2.FindElement(By.Id("Ssn")).SendKeys(ssn);
            //Account Number
            driver2.FindElement(By.Id("AccountNumber")).SendKeys(accountnumber);
            //Birth Month 
            //Changing the number in the for loop will change the month:  
            //January=1, February=2, March=3, etc...
            driver2.FindElement(By.ClassName("k-input")).Click();
            for (int i = 0; i < month; i++)
            {
                action1.SendKeys(Keys.ArrowDown).Perform();
            }
            action1.SendKeys(Keys.Enter).Perform();
            //Birth day
            driver2.FindElement(By.Id("Birthdate_Day")).SendKeys(day.ToString());
            //Birth year
            driver2.FindElement(By.Id("Birthdate_Year")).SendKeys(year.ToString());
            //Verify
            new WebDriverWait(driver2, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Name("#"))));
            driver2.FindElement(By.Name("#")).Click();
        }

        internal void part2(String street, String city, String state, int zipcode, String email)
        {
            //IWebDriver driver2 = getDriver();
            //SECOND SCREEN
            driver2.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //Street Address
            driver2.FindElement(By.Id("Street")).SendKeys(street);
            //City
            driver2.FindElement(By.Id("City")).SendKeys(city);
            //State
            //Changing the number in the for loop will change the state:
            //Quick reference: AK1 AL2 AZ3 AR4 CA5 CO6 CT7 DC8 DE9 FL10 GA11 HI12 
            //IA13 ID14 IL15 IN16 KS17 KY18 LA19 MA20 MD21 ME22 MI23 MN24 MO25 MS26 
            //MT27 NC28 ND29 NE30 NH31 NJ32 NM33 NV34 NY35 OH36 OK37 OR38 PA39 PR40 
            //RI41 SC42 SD43 TN44 TX45 UT46 VA47 VI48 VT49 WA50 WI51 WV52 WY53
            driver2.FindElement(By.ClassName("k-input")).Click();
            action1.SendKeys(state);
            /*int STATE = 1;
            for (int i = 0; i < STATE; i++)
            {
                action.SendKeys(Keys.ArrowDown).Perform();
            }*/
            action1.SendKeys(Keys.Enter).Perform();
            //Zipcode
            driver2.FindElement(By.Id("ZipCode")).SendKeys(zipcode.ToString());
            //Email/Confirm
            driver2.FindElement(By.Id("Email")).SendKeys(email);
            driver2.FindElement(By.Id("ConfirmEmail")).SendKeys(email);
            //Verify
            driver2.FindElement(By.Name("#")).Click();
        }

        internal void part3(String answer)
        {
            new WebDriverWait(driver2, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.Id("Questions_0__Answer"))));
            //Last Deposit
            driver2.FindElement(By.Id("Questions_0__Answer")).SendKeys("100");
            //Verify
            new WebDriverWait(driver2, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Name("#"))));
            driver2.FindElement(By.XPath("(//button[@name='#'])[2]")).Click();
            //Verify
            driver2.FindElement(By.XPath("//div/div[4]/button")).Click();
        }

        public void runScreen1(String ssn, String accountnumber, int month, int day, int year, String street, String city, String state, int zipcode, String email, String answer)
        {
            part1(ssn, accountnumber, month, day, year);
            part2(street, city, state, zipcode, email);
            part3(answer);
        }

        //Login information
        internal void username(String user)
        {
            //Username
            driver2.FindElement(By.Id("Username")).SendKeys(user);
            //Verify
            driver2.FindElement(By.Name("#")).Click();
        }

        internal void password(String pass)
        {
            //Password
            driver2.FindElement(By.Id("Password")).SendKeys(pass);
            //Confirm
            driver2.FindElement(By.Id("ConfirmPassword")).SendKeys(pass);
            //Verify
            new WebDriverWait(driver2, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//span[contains(text(),'Password strength indicator:')]/span[contains(text(),'Average')]"))));
            driver2.FindElement(By.XPath("//form[contains(@action, 'UpdatePassword')]//button[text()='Verify']")).Click();
        }

        internal void passphrase(String phrase)
        {
            //Phrase
            driver2.FindElement(By.Id("Passphrase")).SendKeys(phrase);
            //Verify
            driver2.FindElement(By.XPath("(//button[@name='#'])[3]")).Click();
        }

        internal void securityimage()
        {
            //Click on image
            driver2.FindElement(By.XPath("//div[@class='sg-slider k-widget k-listview k-selectable']/img[1]")).Click();
            //Verify
            driver2.FindElement(By.XPath("(//button[@name='#'])[4]")).Click();
        }

        internal void securityquestion(String question)
        {
            //Confirm
            driver2.FindElement(By.Id("Questions_0__Answer")).SendKeys(question);
            //Verify
            driver2.FindElement(By.XPath("(//button[@name='#'])[5]")).Click();
            //Continue
            driver2.FindElement(By.XPath("//button[text()='Continue']")).Click();
        }

        public void runScreen2(String user, String pass, String phrase, String question)
        {
            username(user);
            password(pass);
            passphrase(phrase);
            securityimage();
            securityquestion(question);
        }
        
        //Account Features Page
        public void runScreen3()
        {
            //Toggleboxes
            //driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-2')]")).Click();
            //driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-3')]")).Click();
            //driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-4')]")).Click();
            //driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-5')]")).Click();
            //driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-6')]")).Click();
            //driver.FindElement(By.XPath("//form[contains(@action, 'AccountFeatures')]//label[contains(@for, 'togglebox-7')]")).Click();
            //Continue
            new WebDriverWait(driver2, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//div[contains(@data-viewmodel, 'wizard/viewmodels/step')]/div[2]/button"))));
            driver2.FindElement(By.XPath("//div[contains(@data-viewmodel, 'wizard/viewmodels/step')]/div[2]/button")).Click();
        }

        //Confirmation page
        public void runScreen4()
        {
            //Confirm and enroll
            new WebDriverWait(driver2, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//input[contains(@type, 'submit')]"))));
            action1.SendKeys(Keys.Shift + Keys.Tab).Perform();
            action1.SendKeys(Keys.Enter).Perform();
            setup("qavip");
            driver2.Quit();
        }
    }

}
