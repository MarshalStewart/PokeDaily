using System.Runtime.InteropServices;

namespace BlazorApp.Data;
using YamlDotNet.Serialization;

public class PokemonStats
{
    [YamlMember(Alias = "hp")]
    public int? Hp { get; set; }

    [YamlMember(Alias = "attack")]
    public int? Attack { get; set; }

    [YamlMember(Alias = "defense")]
    public int? Defense { get; set; }

    [YamlMember(Alias = "spatk")]
    public int? SpAtk { get; set; }

    [YamlMember(Alias = "spdef")]
    public int? SpDef { get; set; }

    [YamlMember(Alias = "speed")]
    public int? Speed { get; set; }
}

public class PokemonForms
{
    [YamlMember(Alias = "pokemonid")]
    public string? PokemonId { get; set; }

    [YamlMember(Alias = "formid")]
    public string? FormId { get; set; }

    [YamlMember(Alias = "formname")]
    public string? FormName { get; set; }

    [YamlMember(Alias = "gen")]
    public int? Gen { get; set; }

    [YamlMember(Alias = "release")]
    public string? Release { get; set; }

    [YamlMember(Alias = "type1")]
    public string? Type1 { get; set; }

    [YamlMember(Alias = "type2")]
    public string? Type2 { get; set; }

    [YamlMember(Alias = "stats")]
    public PokemonStats? Stats { get; set; }

    [YamlMember(Alias = "species")]
    public string? Species { get; set; }

    [YamlMember(Alias = "height")]
    public string? Height { get; set; }

    [YamlMember(Alias = "weight")]
    public string? Weight { get; set; }

    [YamlMember(Alias = "gender")]
    public string? Gender { get; set; }

    [YamlMember(Alias = "catchrate")]
    public int? CatchRate { get; set; }

    [YamlMember(Alias = "baseexp")]
    public int? BaseExp { get; set; }

    [YamlMember(Alias = "eggcycles")]
    public int? EggCycles { get; set; }

    [YamlMember(Alias = "friendship")]
    public int? FriendShip { get; set; }

    [YamlMember(Alias = "growthrate")]
    public string? GrowthRate { get; set; }

    [YamlMember(Alias = "evyield")]
    public PokemonStats? EvYield { get; set; }
}

