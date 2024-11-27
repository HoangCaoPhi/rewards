var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);

var mssql = builder.AddSqlServer("sql", password: sqlPassword)
                   .WithLifetime(ContainerLifetime.Persistent);

var orchestrationDb = mssql.AddDatabase("orchestration-db");
var followtwitterverifierDb = mssql.AddDatabase("followtwitterverifier-db");


var launchProfileName = ShouldUseHttpForEndpoints() ? "http" : "https";

builder.AddProject<Projects.Orchestration>("orchestration", launchProfileName: launchProfileName)
       .WaitFor(mssql)
       .WithReference(orchestrationDb);

builder.AddProject<Projects.FollowTwitterVerifier>("followtwitterverifier", launchProfileName: launchProfileName)
       .WaitFor(mssql)
       .WithReference(followtwitterverifierDb);

builder.AddNpmApp(name: "rewards-ui",
                  workingDirectory: "../UIs/rewards-ui",
                  scriptName: "dev")
            .WithHttpEndpoint(env: "FE_PORT")
            .WithExternalHttpEndpoints()
            .PublishAsDockerFile();

builder.Build().Run();

// Serves for testing environment
static bool ShouldUseHttpForEndpoints()
{
    const string EnvVarName = "REWARDS_USE_HTTP_ENDPOINTS";
    var envValue = Environment.GetEnvironmentVariable(EnvVarName);
     
    return int.TryParse(envValue, out int result) && result == 1;
}