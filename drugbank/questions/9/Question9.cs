using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question9(drugbanktype drugbank)
		{
			var path = InitQuestion(9);

			var drugTargetPositions = drugbank.drug
				.SelectMany(d => d.targets
					.Where(t => t.polypeptide != null)
					.SelectMany(t => t.polypeptide
						.Select(p => new DrugTargetPosition(d, t.id, p.cellularlocation))));

			drugTargetPositions.ToFile(path, "drug_target_positions.tsv");
		}
	}
}