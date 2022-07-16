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

namespace HSK_AutomationTest.Tests.Management.SocialSecurity
{

		public class WorkAccidentSocialSecurityCertificate : IWebTest
		{
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Changed_Sug_Headrut;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string TaarichPgiaa;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yamim_Le_Headrut_Number;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yitrat_Mahala_Number;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yamim_Le_Headrut_Text;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yitrat_Mahala_Text;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Query_Result;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Category;
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
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Shaot_Pitzul;
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
				string stringResult;
				bool boolResult;
				actions.GetValueFromJSON getValueFromJSONUsingJsonpath;

				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				//1.
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

				//2.
				InsertScreenPage insertScreenPage = new InsertScreenPage();
				insertScreenPage.Sug_Headrut = Sug_Headrut;
				insertScreenPage.Yamim_Le_Headrut_Text = Yamim_Le_Headrut_Text;
				insertScreenPage.Category = Category;
				insertScreenPage.Me_Taarich = Me_Taarich;
				insertScreenPage.Ad_Taarich = Ad_Taarich;
				insertScreenPage.Yitrat_Mahala_Text = Yitrat_Mahala_Text;
				insertScreenPage.Yamim_Le_Headrut_Number = Yamim_Le_Headrut_Number;
				insertScreenPage.ApplicationURL = ApplicationURL;
				insertScreenPage.Yitrat_Mahala_Number = Yitrat_Mahala_Number;
				executionResult = insertScreenPage.Execute(helper);
		
				// 3. Click 'היעדרויות - כפתור שמירה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

				// 4. Click 'ChekboxByTypeHeadrut'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath(string.Format("//tr//td[contains(text(), '{0}')]/preceding-sibling::td/input", Semel_Mosad));
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'ChekboxByTypeHeadrut'", boolResult, TakeScreenshotConditionType.Failure);

				// 5. Click 'אישור ביטוח לאומי'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_CmdIshurTeunatAvoda']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'אישור ביטוח לאומי'", boolResult, TakeScreenshotConditionType.Failure);

				// 6. Clear 'תאריך פגיעה' contents
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_dtTaarichPgiaa']");
				boolResult = driver.TestProject().ClearContents(by);
				report.Step("Clear 'תאריך פגיעה' contents", boolResult, TakeScreenshotConditionType.Failure);

				// 7. Click 'אישור ביטוח לאומי - כפתור שמירה'
				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 25000;
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'אישור ביטוח לאומי - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Always);
				// set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				// 8. Click 'היעדרויות - כפתור אישור הודעת שגיאה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='btnok']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור אישור הודעת שגיאה'", boolResult, TakeScreenshotConditionType.Always);

				// 9. Type '{{TaarichPgiaa}}' in 'תאריך פגיעה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_dtTaarichPgiaa']");
				boolResult = driver.TestProject().TypeText(by, TaarichPgiaa);
				report.Step(string.Format("Type '{0}' in 'תאריך פגיעה'", TaarichPgiaa), boolResult, TakeScreenshotConditionType.Failure);

				// 10. Click 'אישור ביטוח לאומי - כפתור שמירה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'אישור ביטוח לאומי - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Always);

				// 11. Get text from 'שם היעדרות - אישור בט\"ל'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath(string.Format("//tr//td[contains(text(), '{0}')]/following-sibling::td", Changed_Sug_Headrut));
				stringResult = driver.TestProject().GetText(by);
				report.Step("Get text from 'שם היעדרות - אישור בט\\\"ל'", stringResult != null && stringResult.Equals("תאונת עבודה מאושרת ב\"ל"), TakeScreenshotConditionType.Failure);

				//12.
				//TODO:Add SQL Verification and set Query_Result
				var query = "SELECT STATUS, taarich_pgiaa FROM hsk_owner.hsk_headrut WHERE mispar_zehut='{Mispar_Zehut}' AND sug_headrut='{Changed_Sug_Headrut}' ORDER BY taarich_idkun DESC";
				var dbSid = "";
				var userName = "";
				var password = "";
				var host = "";

				// 13. Gets value in JSON using JsonPath syntax
				// Add step sleep time (Before)
				Thread.Sleep(500);
				getValueFromJSONUsingJsonpath = TestProject.Addons.Proxy.JSONOperations.CreateGetValueFromJSON("", "STATUS", Query_Result);
				executionResult = helper.ExecuteProxy(getValueFromJSONUsingJsonpath);
				report.Step("Gets value in JSON using JsonPath syntax", executionResult == ExecutionResult.Passed && getValueFromJSONUsingJsonpath.result.Equals("3"), TakeScreenshotConditionType.Failure);

				// 14. Gets value in JSON using JsonPath syntax
				// Add step sleep time (Before)
				Thread.Sleep(500);
				getValueFromJSONUsingJsonpath = TestProject.Addons.Proxy.JSONOperations.CreateGetValueFromJSON("", "TAARICH_PGIAA", Query_Result);
				executionResult = helper.ExecuteProxy(getValueFromJSONUsingJsonpath);
				report.Step("Gets value in JSON using JsonPath syntax", executionResult == ExecutionResult.Passed && getValueFromJSONUsingJsonpath.result.Equals("2022-04-05 00:00:00"), TakeScreenshotConditionType.Failure);


				//15. Mehikat Headrut Acharey husafa
				DeletingAbsenceAfterAddtion deletingAbsenceAfterAddtion = new DeletingAbsenceAfterAddtion();
				deletingAbsenceAfterAddtion.Mispar_Zehut = Mispar_Zehut;
				deletingAbsenceAfterAddtion.NewQueryResult = NewQueryResult;
				deletingAbsenceAfterAddtion.Shaot_Pitzul = Shaot_Pitzul;
				deletingAbsenceAfterAddtion.MISPAR_HEADRUT = MISPAR_HEADRUT;
				deletingAbsenceAfterAddtion.Shem_Headrut = Shem_Headrut;
				deletingAbsenceAfterAddtion.Me_Taarich = Me_Taarich;
				deletingAbsenceAfterAddtion.Ad_Taarich = Ad_Taarich;
				deletingAbsenceAfterAddtion.Semel_Mosad = Semel_Mosad;
				deletingAbsenceAfterAddtion.Sug_Headrut = Sug_Headrut;
				deletingAbsenceAfterAddtion.ApplicationURL = ApplicationURL;
				executionResult = deletingAbsenceAfterAddtion.Execute(helper);

				return ExecutionResult.Passed;
			}
		}
	}