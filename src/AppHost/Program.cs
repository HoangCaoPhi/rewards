var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);
 
var mssql = builder.AddSqlServer("sql", password: sqlPassword)
                   .WithDataVolume();

var mongoDb = builder.AddMongoDB("mongo")
                     .WithDataVolume();

var managementDb = mssql.AddDatabase("ManagementDb");
var twitterVerifierDb = mongoDb.AddDatabase("TwitterVerifierDb");
 
var launchProfileName = ShouldUseHttpForEndpoints() ? "http" : "https";

builder.AddProject<Projects.Management>("management", launchProfileName: launchProfileName)
       .WaitFor(mssql)
       .WithReference(managementDb);

builder.AddProject<Projects.TwitterVerifier>("twitterverifier", launchProfileName: launchProfileName)
       .WaitFor(mongoDb)
       .WithReference(twitterVerifierDb);

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