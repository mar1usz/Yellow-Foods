using System.Collections.Generic;
using YellowFoods.Api.Resources.Abstractions;

namespace YellowFoods.Api.Links.Services.Abstractions
{
    public interface ILinkService<TResource> where TResource : Resource
    {
        void AddLinks(TResource resource);

        void AddLinks(IEnumerable<TResource> resources)
        {
            foreach (var resource in resources)
            {
                AddLinks(resource);
            }
        }
    }
}
