namespace SIS.Framework.Views
{
    using System.Collections.Generic;
    using System.IO;
    using ActionResults;

    public class View : IRenderable
    {
        private readonly string fullHtmlContent;

        public View(string fullHtmlContent)
        {
            this.fullHtmlContent = fullHtmlContent;
        }

        public string Render() => this.fullHtmlContent;
    }
}