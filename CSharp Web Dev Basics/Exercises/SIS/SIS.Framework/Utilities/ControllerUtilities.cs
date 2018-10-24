namespace SIS.Framework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller) =>
            controller.GetType().Name.Replace(MvcContext.Get.ControllerSuffix, string.Empty);
    }
}