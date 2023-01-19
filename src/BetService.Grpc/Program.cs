using BetService.DataAccess;
using BetService.Grpc.Infastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.Configure<BetDbConfig>(
    builder.Configuration.GetSection("BetDbConfig"));

builder.Services
    .AddProviders()
    .AddMongoDbContext()
    .AddInfrastructureServices()
    .AddGrpc();

var app = builder.Build();

app.MapGrpcService<BetService.Grpc.Services.BetService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
