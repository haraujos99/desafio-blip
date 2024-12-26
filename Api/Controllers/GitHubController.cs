using GithubMiddlewareAPI.Config;
using GithubMiddlewareAPI.Model;
using GithubMiddlewareAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

namespace GithubMiddlewareAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly ILogger<GitHubController> _logger;
        private readonly IOptions<AppSettings> _config;

        public GitHubController(ILogger<GitHubController> logger, IOptions<AppSettings> configuration)
        {
            _config = configuration;
            _logger = logger;
        }


        [HttpGet("LastFiveCSharpRepo")]
        /// <summary>
        /// Retrieves the last five C# repositories from the specified GitHub organization.
        /// </summary>
        /// <returns>
        /// - An <see cref="ActionResult"/> containing a list of up to the last five repositories written in C# (HTTP 200).
        /// - A status code 204 (No Content) if no repositories or C# repositories are found.
        /// - A status code 500 (Internal Server Error) if an exception occurs.
        /// </returns>
        public async Task<ActionResult<IEnumerable<RepositoryDescription>>> GetLastFiveCSharpRepo()
        {
            try
            {
                Log.Information("Creating GitHub API Client");
                GitHubApiClient client = new(_config.Value.Token);
                Log.Information("Successfully created");

                Log.Information($"Getting all repositories by creation date ASC from organization:{_config.Value.Organization}");
                List<RepositoryDescription> repositories = await client.GetRepositoriesAsync(_config.Value.Organization, "?sort=created&direction=asc");
                
                Log.Information("Filtering repositories with language C#");
                List<RepositoryDescription> cSharpRepositories = repositories.Where(r => r.language?.Equals("C#", StringComparison.OrdinalIgnoreCase) ?? false).ToList();

                if(repositories.Count == 0 || cSharpRepositories.Count == 0) return StatusCode(204);

                Log.Information("Returning the oldest 5 repositories");
                return cSharpRepositories.Take(5).ToList() ?? new List<RepositoryDescription>();
            } catch (Exception ex) {
                Log.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
