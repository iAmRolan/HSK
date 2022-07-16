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

namespace HSK_AutomationTest.Infrastructure.BusinessFunctions
{
	public class FileUpload : IWebTest
	{
		public static string ExmapleFilePathToUpload = "N:\\fileUplad";
		public static string FileName = "upload.pdf";
		public static string ExpectedFilename = "upload.pdf";
		public static string FileInputXpath = "//input[@id='ctl00_Main_fileUpload']";


		public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				ExecutionResult executionResult;
				By by;
				string stringResult;
				bool boolResult;

				actions.UploadFileByXpathAction uploadFileUsingXpath;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				// 1. Click 'היעדרויות - צרף קובץ'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_rdMetzoraf']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - צרף קובץ'", boolResult, TakeScreenshotConditionType.Failure);

				// 2. Upload a file to a specific element identifies by XPath
				// Add step sleep time (Before)
				Thread.Sleep(500);
				uploadFileUsingXpath = TestProject.Addons.Proxy.FileUploader.CreateUploadFileByXpathAction(ExmapleFilePathToUpload, FileInputXpath);
				executionResult = helper.ExecuteProxy(uploadFileUsingXpath);
				report.Step("Upload a file to a specific element identifies by XPath", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

				// 3. Get text from 'היעדרויות - שם קובץ'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//a[@id='ctl00_Main_linkfile']");
				stringResult = driver.TestProject().GetText(by);
				report.Step("Get text from 'היעדרויות - שם קובץ'", stringResult != null && stringResult.Equals(ExpectedFilename), TakeScreenshotConditionType.Failure);

				return ExecutionResult.Passed;
			}
		}
	}