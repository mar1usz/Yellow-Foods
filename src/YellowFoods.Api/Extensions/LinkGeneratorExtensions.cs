using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace YellowFoods.Api.Extensions
{
    public static class LinkGeneratorExtensions
    {
        public static string GetUriByNameofAction(
            this LinkGenerator generator,
            HttpContext httpContext,
            string action,
            string controller,
            object values)
        {
            string suffix = "Controller";

            if (controller != null
                && controller.EndsWith(suffix))
            {
                int index = controller.LastIndexOf(suffix);
                controller = controller.Remove(index);
            }

            return generator.GetUriByAction(
                httpContext,
                action,
                controller,
                values);
        }
    }
}
