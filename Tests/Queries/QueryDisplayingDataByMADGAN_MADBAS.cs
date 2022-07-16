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
    public class QueryDisplayingDataByMADGAN_MADBAS
    {
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shnat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shanat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		public string ApplicationURL;

		public ExecutionResult Execute(WebTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;
			By by;
			ExecutionResult executionResult;
			MainQueryPage mainQueryPage;
			string stringResult;
			bool boolResult;
			io.testproject.addons.web.element.select.SelectOptionbyVisibleText selectOptionsByText;
			io.testproject.addons.element.web.DoubleClickNoJs doubleClick;
			io.testproject.addons.element.web.SwitchToFrame switchToIframe;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test
			// Add step sleep time (Before)
			Thread.Sleep(500);

			mainQueryPage = new MainQueryPage();
			mainQueryPage.ApplicationURL = ApplicationURL;
			executionResult = mainQueryPage.Execute(helper);
			report.Step("This test was auto generated from steps of the 'שאילתת הצגת סוגי העדרות' test", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 1. Click 'סיווג לפי מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//li[@id='ctl00_Main_TdTabMosad']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'סיווג לפי מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			Thread.Sleep(500);
			MADGAN_MADBASLocatorBar locatorBar = new MADGAN_MADBASLocatorBar();
			locatorBar.Shanat_Limudim = Shnat_Limudim;
			locatorBar.Shem_Mosad = Shem_Mosad;
			locatorBar.Shem_Oved = Shem_Oved;
			locatorBar.Semel_Mosad = Semel_Mosad;
			executionResult = locatorBar.Execute(helper);
			report.Step("בדיקת פס איתור - דיווחי מדבס/מדגן", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

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


	public class MADGAN_MADBASLocatorBar : IWebTest
	{
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shanat_Limudim;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Semel_Mosad;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Oved;
		[ParameterAttribute(Direction = ParameterDirection.Input)]
		public string Shem_Mosad;
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
			Actions.CountItems countItemsInAWebListElement;

			// set timeout for driver actions (similar to step timeout)
			driver.Timeout = 15000;

			// 1. Click 'היעדרויות - כפתור איתור מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_cmdIturMosad']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'היעדרויות - כפתור איתור מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 2. Run Switch to iFrame
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			switchToIframe = TestProject.Addons.Proxy.ElementExtensions.CreateSwitchToFrame();
			executionResult = helper.ExecuteProxy(switchToIframe, by);
			report.Step("Run Switch to iFrame", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 3. Type '{{Shem_Mosad}}' in 'חלון איתור מוסד - שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_txtMosad']");
			boolResult = driver.TestProject().TypeText(by, Shem_Mosad);
			report.Step(string.Format("Type '{0}' in 'חלון איתור מוסד - שם מוסד'", Shem_Mosad), boolResult, TakeScreenshotConditionType.Failure);

			// 4. Click 'חלון איתור מוסד - כפתור חיפוש'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ctl00_Main_cmdSearch']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - כפתור חיפוש'", boolResult, TakeScreenshotConditionType.Failure);

			// 5. Click 'חלון איתור מוסד - בחירת מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Semel_Mosad));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - בחירת מוסד'", boolResult, TakeScreenshotConditionType.Failure);

			// 6. Click 'חלון איתור מוסד - כפתור אישור'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='Select']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'חלון איתור מוסד - כפתור אישור'", boolResult, TakeScreenshotConditionType.Failure);

			// 7. Get text from 'פס איתור - שם מוסד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShemMosad']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'פס איתור - שם מוסד'", stringResult != null && stringResult.Equals(Shem_Mosad), TakeScreenshotConditionType.Failure);

			// 8. Counts the elements inside an HTML web list element
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id=\"ctl00_cboShnatlimud\"]");
			countItemsInAWebListElement = TestProject.Addons.Proxy.WebListOperations.CreateCountItems();
			executionResult = helper.ExecuteProxy(countItemsInAWebListElement, by);
			report.Step("Counts the elements inside an HTML web list element", executionResult == ExecutionResult.Passed && countItemsInAWebListElement.numOfElements.Equals(17), TakeScreenshotConditionType.Failure);

			// 9. Click 'פס איתור - שנת לימודים'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//select[@id=\"ctl00_cboShnatlimud\"]");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - שנת לימודים'", boolResult, TakeScreenshotConditionType.Failure);

			// 10. Click 'פס איתור - בחירת שנת לימודים'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//select[@id=\"ctl00_cboShnatlimud\"]//option[.='{0}']", Shanat_Limudim));
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'פס איתור - בחירת שנת לימודים'", boolResult, TakeScreenshotConditionType.Failure);

			// 11. Click 'כפתור איתור עובד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//img[@id='ctl00_cmdIturOvh']");
			boolResult = driver.TestProject().Click(by);
			report.Step("Click 'כפתור איתור עובד'", boolResult, TakeScreenshotConditionType.Failure);

			// 12. Run Switch to iFrame
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//iframe[@id='ifrmPopModal']");
			switchToIframe = TestProject.Addons.Proxy.ElementExtensions.CreateSwitchToFrame();
			executionResult = helper.ExecuteProxy(switchToIframe, by);
			report.Step("Run Switch to iFrame", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 13. Type '{{Shem_Oved}}' in 'איתור עובד - שם עובד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//input[@id='ShemSearch']");
			boolResult = driver.TestProject().TypeText(by, Shem_Oved);
			report.Step(string.Format("Type '{0}' in 'איתור עובד - שם עובד'", Shem_Oved), boolResult, TakeScreenshotConditionType.Failure);

			// 14. Double Click 'חלון איתור - בחירת עובד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath(string.Format("//td[.='{0}']", Shem_Oved));
			doubleClick = TestProject.Addons.Proxy.ElementExtensions.CreateDoubleClickNoJs();
			executionResult = helper.ExecuteProxy(doubleClick, by);
			report.Step("Double Click 'חלון איתור - בחירת עובד'", executionResult == ExecutionResult.Passed, TakeScreenshotConditionType.Failure);

			// 15. Get text from 'פס איתור - שם עובד'
			// Add step sleep time (Before)
			Thread.Sleep(500);
			by = By.XPath("//span[@id='ctl00_lblShem']");
			stringResult = driver.TestProject().GetText(by);
			report.Step("Get text from 'פס איתור - שם עובד'", stringResult != null && stringResult.Contains(Shem_Oved), TakeScreenshotConditionType.Failure);

			return ExecutionResult.Passed;
		}
	}
}
