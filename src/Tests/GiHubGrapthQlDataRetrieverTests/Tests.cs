using Common;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace GiHubGrapthQlDataRetrieverTests
{
    public class Tests
    {
	    private readonly GiHubGrapthQlDataRetriever.GiHubGrapthQlDataRetriever _dataRetriever;

		public Tests()
	    {
		    _dataRetriever = new GiHubGrapthQlDataRetriever.GiHubGrapthQlDataRetriever("panasiux", TokenProvider.Token);
	    }

        [Fact]
        public async System.Threading.Tasks.Task SmokeTestAsync()
        {
	        var res = await _dataRetriever.GetRepositoriesByCity("stockholm");
			Assert.NotNull(res.Value);
		}
    }
}
