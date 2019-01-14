using System;
using System.Linq;

namespace drugbank
{
	public class TargetModifications : ICsvRow
	{
		public TargetModifications(string targetId, string uniprotId, goclassifiertype[] goClassifiers)
		{
			TargetId = targetId;
			UniprotId = uniprotId;
			Subtype = AssignSubtype(goClassifiers);
		}

		public TargetModifications(TargetModifications targetModifications, Modifications modifications)
		{
			TargetId = targetModifications.TargetId;
			UniprotId = targetModifications.UniprotId;
			Subtype = targetModifications.Subtype;
			Modifications = modifications;
		}

		public string TargetId { get; set; }
		public string UniprotId { get; set; }
		public Modifications Modifications { get; set; }
		public Subtype Subtype { get; set; }

		public string[] Header => new string[]
		{
			nameof(TargetId), nameof(UniprotId), nameof(Modifications.N_glycosilation),
			nameof(Modifications.O_glycosilation), nameof(Modifications.Phosphorylation), nameof(Modifications.S_glycosilation),
			nameof(Modifications.Sulfation), nameof(Modifications.Ubiquitition), nameof(Subtype)
		};

		public string[] Row => new string[]
		{
			TargetId,
			UniprotId,
			Modifications?.N_glycosilation,
			Modifications?.O_glycosilation,
			Modifications?.Phosphorylation,
			Modifications?.S_glycosilation,
			Modifications?.Sulfation,
			Modifications?.Ubiquitition,
			Subtype.ToString()
		};

		private Subtype AssignSubtype(goclassifiertype[] goClassifiers)
		{
			var descriptions = goClassifiers.Select(g => g.description).JoinWithPipes();
			if (descriptions.Contains("receptor", StringComparison.OrdinalIgnoreCase))
			{
				return Subtype.TransmembraneReceptors;
			}
			if (descriptions.Contains("ion channel", StringComparison.OrdinalIgnoreCase))
			{
				return Subtype.IonChannels;
			}
			if (descriptions.Contains("kinase", StringComparison.OrdinalIgnoreCase))
			{
				return Subtype.Kinases;
			}
			return Subtype.Other;
		}
	}

	public enum Subtype
	{
		TransmembraneReceptors,
		IonChannels,
		Kinases,
		Metaloenzymes,
		Other
	}
}