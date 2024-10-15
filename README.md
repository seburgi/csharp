
<p align="center">
  <a href="https://hackathon.walter-group.com">
    <img alt="WALTER GROUP Hackathon: Sustainable Logistics" src="images/header.svg" width="500px" >
  </a>

<h4 align="center">This is the <b>C#</b> agent Replit template for the <br><a href="https://hackathon.walter-group.com" target="_blank">WALTER GROUP Hackathon: Sustainable Logistics</a> which you can use to get started quickly. Click on the green `Fork` button!</h4>

  <p align="center">
    <a href="https://www.walter-group.com"><img src="https://raster.shields.io/badge/Organiser-WALTER%20GROUP-%2300529e.png" alt="Organiser WALTER GROUP"></img></a>
    <a href="https://join.slack.com/t/wg-hackathon-2024/shared_invite/zt-2ri6ti5h2-tmw7XY4CU7pdlx3jar6d0g"><img src="https://raster.shields.io/badge/Slack-join%20chat-green.png" alt="Join Slack chat"></img></a>
  </p>
</p>

**All questions about the simulation and its rules are answered under [Simulation](https://github.com/WALTER-GROUP/hackathon-sustainable-logistics#simulation).**

## Prerequisites
- **Replit account** - Create a new Replit account [here](https://replit.com/signup).

## Where should I add the logic of my truck agent?
- Open the file [Logistics.Hackathon/Program.cs](Logistics.Hackathon/Program.cs)
- The line `app.MapPost("/decide", async (DecideRequest request) =>` will always be called by the simulation when the next decision is needed from your truck agent. The argument of this method contains all the information you need to decide for the next move. Just return an instance of [DecideRequest](Logistics.Hackathon/Model/DecideRequest.cs) and the simulation will take over again. You can use [HackathonMap](Logistics.Hackathon/HackathonMap.cs) to get the full map with all the information of the [locations](Logistics.Hackathon/Model/Location.cs) on the map.

## How can I run my truck agent?
- Just click on the green `> Run` button at the top of the Replit website.

## What about tests?
- Open the file [Logistics.Hackathon.Tests/Tests.cs](Logistics.Hackathon.Tests/Tests.cs)
- This is an integration test which will start your agent and will call the `decide` method with the contents of file [Test/Tests/Resources/sample_decide_0.json](Test/Tests/Resources/sample_decide_0.json)
- You can always change the test and debug your script.
- Also checkout the other sample requests provided.
- To run the tests go to the left side panel in Replit, look for the "Shell" entry and click on it. A new shell tab will open and there execute the following command: `dotnet test`

## Can I get more information about the model properties?
Sure, check out our [API documentation](https://app.swaggerhub.com/apis-docs/walter-group/walter-group-hackathon-sustainable-logistics/1.0.0) and also thoroughly read our [Simulation documentation](https://github.com/WALTER-GROUP/hackathon-sustainable-logistics#simulation).