namespace drugbank
{
	public class DrugInterraction : ICsvRow
	{
		public DrugInterraction(string drugId, druginteractiontype interraction)
		{
			Drug1Id = drugId;
			Interraction = interraction;
		}

		public string Drug1Id { get; set; }
		public druginteractiontype Interraction { get; set; }
		public string Drug2Id { get => Interraction.drugbankid.Value; }
		public string Name { get => Interraction.name; }
		public string Description { get => Interraction.description; }

		public virtual string[] Header => new string[] { nameof(Drug1Id), nameof(Drug2Id), nameof(Name), nameof(Description) };

		public virtual string[] Row => new string[] { Drug1Id, Drug2Id, Name, Description };
	}
}

