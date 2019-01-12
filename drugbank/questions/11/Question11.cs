using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question11(drugbanktype drugbank)
		{
			var path = InitQuestion(11);

			drugbank.drug
				.Select(d => new DrugTargetsCountCreationDate(d))
				.ToFile(path, "drug_targets_count_creation_date.tsv");

		}
	}
}