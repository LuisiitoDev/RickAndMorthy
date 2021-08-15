using System.Collections.Generic;

namespace RickAndMorthy.Model
{
    public class Episode
    {
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public IEnumerable<string> characters { get; set; }
    }
}
