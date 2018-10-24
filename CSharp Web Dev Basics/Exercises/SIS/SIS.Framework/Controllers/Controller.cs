namespace SIS.Framework.Controllers
{
    using System.IO;
    using System.Runtime.CompilerServices;
    using ActionResults;
    using HTTP.Requests;
    using Models;
    using Security;
    using Utilities;
    using Views;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
        }

        protected ViewModel Model { get; }

        public Model ModelState { get; } = new Model();

        private ViewEngine ViewEngine { get; } = new ViewEngine();

        public IIdentity Identity
            => (IIdentity) this.Request.Session.GetParameter("auth");

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string actionName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            string viewContent;

            try
            {
                viewContent = this.ViewEngine.GetViewContent(controllerName, actionName);
            }
            catch (FileNotFoundException e)
            {
                this.Model.Data["Error"] = e.Message;

                viewContent = this.ViewEngine.GetErrorContent();
            }

            string renderedContent = this.ViewEngine.RenderHtml(viewContent, this.Model.Data);

            return new ViewResult(new View(renderedContent));
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter("auth", auth);
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }
    }
}