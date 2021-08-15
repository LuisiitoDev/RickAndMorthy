namespace RickAndMorthy.Model
{
    public class Response<TResponse> where TResponse : class
    {
        public Info info { get; set; }
        public TResponse results { get; set; }
    }
}
