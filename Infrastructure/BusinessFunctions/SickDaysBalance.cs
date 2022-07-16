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
	public class SickDaysBalance : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yitrat_Mahala_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yamim_Le_Headrut_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yamim_Le_Headrut_Number;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Yitrat_Mahala_Number;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			ExecutionResult executionResult;
			By by;
			string stringResult;
			TestProject.Addons.Proxy.Actions.ReplaceSubstrings replaceSubstrings;
			TestProject.Addons.Proxy.Actions.ConvertStringToNumber convertStringToNumber;
			
			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;
			
			 // 1. Get text from 'היעדרויות - יתרת מחלה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//a[@id='ctl00_Main_lnkItratMachalaDoch']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות - יתרת מחלה'", stringResult != null, TakeScreenshotConditionType.Failure);
			Yitrat_Mahala_Text = stringResult;
			
			 // 2. Get text from 'מספר ימי היעדרות'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_Main_LblMisparYamim']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'מספר ימי היעדרות'", stringResult != null, TakeScreenshotConditionType.Failure);
			Yamim_Le_Headrut_Text = stringResult;
			
			 // 3. Replace all occurrences of 'ימים' with '[NONE]' in '{{Yitrat_Mahala_Text}}'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			replaceSubstrings = TestProject.Addons.Proxy.StringUtils.CreateReplaceSubstrings(Yitrat_Mahala_Text, "ימים", "");
			executionResult = helper.ExecuteProxy(replaceSubstrings);
			report.Step(string.Format("Replace all occurrences of 'ימים' with '[NONE]' in '{0}'", Yitrat_Mahala_Text), executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Yitrat_Mahala_Text = replaceSubstrings.result;
			
			 // 4. Remove none numeric characters from '{{Yamim_Le_Headrut_Text}}'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			convertStringToNumber = TestProject.Addons.Proxy.StringUtils.CreateConvertStringToNumber(Yamim_Le_Headrut_Text);
			executionResult = helper.ExecuteProxy(convertStringToNumber);
			report.Step(string.Format("Remove none numeric characters from '{0}'", Yamim_Le_Headrut_Text), executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Yamim_Le_Headrut_Number = convertStringToNumber.output;
			
			 // 5. Remove none numeric characters from '{{Yitrat_Mahala_Text}}'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			convertStringToNumber = TestProject.Addons.Proxy.StringUtils.CreateConvertStringToNumber(Yitrat_Mahala_Text);
			executionResult = helper.ExecuteProxy(convertStringToNumber);
			report.Step(string.Format("Remove none numeric characters from '{0}'", Yitrat_Mahala_Text), executionResult == ExecutionResult.Passed && int.Parse(convertStringToNumber.output) >= int.Parse(Yamim_Le_Headrut_Number), TakeScreenshotConditionType.Failure);
			Yitrat_Mahala_Number = convertStringToNumber.output;
			
			return ExecutionResult.Passed;
		}
	}
}