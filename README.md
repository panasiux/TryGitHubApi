# Playing around GitHub GraphQL API
Web service is able to connect to GitHub's GraphQL API and perform queries accouding to its own REST API

## How to run
1. Download and install .net core sdk
2. Configure web service url in hosting.json (default is http://localhost:5000)
3. Run 'dotnet build' in src dir
4. Run web service in console 'dotnet WebService.dll' in 'src\WebService\bin\Debug\netcoreapp2.0' dir
5. To call towards github graphql API token must be provided. It can be created for user on https://github.com/settings/tokens. While generated add this token to system variables with alias GIT_USER_TOKEN (or use API to specify it - see below)

## REST Samples (e.g. for postman):
Consider server url is 'localhost:5000'

1. If no user token has been added to system variable one can add it via API (POST):
```http
http://localhost:5000/api/git/token
```
pass token as a json body

2. Recursive search by user and followers. Find user and her followers (which are users as well), and for each follower find followers and so on... depth param specifies depth of recursion (0 means don't get followers). amount param specifies amount of followers on each level (GET):
```http
http://localhost:5000/api/git/users/torvalds?depth=2&amount=3
```
3. Search repositories by city in description (GET):
```http
http://localhost:5000/api/git/repos/berlin
```
4. Search user repository info (GET):
```http
http://localhost:5000/api/git/repos/info/torvalds
```

## Util
Utility provided to run query without running web service
run from 'src\Tests\Util\bin\Debug\netcoreapp2.0' to perform 'recursive' user search. Parameters: user, depth, amount
```cmd
dotnet Util.dll Location torvalds 5 2
```
