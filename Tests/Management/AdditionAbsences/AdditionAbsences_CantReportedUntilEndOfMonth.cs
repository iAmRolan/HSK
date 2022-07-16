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
using HSK_AutomationTest.Infrastructure.BusinessFunctions;

namespace HSK_AutomationTest.Tests.Management.AdditionAbsences
{
		/// </summary>
		public class AdditionAbsences_CantReportedUntilEndOfMonth : IWebTest
		{
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Category;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string QueryResult;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Shem_Headrut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Me_Taarich;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Sug_Headrut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Mispar_Zehut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Semel_Mosad;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Ad_Taarich;
			[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
			public string ApplicationURL;
			public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				ExecutionResult executionResult;
				By by;
				string stringResult;
				bool boolResult;
				actions.GetValueFromJSON getValueFromJSONUsingJsonpath;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				//1.
				ManagePage managePage = new ManagePage();
				managePage.ApplicationURL = ApplicationURL;
				managePage.Semel_Mosad = Semel_Mosad;
				managePage.Mispar_Zehut = Mispar_Zehut;
				executionResult = managePage.Execute(helper);

				//2.
				InsertScreenPage insertScreenPage = new InsertScreenPage();
				insertScreenPage.ApplicationURL = ApplicationURL;
				insertScreenPage.Sug_Headrut = Sug_Headrut;
				insertScreenPage.Me_Taarich = Me_Taarich;
				insertScreenPage.Ad_Taarich = Ad_Taarich;
				insertScreenPage.Category = Category;
				executionResult = insertScreenPage.Execute(helper);

				//3.
				FileUpload fileUpload = new FileUpload();
				executionResult = fileUpload.Execute(helper);

				// 4. Click 'היעדרויות - כפתור שמירה'
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

				// 5. Get text from 'היעדרויות שורת הערה'
				Thread.Sleep(500);
				by = By.XPath("//span[@id='ctl00_lblShortMsgLine']");
				stringResult = driver.TestProject().GetText(by);
				report.Step("Get text from 'היעדרויות שורת הערה'", stringResult != null, TakeScreenshotConditionType.Always);

				// 6.
				//TODO:Add SQL Verification and set Query_Result
				var query = "SELECT STATUS, MISPAR_HEADRUT FROM HSK_OWNER.HSK_HEADRUT WHERE MISPAR_ZEHUT = '{Mispar_Zehut}' AND SUG_HEADRUT = '{Sug_Headrut}'  ORDER BY TAARICH_IDKUN DESC ";
				var dbSid = "";
				var userName = "";
				var password = "";
				var host = "";

				// 7. Gets value in JSON using JsonPath syntax
				driver.Timeout = 25000;
				Thread.Sleep(1000);
				getValueFromJSONUsingJsonpath = TestProject.Addons.Proxy.JSONOperations.CreateGetValueFromJSON("", "STATUS", QueryResult);
				executionResult = helper.ExecuteProxy(getValueFromJSONUsingJsonpath);
				report.Step("Gets value in JSON using JsonPath syntax", executionResult == ExecutionResult.Passed && getValueFromJSONUsingJsonpath.result.Equals("3"), TakeScreenshotConditionType.Failure);
				driver.Timeout = 15000;

				//8.
				DeletingAbsenceAfterAddtion deletingAbsenceAfterAddtion = new DeletingAbsenceAfterAddtion();
				deletingAbsenceAfterAddtion.Semel_Mosad = Semel_Mosad;
				deletingAbsenceAfterAddtion.Sug_Headrut = Sug_Headrut;
				deletingAbsenceAfterAddtion.ApplicationURL = ApplicationURL;
				deletingAbsenceAfterAddtion.Mispar_Zehut = Mispar_Zehut;
				executionResult = deletingAbsenceAfterAddtion.Execute(helper);

				return ExecutionResult.Passed;
			}
		}
	}
