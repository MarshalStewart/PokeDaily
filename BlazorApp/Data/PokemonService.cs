namespace BlazorApp.Data;

using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class PokemonService
{
    private Dictionary<string, Pokemon>? pokemonDict;
    private bool init = false;
    // private List<Pokemon>? pokemonList;

    private void initDict() {
        string filename = @"database/data/pokemon.yaml";
        var yml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
            .Build();

        //yml contains a string containing your YAML
        var tmpDict = deserializer.Deserialize<Dictionary<string, Pokemon>>(yml);
        pokemonDict = new Dictionary<string, Pokemon>(tmpDict, StringComparer.OrdinalIgnoreCase);

        init = true;

    }

    public Task<Pokemon?> CheckIfPokemonValid(string userInput)
    {
        if (!init) {
            initDict(); // populates pokemonDict
        }

        if (pokemonDict is null) {
            return Task.FromResult<Pokemon?>(null);
        }

        userInput = userInput.ToLower();

        if (pokemonDict.TryGetValue(userInput, out Pokemon? pokemon)) {
            return Task.FromResult<Pokemon?>(pokemon);
        }
        else
        {
            // Return null if the key is not found
            return Task.FromResult<Pokemon?>(null);
        }

    }
   
    // Ran on page init
    public Task<Pokemon[]?> GetAllPokemon()
    {
        if (!init) {
            initDict(); // populates pokemonDict
        }

        if (pokemonDict is null) {
            return Task.FromResult<Pokemon[]?>(null);
        }

        return Task.FromResult<Pokemon[]?>(pokemonDict.Values.ToArray());
    }

    public Task<Pokemon> GetDailyRandomPokemon()
    {
        if (!init) {
            initDict(); // populates pokemonDict
        }

        // TODO: add ability to specify which generations

        // Get today's date
        DateTime today = DateTime.Now;

        // Use the date to create a seed value
        int seed = today.Year * 10000 + today.Month * 100 + today.Day;

        // Create a Random object with the seed value
        Random random = new Random(seed);

        // Get a random integer
        int randIndex = random.Next(1, pokemonDict.Count);

        return Task.FromResult(pokemonDict.Values.ToArray()[randIndex]);
    }

    public Task<Pokemon> GetRandomPokemon()
    {
        if (!init) {
            initDict(); // populates pokemonDict
        }

        // Create a Random object with the seed value
        Random random = new Random();

        // Get a random integer
        int randIndex = random.Next(1, pokemonDict.Count);

        return Task.FromResult(pokemonDict.Values.ToArray()[randIndex]);
    }

}
