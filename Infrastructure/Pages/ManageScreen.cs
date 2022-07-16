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
		public class ManagePage : IWebTest
		{
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Shaot_Pitzul;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Shem_Headrut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Semel_Mosad;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Me_Taarich;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Ad_Taarich;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Mispar_Zehut;
			[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
			public string ApplicationURL;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Sug_Headrut;
			public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				By by;
				bool boolResult;
				ExecutionResult executionResult;
				
				MainPage pOMMainscreen;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				// 1. Run POM_MainScreen
				// Add step sleep time (Before)
				Thread.Sleep(500);
				pOMMainscreen = new MainPage();
				pOMMainscreen.ApplicationURL = "http://itest20121/Hsk";
				executionResult = pOMMainscreen.Execute(helper);
				report.Step("Run POM_MainScreen", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

				// 2. Clear 'היעדרויות-סמל מוסד' contents
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_txtSemelMosad']");
				boolResult = driver.TestProject().ClearContents(by);
				report.Step("Clear 'היעדרויות-סמל מוסד' contents", boolResult, TakeScreenshotConditionType.Failure);

				// 3. Type '{{Semel_Mosad}}' in 'היעדרויות-סמל מוסד'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_txtSemelMosad']");
				boolResult = driver.TestProject().TypeText(by, Semel_Mosad);
				report.Step(string.Format("Type '{0}' in 'היעדרויות-סמל מוסד'", Semel_Mosad), boolResult, TakeScreenshotConditionType.Failure);

				// 4. Click 'היעדרויות-שורת תז'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//div[@id='ctl00_divZehutLine']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות-שורת תז'", boolResult, TakeScreenshotConditionType.Failure);

				// 5. Clear 'היעדרויות-מספר זהות' contents
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_txtZehut']");
				boolResult = driver.TestProject().ClearContents(by);
				report.Step("Clear 'היעדרויות-מספר זהות' contents", boolResult, TakeScreenshotConditionType.Failure);

				// 6. Type '{{Mispar_Zehut}}' in 'היעדרויות-מספר זהות'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_txtZehut']");
				boolResult = driver.TestProject().TypeText(by, Mispar_Zehut);
				report.Step(string.Format("Type '{0}' in 'היעדרויות-מספר זהות'", Mispar_Zehut), boolResult, TakeScreenshotConditionType.Failure);

				// 7. Click 'היעדרויות-שורת תז'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//div[@id='ctl00_divZehutLine']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות-שורת תז'", boolResult, TakeScreenshotConditionType.Failure);

				return ExecutionResult.Passed;
			}
		}
	}
