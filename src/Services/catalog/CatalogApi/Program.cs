using BuildingBlocks.Behaviours;
using FluentValidation;
using BuildingBlocks.messaging.MassTransit;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));

});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();
builder.Services.AddMessageBroker(builder.Configuration, typeof(Program).Assembly);
// Add services to the container
var app = builder.Build();

// configure the http request pipeline.
app.MapCarter();
app.Run();
