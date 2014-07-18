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
		public void TestCase()
		{
			runScreen1 ("000017804", "0000017804", 1, 1, 1999);
			runScreen2 ("a", "a", "Alaska", 11111, "a@a.com");
			runScreen3 ("100", "017804", "123qweasdqwe123", "cat", "cat");
			runScreen4 ();
		}

		public static void Main(){
		
		}

	}

}