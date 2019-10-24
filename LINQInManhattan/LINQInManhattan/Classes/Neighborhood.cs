using System;
using System.Collections.Generic;

namespace LINQInManhattan.Classes
{
    public class Neighborhood
    {
        public string type { get; set; }
        public IList<Feature> features { get; set; }
    }
}
