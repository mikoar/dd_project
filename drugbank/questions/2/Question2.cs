using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question2(drugbanktype drugbank)
		{
			var path = InitQuestion(2);
			var drugQuery = drugbank.drug
				.Where(d => d.classification != null);

			drugQuery
				.SelectMany(d => d.targets
					.Select(t => new DrugClassificationAndTargetSubtype(d.classification, d.drugbankid.First(id => id.primary).Value, t.id, "target")))
				.ToFile(path, "drug_classification_targets.tsv");

			drugQuery
				.SelectMany(d => d.transporters
					.Select(t => new DrugClassificationAndTargetSubtype(d.classification, d.drugbankid.First(id => id.primary).Value, t.id, "transporter")))
				.ToFile(path, "drug_classification_transporters.tsv");

			drugQuery
				.SelectMany(d => d.enzymes
					.Select(t => new DrugClassificationAndTargetSubtype(d.classification, d.drugbankid.First(id => id.primary).Value, t.id, "enzyme")))
				.ToFile(path, "drug_classification_enzymes.tsv");

			drugQuery
				.SelectMany(d => d.carriers
					.Select(t => new DrugClassificationAndTargetSubtype(d.classification, d.drugbankid.First(id => id.primary).Value, t.id, "carrier")))
				.ToFile(path, "drug_classification_carriers.tsv");
		}
	}
}