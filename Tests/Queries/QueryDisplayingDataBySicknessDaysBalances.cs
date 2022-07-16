using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Threading;
using System;
using TestProject.SDK;
using TestProject.SDK.Tests.Helpers;
using TestProject.SDK.Tests;
using TestProject.Common.Attributes;
using TestProject.Common.Enums;
using HSK_AutomationTest.Infrastructure.Pages;

namespace HSK_AutomationTest.Tests.Queries
{

	public class QueryDisplayingDataBySicknessDaysBalances : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			MainQueryPage mainQueryPage;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1.
			mainQueryPage = new MainQueryPage();
			mainQueryPage.ApplicationURL = ApplicationURL;
			executionResult = mainQueryPage.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 2. Move mouse to 'הצגת יתרות - כפתור'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//li//span[contains(text(), 'הצגת יתרות')]");
			boolResult = driver.TestProject().MoveMouseToElement(by);
			report.Step("Move mouse to 'הצגת יתרות - כפתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Click 'הצגת יתרות מחלה לעובד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//a[@href=\"/Hsk/HskItrotMachalaLeoved.aspx\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הצגת יתרות מחלה לעובד'", boolResult, TakeScreenshotConditionType.Failure);

			// 4. Is 'מסך הצגת יתרות ' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@id='search']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'מסך הצגת יתרות ' present?", boolResult, TakeScreenshotConditionType.Always);

			//5.
			Thread.Sleep(500);
			SicknessDaysBalancesLocatorBar locatorBar = new SicknessDaysBalancesLocatorBar();
			locatorBar.Mispar_Zehut = Mispar_Zehut;
			locatorBar.Shem_Oved = Shem_Oved;
			executionResult = locatorBar.Execute(helper);
			report.Step("בדיקת פס איתור - דיווחי מדבס/מדגן", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}

	public class SicknessDaysBalancesLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			string stringResult;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Type '{{Mispar_Zehut}}' in 'היעדרויות-מספר זהות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_txtZehut']");
			boolResult = driver.TestProject().TypeText(by, Mispar_Zehut);
			report.Step(string.Format("Type '{0}' in 'היעדרויות-מספר זהות'", Mispar_Zehut), boolResult, TakeScreenshotConditionType.Failure);

			// 2. Click 'שורת שם '
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@id='ctl00_divShemOvh']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'שורת שם '", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Get text from 'היעדרויות - שם עובד הוראה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShem']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות - שם עובד הוראה'", stringResult != null && stringResult.Equals(Shem_Oved), TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}
