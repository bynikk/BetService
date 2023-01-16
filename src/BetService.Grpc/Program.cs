using BetService.BusinessLogic.Models.Competitions;
using BetService.DataAccess;
using BetService.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.Configure<BetDbConfig>(
    builder.Configuration.GetSection("BetDbConfig"));

builder.Services
    .AddMongoDbContext()
    .AddGrpc();

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "It's works!");

app.Run();
