using TestProject.Common.DTO.ExecutionResult;
using TestProject.Common.Enums;
using System;
using System.Reflection;
using TestProject.SDK;
using HSK_AutomationTest.Tests.Queries;

namespace HSK_AutomationTest
{
    public class Runner
    {
		public static string DevToken = "p9v_CtmfGUEfApEkWNjIrlwKaspjYMnhZ8ZigkYPgMI1";
		public static AutomatedBrowserType Browser = AutomatedBrowserType.Chrome;

		public static StepExecutionResult RunTest2()
		{
			using (var runner = new RunnerBuilder(DevToken).AsWeb(Browser).Build())
				 runner.Run(new QueryDisplayingDataByYearBalances(), true);
				return null;
			// runner.Run(new Test2(), true);
		}

		public static StepExecutionResult RunTest()
		{
			using (var runner = new RunnerBuilder(DevToken).AsWeb(Browser).Build())
				return null;// runner.Run(new Test(), true);
		}

		public static void Main(string[] args)
		{
			try
			{
				/*
				using Oracle.DataAccess.Client;  
				OracleConnection myConnection = new OracleConnection();  
				myConnection.ConnectionString = myConnectionString;  
				myConnection.Open();  
				//execute queries   
				myConnection.Close();  */

				RunTest2();

				Console.Write("test");

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
