using ApexCharts;   // ApexCharts namespace
using BlazorAppIntro.Components;  // Your custom components
using MudBlazor.Services;  // MudBlazor services

var builder = WebApplication.CreateBuilder(args);

// Register Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();  
builder.Services.AddMudServices();  
builder.Services.AddApexCharts(e =>
            {
                e.GlobalOptions = new ApexChartBaseOptions
                {
                    Debug = true,
                    Theme = new Theme { Palette = PaletteType.Palette6 }
                };
            });  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);  // Error handling in production
    app.UseHsts();  
}

app.UseHttpsRedirection();  
app.UseAntiforgery();  
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); 

app.Run();
