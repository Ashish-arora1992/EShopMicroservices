using Basket.Api.Basket.Data;
using BuildingBlocks.Behaviours;
using Discount.Grpc;
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
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);

}).UseLightweightSessions();

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!);
});
builder.Services.AddScoped<IBasketRepository,BasketRepository>();
builder.Services.AddMessageBroker(builder.Configuration);
// Add services to the container
var app = builder.Build();

// configure the http request pipeline.

app.MapCarter();
app.Run();
