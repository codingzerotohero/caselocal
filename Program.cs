using BlazorWebAssemblyApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMsalAuthentication(options =>
{
	builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
	options.ProviderOptions.LoginMode = "redirect";
});


builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("alleansatte", policy =>
    {
        policy.RequireAssertion(context => context.User.HasClaim(c =>
        {
            return c.Type == "groups" && c.Value.Contains(builder.Configuration["groups:alleansattegruppeid"]);
        }));
    });

    options.AddPolicy("hr", policy =>
	{
		policy.RequireAssertion(context => context.User.HasClaim(c =>
		{
			return c.Type == "groups" && c.Value.Contains(builder.Configuration["groups:hrgruppeid"]);
		}));
	});
});

await builder.Build().RunAsync();
