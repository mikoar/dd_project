namespace drugbank
{
	public interface ICsvRow
	{
		string[] Header { get; }
		string[] Row { get; }
	}
}
