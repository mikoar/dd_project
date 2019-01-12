namespace drugbank
{
	public class DrugClassificationAndTargetSubtype : ICsvRow
	{
		public DrugClassificationAndTargetSubtype(classificationtype classification, string drugId, string targetId, string subtype)
		{
			AlternativeParrents = classification.alternativeparent?.JoinWithPipes();
			DirectParent = classification.directparent;
			Kingdom = classification.kingdom;
			Subclass = classification.subclass;
			Superclass = classification.superclass;
			Class = classification.@class;
			DrugId = drugId;
			TargetId = targetId;
			Subtype = subtype;
		}

		public string AlternativeParrents { get; set; }
		public string DirectParent { get; set; }
		public string Kingdom { get; set; }
		public string Superclass { get; set; }
		public string Class { get; set; }
		public string Subclass { get; set; }
		public string DrugId { get; set; }
		public string TargetId { get; set; }
		public string Subtype { get; set; }

		public string[] Header => new string[] { nameof(DrugId), nameof(TargetId), nameof(Superclass), nameof(Class), nameof(Subclass) };

		public string[] Row => new string[] { DrugId, TargetId, Superclass, Class, Subclass };

	}
}
