using System.IO;
using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question1(drugbanktype drugbank)
		{
			var path = InitQuestion(1);

			var drugtargets = drugbank.drug
				.SelectMany(d => d.targets
					.Select(t => new DrugTarget(d.drugbankid.First(id => id.primary).Value, t.id)));
			drugtargets.ToFile(path, "drug_targets.tsv");

			var drugTargetsCountQuery = drugbank.drug.Select(d => new { id = d.drugbankid.First(id => id.primary).Value, targetsCount = d.targets.Count() });
			var maxTargets = drugTargetsCountQuery.Max(d => d.targetsCount);
			var minTargets = drugTargetsCountQuery.Min(d => d.targetsCount);

			var drugsWithTargets = drugTargetsCountQuery.Where(d => d.targetsCount == maxTargets);
			File.WriteAllLines(Path.Combine(path, "drugs_with_max_targets_count.tsv"), drugsWithTargets.Select(d => d.id).Prepend($"max targets, {maxTargets}"));

			drugsWithTargets = drugTargetsCountQuery.Where(d => d.targetsCount == minTargets);
			File.WriteAllLines(Path.Combine(path, "drugs_with_min_targets_count.tsv"), drugsWithTargets.Select(d => d.id).Prepend($"min targets, {minTargets}"));

			File.WriteAllText(Path.Combine(path, "mean_targets_count.tsv"), drugTargetsCountQuery.Select(d => d.targetsCount).Average().ToString());
		}
	}
}