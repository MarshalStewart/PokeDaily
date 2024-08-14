namespace BlazorApp.Data;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class PokemonService
{
    public Task<Pokemon[]> GetAllPokemon()
    {

        string filename = @"database/data/pokemon.yaml";
        var yml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
            .Build();

        //yml contains a string containing your YAML
        var pokemonDict = deserializer.Deserialize<Dictionary<string, Pokemon>>(yml);

        // Console.WriteLine(p);

        // Convert dictionary to a list for indexed access
        var pokemonList = pokemonDict.ToList();

        return Task.FromResult(pokemonDict.Values.ToArray());
    }

    public Task<Pokemon> GetRandomPokemon()
    {

        // Migrate to a new service for pokemon form class, change the random number to be calculated based on the current date so it doesn't change. Add a class to handle the current gueses? don't need something to handle refresh so if you refresh you lose all progress. a nice to have would be the predictive search, but don't need that. in js handle the number of guesses someone has inputed, and handle the comparison to the stats, so we would need to add a service for the query from the users guess to return the form for that pokemon. For this one I would like the option to checkbox what settings are available on the daily wordle, the one on squidle doesn't have good options for configuring that. 

        string filename = @"database/data/pokemon.yaml";
        var yml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
            .Build();

        //yml contains a string containing your YAML
        var pokemonDict = deserializer.Deserialize<Dictionary<string, Pokemon>>(yml);

        // Console.WriteLine(p);

        // Convert dictionary to a list for indexed access
        var pokemonList = pokemonDict.ToList();

        Random random = new Random();

        // Get a random integer
        int randIndex = random.Next(1, pokemonDict.Count); // Random integer between 1 and 99

        return Task.FromResult(pokemonDict.Values.ToArray()[randIndex]);
    }

}
