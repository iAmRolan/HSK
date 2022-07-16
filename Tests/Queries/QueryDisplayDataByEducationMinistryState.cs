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

	public class QueryDisplayDataByEducationMinistryState : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shanat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string Data_Count;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string Last_File_Path;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string PDF_Content;
		[ParameterAttribute(Direction = ParameterDirection.Output)]
		public string Last_Downloaded_File_name;
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
			io.testproject.addons.element.web.CountElementsFoundByWeb countElements;
			addon.EvaluateMathExpr evaluateMathematicalExpression;
			io.testproject.addons.general.GetLastDownloadedFile getLastDownloadedFile;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test
			Thread.Sleep(500);
			mainQueryPage = new MainQueryPage();
			mainQueryPage.ApplicationURL = ApplicationURL;
			executionResult = mainQueryPage.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);


			// 2. Click 'הצגת מצב במשהח'
			Thread.Sleep(500);
			by = By.XPath("//a[contains(@href, '/Hsk/HskSheiltaHeadrutMMeudkan.aspx')]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'הצגת מצב במשהח'", boolResult, TakeScreenshotConditionType.Failure);

			//3
			Thread.Sleep(500);
			EOMLocatorBar locatorBar = new EOMLocatorBar();
			locatorBar.Shem_Mosad = Shem_Mosad;
			locatorBar.Shanat_Limudim = Shanat_Limudim;
			locatorBar.Semel_Mosad = Semel_Mosad;
			locatorBar.Shem_Oved = Shem_Oved;
			locatorBar.Mispar_Zehut = Mispar_Zehut;
			executionResult = locatorBar.Execute(helper);
			report.Step("פס איתור -הצגת נתונים לפי מחוזי/ארצי (טלר)", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 4. Click 'פס איתור - כפתור איתור'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_cmdItur']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - כפתור איתור'", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Is 'טבלת דיווחים' present?
			Thread.Sleep(500);
			by = By.XPath("//table[@id='ctl00_Main_MainTable']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'טבלת דיווחים' present?", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'כפתור הצגה לפני הדפסה'
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_btnOpenReport']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור הצגה לפני הדפסה'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. get last downloaded file details
			Thread.Sleep(500);
			getLastDownloadedFile = TestProject.Addons.Proxy.GenericExtensions.CreateGetLastDownloadedFile("C:\\Users\\sp677\\Downloads");
			executionResult = helper.ExecuteProxy(getLastDownloadedFile);
			report.Step("get last downloaded file details", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Last_Downloaded_File_name = getLastDownloadedFile.name;

			// 8. Read the text content of a PDF file
			Thread.Sleep(500);
			pDFReader = TestProject.Addons.Proxy.PDFActions.CreatePDFReadAction("", string.Format("C:\\Users\\sp677\\Downloads\\{0}", Last_Downloaded_File_name));
			executionResult = helper.ExecuteProxy(pDFReader);
			report.Step("Read the text content of a PDF file", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			PDF_Content = pDFReader.pdfContent;

			// 6. Count element found by '[NONE]'
			Thread.Sleep(500);
			countElements = TestProject.Addons.Proxy.ElementExtensions.CreateCountElementsFoundByWeb("", "//table[@id='ctl00_Main_grdHeadruyot']//tr", "XPATH");
			executionResult = helper.ExecuteProxy(countElements);
			report.Step("Count element found by '[NONE]'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Data_Count = countElements.amount.ToString();

			// 7. Evaluate '{{Data_Count}}-1'
			Thread.Sleep(500);
			evaluateMathematicalExpression = TestProject.Addons.Proxy.MathematicalUtilities.CreateEvaluateMathExpr(string.Format("{0}-1", Data_Count));
			executionResult = helper.ExecuteProxy(evaluateMathematicalExpression);
			report.Step(string.Format("Evaluate '{0}-1'", Data_Count), executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);
			Data_Count = evaluateMathematicalExpression.result;

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
			Last_File_Path = getPathOfLatestDownloadedFile.pathOfLastDownloadedFile;

			return ExecutionResult.Passed;
		}
	}

	public class EOMLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shanat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Mispar_Zehut;
		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			bool boolResult;
			ExecutionResult executionResult;
			string stringResult;
			io.testproject.addons.element.web.SwitchToFrame switchToIframe;
			Actions.CountItems countItemsInAWebListElement;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Click 'כפתור איתור מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id=\"ctl00_cmdIturMosad\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור איתור מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. Is 'חלון איתור מוסד' present?
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//div[@class='dialogModal_content']");
			boolResult = driver.TestProject().IsPresent(by);
			report.Step("Is 'חלון איתור מוסד' present?", boolResult, TakeScreenshotConditionType.Failure);

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

			// 6. Click 'חלון איתור מוסד - בחירת מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Semel_Mosad));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - בחירת מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Click 'חלון איתור מוסד - כפתור אישור'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='Select']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - כפתור אישור'", boolResult, TakeScreenshotConditionType.Failure);

			// 8. Get text from 'היעדרויות-שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShemMosad']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'היעדרויות-שם מוסד'", stringResult != null && stringResult.Equals(Shem_Mosad), TakeScreenshotConditionType.Failure);

			// 9. Counts the elements inside an HTML web list element
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id=\"ctl00_cboShnatlimud\"]");
			countItemsInAWebListElement = TestProject.Addons.Proxy.WebListOperations.CreateCountItems();
			executionResult = helper.ExecuteProxy(countItemsInAWebListElement, by);
			report.Step("Counts the elements inside an HTML web list element", executionResult == ExecutionResult.Passed && countItemsInAWebListElement.numOfElements.Equals(17), TakeScreenshotConditionType.Failure);

			// 10. Click 'פס איתור - שנת לימודים'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id=\"ctl00_cboShnatlimud\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - שנת לימודים'", boolResult, TakeScreenshotConditionType.Failure);

			// 11. Click 'פס איתור - בחירת שנת לימודים'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//select[@id=\"ctl00_cboShnatlimud\"]//option[.='{0}']", Shanat_Limudim));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - בחירת שנת לימודים'", boolResult, TakeScreenshotConditionType.Failure);

			// 12. Type '{{Mispar_Zehut}}' in 'פס איתור - שורת תז'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_txtZehut']");
			boolResult = driver.TestProject().TypeText(by, Mispar_Zehut);
			report.Step(string.Format("Type '{0}' in 'פס איתור - שורת תז'", Mispar_Zehut), boolResult, TakeScreenshotConditionType.Failure);

			// 13. Click 'היעדרויות-שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShemMosad']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות-שם מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 14. Get text from 'פס איתור - שם עו\"ה'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShem']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'פס איתור - שם עו\\\"ה'", stringResult != null && stringResult.Equals(Shem_Oved), TakeScreenshotConditionType.Failure);

			// 15. Click 'פס איתור - היעדרויות לעובד '
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Search_radSugHeadrut_1']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - היעדרויות לעובד '", boolResult, TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}