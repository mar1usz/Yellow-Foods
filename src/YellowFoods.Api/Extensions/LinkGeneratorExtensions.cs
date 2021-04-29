using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace YellowFoods.Api.Extensions
{
    public static class LinkGeneratorExtensions
    {
        public static string GetUriByNameofAction(
            this LinkGenerator generator,
            HttpContext httpContext,
            string action = null,
            string controller = null,
            object values = null,
            string scheme = null,
            HostString? host = null,
            PathString? pathBase = null,
            FragmentString fragment = default,
            LinkOptions options = null)
        {
            string controllerSuffix = "Controller";

            if (controller != null
                && controller.EndsWith(controllerSuffix))
            {
                int index = controller.LastIndexOf(controllerSuffix);
                controller = controller.Remove(index);
            }

            return generator.GetUriByAction(
                httpContext,
                action,
                controller,
                values,
                scheme,
                host,
                pathBase,
                fragment,
                options);
        }
    }
}
