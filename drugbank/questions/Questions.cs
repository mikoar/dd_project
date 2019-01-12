using System;
using System.IO;

namespace drugbank
{
	public partial class Questions
	{
		private string InitQuestion(int questionNumber)
		{
			Console.WriteLine($"Question {questionNumber}...");
			var path = Path.Combine(Directory.GetCurrentDirectory(), "out", questionNumber.ToString());
			Directory.CreateDirectory(path);

			foreach (var file in new DirectoryInfo(path).GetFiles())
			{
				file.Delete();
			}

			return path;
		}
	}
}
