using System.Collections.Generic;
using System.Linq;

namespace drugbank
{
	public class DrugTargetPosition : DrugTarget
	{
		public DrugTargetPosition(drugtype drug, string targetId, string position) : base(drug.drugbankid.First(id => id.primary).Value, targetId)
		{
			Position = ClassifyPosition(position);
			PatentsApproved = drug.patents.Select(p => p.approved);
		}

		public Positions Position { get; set; }
		public IEnumerable<string> PatentsApproved { get; set; }

		public override string[] Header => new string[] { nameof(DrugId), nameof(TargetId), nameof(Position), nameof(PatentsApproved) };

		public override string[] Row => new string[] { DrugId, TargetId, Position.ToString(), PatentsApproved.OrderBy(p => p).JoinWithPipes() };

		private Positions ClassifyPosition(string position)
		{
			if (position.ToLower().Contains("membrane"))
			{
				return Positions.PlasmaMembrane;
			}
			else if (position.ToLower().Contains("cytoplasm"))
			{
				return Positions.Cytosol;
			}
			else if (position.ToLower().Contains("mitochondrion"))
			{
				return Positions.Mitochondrion;
			}
			else if (position.ToLower().Contains("nucleus"))
			{
				return Positions.Nucleus;
			}
			else if (position.ToLower().Contains("surface")
				|| position.ToLower().Contains("cell outer membrane")
				|| position.ToLower().Contains("junction")
				|| position.ToLower().Contains("fimbrium"))
			{
				return Positions.ExtracelluralSpace;
			}


			return Positions.Other;
		}
	}

	public enum Positions
	{
		PlasmaMembrane,
		Cytosol,
		ExtracelluralSpace,
		Mitochondrion,
		Nucleus,
		Other
	}
}
