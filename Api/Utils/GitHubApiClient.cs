using GithubMiddlewareAPI.Model;
using Serilog;

namespace GithubMiddlewareAPI.Utils
{
    public class GitHubApiClient
    {
        private readonly HttpClient _httpClient;

        public GitHubApiClient(string token)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubApiClient");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<RepositoryDescription>> GetRepositoriesAsync(string organization, string queryParams = null)
        {
            try
            {
                string uri = $"orgs/{organization}/repos";
                if (!String.IsNullOrEmpty(queryParams)) uri += "?" + queryParams;

                Log.Information($"URL: https://api.github.com/{uri}");
                var repos = await _httpClient.GetFromJsonAsync<List<RepositoryDescription>>(uri);
                if (repos == null) return new List<RepositoryDescription>();

                return repos.ToList();

            } catch (Exception ex) { 
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
