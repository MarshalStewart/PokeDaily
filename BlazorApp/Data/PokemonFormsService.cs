namespace BlazorApp.Data;

using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class PokemonFormsService
{
    private Dictionary<string, PokemonForms>? pokemonFormDict;
    private bool init = false;
    // private List<PokemonForms>? pokemonList;

    private void initDict() {
        string filename = @"database/data/pokemon-forms.yaml";
        var yml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
            .Build();

        //yml contains a string containing your YAML
        var tmpDict = deserializer.Deserialize<Dictionary<string, PokemonForms>>(yml);
        pokemonFormDict = new Dictionary<string, PokemonForms>(tmpDict, StringComparer.OrdinalIgnoreCase);

        init = true;

    }

    public Task<PokemonForms?> GetPokemonForm(string userInput)
    {
        if (!init) {
            initDict(); // populates pokemonFormDict
        }

        if (pokemonFormDict is null) {
            return Task.FromResult<PokemonForms?>(null);
        }

        userInput = userInput.ToLower();

        if (pokemonFormDict.TryGetValue(userInput, out PokemonForms? pokemon)) {
            return Task.FromResult<PokemonForms?>(pokemon);
        }
        else
        {
            // Return null if the key is not found
            return Task.FromResult<PokemonForms?>(null);
        }

    }

    // // Ran on page init
    // public Task<PokemonForms[]?> GetAllPokemon()
    // {
    //     if (!init) {
    //         initDict(); // populates pokemonFormDict
    //     }

    //     if (pokemonFormDict is null) {
    //         return Task.FromResult<PokemonForms[]?>(null);
    //     }

    //     return Task.FromResult<PokemonForms[]?>(pokemonFormDict.Values.ToArray());
    // }
}
