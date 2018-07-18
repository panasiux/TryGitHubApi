using AutoMapper;
using CommandDotNet;
using GiHubGrapthQlDataRetriever;
using GitHubGrapthQlDataRetriever;

namespace Util
{
    class Program
    {
		static void Main(string[] args)
		{
		    InitAutoMapper();
            var appRunner = new AppRunner<Commands.Commands>();
            appRunner.Run(args);
        }

        private static void InitAutoMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperRepoProfile>();
            });
        }
    }
}
