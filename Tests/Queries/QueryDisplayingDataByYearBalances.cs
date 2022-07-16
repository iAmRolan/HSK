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
	public class QueryDisplayingDataByYearBalances : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shnat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string File_Path;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Data;
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
			//io.testproject.addons.general.GetPathOfLastDownloadedFile getPathOfLatestDownloadedFile;
			//io.testproject.PDFReadAction pDFReader;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1.
			mainQueryPage = new MainQueryPage();
			mainQueryPage.ApplicationURL = ApplicationURL;
			executionResult = mainQueryPage.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 2. Move mouse to 'הצגת יתרות - כפתור'
			Thread.Sleep(500);
			by = By.XPath("//li//span[contains(text(), 'הצגת יתרות')]");
			boolResult = driver.TestProject().MoveMouseToElement(by);
			report.Step("Move mouse to 'הצגת יתרות - כפתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 3. Click 'הצגת יתרות לשנה\"ל'
			Thread.Sleep(500);
			by = By.XPath("//a[@href=\"/Hsk/HskNitsulTikrotHead.aspx\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הצגת יתרות לשנה\\\"ל'", boolResult, TakeScreenshotConditionType.Failure);

			//4.
			Thread.Sleep(500);
			YearBalancesLocatorBar locatorBar = new YearBalancesLocatorBar();
			locatorBar.Semel_Mosad = Semel_Mosad;
			locatorBar.Mispar_Zehut = Mispar_Zehut;
			locatorBar.Shnat_Limudim = Shnat_Limudim;
			locatorBar.Shem_Oved = Shem_Oved;
			locatorBar.Shem_Mosad = Shem_Mosad;
			executionResult = locatorBar.Execute(helper);
			report.Step("בדיקת פס איתור - דיווחי מדבס/מדגן", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 5. Click 'פס איתור - כפתור איתור'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_cmdItur']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'הפסדה לפני הצגה - יתרות לשנה\"ל'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='cmdOpenReport']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הפסדה לפני הצגה - יתרות לשנה\\\"ל'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Returns the path of the latest downloaded file
			//Thread.Sleep(500);
			//getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			//executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			//report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			//File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			// 8. Read the text content of a PDF file
			//Thread.Sleep(500);
			//pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction("", File_Path);
			//executionResult = helper.ExecuteProxy(pDFReader);
			//report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			//PDF_Data = pDFReader.pdfContent;

			// 9. Click 'פתיחת דוח אקסל - יתרות לשנה\"ל'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='cmdOpenExcel']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פתיחת דוח אקסל - יתרות לשנה\\\"ל'", boolResult, TakeScreenshotConditionType.Failure);

			// 10. Returns the path of the latest downloaded file
			/*.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;
			*/

			return ExecutionResult.Passed;
		}
	}

	public class YearBalancesLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shnat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			ExecutionResult executionResult;
			bool boolResult;
			string stringResult;
			io.testproject.addons.element.web.DoubleClickNoJs doubleClick;
			io.testproject.addons.element.web.SwitchToFrame switchToIframe;
			io.testproject.addons.web.element.select.SelectOptionbyVisibleText selectOptionsByText;

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

			// 7. Get text from 'היעדרויות-שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShemMosad']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות-שם מוסד'", stringResult != null && stringResult.Equals(Shem_Mosad), TakeScreenshotConditionType.Failure);

			// 8. Click 'כפתור איתור עובד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_cmdIturOvh']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור איתור עובד'", boolResult, TakeScreenshotConditionType.Failure);

			// 9. Is 'iFrame - חלון איתור ' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'iFrame - חלון איתור ' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 10. Run Switch to iFrame
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			switchToIframe = TestProject.Addons.Proxy.ElementExtensions.CreateSwitchToFrame();
			executionResult = helper.ExecuteProxy(switchToIframe, by);
			report.Step("Run Switch to iFrame", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 11. Double Click 'בחירת עובד - הצגת יתרות '
			// Add step sleep time (Before)
			
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Mispar_Zehut));
			doubleClick = TestProject.Addons.Proxy.ElementExtensions.CreateDoubleClickNoJs();
			executionResult = helper.ExecuteProxy(doubleClick, by);
			report.Step("Double Click 'בחירת עובד - הצגת יתרות '", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			

			// 12. Get text from 'היעדרויות - שם עובד הוראה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShem']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות - שם עובד הוראה'", stringResult != null && stringResult.Equals(Shem_Oved), TakeScreenshotConditionType.Failure);

			// 13. Select options in 'בחירת שנה - שאילתת יתרות ' with text '[NONE]'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id='ctl00_cboShnatlimud']");
			selectOptionsByText = TestProject.Addons.Proxy.WebExtensions.CreateSelectOptionbyVisibleText(Shnat_Limudim);
			executionResult = helper.ExecuteProxy(selectOptionsByText, by);
			report.Step("Select options in 'בחירת שנה - שאילתת יתרות ' with text '[NONE]'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}

