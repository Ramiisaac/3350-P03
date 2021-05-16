using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace proj_3
{
	class Program
	{
		static void Main(string[] args)
		{
			var parent = Task.Factory.StartNew(() => {
				Console.WriteLine("Status: Parent thread executing...");
				var child = Task.Factory.StartNew(() => {
					Console.WriteLine("Status: Child thread starting...");
					Ops();
					Console.WriteLine("Status: Child thread completed.");
				}, TaskCreationOptions.AttachedToParent);
			});
			parent.Wait();
			Console.WriteLine("Status: Parent has completed.");
		}

		private static void Ops(){

			Console.WriteLine("*** CHILD THREAD TASKS: START ***");

			string fileName = @"C:\Temp\Sample.txt";
            FileInfo fi = new FileInfo(fileName);

            try
            {
                // Check if file already exists and delete if y
                if (fi.Exists)
                {
                    fi.Delete();
                }

                // Create a new file and input string
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("I (the file) was created on {0}", DateTime.Now.ToString());
				}

                Console.WriteLine("Test File Content:");

                // Read and write file content to console
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

				Console.WriteLine("*** CHILD THREAD TASKS: END ***");

			}
			catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
	}
}