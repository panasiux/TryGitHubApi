# Playing around GitHub GraphQL API
Web service is able to connect to GitHub's GraphQL API and perform queries accouding to its own REST API

## How to run
1. Download and install .net core sdk
2. Configure web service url in hosting.json (default is http://localhost:5000)
3. Run 'dotnet build' in src dir
4. Run web service in console 'dotnet WebService.dll'

## REST Samples (e.g. for postman):
Consider server url is 'localhost:5000'

http://localhost:5000/api/git/users/torvalds?depth=2&amount=3