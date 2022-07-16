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

	public class DeletingAbsenceAfterAddtion : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string NewQueryResult;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shaot_Pitzul;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string MISPAR_HEADRUT;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Me_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			string stringResult;
			bool boolResult;
			ExecutionResult executionResult;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Scrolls to an element with defined amount of swipes
			Thread.Sleep(500);

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

			// 2. Click 'היעדרויות -כפתור איתור'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.CssSelector("#ctl00_cmdItur");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות -כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

			//3
			//TODO: Add Scroll to Element - By.Xpath("//tr//td[contains(text(), '{Semel_Mosad}')]/preceding-sibling::td/input")

			// 4. Click 'CheckBox_Sug_Headrut'
			Thread.Sleep(500);
			by = By.XPath(string.Format("//tr//td[contains(text(), '{0}')]/preceding-sibling::td/input", Sug_Headrut));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'CheckBox_Sug_Headrut'", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Click 'היעדרויות - כפתור מחיקה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdDelete']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור מחיקה'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'היעדרויות - כפתור אישור מחיקה'
			driver.Timeout = 25000;
			Thread.Sleep(1000);
			by = By.XPath("//div[@id='dialog-contentfooter']//input[@id='btn0']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור אישור מחיקה'", boolResult, TakeScreenshotConditionType.Failure);
			driver.Timeout = 15000;

			// 7. Get text from 'היעדרויות שורת הערה'
			driver.Timeout = 25000;
			Thread.Sleep(1000);
			by = By.XPath("//span[@id='ctl00_lblShortMsgLine']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות שורת הערה'", stringResult != null && stringResult.Equals("פעולת העדכון עברה בהצלחה"), TakeScreenshotConditionType.Failure);
			driver.Timeout = 15000;

			//8
			//TODO:Add SQL Verification
			var query = "SELECT STATUS FROM HSK_OWNER.HSK_HEADRUT WHERE MISPAR_ZEHUT = '{Mispar_Zehut}' AND SUG_HEADRUT = '{Sug_Headrut}'  ORDER BY TAARICH_IDKUN DESC";
			var dbSid = "";
			var userName = "";
			var password = "";
			var host = "";
			NewQueryResult = ""; //shoud put the query results here

			// 9. Gets value in JSON using JsonPath syntax
			// Add step sleep time (Before)
			Thread.Sleep(500);	
			actions.GetValueFromJSON getValueFromJSONUsingJsonpath;
			getValueFromJSONUsingJsonpath = TestProject.Addons.Proxy.JSONOperations.CreateGetValueFromJSON("", NewQueryResult, "STATUS");
			executionResult = helper.ExecuteProxy(getValueFromJSONUsingJsonpath);
			report.Step("Gets value in JSON using JsonPath syntax", executionResult == ExecutionResult.Passed && getValueFromJSONUsingJsonpath.result.Equals("19"), TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}