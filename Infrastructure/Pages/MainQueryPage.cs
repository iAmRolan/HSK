
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

namespace HSK_AutomationTest.Infrastructure.Pages
{
	public class MainQueryPage : IWebTest
	{
		[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Navigate to '{{ApplicationURL}}'
			// Navigates the specified URL (Auto-generated)
			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 25000;
			// Add step sleep time (Before)
			Thread.Sleep(500);
			boolResult = driver.TestProject().NavigateToURL(ApplicationURL);
			report.Step(string.Format("Navigate to '{0}'", ApplicationURL), boolResult, TakeScreenshotConditionType.Failure);
			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 2. Move mouse to 'לשונית היעדרויות '
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[. = '\n\t\t\t\t\tהיעדרויות']");
			boolResult = driver.TestProject().MoveMouseToElement(by);
			report.Step("Move mouse to 'לשונית היעדרויות '", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Move mouse to 'שאילתות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("/html/body/form/div[3]/div[1]/div[4]/div[1]/div[2]/div/ul/li[4]/ul/li[2]/span");
			boolResult = driver.TestProject().MoveMouseToElement(by);
			report.Step("Move mouse to 'שאילתות'", boolResult, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}