using Microsoft.AspNetCore.ResponseCompression;
using SchedulingApp.Server;
using SchedulingApp.Server.Hubs;
using SchedulingApp.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});
builder.Services.AddSingleton<ISchedulingService, SchedulingService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseResponseCompression();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapHub<CalendarHub>("/calendarhub");
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
var schedulingService = app.Services.GetRequiredService<ISchedulingService>();
schedulingService.MapCSV("wwwroot\\Data\\input.csv");
app.Run();
