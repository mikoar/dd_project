using System.Collections.Generic;
using System.Linq;

namespace drugbank
{
	public class DrugPrice : ICsvRow
	{
		public DrugPrice(drugtype drug, pricetype price)
		{
			DrugId = drug.drugbankid.First(id => id.primary).Value;
			Price = price.cost.Value;
			PriceUnit = price.unit;
			PriceDescription = price.description;
			Halflife = drug.halflife;
			Toxicity = drug.toxicity;
			RouteOfElimination = drug.routeofelimination;

		}
		public string DrugId { get; set; }
		public string Price { get; set; }
		public string PriceUnit { get; set; }
		public string PriceDescription { get; set; }
		public string Halflife { get; set; }
		public string Toxicity { get; set; }
		public string RouteOfElimination { get; set; }

		public string[] Header => new string[] { nameof(DrugId), nameof(Price), nameof(PriceUnit), nameof(PriceDescription), nameof(Halflife), nameof(Toxicity), nameof(RouteOfElimination) };

		public string[] Row => new string[] { DrugId, Price, PriceUnit, PriceDescription, Halflife, Toxicity, RouteOfElimination };

	}
}