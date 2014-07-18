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
		public Confirmation ()
		{
		}

		public void runScreen4(){
			//Confirm and enroll

			action.SendKeys (Keys.Shift + Keys.Tab).Perform();
			action.SendKeys (Keys.Enter).Perform();
		}
	}
}

