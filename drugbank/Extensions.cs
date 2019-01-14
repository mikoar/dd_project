using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace drugbank
{
	public static class Extensions
	{
		public static void ToFile(this IEnumerable<ICsvRow> collection, string path, string fileName)
		{
			var delimiter = '\t';
			var filePath = Path.Combine(path, fileName);
			Console.WriteLine($"Writing { filePath }.");
			using(var file = File.CreateText(Path.Combine(Directory.GetCurrentDirectory(), filePath)))
			{
				file.WriteLine(string.Join(delimiter, collection.FirstOrDefault()?.Header));

				foreach (var row in collection)
				{
					file.WriteLine(string.Join(delimiter, row.Row.Select(field => $"\"{ field }\"")));
				}
			}
		}

		public static string JoinWithPipes(this IEnumerable<string> collection)
		{
			if (collection == null || !collection.Any())
			{
				return string.Empty;
			}
			else
			{
				return string.Join('|', collection);
			}
		}
	}
}