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
using HSK_AutomationTest.Infrastructure.BusinessFunctions;

namespace HSK_AutomationTest.Infrastructure.Pages
{
	public class InsertScreenPage : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yamim_Le_Headrut_Number;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yitrat_Mahala_Number;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yamim_Le_Headrut_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yitrat_Mahala_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Me_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Category;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Description = "Auto generated application URL parameter", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			InsertScreenPage insertScreen;
			
			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;
			
			 // 1. Click 'היעדרויות-כפתור הוספה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//*[@id=\"ctl00_Main_cmdInsert\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות-כפתור הוספה'", boolResult, TakeScreenshotConditionType.Failure);
			
			 // 2. Click 'היעדרויות - תפריט סוגי היעדרות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id='ctl00_Main_cboSugHeadrut']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - תפריט סוגי היעדרות'", boolResult, TakeScreenshotConditionType.Failure);
			
			 // 3. Click 'היעדרויות - סוג העידרות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//select[@id='ctl00_Main_cboSugHeadrut']//option[@value='{0}']", Sug_Headrut));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - סוג העידרות'", boolResult, TakeScreenshotConditionType.Failure);
			
			 // 4. Is 'קטגוריית היעדרות ' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_Main_lblCatogory']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'קטגוריית היעדרות ' present?", boolResult, TakeScreenshotConditionType.Failure);
			
			 // 5. Does 'קטגוריית היעדרות ' contain '{{Category}}'?
			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 25000;
			// Add step sleep time (Before)
			Thread.Sleep(1000);
			by = By.XPath("//span[@id='ctl00_Main_lblCatogory']");
			boolResult = driver.TestProject().ContainsText(by, Category);
			report.Step(string.Format("Does 'קטגוריית היעדרות ' contain '{0}'?", Category), boolResult, TakeScreenshotConditionType.Failure);
			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;
			
			 // 6. Type '{{Me_Taarich}}' in 'היעדרויות - תאריך התחלה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_dtMeTaarich']");
			boolResult = driver.TestProject().TypeText(by, Me_Taarich);
			report.Step(string.Format("Type '{0}' in 'היעדרויות - תאריך התחלה'", Me_Taarich), boolResult, TakeScreenshotConditionType.Failure);
			
			 // 7. Click 'היעדרויות - תאריך סיום'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - תאריך סיום'", boolResult, TakeScreenshotConditionType.Failure);
			
			 // 8. Type '{{Ad_Taarich}}' in 'היעדרויות - תאריך סיום'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_dtAdTaarich']");
			boolResult = driver.TestProject().TypeText(by, Ad_Taarich);
			report.Step(string.Format("Type '{0}' in 'היעדרויות - תאריך סיום'", Ad_Taarich), boolResult, TakeScreenshotConditionType.Failure);
			
			 // 9. Click 'שורת מספר ימים'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_Main_Label1']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'שורת מספר ימים'", boolResult, TakeScreenshotConditionType.Failure);
			
			 // 10. This test was auto generated from steps of the 'POM - מסך הוספה' test
			// This step was auto generated from several steps
			if (Category.Equals("מחלה"))
			{

				SickDaysBalance sickDaysBalance = new SickDaysBalance();
				sickDaysBalance.Yitrat_Mahala_Number = Yitrat_Mahala_Number;
				sickDaysBalance.Yamim_Le_Headrut_Number = Yamim_Le_Headrut_Number;
				sickDaysBalance.Yamim_Le_Headrut_Text = Yamim_Le_Headrut_Text;
				sickDaysBalance.Yitrat_Mahala_Text = Yitrat_Mahala_Text;
				executionResult = sickDaysBalance.Execute(helper);
				report.Step("בדיקת ימי מחלה", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			}

			
			return ExecutionResult.Passed;
		}
	}
}