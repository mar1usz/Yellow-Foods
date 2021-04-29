using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace YellowFoods.Api.Extensions
{
    public static class LinkGeneratorExtensions
    {
        public static string GetUriByNameofAction(
            this LinkGenerator generator,
            HttpContext httpContext,
            string action,
            string controller,
            object values = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            return generator.GetUriByAction(
                httpContext,
                action,
                controller.RemoveSuffix("Controller"),
                values);
        }
    }
}
