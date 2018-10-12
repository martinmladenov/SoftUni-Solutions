namespace SIS.Framework.Views
{
    using System.IO;
    using ActionResults;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile(string fullyQualifiedTemplateName)
        {
            return File.ReadAllText(fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var html = this.ReadFile(this.fullyQualifiedTemplateName);

            return html;
        }
    }
}