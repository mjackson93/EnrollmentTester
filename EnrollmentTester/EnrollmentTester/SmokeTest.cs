using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace EnrollmentTester
{

    [TestFixture()]
    public class SmokeTest
    {
        public static IWebDriver driver = new FirefoxDriver();
        public static Actions action = new Actions(driver);
        public static int WAIT_UNTIL_TIME = 30;



        /* A smoke test for enrolling a user, logging in with the user, and then unenrolling the user. */
        [TestCase(17818, "123qweasdqwe123")]
        public void Test(int number, String pass)
        {
            String username = "0" + number;
            UnenrollUser(username);

            EnrollUser(number, pass);
            site_login(username, "", pass);
            UnenrollUser(username);
			
        }




        /* UnenrollUser
         * ------------
         * Goes to the QA tools site and un-enrolls the given user by username via the Kill Bill tool.
         */
        public void UnenrollUser(String username)
        {
            driver.Navigate().GoToUrl("https://qatools.orpheusdev.net/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_UNTIL_TIME));
            wait.Until(d => d.FindElement(By.XPath("//select [contains(@id, 'cnnId')]")));
            driver.FindElement(By.XPath("//select [contains(@id, 'cnnId')]")).Click();
            for (int i = 0; i < 3; i++) action.SendKeys(Keys.Down).Perform();
            action.SendKeys(Keys.Enter).Perform();
            driver.FindElement(By.XPath("//input [contains(@name, 'param')]")).SendKeys(username);
            driver.FindElement(By.XPath("//button [contains(@id, 'button3')]")).Click();
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch { }
            System.Threading.Thread.Sleep(1000); //TODO: remove this
            Console.WriteLine(driver.FindElement(By.XPath("//div[contains(@id, 'main')]/div")).Text);
			//Assert.AreEqual("Orpheus Develop Mock - Security image", securityImagePage.GetPageTitle());

        }
			

        /* EnrollUser
         * ------------
         * Enrolls a user based on the given number and password. 
         */
        public void EnrollUser(int number, String pass)
        {
            GoToEnv("qavip");
            String testssn = "0000" + number.ToString();
            String testaccountnumber = "00000" + number.ToString();
            String testusername = "0" + number.ToString();

            runScreen1(testssn, testaccountnumber, "January", 1, 1999, "a", "a", "Alaska", 11111, "a@a.com", "100");
            runScreen2(testusername, pass, "cat", "cat");
            runScreen3();
            runScreen4();
        }
        


        // TEMPORARY    TODO: Replace with Justin's
            // Logs in the given user
        private void site_login(String user, String answer, String pass)
        {
            WebDriverWait wait;
            //Console.WriteLine(driver.FindElement(By.Name("version")).GetAttribute("content"));
            
            //Login Screen
            //Type in the username and proceed
			Assert.AreEqual("Orpheus QA VIP - Log In", driver.Title, "Step1: Page Title is wrong");
            driver.FindElement(By.Id("UserName")).SendKeys(user);
            //action.SendKeys(user).Perform();
            action.SendKeys(Keys.Enter).Perform();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_UNTIL_TIME));
            wait.Until(d => d.FindElement(By.XPath("//button [text()='Continue']")));

            //Login Screen
            //Checks if it asks for security question or not
            if (driver.Title.Contains("question"))
            {
                //Type in security question answer
				Assert.AreEqual("Orpheus QA VIP - Security question", driver.Title, "Step2: Page Title is wrong");
                action.SendKeys(answer).Perform();
                action.SendKeys(Keys.Enter).Perform();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_UNTIL_TIME));
                wait.Until(d => d.FindElement(By.Name("Password")));
            }

            //Password Screen
            //Type in the password and proceed
			Assert.AreEqual("Orpheus QA VIP - Security image", driver.Title, "Step3: Page Title is wrong");
            driver.FindElement(By.Id("Password")).SendKeys(pass);
            //action.SendKeys(pass).Perform();
            action.SendKeys(Keys.Enter).Perform();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_UNTIL_TIME));
            wait.Until(d => d.FindElement(By.XPath("//a [contains(@href, '/Users/Account/LogOff?ReturnUrl=%2Fspa%3FcontentUrl%3Daccounts%2Foverview')]")));
			Assert.AreEqual("Dashboard", driver.Title, "Step4: OverviewPage Title is wrong");
            driver.FindElement(By.XPath("//a [contains(@href, '/Users/Account/LogOff?ReturnUrl=%2Fspa%3FcontentUrl%3Daccounts%2Foverview')]")).Click();
            //wait.Until(d => d.FindElement(By.Id("UserName")));
            System.Threading.Thread.Sleep(2500);

        }

        public static void Main() { }



        // Navigates the webpage to the given environment.
        internal static void GoToEnv(String dnp)
        {
            driver.Navigate().GoToUrl("https://" + dnp + ".orpheusdev.net/Users/Account/LogOn");
        }



        //Identity Verification Page
        public void runScreen1(String ssn, String accountnumber, String month, int day, int year, String street, String city, String state, int zipcode, String email, String answer)
        {
            part1(ssn, accountnumber, month, day, year);
            part2(street, city, state, zipcode, email);
            part3(answer);
        }

        internal void part1(String ssn, String accountnumber, String month, int day, int year)
        {
            driver.FindElement(By.LinkText("Register")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("Ssn"))));
            driver.FindElement(By.Id("Ssn")).SendKeys(ssn);
            driver.FindElement(By.Id("AccountNumber")).SendKeys(accountnumber);
            driver.FindElement(By.ClassName("k-input")).Click();
            action.SendKeys(month);
            action.SendKeys(Keys.Enter).Perform();
            driver.FindElement(By.Id("Birthdate_Day")).SendKeys(day.ToString());
            driver.FindElement(By.Id("Birthdate_Year")).SendKeys(year.ToString());
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Name("#"))));
            //Verify
            driver.FindElement(By.Name("#")).Click();
        }

        internal void part2(String street, String city, String state, int zipcode, String email)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Street")).SendKeys(street);
            driver.FindElement(By.Id("City")).SendKeys(city);
            driver.FindElement(By.ClassName("k-input")).Click();
            action.SendKeys(state);
            action.SendKeys(Keys.Enter).Perform();
            driver.FindElement(By.Id("ZipCode")).SendKeys(zipcode.ToString());
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("ConfirmEmail")).SendKeys(email);
            //Verify
            driver.FindElement(By.Name("#")).Click();
        }

        internal void part3(String answer)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.Id("Questions_0__Answer"))));
            //Last Deposit
            driver.FindElement(By.Id("Questions_0__Answer")).SendKeys("100");
            //Verify
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Name("#"))));
            driver.FindElement(By.XPath("(//button[@name='#'])[2]")).Click();
            //Verify
            driver.FindElement(By.XPath("//div/div[4]/button")).Click();
        }
        


        //Login information
        public void runScreen2(String user, String pass, String phrase, String question)
        {
            username(user);
            password(pass);
            passphrase(phrase);
            securityimage();
            securityquestion(question);
        }

        internal void username(String user)
        {
            driver.FindElement(By.Id("Username")).SendKeys(user);
            //Verify
            driver.FindElement(By.Name("#")).Click();
        }

        internal void password(String pass)
        {
            driver.FindElement(By.Id("Password")).SendKeys(pass);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(pass);
            //Verify
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//span[contains(text(),'Password strength indicator:')]/span[contains(text(),'Average')]"))));
            driver.FindElement(By.XPath("//form[contains(@action, 'UpdatePassword')]//button[text()='Verify']")).Click();
        }

        internal void passphrase(String phrase)
        {
            driver.FindElement(By.Id("Passphrase")).SendKeys(phrase);
            //Verify
            driver.FindElement(By.XPath("(//button[@name='#'])[3]")).Click();
        }

        internal void securityimage()
        {
            //Click on image
            driver.FindElement(By.XPath("//div[@class='sg-slider k-widget k-listview k-selectable']/img[1]")).Click();
            //Verify
            driver.FindElement(By.XPath("(//button[@name='#'])[4]")).Click();
        }

        internal void securityquestion(String question)
        {
            //Confirm
            driver.FindElement(By.XPath("//input [contains(@class, 'k-textbox size-medium rounded') and contains(@name, 'Questions[0].Answer')]")).SendKeys(question);
            //Verify
            driver.FindElement(By.XPath("(//button[@name='#'])[5]")).Click();
            //Continue
            driver.FindElement(By.XPath("//button[text()='Continue']")).Click();
        }



        //Account Features Page
        public void runScreen3()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//div[contains(@data-viewmodel, 'wizard/viewmodels/step')]/div[2]/button"))));
            driver.FindElement(By.XPath("//div[contains(@data-viewmodel, 'wizard/viewmodels/step')]/div[2]/button")).Click();
        }



        //Confirmation page
        public void runScreen4()
        {
            //Confirm and enroll
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//input[contains(@type, 'submit')]"))));
            action.SendKeys(Keys.Shift + Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.Id("UserName")));
        }
    }

}
