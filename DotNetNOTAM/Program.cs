using Microsoft.OpenApi.Models;
using NotamStore.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNet NOTAM API", Description = "Check NOTAMS by ICAO", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet NOTAM API V1");
});

app.MapGet("/", () => "Use the /notams endpoint to get NOTAMS by ICAO");

app.MapGet("/notams/{id}", (int id) => NotamDB.GetNotams(id));
app.MapGet("/notams/{icao}", (string icao) => NotamDB.GetNotams(icao));
app.MapGet("/notams", () => NotamDB.GetNotams());
app.MapPost("/notams", (Notam pizza) => NotamDB.CreateNotam(pizza));
app.MapPut("/notams", (Notam pizza) => NotamDB.UpdateNotam(pizza));
app.MapDelete("/notams/{id}", (int id) => NotamDB.RemoveNotam(id));

app.Run();
