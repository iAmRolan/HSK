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

namespace HSK_AutomationTest.Infrastructure.BusinessFunctions
{
		public class AbsencesUpdate : IWebTest
		{
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Mispar_Zehut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Ad_Taarich;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Me_Taarich;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Sug_Headrut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Shem_Headrut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Ad_Taarich_Hadash;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string QueryResult;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Semel_Mosad;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Shaot_Pitzul;
			[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
			public string ApplicationURL;
			public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				By by;
				bool boolResult;
				ExecutionResult executionResult;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				//1
				ManagePage managePage = new ManagePage();
				managePage.ApplicationURL = ApplicationURL;
				managePage.Shem_Headrut = Shem_Headrut;
				managePage.Sug_Headrut = Sug_Headrut;
				managePage.Me_Taarich = Me_Taarich;
				managePage.Ad_Taarich = Ad_Taarich;
				managePage.Mispar_Zehut = Mispar_Zehut;
				managePage.Semel_Mosad = Semel_Mosad;
				managePage.Shaot_Pitzul = Shaot_Pitzul;
				executionResult = managePage.Execute(helper);

				// 1. Click 'היעדרויות -כפתור איתור'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.CssSelector("#ctl00_cmdItur");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות -כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

				// 2. Click 'ChekboxByTypeHeadrut'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath(string.Format("//tr//td[contains(text(), '{0}')]/preceding-sibling::td/input", Semel_Mosad));
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'ChekboxByTypeHeadrut'", boolResult, TakeScreenshotConditionType.Failure);

				// 3. Click 'היעדרויות - כפתור החלפה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("/html/body/form/div[3]/div[2]/div/contenttemplate/table[2]/tbody/tr/td/table/tbody/tr/td[2]/input");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור החלפה'", boolResult, TakeScreenshotConditionType.Failure);

				// 4. Click 'היעדרויות - תאריך סיום'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - תאריך סיום'", boolResult, TakeScreenshotConditionType.Failure);

				// 5. Clear 'היעדרויות - תאריך סיום' contents
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
				boolResult = driver.TestProject().ClearContents(by);
				report.Step("Clear 'היעדרויות - תאריך סיום' contents", boolResult, TakeScreenshotConditionType.Failure);

				// 6. Type '{{Ad_Taarich_Hadash}}' in 'היעדרויות - תאריך סיום'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
				boolResult = driver.TestProject().TypeText(by, Ad_Taarich_Hadash);
				report.Step(string.Format("Type '{0}' in 'היעדרויות - תאריך סיום'", Ad_Taarich_Hadash), boolResult, TakeScreenshotConditionType.Failure);

				// 7. Click 'שורת מספר ימים'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//span[@id='ctl00_Main_Label1']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'שורת מספר ימים'", boolResult, TakeScreenshotConditionType.Failure);

				// 8. Click 'היעדרויות - כפתור שמירה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

				return ExecutionResult.Passed;
			}
		}
	}