using DigitalPlane.ConferenceProject.Application;
using DigitalPlane.ConferenceProject.Persistence;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(
    builder.Configuration,
    "DigitalPlaneConferenceProjectConnectionString",
    "DigitalPlane.ConferenceProject.Api");
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Open");
app.UseAuthorization();
app.MapControllers();
app.Run();