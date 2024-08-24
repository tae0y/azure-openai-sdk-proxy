var builder = DistributedApplication.CreateBuilder(args);

var config = builder.Configuration;
var apiapp = builder.AddProject<Projects.AzureOpenAIProxy_ApiApp>("apiapp")
                    .WithExternalHttpEndpoints();

builder.AddProject<Projects.AzureOpenAIProxy_PlaygroundApp>("playgroundapp")
       .WithExternalHttpEndpoints()
       .WithEnvironment("OpenAI__Endpoint", config["OpenAI:Endpoint"])
       .WithEnvironment("OpenAI__ApiKey", config["OpenAI:ApiKey"])
       .WithEnvironment("OpenAI__DeploymentName", config["OpenAI:DeploymentName"])
       .WithReference(apiapp);

await builder.Build().RunAsync();
