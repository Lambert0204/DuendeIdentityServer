using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddIdentityServer(option => 
{
    option.Events.RaiseErrorEvents = true;
    option.Events.RaiseInformationEvents = true;
    option.Events.RaiseFailureEvents = true;
    option.Events.RaiseSuccessEvents = true;

    //option.EmitStaticAudienceClaim = true;
})
.AddTestUsers(TestUsers.Users)
.AddInMemoryClients(Config.Clients)
.AddInMemoryApiResources(Config.ApiResources)
.AddInMemoryApiScopes(Config.ApiScopes)
.AddInMemoryIdentityResources(Config.IdentityResources);

var app = builder.Build();

app.UseIdentityServer();
// app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();

app.Run();
