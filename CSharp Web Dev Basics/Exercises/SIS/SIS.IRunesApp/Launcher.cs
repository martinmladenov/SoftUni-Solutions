namespace SIS.IRunesApp
{
    using MvcFramework;

    public static class Launcher
    {
        public static void Main()
        {
           WebHost.Start(new StartUp());
        }
    }
}