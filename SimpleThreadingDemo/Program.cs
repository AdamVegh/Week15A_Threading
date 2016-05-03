using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadingDemo
{
	class Program
	{

		static void Counting()
		{
			for (int i = 1; i < 11; i++)
			{
				Console.WriteLine("Counting: {0}, Thread ID: {1}",
								  i, Thread.CurrentThread.ManagedThreadId);
				Thread.Sleep(10);
			}
		}


		static void Main(string[] args)
		{
			ThreadStart starter = new ThreadStart(Counting);
			Thread first = new Thread(starter);
			Thread second = new Thread(starter);

			Console.WriteLine("First thread starts...");
			first.Start();
			Console.WriteLine("Second thread starts...");
			second.Start();

			first.Join();
			second.Join();

			Console.WriteLine("Press enter to exit...");
			Console.ReadLine();
		}
	}
}
