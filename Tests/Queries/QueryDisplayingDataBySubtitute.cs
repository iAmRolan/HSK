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

namespace HSK_AutomationTest.Tests.Queries
{
	public class QueryDisplayingDataBySubtitute : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Content_Sikum;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Content;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string File_Path;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		[ParameterAttribute(Description = "Auto generated application URL parameter", DefaultValue = "http://itest20121/Hsk", Direction = ParameterDirection.Input)]
		public string ApplicationURL;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			ExecutionResult executionResult;
			MainQueryPage mainQueryPage;
			By by;
			bool boolResult;
			io.testproject.PDFReadAction pDFReader;
			io.testproject.addons.general.GetPathOfLastDownloadedFile getPathOfLatestDownloadedFile;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			//1.
			mainQueryPage = new MainQueryPage();
			mainQueryPage.ApplicationURL = ApplicationURL;
			executionResult = mainQueryPage.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 2. Click 'הצגת היעדרויות מול מילוי מקום'
			Thread.Sleep(500);
			by = By.XPath("//a[@href=\"/Hsk/HskRepHeadMM.aspx?a=2\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הצגת היעדרויות מול מילוי מקום'", boolResult, TakeScreenshotConditionType.Failure);

			//3.
			Thread.Sleep(500);
			MADGAN_MADBASLocatorBar locatorBar = new MADGAN_MADBASLocatorBar();
			locatorBar.Shem_Mosad = Shem_Mosad;
			locatorBar.Semel_Mosad = Semel_Mosad;
			executionResult = locatorBar.Execute(helper);
			report.Step("בדיקת פס איתור - דיווחי מדבס/מדגן", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 4. Click 'כפתור איתור - מ\"מ'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_cmdItur']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור איתור - מ\\\"מ'", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Is 'טבלת דיווח מ\"מ' present?
			Thread.Sleep(500);
			by = By.XPath("//div[@id='ctl00_Main_MainTable']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'טבלת דיווח מ\\\"מ' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'כפתור הצגה לפני הדפסה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenReport']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור הצגה לפני הדפסה'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			// 8. Read the text content of a PDF file
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction(File_Path, "");
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content = pDFReader.pdfContent;

			// 9. Click 'הדספת דוח סיכום'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenExcel']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הדספת דוח סיכום'", boolResult, TakeScreenshotConditionType.Failure);

			// 10. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			// 11. Read the text content of a PDF file	
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction(File_Path, "");
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content_Sikum = pDFReader.pdfContent;

			return ExecutionResult.Passed;
		}
	}

	class SubtituteLocatorBar: IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		public string Semel_Mosad;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			string stringResult;
			io.testproject.addons.element.web.SwitchToFrame switchToIframe;
			io.testproject.addons.element.web.DoubleClickNoJs doubleClick;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Click 'היעדרויות - כפתור איתור מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_cmdIturMosad']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור איתור מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. Is 'iFrame - חלון איתור ' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'iFrame - חלון איתור ' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Run Switch to iFrame
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			switchToIframe = TestProject.Addons.Proxy.ElementExtensions.CreateSwitchToFrame();
			executionResult = helper.ExecuteProxy(switchToIframe, by);
			report.Step("Run Switch to iFrame", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 4. Type '{{Shem_Mosad}}' in 'חלון איתור מוסד - שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_txtMosad']");
			boolResult = driver.TestProject().TypeText(by, Shem_Mosad);
			report.Step(string.Format("Type '{0}' in 'חלון איתור מוסד - שם מוסד'", Shem_Mosad), boolResult, TakeScreenshotConditionType.Failure);

			// 5. Click 'חלון איתור מוסד - כפתור חיפוש'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSearch']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - כפתור חיפוש'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Double Click 'חלון איתור מוסד - בחירת מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Semel_Mosad));
			doubleClick = TestProject.Addons.Proxy.ElementExtensions.CreateDoubleClickNoJs();
			executionResult = helper.ExecuteProxy(doubleClick, by);
			report.Step("Double Click 'חלון איתור מוסד - בחירת מוסד'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 7. Get text from 'פס איתור - שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShemMosad']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'פס איתור - שם מוסד'", stringResult != null && stringResult.Equals(Shem_Mosad), TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}
