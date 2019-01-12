using System.Collections.Generic;
using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question6(drugbanktype drugbank)
		{
			var path = InitQuestion(6);

			var targets = drugbank.drug
				.SelectMany(d => d.targets
					.Select(t => new DrugTarget(d.drugbankid.First(id => id.primary).Value, t.id)))
				.GroupBy(dt => dt.TargetId)
				.Select(group => new { targetId = group.Key, drugs = group.Select(g => g.DrugId) });

			var drugDrugLinks = new HashSet<DrugDrugLink>();
			DrugDrugLink link;

			foreach (var target in targets)
			{
				foreach (var drug1 in target.drugs)
				{
					foreach (var drug2 in target.drugs)
					{
						if (drug1 != drug2)
						{
							link = new DrugDrugLink(drug1, drug2);
							drugDrugLinks.TryGetValue(link, out DrugDrugLink existingLink);
							link = existingLink ?? link;
							link.LinkValue += 1;
							drugDrugLinks.Add(link);
						}
					}
				}
			}

			foreach (var drugDrugLink in drugDrugLinks)
			{
				drugDrugLink.LinkValue /= 2;
			}

			drugDrugLinks.ToFile(path, "drug_drug_link.tsv");

			drugbank.drug
				.SelectMany(d => d.druginteractions
					.Select(i => new DrugInterraction(d.drugbankid.First(id => id.primary).Value, i)))
				.ToFile(path, "drug_interactions.tsv");
		}
	}
}