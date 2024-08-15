namespace BlazorApp.Data;

using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class PokemonTypesService
{
    private Dictionary<string, PokemonTypes>? typesDict;
    private bool init = false;
    // private List<PokemonTypes>? pokemonList;

    private void initDict() {
        string filename = @"database/data/types.yaml";
        var yml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
            .Build();

        //yml contains a string containing your YAML
        var tmpDict = deserializer.Deserialize<Dictionary<string, PokemonTypes>>(yml);
        typesDict = new Dictionary<string, PokemonTypes>(tmpDict, StringComparer.OrdinalIgnoreCase);

        init = true;

    }

    // Ran on page init
    public Task<PokemonTypes[]?> GetAllTypes()
    {
        if (!init) {
            initDict(); // populates typesDict
        }

        if (typesDict is null) {
            return Task.FromResult<PokemonTypes[]?>(null);
        }

        return Task.FromResult<PokemonTypes[]?>(typesDict.Values.ToArray());
    }

}
