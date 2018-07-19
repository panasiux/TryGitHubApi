# Playing around GitHub GraphQL API
Web service is able to connect to GitHub's GraphQL API and perform queries accouding to its own REST API

## How to run
1. Download and install .net core sdk
2. Configure web service url in hosting.json (default is http://localhost:5000)
3. Run 'dotnet build' in src dir
4. Run web service in console 'dotnet WebService.dll' in 'src\WebService\bin\Debug\netcoreapp2.0' dir

## REST Samples (e.g. for postman):
Consider server url is 'localhost:5000'

1. Recursive search by user and followers. Find user and her followers (which are users as well), and for each follower find followers and so on... depth param specifies depth of recursion (0 means don't get followers). amount param specifies amount of followers on each level
```http
http://localhost:5000/api/git/users/torvalds?depth=2&amount=3
```