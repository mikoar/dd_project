using System.Linq;

namespace drugbank
{
	public class DrugTargetGroup : DrugTarget
	{
		public DrugTargetGroup(string drugId, string targetId, grouptype[] groupTypes) : base(drugId, targetId)
		{
			GroupTypes = groupTypes;
		}

		public grouptype[] GroupTypes { get; set; }

		public override string[] Header => new string[] { nameof(DrugId), nameof(TargetId), nameof(GroupTypes) };

		public override string[] Row => new string[] { DrugId, TargetId, GroupTypes.Select(g => g.ToString()).JoinWithPipes() };
	}
}
