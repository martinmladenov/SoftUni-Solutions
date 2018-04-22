namespace FestivalManager.Core.IO
{
    using Contracts;

    public class StringReader : IReader
    {
        private readonly System.IO.StringReader reader;

        public StringReader(string contents)
        {
            this.reader = new System.IO.StringReader(contents);
        }

        public string ReadLine() => this.reader.ReadLine();
    }
}