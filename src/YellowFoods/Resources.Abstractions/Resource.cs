﻿using System.Collections.Generic;
using YellowFoods.Links;

namespace YellowFoods.Resources.Abstractions
{
    public abstract class Resource
    {
        public IList<Link> Links { get; set; } = new List<Link> { };

        public void AddLink(Link link) => Links.Add(link);
        
        public void AddLinks(IEnumerable<Link> links)
        {
            foreach (var link in links)
            {
                AddLink(link);
            }
        }
    }
}
