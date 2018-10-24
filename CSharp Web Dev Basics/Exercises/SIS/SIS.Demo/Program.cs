namespace SIS.Demo
{
    using Framework;

    public static class Launcher
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}