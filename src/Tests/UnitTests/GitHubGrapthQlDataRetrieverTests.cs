using Common;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace UnitTests
{
    public class GitHubGrapthQlDataRetrieverTests
    {
	    private readonly GitHubGrapthQlDataRetriever.GitHubGrapthQlDataRetriever _dataRetriever;

		public GitHubGrapthQlDataRetrieverTests()
	    {
            _dataRetriever = new GitHubGrapthQlDataRetriever.GitHubGrapthQlDataRetriever("panasiux", TokenProvider.Token);
	    }

        [Fact]
        public async System.Threading.Tasks.Task SmokeTestAsync()
        {
	        var res = await _dataRetriever.GetRepositoriesByCity("stockholm");
			Assert.NotNull(res.Value);
		}
    }
}
