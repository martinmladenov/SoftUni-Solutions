namespace FestivalManager.Core.IO
{
	using System.IO;
	using Contracts;

    public class FileReader : IReader
	{
		private readonly System.IO.StreamReader reader;

		public FileReader(string contents)
		{
			this.reader = new System.IO.StreamReader(new System.IO.FileStream(contents, FileMode.Open, FileAccess.Read & FileAccess.Write));
		}

		public string ReadLine() => this.reader.ReadLine();
	}
}