using System;
using System.Collections.Generic;
using System.Linq;

namespace drugbank
{
	public class DrugTargetGoClassifier : DrugTarget
	{
		public DrugTargetGoClassifier(drugtype drug, targettype target, goclassifiertype targetGoClassifier) : base(drug.drugbankid.First(id => id.primary).Value, target.id)
		{
			MultiTarget = drug.targets.Length > 1;
			TargetClassifierCategory = targetGoClassifier.category;
			TargetClassifierDescription = targetGoClassifier.description;
			CreatonDate = drug.created;
			PatentsApproved = drug.patents.Select(p => DateTime.Parse(p.approved));
		}

		public bool MultiTarget { get; set; }
		public string TargetClassifierCategory { get; set; }
		public string TargetClassifierDescription { get; set; }
		public DateTime CreatonDate { get; set; }
		public IEnumerable<DateTime> PatentsApproved { get; set; }

		public override string[] Header => new string[] { nameof(DrugId), nameof(TargetId), nameof(MultiTarget), nameof(TargetClassifierCategory), nameof(TargetClassifierDescription), nameof(CreatonDate), nameof(PatentsApproved) };

		public override string[] Row =>

			new string[] { DrugId, TargetId, MultiTarget.ToString(), TargetClassifierCategory, TargetClassifierDescription, CreatonDate.ToString("yyyy"), PatentsApproved.OrderBy(p => p).Select(p => p.ToString("yyyy")).JoinWithPipes() };

		public override bool Equals(object obj)
		{
			return obj is DrugTargetGoClassifier d &&
				d.DrugId == DrugId &&
				d.TargetId == TargetId &&
				d.MultiTarget == MultiTarget &&
				d.TargetClassifierCategory == TargetClassifierCategory &&
				d.TargetClassifierDescription == TargetClassifierDescription &&
				d.CreatonDate == CreatonDate;
		}

		public override int GetHashCode()
		{
			return (DrugId +
				TargetId +
				MultiTarget.ToString() +
				TargetClassifierCategory +
				TargetClassifierDescription +
				CreatonDate.ToString()).GetHashCode();
		}
	}
}