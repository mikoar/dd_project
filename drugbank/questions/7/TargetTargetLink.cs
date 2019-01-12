namespace drugbank
{
	public class TargetTargetLink : DrugDrugLink, ICsvRow
	{
		public TargetTargetLink(string target1Id, string target2Id) : base(target1Id, target2Id) { }

		public string Target1Id => Drug1Id;
		public string Target2Id => Drug2Id;

		public override string[] Header => new string[] { nameof(Target1Id), nameof(Target2Id), nameof(LinkValue) };
	}
}
