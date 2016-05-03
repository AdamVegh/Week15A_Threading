using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingleInstance
{
	class Program
	{
		static void Main(string[] args)
		{
			Mutex myMutex = null;
			const string MutexName = "RUNMEONCE";

			try
			{
				myMutex = Mutex.OpenExisting(MutexName);
			}
			catch (WaitHandleCannotBeOpenedException)
			{
				Console.WriteLine("Sorry, but the mutex called {0} doesn't exist...", MutexName);
				Console.WriteLine("Press enter to make one...");
				Console.ReadLine();
			}

			if (myMutex == null)
				myMutex = new Mutex(true, MutexName);
			else
			{
				myMutex.Close();
				return;
			}

			Console.WriteLine("Yesss, I've done it!\nPress enter to exit...");
			Console.ReadLine();
		}
	}
}
