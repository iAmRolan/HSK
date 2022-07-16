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

namespace HSK_AutomationTest.Tests.Management.ChangeAbsenses
{
	public class ReplacingAbsencesAfterInsertion : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich_Hadash;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shaot_Pitzul;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string MISPAR_HEADRUT;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Category;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Me_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string QueryResult;
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
			managePage.Me_Taarich = Me_Taarich;
			managePage.Ad_Taarich = Ad_Taarich;
			managePage.Mispar_Zehut = Mispar_Zehut;
			managePage.Semel_Mosad = Semel_Mosad;
			managePage.ApplicationURL = ApplicationURL;
			managePage.Sug_Headrut = Sug_Headrut;
			managePage.Shem_Headrut = Shem_Headrut;
			managePage.Shaot_Pitzul = Shaot_Pitzul;
			executionResult = managePage.Execute(helper);

			//2
			InsertScreenPage insertScreenPage = new InsertScreenPage();
			insertScreenPage.Ad_Taarich = Ad_Taarich;
			insertScreenPage.Me_Taarich = Me_Taarich;
			insertScreenPage.Category = Category;
			insertScreenPage.Sug_Headrut = Sug_Headrut;
			insertScreenPage.ApplicationURL = ApplicationURL;
			executionResult = insertScreenPage.Execute(helper);

			// 3. Click 'היעדרויות - כפתור שמירה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

			// 4.
			ReplaceAbsence replaceAbsence = new ReplaceAbsence();
			replaceAbsence.Me_Taarich = Me_Taarich;
			replaceAbsence.Sug_Headrut = Sug_Headrut;
			replaceAbsence.Shem_Headrut = Shem_Headrut;
			replaceAbsence.Shaot_Pitzul = Shaot_Pitzul;
			replaceAbsence.Ad_Taarich_Hadash = Ad_Taarich_Hadash;
			replaceAbsence.Ad_Taarich = Ad_Taarich;
			replaceAbsence.Mispar_Zehut = Mispar_Zehut;
			replaceAbsence.ApplicationURL = ApplicationURL;
			replaceAbsence.Semel_Mosad = Semel_Mosad;
			executionResult = replaceAbsence.Execute(helper);

			// 5.
			ReplacementAbsenceExamination replacementAbsenceExamination = new ReplacementAbsenceExamination();
			replacementAbsenceExamination.Mispar_Zehut = Mispar_Zehut;
			replacementAbsenceExamination.Sug_Headrut = Sug_Headrut;
			replacementAbsenceExamination.QueryResult = QueryResult;
			executionResult = replacementAbsenceExamination.Execute(helper);

			// 6.
			DeletingAbsenceAfterAddtion deletingAbsenceAfterAddtion = new DeletingAbsenceAfterAddtion();
			deletingAbsenceAfterAddtion.ApplicationURL = ApplicationURL;
			deletingAbsenceAfterAddtion.NewQueryResult = QueryResult;
			deletingAbsenceAfterAddtion.MISPAR_HEADRUT = MISPAR_HEADRUT;
			deletingAbsenceAfterAddtion.Shem_Headrut = Shem_Headrut;
			deletingAbsenceAfterAddtion.Me_Taarich = Me_Taarich;
			deletingAbsenceAfterAddtion.Ad_Taarich = Ad_Taarich;
			deletingAbsenceAfterAddtion.Mispar_Zehut = Mispar_Zehut;
			deletingAbsenceAfterAddtion.Semel_Mosad = Semel_Mosad;
			deletingAbsenceAfterAddtion.Sug_Headrut = Sug_Headrut;

			return ExecutionResult.Passed;
		}
	}

	public class ReplaceAbsence : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
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
		public string Shaot_Pitzul;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string QueryResult;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich_Hadash;
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
			managePage.Shaot_Pitzul = Shaot_Pitzul;
			managePage.Sug_Headrut = Sug_Headrut;
			managePage.Me_Taarich = Me_Taarich;
			managePage.Ad_Taarich = Ad_Taarich;
			managePage.Mispar_Zehut = Mispar_Zehut;
			managePage.Semel_Mosad = Semel_Mosad;
			managePage.ApplicationURL = ApplicationURL;
			executionResult = managePage.Execute(helper);

			// 2. Click 'היעדרויות -כפתור איתור'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.CssSelector("#ctl00_cmdItur");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות -כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 3.
			//TODO: add scroll to element bu xpath "//tr//td[contains(text(), '{Semel_Mosad}')]/preceding-sibling::td/input"

			// 4. Click 'ChekboxByTypeHeadrut'
			Thread.Sleep(500);
			by = By.XPath(string.Format("//tr//td[contains(text(), '{0}')]/preceding-sibling::td/input", Semel_Mosad));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'ChekboxByTypeHeadrut'", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Click 'היעדרויות - כפתור החלפה'
			Thread.Sleep(500);
			by = By.XPath("/html/body/form/div[3]/div[2]/div/contenttemplate/table[2]/tbody/tr/td/table/tbody/tr/td[2]/input");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור החלפה'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'היעדרויות - תאריך סיום'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - תאריך סיום'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Clear 'היעדרויות - תאריך סיום' contents
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
			boolResult = driver.TestProject().ClearContents(by);
			report.Step("Clear 'היעדרויות - תאריך סיום' contents", boolResult, TakeScreenshotConditionType.Failure);

			// 8. Type '{{Ad_Taarich_Hadash}}' in 'היעדרויות - תאריך סיום'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
			boolResult = driver.TestProject().TypeText(by, Ad_Taarich_Hadash);
			report.Step(string.Format("Type '{0}' in 'היעדרויות - תאריך סיום'", Ad_Taarich_Hadash), boolResult, TakeScreenshotConditionType.Failure);

			// 9. Click 'שורת מספר ימים'
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_Main_Label1']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'שורת מספר ימים'", boolResult, TakeScreenshotConditionType.Failure);

			// 10. Click 'היעדרויות - כפתור שמירה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}

	public class ReplacementAbsenceExamination : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string QueryResult;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			actions.GetValueFromJSON getValueFromJSONUsingJsonpath;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Does 'היעדרויות - הודעת עדכון' contain '{{ExpectedUpdateMessage}}'?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShortMsgLine']");
			boolResult = driver.TestProject().ContainsText(by, "פעולת העדכון עברה בהצלחה");
			report.Step(string.Format("Does 'היעדרויות - הודעת עדכון' contain '{0}'?", "פעולת העדכון עברה בהצלחה"), boolResult, TakeScreenshotConditionType.Failure);

			// 2.
			//TODO:Add SQL Verification
			var query = "SELECT AD_TAR FROM HSK_OWNER.HSK_HEADRUT WHERE MISPAR_ZEHUT = '{Mispar_Zehut}' AND SUG_HEADRUT = '{Sug_Headrut}'  ORDER BY TAARICH_IDKUN DESC ";
			var dbSid = "";
			var userName = "";
			var password = "";
			var host = "";

			// 3. Gets value in JSON using JsonPath syntax
			// Add step sleep time (Before)
			Thread.Sleep(500);
			getValueFromJSONUsingJsonpath = TestProject.Addons.Proxy.JSONOperations.CreateGetValueFromJSON(QueryResult, "AD_TAR", "");
			executionResult = helper.ExecuteProxy(getValueFromJSONUsingJsonpath);
			report.Step("Gets value in JSON using JsonPath syntax", executionResult == ExecutionResult.Passed && getValueFromJSONUsingJsonpath.result.Equals("2022-06-09 00:00:00"), TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}


