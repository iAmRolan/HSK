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

namespace HSK_AutomationTest.Tests.Management.CancelTransactions
{
	public class AddingAbsenceRecord : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yamim_Le_Headrut_Number;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yitrat_Mahala_Number;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yamim_Le_Headrut_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shaot_Pitzul;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Category;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Me_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yitrat_Mahala_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Text_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string QueryResult;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Taarich_Rishum;
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

			// 3. Click 'אישור ביטוח לאומי - כפתור שמירה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'אישור ביטוח לאומי - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

			//4
			executionResult = managePage.Execute(helper);

			// 5. Click 'פס איתור - כפתור איתור'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_cmdItur']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'היעדרויות -ביטול תנועות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdBitulTnuot']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות -ביטול תנועות'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Click 'היעדרות לביטול'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']/following-sibling::td[7][.='{1}']/preceding-sibling::td//input", Text_Headrut, Taarich_Rishum));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרות לביטול'", boolResult, TakeScreenshotConditionType.Failure);

			// 8. Click 'היעדרויות -ביטול תנועות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdBitulTnuot']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות -ביטול תנועות'", boolResult, TakeScreenshotConditionType.Failure);

			// 9. Get text from 'היעדרויות שורת הערה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShortMsgLine']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות שורת הערה'", stringResult != null && stringResult.Equals("פעולת העדכון עברה בהצלחה"), TakeScreenshotConditionType.Failure);


			//TODO:Add SQL Verification
			var query = "SELECT * FROM hsk_owner.hsk_headrut WHERE mispar_zehut = '{Mispar_Zehut}' AND sug_headrut = '{Sug_Headrut}' AND me_tar = '{Me_Taarich}' ORDER BY taarich_idkun DESC";
			var dbSid = "";
			var userName = "";
			var password = "";
			var host = "";


			return ExecutionResult.Passed;
		}
	}
}