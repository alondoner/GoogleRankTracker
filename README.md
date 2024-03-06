# GoogleRankTracker

##  Description
This solution is a .NET Core Web API & SPA pair. It was developed using Visual Studio 2022. This solution is running on .NET 8 and Node.js.

The SPA was implemented using the latest version 18.2.0 of React with Vite 5.1.4 offering 3 capabilities: Making google search, getting search history and viewing trends. Navigation between the different features was created using the latest version 6.22.2 of React Router.

The backend API was developed with C# 12 and uses an Entity Framework Core In-memory database to store data.

##  How to Install and Run
First of all, make sure .NET 8 and Node.js are installed on your machine.

You can open and run the solution directly using Visual Studio or follow the steps below:

### SPA
1- Start Visual Studio or Visual Code environment

2- Launch VS Developer PowerShell

3- Using cd command go to "googleranktracker.client" folder

4- Execute "npm install" command

5- Execute "npm run dev" command

### Web API
1- Start Visual Studio or Visual Code environment

2- Launch VS Developer PowerShell

3- Using cd command, go to "GoogleRankTracker.Server" folder

4- Execute "dotnet run" command

##  How to Use
The SPA  is published on https://localhost:5173.

To test the Web API, Swagger UI is available on https://localhost:7013/swagger/index.html.
