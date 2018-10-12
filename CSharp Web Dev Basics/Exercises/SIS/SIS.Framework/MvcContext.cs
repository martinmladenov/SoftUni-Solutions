namespace SIS.Framework
{
    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext() { }

        public static MvcContext Get => instance ?? (instance = new MvcContext());
        
        public string AssemblyName { get; set; }
        
        public string ControllersFolder { get; set; }

        public string ControllerSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}