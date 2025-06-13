using NutritionalAdvice.Domain;
using NutritionalAdvice.Application;
using NutritionalAdvice.Infrastructure;

using Joseco.Outbox.EFCore;
using Microsoft.Extensions.Hosting;
using NutritionalAdvice.Domain.Abstractions;
using Microsoft.Extensions.Configuration;

var builder = Host.CreateApplicationBuilder(args);

string serviceName = "nutritionaladvice.worker-service";


builder.Services.AddInfrastructure(builder.Configuration, builder.Environment, serviceName);
builder.Services.AddOutboxBackgroundService<DomainEvent>();

var host = builder.Build();
host.Run();