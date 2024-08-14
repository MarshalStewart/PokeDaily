namespace BlazorApp.Data;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class PokemonService
{
    public Task<Pokemon[]> GetPokemonAsync()
    {

       TextReader textReader = '';

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
            .Build();

        //yml contains a string containing your YAML
        var p = deserializer.Deserialize<Pokemon>(yml);
        var h = p.Addresses["home"];
        System.Console.WriteLine($"{p.Name} is {p.Age} years old and lives at {h.Street} in {h.City}, {h.State}.");
        // Output:
        // George Washington is 89 years old and lives at 400 Mockingbird Lane in Louaryland, Hawidaho.


    }
}
