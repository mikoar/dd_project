using System;

namespace drugbank
{
	public class DrugDrugLink : ICsvRow
	{
		public DrugDrugLink(string drug1Id, string drug2Id)
		{
			Drug1Id = drug1Id;
			Drug2Id = drug2Id;
			LinkValue = 0;
		}

		public string Drug1Id { get; set; }
		public string Drug2Id { get; set; }
		public int LinkValue { get; set; }

		public virtual string[] Header => new string[] { nameof(Drug1Id), nameof(Drug2Id), nameof(LinkValue) };

		public virtual string[] Row => new string[] { Drug1Id, Drug2Id, LinkValue.ToString() };


		public override bool Equals(object obj)
		{
			return obj is DrugDrugLink d
				&& ((d.Drug1Id == Drug1Id && d.Drug2Id == Drug2Id)
					|| (d.Drug1Id == Drug2Id && d.Drug2Id == Drug1Id));
		}

		public override int GetHashCode()
		{
			var ids = new string[] { Drug1Id, Drug2Id };
			Array.Sort(ids);
			return string.Join("", ids).GetHashCode();
		}
	}
}
