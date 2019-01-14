using System;
using System.Linq;

namespace drugbank
{
	public class Modifications // : ICsvRow
	{
		public Modifications(string row)
		{
			var parameters = row.Split('\t');

			UniprotId = parameters[0];
			C_glycosilation = parameters[1];
			N_glycosilation = parameters[2];
			O_glycosilation = parameters[3];
			S_glycosilation = parameters[4];
			Phosphorylation = parameters[5];
			Sulfation = parameters[6];
			Ubiquitition = parameters[7];
		}

		public string UniprotId { get; set; }
		public string C_glycosilation { get; set; }
		public string N_glycosilation { get; set; }
		public string O_glycosilation { get; set; }
		public string S_glycosilation { get; set; }
		public string Phosphorylation { get; set; }
		public string Sulfation { get; set; }
		public string Ubiquitition { get; set; }

		// public string[] Header => new string[] { nameof(DrugId), nameof(Created), nameof(TargetsCount) };

		// public string[] Row => new string[] { DrugId, Created.ToString("yyyy-MM-dd"), TargetsCount.ToString() };
	}
}