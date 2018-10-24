namespace SIS.Framework
{
    using System.Reflection;

    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext()
        {
        }

        public static MvcContext Get => instance ?? (instance = new MvcContext());

        public string AssemblyName { get; } = Assembly.GetEntryAssembly().GetName().Name;

        public string ControllersFolder { get; } = "Controllers";

        public string ControllerSuffix { get; } = "Controller";

        public string ViewsFolder { get; } = "Views";
    }
}