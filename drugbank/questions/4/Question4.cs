using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question4(drugbanktype drugbank)
		{
			var path = InitQuestion(4);

			drugbank.drug
				.SelectMany(d => d.targets
					.Select(c => new DrugTargetGroup(d.drugbankid.First(id => id.primary).Value, c.id, d.groups.group)))
				.ToFile(path, "drug_targets_groups.tsv");
		}
	}
}