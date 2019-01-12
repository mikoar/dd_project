namespace drugbank
{
	public class DrugTarget : ICsvRow
	{
		public DrugTarget(string drugId, string targetId)
		{
			DrugId = drugId;
			TargetId = targetId;
		}

		public string DrugId { get; set; }
		public string TargetId { get; set; }

		public virtual string[] Header => new string[] { nameof(DrugId), nameof(TargetId) };

		public virtual string[] Row => new string[] { DrugId, TargetId };

	}
}
