using SecureCientDataManagementFrontend.Components;
using SecureCientDataManagementFrontend.Interfaces;
using SecureCientDataManagementFrontend.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddHttpClient();
// Configure the HTTP request pipeline.
builder.Services.AddScoped<IClientApiService, ClientApiService>();
builder.WebHost.UseUrls("http://0.0.0.0:80");
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
