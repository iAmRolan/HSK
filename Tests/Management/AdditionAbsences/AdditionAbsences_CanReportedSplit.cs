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
		public class AdditionAbsences_CanReportedSplit : IWebTest
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
			public string Category;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string QueryResult;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string MISPAR_HEADRUT;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string NewQueryResult;
			[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
			public string ApplicationURL;
			public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				ExecutionResult executionResult;
				By by;
				bool boolResult;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				//1.
				ManagePage managePage = new ManagePage();
				managePage.ApplicationURL = ApplicationURL;
				managePage.Semel_Mosad = Semel_Mosad;
				managePage.Mispar_Zehut = Mispar_Zehut;
				managePage.Me_Taarich = Me_Taarich;
				managePage.Sug_Headrut = Sug_Headrut;
				managePage.Shem_Headrut = Shem_Headrut;
				managePage.Shaot_Pitzul = Shaot_Pitzul;
				managePage.Ad_Taarich = Ad_Taarich;
				executionResult = managePage.Execute(helper);

				//2.
				InsertScreenPage insertScreenPage = new InsertScreenPage();
				insertScreenPage.Ad_Taarich = Ad_Taarich;
				insertScreenPage.Me_Taarich = Me_Taarich;
				insertScreenPage.Category = Category;
				insertScreenPage.ApplicationURL = ApplicationURL;
				insertScreenPage.Sug_Headrut = Sug_Headrut;
				executionResult = insertScreenPage.Execute(helper);

				// 3. Click 'היעדרויות - כפתור שמירה'
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

				// 4. Is 'היעדרויות - חלון שגיאה' present?
				Thread.Sleep(500);
				by = By.XPath("//div[@id='dialog']");
				boolResult = driver.TestProject().IsPresent(by);
				report.Step("Is 'היעדרויות - חלון שגיאה' present?", boolResult, TakeScreenshotConditionType.Always);

				// 5. Click 'היעדרויות - כפתור אישור הודעת שגיאה'
				Thread.Sleep(500);
				by = By.XPath("//input[@id='btnok']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור אישור הודעת שגיאה'", boolResult, TakeScreenshotConditionType.Failure);

				// 6. Click 'תפריט סוגי פיצול'
				Thread.Sleep(500);
				by = By.XPath("//select[@id='ctl00_Main_cboMeafyeneyPitsul']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'תפריט סוגי פיצול'", boolResult, TakeScreenshotConditionType.Failure);

				// 7. Click 'סוג פיצול'
				Thread.Sleep(500);
				by = By.XPath("//select[@id='ctl00_Main_cboMeafyeneyPitsul']//option[@value='5270']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'סוג פיצול'", boolResult, TakeScreenshotConditionType.Failure);

				// 8. Click 'היעדרויות - כפתור שמירה'
				/* This step is disabled
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);
				*/

				// 9. Does 'היעדרויות שורת הערה' contain 'יש להזין לסוג היעדרות זה שעות ליום'?
				/* This step is disabled
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//span[@id='ctl00_lblShortMsgLine']");
				boolResult = driver.TestProject().ContainsText(by, "יש להזין לסוג היעדרות זה שעות ליום");
				report.Step("Does 'היעדרויות שורת הערה' contain 'יש להזין לסוג היעדרות זה שעות ליום'?", boolResult, TakeScreenshotConditionType.Always);
				*/

				// 10. Type '{{Shaot_Pitzul}}' in 'היעדרויות פיצול - שעות ליום'
				Thread.Sleep(500);
				by = By.XPath("//input[@name='ctl00$Main$txtShaotLeyom']");
				boolResult = driver.TestProject().TypeText(by, Shaot_Pitzul);
				report.Step(string.Format("Type '{0}' in 'היעדרויות פיצול - שעות ליום'", Shaot_Pitzul), boolResult, TakeScreenshotConditionType.Failure);

				// 11. Click 'שורת מספר ימים'
				Thread.Sleep(500);
				by = By.XPath("//span[@id='ctl00_Main_Label1']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'שורת מספר ימים'", boolResult, TakeScreenshotConditionType.Failure);

				// 12. Click 'היעדרויות - כפתור שמירה'
				driver.Timeout = 25000;
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);
				driver.Timeout = 15000;

				// 13.
				//TODO:Add SQL Verification and set Query_Result
				var query = "SELECT STATUS, MISPAR_HEADRUT FROM HSK_OWNER.HSK_HEADRUT WHERE MISPAR_ZEHUT = '{Mispar_Zehut}' AND SUG_HEADRUT = '{Sug_Headrut}' ORDER BY TAARICH_IDKUN DESC";
				var dbSid = "";
				var userName = "";
				var password = "";
				var host = "";


				// 14. Gets value in JSON using JsonPath syntax
				Thread.Sleep(500);
				var getValueFromJSONUsingJsonpath = TestProject.Addons.Proxy.JSONOperations.CreateGetValueFromJSON("", "STATUS", QueryResult);
				executionResult = helper.ExecuteProxy(getValueFromJSONUsingJsonpath);
				report.Step("Gets value in JSON using JsonPath syntax", executionResult == ExecutionResult.Passed && getValueFromJSONUsingJsonpath.result.Equals("3"), TakeScreenshotConditionType.Failure);

				//15.
				DeletingAbsenceAfterAddtion deletingAbsenceAfterAddtion = new DeletingAbsenceAfterAddtion();
				deletingAbsenceAfterAddtion.Shem_Headrut = Shem_Headrut;
				deletingAbsenceAfterAddtion.ApplicationURL = ApplicationURL;
				deletingAbsenceAfterAddtion.Sug_Headrut = Sug_Headrut;
				deletingAbsenceAfterAddtion.Semel_Mosad = Semel_Mosad;
				deletingAbsenceAfterAddtion.Mispar_Zehut = Mispar_Zehut;
				deletingAbsenceAfterAddtion.Ad_Taarich = Ad_Taarich;
				deletingAbsenceAfterAddtion.Me_Taarich = Me_Taarich;
				deletingAbsenceAfterAddtion.MISPAR_HEADRUT = MISPAR_HEADRUT;
				deletingAbsenceAfterAddtion.NewQueryResult = NewQueryResult;
				deletingAbsenceAfterAddtion.Shaot_Pitzul = Shaot_Pitzul;
				executionResult = deletingAbsenceAfterAddtion.Execute(helper);

				return ExecutionResult.Passed;
			}
		}
	}