using System.Collections.Generic;

namespace drugbank
{
	public partial class Questions
	{
		public void Question7(drugbanktype drugbank)
		{
			var path = InitQuestion(7);

			var targetTargetLinks = new HashSet<TargetTargetLink>();
			TargetTargetLink link;

			foreach (var drug in drugbank.drug)
			{
				foreach (var target1 in drug.targets)
				{
					foreach (var target2 in drug.targets)
					{
						if (target1 != target2)
						{
							link = new TargetTargetLink(target1.id, target2.id);
							targetTargetLinks.TryGetValue(link, out TargetTargetLink existingLink);
							link = existingLink ?? link;
							link.LinkValue += 1;
							targetTargetLinks.Add(link);
						}
					}
				}
			}

			foreach (var targetTargetLink in targetTargetLinks)
			{
				targetTargetLink.LinkValue /= 2;
			}

			targetTargetLinks.ToFile(path, "target_target_link.tsv");
		}
	}
}