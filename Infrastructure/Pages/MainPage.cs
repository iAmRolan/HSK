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
	public class MainPage : IWebTest
		{
			[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
			public string ApplicationURL;
			public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				By by;
				ExecutionResult executionResult;
				bool boolResult;
				io.testproject.addon.ClickActions.ClickIfVisibleWeb clickIfVisible;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				// 1. Navigate to '{{ApplicationURL}}'
				// Navigates the specified URL (Auto-generated)
				// Add step sleep time (Before)
				Thread.Sleep(500);
				boolResult = driver.TestProject().NavigateToURL(ApplicationURL);
				report.Step(string.Format("Navigate to '{0}'", ApplicationURL), boolResult, TakeScreenshotConditionType.Failure);

				// 2. Move mouse to 'לשונית היעדרויות '
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//span[. = '\n\t\t\t\t\tהיעדרויות']");
				boolResult = driver.TestProject().MoveMouseToElement(by);
				report.Step("Move mouse to 'לשונית היעדרויות '", boolResult, TakeScreenshotConditionType.Failure);

				// 3. Click 'היעדרויות-כפתור ניהול' if it's visible
				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 25000;
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//span[contains(text(),'היעדרויות')]/following-sibling::ul//a[contains(@href,\"/Hsk/HskNihulHeadruyot.aspx\")]");
				clickIfVisible = TestProject.Addons.Proxy.VisibleElementsOperations.CreateClickIfVisibleWeb("");
				executionResult = helper.ExecuteProxy(clickIfVisible, by);
				report.Step("Click 'היעדרויות-כפתור ניהול' if it's visible", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				return ExecutionResult.Passed;
			}
		}
	}