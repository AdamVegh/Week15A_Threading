using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
	class Program
	{
		static void ShowMyText(object state)
		{
			string myText = (string)state;
			Console.WriteLine("Thread ID: {0}, Text: {1}", Thread.CurrentThread.ManagedThreadId, myText);
		}

		static void Main(string[] args)
		{
			WaitCallback wcb = new WaitCallback(ShowMyText);

			ThreadPool.QueueUserWorkItem(wcb, "Python");
			ThreadPool.QueueUserWorkItem(wcb, "MySQL");
			ThreadPool.QueueUserWorkItem(wcb, "Java");
			ThreadPool.QueueUserWorkItem(wcb, "CSharp");

			Console.WriteLine("Press enter to exit...");
			Console.ReadLine();
		}
	}
}
