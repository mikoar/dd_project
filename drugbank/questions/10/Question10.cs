using System;
using System.IO;
using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question10(drugbanktype drugbank)
		{
			var path = InitQuestion(10);
			Console.WriteLine("Enter modifications tsv file path...");

			var modsFile = Console.ReadLine();

			var mods = File.ReadAllLines(modsFile).Select(l => new Modifications(l));

			var targetModifications = drugbank.drug
				.SelectMany(d => d.targets
					.Where(t => t.polypeptide != null)
					.SelectMany(t => t.polypeptide
						.Select(p => new TargetModifications(t.id, p.id, p.goclassifiers))));

			targetModifications = targetModifications.Join(mods,
				t => t.UniprotId,
				m => m.UniprotId,
				(t, m) => new TargetModifications(t, m));

			targetModifications
				.ToFile(path, "target_mods.tsv");
		}
	}
}