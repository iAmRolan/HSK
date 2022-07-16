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
    public class QueryDisplayingDataByInstitutionAbsences : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Content;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string File_Path;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string Data_Count;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shnat_Limudim;
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
			io.testproject.addons.general.GetPathOfLastDownloadedFile getPathOfLatestDownloadedFile;
			io.testproject.PDFReadAction pDFReader;
			addon.EvaluateMathExpr evaluateMathematicalExpression;
			io.testproject.addons.element.web.CountElementsFoundByWeb countElements;

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

			// 3. Click 'הצגת נתונים לפי היעדרות'
			Thread.Sleep(500);
			by = By.XPath("//a[@href= '/Hsk/HskRepHeadrutClali.aspx']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הצגת נתונים לפי היעדרות'", boolResult, TakeScreenshotConditionType.Failure);

			// 4. This test was auto generated from steps of the 'שאילתת הצגת נתונים לפי העדרות - עובד' test
			Thread.Sleep(500);
			InstitutionLocatorBar locatorBar = new InstitutionLocatorBar();
			locatorBar.Shem_Mosad = Shem_Mosad;
			locatorBar.Shnat_Limudim = Shnat_Limudim;
			locatorBar.Semel_Mosad = Semel_Mosad;
			executionResult = locatorBar.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת נתונים לפי העדרות - עובד' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 5. Click 'כפתור איתור'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdItur']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Is 'טבלת דיווחים' present?
			Thread.Sleep(500);
			by = By.XPath("//table[@id='ctl00_Main_MainTable']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'טבלת דיווחים' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Count element found by '[NONE]'
			Thread.Sleep(500);
			countElements = TestProject.Addons.Proxy.ElementExtensions.CreateCountElementsFoundByWeb("XPATH", "", "//table[@id='ctl00_Main_grdOvedMosad']//tr");
			executionResult = helper.ExecuteProxy(countElements);
			report.Step("Count element found by '[NONE]'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Data_Count = countElements.amount.ToString();

			// 8. Evaluate '{{Data_Count}}-1'
			Thread.Sleep(500);
			evaluateMathematicalExpression = TestProject.Addons.Proxy.MathematicalUtilities.CreateEvaluateMathExpr(string.Format("{0}-1", Data_Count));
			executionResult = helper.ExecuteProxy(evaluateMathematicalExpression);
			report.Step(string.Format("Evaluate '{0}-1'", Data_Count), executionResult == ExecutionResult.Passed && evaluateMathematicalExpression.result.Equals("3"), TakeScreenshotConditionType.Failure);
			Data_Count = evaluateMathematicalExpression.result;

			// 9. Click 'כפתור הצגה לפני הדפסה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenReport']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור הצגה לפני הדפסה'", boolResult, TakeScreenshotConditionType.Failure);

			// 10. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			// 11. Read the text content of a PDF file
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction("", File_Path);
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content = pDFReader.pdfContent;

			// 12. Click 'פתיחת דוח אקסל -לפי מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenExcel']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פתיחת דוח אקסל -לפי מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 13. Returns the path of the latest downloaded file
			Thread.Sleep(500);
			getPathOfLatestDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetPathOfLastDownloadedFile();
			executionResult = helper.ExecuteProxy(getPathOfLatestDownloadedFile);
			report.Step("Returns the path of the latest downloaded file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			return ExecutionResult.Passed;
		}
	}


    class InstitutionLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shnat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			ExecutionResult executionResult;
			string stringResult;
			bool boolResult;
			io.testproject.addons.web.element.select.SelectOptionbyVisibleText selectOptionsByText;
			io.testproject.addons.element.web.DoubleClickNoJs doubleClick;
			io.testproject.addons.element.web.SwitchToFrame switchToIframe;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Click 'סיווג לפי מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//li[@id='ctl00_Main_TdTabMosad']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'סיווג לפי מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. Click 'איתור מוסד -לפי מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id=\"ctl00_Main_cmdIturMosad\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'איתור מוסד -לפי מוסד'", boolResult, TakeScreenshotConditionType.Failure);

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

			// 5. Type '{{Shem_Mosad}}' in 'חלון איתור מוסד - שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_txtMosad']");
			boolResult = driver.TestProject().TypeText(by, Shem_Mosad);
			report.Step(string.Format("Type '{0}' in 'חלון איתור מוסד - שם מוסד'", Shem_Mosad), boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'חלון איתור מוסד - כפתור חיפוש'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSearch']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - כפתור חיפוש'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Double Click 'חלון איתור מוסד - בחירת מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Semel_Mosad));
			doubleClick = TestProject.Addons.Proxy.ElementExtensions.CreateDoubleClickNoJs();
			executionResult = helper.ExecuteProxy(doubleClick, by);
			report.Step("Double Click 'חלון איתור מוסד - בחירת מוסד'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 8. Get text from 'שם מוסד - לפי מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_Main_lblShemMosad']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'שם מוסד - לפי מוסד'", stringResult != null && stringResult.Equals(Shem_Mosad), TakeScreenshotConditionType.Failure);

			// 9. Select options in 'שנת לימוד - בחירה לפי מוסד' with text '[NONE]'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id='ctl00_Main_cboShnatlimud']");
			selectOptionsByText = TestProject.Addons.Proxy.WebExtensions.CreateSelectOptionbyVisibleText(Shnat_Limudim);
			executionResult = helper.ExecuteProxy(selectOptionsByText, by);
			report.Step("Select options in 'שנת לימוד - בחירה לפי מוסד' with text '[NONE]'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 10. Click 'קטגרויות '
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cboCatHeadrut_MultiSelect_mltDropDown']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'קטגרויות '", boolResult, TakeScreenshotConditionType.Failure);

			// 11. Click 'קטגוריות - הוסף הכל'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@value='הוסף הכל']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'קטגוריות - הוסף הכל'", boolResult, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}
