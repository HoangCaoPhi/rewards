var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Orchestration>("orchestration");

builder.AddProject<Projects.FollowTwitterVerifier>("followtwitterverifier");

builder.AddNpmApp(name: "rewards-ui",
                  workingDirectory: "../UIs/rewards-ui",
                  scriptName: "dev")
            .WithHttpEndpoint(env: "FE_PORT")
            .WithExternalHttpEndpoints()
            .PublishAsDockerFile();

builder.Build().Run();
