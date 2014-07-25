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

	[TestFixture()]
	public class Program : Confirmation
	{
		[Test()]
		public void TestCase() {
			int number = 17818;

			String testssn = "0000" + number.ToString();
			String testaccountnumber = "00000" + number.ToString();
			String testusername = "0" + number.ToString();

			runScreen1 (testssn, testaccountnumber, 1, 1, 1999, "a", "a", "Alaska", 11111, "a@a.com", "100");
			runScreen2 (testusername, "123qweasdqwe123", "cat", "cat");
			runScreen3 ();
			runScreen4 ();
		}

		public static void Main(){}

	}

}