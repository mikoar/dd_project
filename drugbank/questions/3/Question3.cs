using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question3(drugbanktype drugbank)
		{
			var path = InitQuestion(3);

			drugbank.drug
				.SelectMany(d => d.carriers
					.Select(c => new DrugTarget(d.drugbankid.First(id => id.primary).Value, c.id)))
				.ToFile(path, "drug_carriers.tsv");

			drugbank.drug
				.SelectMany(d => d.transporters
					.Select(t => new DrugTarget(d.drugbankid.First(id => id.primary).Value, t.id)))
				.ToFile(path, "drug_transporters.tsv");

			drugbank.drug
				.SelectMany(d => d.enzymes
					.Select(e => new DrugTarget(d.drugbankid.First(id => id.primary).Value, e.id)))
				.ToFile(path, "drug_enzymes.tsv");
		}
	}
}