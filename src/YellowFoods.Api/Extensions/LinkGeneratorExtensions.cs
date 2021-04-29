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
            if (controller != null)
            {
                controller = controller.RemoveSuffix("Controller");
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
