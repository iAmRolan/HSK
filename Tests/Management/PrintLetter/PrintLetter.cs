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

namespace HSK_AutomationTest.Tests.Management.PrintLetter
{
	public class PrintLetter : IWebTest
	{
		public string PDF_Content = "";
		public string Downloaded_File_Name = "";
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Print_Btn_Atr_Value;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shaot_Pitzul;
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
		public string Yitrat_Mahala_Text;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Ad_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Me_Taarich;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Category;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Sug_Headrut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string MISPAR_HEADRUT;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string QueryResult;
		[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			ExecutionResult executionResult;
			bool boolResult;
			io.testproject.addons.web.element.GetElementAttribute getAttributeValue;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			//1.
			ManagePage managePage = new ManagePage();
			managePage.Shaot_Pitzul = Shaot_Pitzul;
			managePage.Shem_Headrut = Shem_Headrut;
			managePage.Sug_Headrut = Sug_Headrut;
			managePage.Me_Taarich = Me_Taarich;
			managePage.Ad_Taarich = Ad_Taarich;
			managePage.Mispar_Zehut = Mispar_Zehut;
			managePage.Semel_Mosad = Semel_Mosad;
			managePage.ApplicationURL = ApplicationURL;
			executionResult = managePage.Execute(helper);

			//2.
			InsertScreenPage insertScreenPage = new InsertScreenPage();
			insertScreenPage.Ad_Taarich = Ad_Taarich;
			insertScreenPage.Sug_Headrut = Sug_Headrut;
			insertScreenPage.Category = Category;
			insertScreenPage.Me_Taarich = Me_Taarich;
			insertScreenPage.Yamim_Le_Headrut_Number = Yamim_Le_Headrut_Number;
			insertScreenPage.Yitrat_Mahala_Number = Yitrat_Mahala_Number;
			insertScreenPage.Yamim_Le_Headrut_Text = Yamim_Le_Headrut_Text;
			insertScreenPage.Yitrat_Mahala_Text = Yitrat_Mahala_Text;
			insertScreenPage.ApplicationURL = ApplicationURL;
			executionResult = insertScreenPage.Execute(helper);

			// 3. Click 'היעדרויות - כפתור שמירה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSave']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור שמירה'", boolResult, TakeScreenshotConditionType.Failure);

			// 4. Click 'ChekboxByTypeHeadrut'
			Thread.Sleep(500);
			by = By.XPath(string.Format("//tr//td[contains(text(), '{0}')]/preceding-sibling::td/input", Semel_Mosad));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'ChekboxByTypeHeadrut'", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Is 'היעדרויות - הדפסת מכתב' is clickable?
			/* This step is disabled
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdPrintMichtav']");
			boolResult = driver.TestProject().IsClickable(by);
			report.Step("Is 'היעדרויות - הדפסת מכתב' is clickable?", boolResult, TakeScreenshotConditionType.Failure);
			*/

			// 6. Get 'disabled' attribute value on 'היעדרויות - הדפסת מכתב'
			// Add step sleep time (Before)
			by = By.XPath("//input[@id='ctl00_Main_cmdPrintMichtav']");
			getAttributeValue = TestProject.Addons.Proxy.WebExtensions.CreateGetElementAttribute("disabled");
			executionResult = helper.ExecuteProxy(getAttributeValue, by);
			report.Step("Get 'disabled' attribute value on 'היעדרויות - הדפסת מכתב'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Print_Btn_Atr_Value = getAttributeValue.attributeValue;

			//7.
			PrintLetterActiveButton PrintLetterActiveButton = new PrintLetterActiveButton();
			PrintLetterActiveButton.PDF_Content = PDF_Content;
			PrintLetterActiveButton.Downloaded_File_Name = Downloaded_File_Name;
			executionResult = PrintLetterActiveButton.Execute(helper);

			//8. Mehikat Headrut Acharey husafa
			DeletingAbsenceAfterAddtion deletingAbsenceAfterAddtion = new DeletingAbsenceAfterAddtion();
			deletingAbsenceAfterAddtion.Ad_Taarich = Ad_Taarich;
			deletingAbsenceAfterAddtion.NewQueryResult = QueryResult;
			deletingAbsenceAfterAddtion.Shaot_Pitzul = Shaot_Pitzul;
			deletingAbsenceAfterAddtion.MISPAR_HEADRUT = MISPAR_HEADRUT;
			deletingAbsenceAfterAddtion.Shem_Headrut = Shem_Headrut;
			deletingAbsenceAfterAddtion.Me_Taarich = Me_Taarich;
			deletingAbsenceAfterAddtion.Mispar_Zehut = Mispar_Zehut;
			deletingAbsenceAfterAddtion.Semel_Mosad = Semel_Mosad;
			deletingAbsenceAfterAddtion.Sug_Headrut = Sug_Headrut;
			deletingAbsenceAfterAddtion.ApplicationURL = ApplicationURL;
			executionResult = deletingAbsenceAfterAddtion.Execute(helper);

			return ExecutionResult.Passed;
		}
	}
	
	public class PrintLetterActiveButton : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string Downloaded_File_Name;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Content;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			io.testproject.addons.general.GetLastDownloadedFile getLastDownloadedFile;
			io.testproject.PDFReadAction pDFReader;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Click 'היעדרויות - הדפסת מכתב'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdPrintMichtav']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - הדפסת מכתב'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. get last downloaded file details
			Thread.Sleep(500);
			getLastDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetLastDownloadedFile("C:\\Users\\sp677\\Downloads", 0);
			executionResult = helper.ExecuteProxy(getLastDownloadedFile);
			report.Step("get last downloaded file details", executionResult == ExecutionResult.Passed && getLastDownloadedFile.name.Contains("Report"), TakeScreenshotConditionType.Failure);
			Downloaded_File_Name = getLastDownloadedFile.name;

			// 3. Read the text content of a PDF file
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction(string.Format("C:\\Users\\sp677\\Downloads\\{0}", Downloaded_File_Name), "");
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content = pDFReader.pdfContent;

			return ExecutionResult.Passed;
		}
	}
}