using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp.Data;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<PokemonService>();
builder.Services.AddSingleton<PokemonFormsService>();
builder.Services.AddSingleton<PokemonTypesService>();


        string filename = @"database/data/pokemon-forms.yaml";
        var yml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)  // Ensure correct naming convention
            .Build();

        using (var reader = new StringReader(yml))
        {
            var x =  deserializer.Deserialize<Dictionary<string, PokemonForms>>(reader);
        }

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
