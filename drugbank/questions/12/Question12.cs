using System.Linq;

namespace drugbank
{
	public partial class Questions
	{
		public void Question12(drugbanktype drugbank)
		{
			var path = InitQuestion(12);

			drugbank.drug
				.Where(d => d.prices != null)
				.SelectMany(d => d.prices
					.Select(p => new DrugPrice(d, p)))
				.ToFile(path, "drug_prices.tsv");
		}
	}
}