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

namespace TestProject.Generated.Tests.HSK
{
	public class TestLocatorbar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Me_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			ExecutionResult executionResult;
			By by;
			bool boolResult;
			ManagePage pOMManagescreen;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Run POM_ManageScreen
			// Add step sleep time (Before)
			Thread.Sleep(500);
			pOMManagescreen = new ManagePage();
			pOMManagescreen.ApplicationURL = ApplicationURL;
			pOMManagescreen.Semel_Mosad = Semel_Mosad;
			pOMManagescreen.Mispar_Zehut = Mispar_Zehut;
			pOMManagescreen.Ad_Taarich = Ad_Taarich;
			pOMManagescreen.Me_Taarich = Me_Taarich;
			pOMManagescreen.Sug_Headrut = Sug_Headrut;
			pOMManagescreen.Shem_Headrut = Shem_Headrut;
			executionResult = pOMManagescreen.Execute(helper);
			report.Step("Run POM_ManageScreen", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 2. Is 'היעדרויות - כפתור איתור מוסד' is clickable?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_cmdIturMosad']");
			boolResult = driver.TestProject().IsClickable(by);
			report.Step("Is 'היעדרויות - כפתור איתור מוסד' is clickable?", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Click 'היעדרויות - כפתור איתור מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_cmdIturMosad']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור איתור מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 4. Is 'היעדרויות - חלון איתור מוסד' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@class='dialogModal open']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'היעדרויות - חלון איתור מוסד' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Click 'היעדרויות - כפתור סגירה (חלון איתור מוסד)'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@class='dialogModal open']//button");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור סגירה (חלון איתור מוסד)'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'כפתור איתור עו\"ה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@class='HskHand' and contains(@title,'רשימת עובדי ההוראה במוסד')]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור איתור עו\\\"ה'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Is 'היעדרויות - חלון איתור מוסד' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@class='dialogModal open']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'היעדרויות - חלון איתור מוסד' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 8. Click 'היעדרויות - כפתור סגירה (חלון איתור מוסד)'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@class='dialogModal open']//button");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור סגירה (חלון איתור מוסד)'", boolResult, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}