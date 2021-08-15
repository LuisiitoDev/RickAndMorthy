using System.Collections.Generic;

namespace RickAndMorthy.Model
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public Location origin { get; set; }
        public Location location { get; set; }
        public string image { get; set; }
        public IEnumerable<string> episodes { get; set; }
    }
}
