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

app.Run();

namespace BetService.Grpc
{
    public partial class Program { }
}
