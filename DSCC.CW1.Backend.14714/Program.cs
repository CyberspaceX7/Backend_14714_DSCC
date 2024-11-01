using DSCC.CW1.Backend._14714.DBContexts;
using DSCC.CW1.Backend._14714.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GymContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("GymDB")));


builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IMembershipRepository, MembershipPlanRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
