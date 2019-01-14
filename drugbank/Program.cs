using System;
using System.Xml;
using System.Xml.Serialization;

namespace drugbank
{
	static class Program
	{
		static void Main(string[] args)
		{
			var xmlFilename = args[0];

			var serializer = new XmlSerializer(typeof(drugbanktype));
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($"Parsing {xmlFilename}.");
			var drugbank = (drugbanktype) serializer.Deserialize(new XmlTextReader(xmlFilename));
			Console.WriteLine("XML Parsed");

			var questions = new Questions();
			questions.Question1(drugbank);
			questions.Question2(drugbank);
			questions.Question3(drugbank);
			questions.Question4(drugbank);
			questions.Question6(drugbank);
			questions.Question7(drugbank);
			questions.Question8(drugbank);
			questions.Question9(drugbank);
			questions.Question10(drugbank);
			questions.Question12(drugbank);
		}
	}
}