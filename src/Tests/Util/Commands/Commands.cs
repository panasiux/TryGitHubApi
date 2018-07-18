using System;
using System.Threading.Tasks;
using Common;
using Declarations.DomainModel;
using Declarations.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Util.Commands
{
	public class Commands
	{
	    private readonly GiHubGrapthQlDataRetriever.GiHubGrapthQlDataRetriever _dataRetriever;

        public Commands()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            _dataRetriever = new GiHubGrapthQlDataRetriever.GiHubGrapthQlDataRetriever(configuration["user"], TokenProvider.Token);
        }

        public async Task Location(string user, int depth, int amount)
        {
            try
            {
                var data = await _dataRetriever.GetUserGraphByLogin(user, depth, amount);
                if (!string.IsNullOrEmpty(data.Error))
                {
                    Console.WriteLine($"Error occured: {data.Error}");
                    return;
                }

                PrintUser(data.Value, 0);
            }
            catch (NoTokenException e)
            {
                Console.WriteLine("No token found. Please add it to environment variables or by using this util");
            }
        }

	    private static void PrintUser(GitUser u, int offset)
	    {
	        var tab = new string(' ', offset*2);

            Console.WriteLine($"{tab}{u.Login} ({u.Name}) {u.Location}");
            u.Followers.ForEach(f => PrintUser(f, offset+1));
	    }
    }
}

