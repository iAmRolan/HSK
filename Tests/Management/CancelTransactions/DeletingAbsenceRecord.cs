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

namespace HSK_AutomationTest.Tests.Management.CancelTransactions
{
		public class DeletingAbsenceRecord : IWebTest
		{
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string NewQueryResult;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string MISPAR_HEADRUT;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yamim_Le_Headrut_Number;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yitrat_Mahala_Number;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yamim_Le_Headrut_Text;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Yitrat_Mahala_Text;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Text_Headrut;
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
			public string Taarich_Rishum;
			[ParameterAttribute(Direction = ParameterDirection.Input)]
			public string Sug_Peula;
			[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
			public string ApplicationURL;
			public ExecutionResult Execute(WebTestHelper helper)
			{
				var driver = helper.Driver;
				var report = helper.Reporter;
				By by;
				bool boolResult;
				ExecutionResult executionResult;

				//set timeout for driver actions (similar to step timeout)
				driver.Timeout = 15000;

				//1
				ManagePage managePage = new ManagePage();
				managePage.ApplicationURL = ApplicationURL;
				managePage.Semel_Mosad = Semel_Mosad;
				managePage.Mispar_Zehut = Mispar_Zehut;
				managePage.Ad_Taarich = Ad_Taarich;
				managePage.Me_Taarich = Me_Taarich;
				managePage.Sug_Headrut = Sug_Headrut;
				managePage.Shem_Headrut = Shem_Headrut;
				managePage.Shaot_Pitzul = Shaot_Pitzul;
				executionResult = managePage.Execute(helper);

				//2
				InsertScreenPage insertScreenPage = new InsertScreenPage();
				insertScreenPage.ApplicationURL = ApplicationURL;
				insertScreenPage.Sug_Headrut = Sug_Headrut;
				insertScreenPage.Me_Taarich = Me_Taarich;
				insertScreenPage.Ad_Taarich = Ad_Taarich;
				insertScreenPage.Yitrat_Mahala_Text = Yitrat_Mahala_Text;
				insertScreenPage.Yamim_Le_Headrut_Text = Yamim_Le_Headrut_Text;
				insertScreenPage.Yitrat_Mahala_Number = Yitrat_Mahala_Number;
				insertScreenPage.Yamim_Le_Headrut_Number = Yamim_Le_Headrut_Number;
				insertScreenPage.Category = Category;
				executionResult = insertScreenPage.Execute(helper);


				// 3. Click 'היעדרויות - כפתור שמירה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);


				//4. Mehikat Headrut Acharey husafa
				DeletingAbsenceAfterAddtion deletingAbsenceAfterAddtion = new DeletingAbsenceAfterAddtion();
				deletingAbsenceAfterAddtion.Shem_Headrut = Shem_Headrut;
				deletingAbsenceAfterAddtion.NewQueryResult = NewQueryResult;
				deletingAbsenceAfterAddtion.Shaot_Pitzul = Shaot_Pitzul;
				executionResult = deletingAbsenceAfterAddtion.Execute(helper);

				//5
				executionResult = managePage.Execute(helper);

				// 6. Click 'היעדרויות -ביטול תנועות'
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdBitulTnuot']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות -ביטול תנועות'", boolResult, TakeScreenshotConditionType.Failure);

				// 7. Click 'היעדרות לביטול - מחיקה'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath(string.Format("//td[.='{0}']/following-sibling::td[7][.='{1}']/following-sibling::td[3][.='{2}']/preceding-sibling::td[11]", Text_Headrut, Taarich_Rishum, Sug_Peula));
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרות לביטול - מחיקה'", boolResult, TakeScreenshotConditionType.Failure);

				// 8. Click 'היעדרויות -ביטול תנועות'
				// Add step sleep time (Before)
				Thread.Sleep(500);
				by = By.XPath("//input[@id='ctl00_Main_cmdBitulTnuot']");
				boolResult = driver.TestProject().Click(by);
				report.Step("Click 'היעדרויות -ביטול תנועות'", boolResult, TakeScreenshotConditionType.Failure);

				//9 TODO:Add SQL Verification
				var query = "SELECT * FROM hsk_owner.hsk_headrut WHERE mispar_zehut='{Mispar_Zehut}' AND sug_headrut='{Sug_Headrut}' ORDER BY taarich_idkun DESC";
				var dbSid = "";
				var userName = "";
				var password = "";
				var host = "";


				return ExecutionResult.Passed;
			}
		}
	}