using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question8(drugbanktype drugbank)
		{
			var path = InitQuestion(8);

			var drugTargetGoClassifier = drugbank.drug
				.SelectMany(d => d.targets
					.Where(t => t.polypeptide != null)
					.SelectMany(t => t.polypeptide
						.SelectMany(p => p.goclassifiers
							.Select(g => new DrugTargetGoClassifier(d, t, g))
							.Distinct())));

			drugTargetGoClassifier.ToFile(path, "drug_target_go_classifiers_with_dates.tsv");

			drugbank.drug
				.Where(d => d.targets.Length > 1)
				.SelectMany(d => d.targets
					.Select(t => new DrugTarget(d.drugbankid.First(id => id.primary).Value, t.id)))
				.ToFile(path, "multitarget_drug_targets.tsv");

			drugbank.drug
				.Where(d => d.targets.Length == 1)
				.SelectMany(d => d.targets
					.Select(t => new DrugTarget(d.drugbankid.First(id => id.primary).Value, t.id)))
				.ToFile(path, "singletarget_drug_targets.tsv");
		}
	}
}