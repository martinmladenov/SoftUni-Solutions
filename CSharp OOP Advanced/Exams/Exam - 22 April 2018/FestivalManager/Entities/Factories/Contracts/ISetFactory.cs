namespace FestivalManager.Entities.Factories.Contracts
{
    using Entities.Contracts;

	public interface ISetFactory
	{
		ISet CreateSet(string name, string type);
	}
}
