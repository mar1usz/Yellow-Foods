using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace YellowFoods.Extensions
{
    public static class LinkGeneratorExtensions
    {
        public static string GetPathByControllerAction(
            this LinkGenerator generator,
            string action,
            string controller,
            object values = null,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = null) =>
                generator.GetPathByAction(
                    action,
                    controller.Replace("Controller", string.Empty),
                    values,
                    pathBase,
                    fragment,
                    options);
    }
}
