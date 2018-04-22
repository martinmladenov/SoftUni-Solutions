namespace FestivalManager
{
    using Core;
    using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main()
		{
			IStage stage = new Stage();

			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			var engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}