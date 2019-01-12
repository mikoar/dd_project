using System;
using System.Linq;

namespace drugbank
{
	public class DrugTargetsCountCreationDate : ICsvRow
	{
		public DrugTargetsCountCreationDate(drugtype drug)
		{
			DrugId = drug.drugbankid.First(id => id.primary).Value;
			Created = drug.created;
			TargetsCount = drug.targets.Count();
		}

		public string DrugId { get; set; }
		public DateTime Created { get; set; }
		public int TargetsCount { get; set; }

		public string[] Header => new string[] { nameof(DrugId), nameof(Created), nameof(TargetsCount) };

		public string[] Row => new string[] { DrugId, Created.ToString("yyyy-MM-dd"), TargetsCount.ToString() };
	}
}