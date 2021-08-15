using SQLite;

namespace RickAndMorthy.Data.Model
{
    public class Favorite
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
