
<p align="center">
  <a href="https://hackathon.walter-group.com">
    <img alt="WALTER GROUP Hackathon: Sustainable Logistics" src="images/header.svg" width="500px" >
  </a>

<h4 align="center">This is the <b>C#</b> agent template repository for the <br><a href="https://hackathon.walter-group.com" target="_blank">WALTER GROUP Hackathon: Sustainable Logistics</a> which you can use to get started quickly.</h4>

  <p align="center">
    <a href="https://www.walter-group.com"><img src="https://img.shields.io/badge/Organiser-WALTER%20GROUP-%2300529e" alt="Organiser WALTER GROUP"></img></a>
    <a href="https://join.slack.com/t/waltergroup-hackathon/shared_invite/zt-1jdcaqm4z-cMDXcMYG6eHlJaTR5YH0zw"><img src="https://img.shields.io/badge/Slack-join%20chat-green" alt="Join Slack chat"></img></a>
  </p>
</p>

**For a detailed explanation of how to make a copy of this repository and get it into the competition build system, please visit [Agent template repositories and competition build system](https://github.com/WALTER-GROUP/hackathon-sustainable-logistics#agent-template-repositories-and-competition-build-system). All questions about the simulation and its rules are answered under [Simulation](https://github.com/WALTER-GROUP/hackathon-sustainable-logistics#simulation).**

## Prerequisites
- **IDE** - We strongly advise you to use an IDE which will help you to edit, compile and run C# code. Our recommendation is [VS Code](https://code.visualstudio.com/download), which you can download for free.
- **.NET 6** - You will need the .NET 6 SDK installed on your machine. You can find it on [Microsoft's website](https://www.microsoft.com/net/download/sdk-list).

## Where should I add the logic of my truck agent?
- Open the project in your favorite IDE and browse to [Src/LogisticsRestApi/Controllers/TruckAgentController.cs](Src/LogisticsRestApi/Controllers/TruckAgentController.cs)
- The method `decide` will always be called by the simulation when the next decision is needed from your truck agent. The argument of this method contains all the information you need to decide for the next move. Just return an instance of [DecideRequest](Src/LogisticsRestApi/Model/DecideRequest.cs) and the simulation will take over again.

## How can I test my truck agent?
- Open the project in your favorite IDE and browse to [Test/Tests/TruckAgentControllerIntegrationTests.cs](Test/Tests/TruckAgentControllerIntegrationTests.cs)
- This is an integration test which will start your agent and will call the `decide` method with the contents of file [Test/Tests/Resources/sample_decide_0.json](Test/Tests/Resources/sample_decide_0.json)
- You can always change the test and debug your script.
- Also checkout the other sample requests provided.

## How can I run the truck agent or its tests without an IDE?
- `dotnet run -p Src/LogisticsRestApi/LogisticsRestApi.csproj ` will start the truck agent, which will then service requests on port 8080.
- `dotnet test` will execute all the tests in the project.

## Can I build a Docker image and run it locally 
- `docker build -t logistic-agent .` will build a local Docker image
- `docker run -p 8080:8080 logistic-agent` will start the truck agent locally in a container and will service requests on port 8080.

## Can I get more information about the model properties?
Sure, check out our [API documentation](https://app.swaggerhub.com/apis-docs/walter-group/walter-group-hackathon-sustainable-logistics/1.0.0) and also thoroughly read our [Simulation documentation](https://github.com/WALTER-GROUP/hackathon-sustainable-logistics#simulation).