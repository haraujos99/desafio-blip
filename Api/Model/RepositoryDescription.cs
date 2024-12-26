namespace GithubMiddlewareAPI.Model
{
    public class RepositoryDescription
    {
        public string name { get; set; }
        public string description { get; set; }
        public string? language { get; set; }
        public string created_at { get; set; }
    }
}
