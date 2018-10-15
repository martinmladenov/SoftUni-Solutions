namespace SIS.Framework.Views
{
    using System.Collections.Generic;
    using System.IO;
    using ActionResults;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            return File.ReadAllText(this.fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var html = this.ReadFile();
            string rendered = this.RenderHtml(html);

            return rendered;
        }

        private string RenderHtml(string html)
        {
            foreach (var p in this.viewData)
            {
                html = html.Replace("{{{" + p.Key + "}}}", p.Value.ToString());
            }

            return html;
        }
    }
}