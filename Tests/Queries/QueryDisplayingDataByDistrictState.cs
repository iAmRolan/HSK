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
	public class QueryDisplayingDataByDistrictState : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mahoz;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Content;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string File_Path;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Teler_Name;
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
			io.testproject.addons.general.GetPathOfLastDownloadedFile getPathOfLatestDownloadedFile;
			io.testproject.PDFReadAction pDFReader;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test
			Thread.Sleep(500);
			mainQueryPage = new MainQueryPage();
			mainQueryPage.ApplicationURL = ApplicationURL;
			executionResult = mainQueryPage.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 2. Move mouse to 'הצגת נתוני היעדרות כללית'
			Thread.Sleep(500);
			by = By.XPath("//span[contains(text(), 'הצגת נתוני היעדרות כללית')]");
			boolResult = driver.TestProject().MoveMouseToElement(by);
			report.Step("Move mouse to 'הצגת נתוני היעדרות כללית'", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Click 'הצגת נתונים לפי מחוזי/ארצי'
			Thread.Sleep(500);
			by = By.XPath("//a[@href=\"/Hsk/HskRepHeadrutClali.aspx?HA=true\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הצגת נתונים לפי מחוזי/ארצי'", boolResult, TakeScreenshotConditionType.Failure);

			//4.
			Thread.Sleep(500);
			TalarLocatorBar locatorBar = new TalarLocatorBar();
			locatorBar.Teler_Name = Teler_Name;
			executionResult = locatorBar.Execute(helper);
			report.Step("פס איתור -הצגת נתונים לפי מחוזי/ארצי (טלר)", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 5. Click 'כפתור הצגה לפני הדפסה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenReport']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור הצגה לפני הדפסה'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			// 7. Read the text content of a PDF file
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction("", File_Path);
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content = pDFReader.pdfContent;

			// 8. Click 'פתיחת דוח אקסל'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenExcel']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פתיחת דוח אקסל'", boolResult, TakeScreenshotConditionType.Failure);

			// 9. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			//10.
			Thread.Sleep(500);
			StateLocatorBar locatorBar1 = new StateLocatorBar();
			locatorBar1.Shem_Mahoz = Shem_Mahoz;
			executionResult = locatorBar.Execute(helper);
			report.Step("פס איתור -הצגת נתונים לפי מחוזי/ארצי (טלר)", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 11. Click 'כפתור הצגה לפני הדפסה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenReport']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור הצגה לפני הדפסה'", boolResult, TakeScreenshotConditionType.Failure);

			// 12. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			// 13. Read the text content of a PDF file
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction(File_Path, "");
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content = pDFReader.pdfContent;

			// 14. Click 'פתיחת דוח אקסל'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenExcel']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פתיחת דוח אקסל'", boolResult, TakeScreenshotConditionType.Failure);

			// 15. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			return ExecutionResult.Passed;
		}
	}

	public class TalarLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Teler_Name;
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

			// 1. Click 'בחירת לשונית טלר'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//a[.='טלר']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'בחירת לשונית טלר'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. Click 'איתור טלר'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_Main_cmdIturTeler']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'איתור טלר'", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Is 'iFrame - חלון איתור ' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'iFrame - חלון איתור ' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 4. Run Switch to iFrame
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			switchToIframe = TestProject.Addons.Proxy.ElementExtensions.CreateSwitchToFrame();
			executionResult = helper.ExecuteProxy(switchToIframe, by);
			report.Step("Run Switch to iFrame", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 5. Type '{{Teler_Name}}' in 'הזנת שם טלר'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_txtTeler']");
			boolResult = driver.TestProject().TypeText(by, Teler_Name);
			report.Step(string.Format("Type '{0}' in 'הזנת שם טלר'", Teler_Name), boolResult, TakeScreenshotConditionType.Failure);

			// 6. Send 'ENTER' key(s)
			// Add step sleep time (Before)
			Thread.Sleep(500);
			boolResult = driver.TestProject().SendKeys("ENTER");
			report.Step("Send 'ENTER' key(s)", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Double Click 'בחירת טלר'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Teler_Name));
			doubleClick = TestProject.Addons.Proxy.ElementExtensions.CreateDoubleClickNoJs();
			executionResult = helper.ExecuteProxy(doubleClick, by);
			report.Step("Double Click 'בחירת טלר'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 8. Get text from 'שם טלר'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_Main_lblShemTeller']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'שם טלר'", stringResult != null && stringResult.Equals(Teler_Name), TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}


	public class StateLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mahoz;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			io.testproject.addons.web.element.select.SelectOptionbyVisibleText selectOptionsByText;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Click 'בחירת לשונית מחוז'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//a[.='מחוז']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'בחירת לשונית מחוז'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. Select options in 'בחירת מחוז' with text '[NONE]'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id='ctl00_Main_cboMachoz']");
			selectOptionsByText = TestProject.Addons.Proxy.WebExtensions.CreateSelectOptionbyVisibleText(Shem_Mahoz);
			executionResult = helper.ExecuteProxy(selectOptionsByText, by);
			report.Step("Select options in 'בחירת מחוז' with text '[NONE]'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 3. Click 'קטגרויות '
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cboCatHeadrut_MultiSelect_mltDropDown']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'קטגרויות '", boolResult, TakeScreenshotConditionType.Failure);

			// 4. Click 'קטגוריות - הוסף הכל'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@value='הוסף הכל']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'קטגוריות - הוסף הכל'", boolResult, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}

