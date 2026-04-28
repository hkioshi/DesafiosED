// See https://aka.ms/new-console-template for more information
using System.Runtime.Intrinsics.X86;
namespace Desafio1;
public class Pokemon
{
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }

    //Um construtor
    public Pokemon(string nome, string tipo, int vida, int ataque, int defesa)
    {
        Nome = nome;
        Tipo = tipo;
        Vida = vida;
        Ataque = ataque;
        Defesa = defesa;
    }
    public void ExibirStatus()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Vida: {Vida}");
        Console.WriteLine($"Ataque: {Ataque}");
        Console.WriteLine($"Defesa: {Defesa}");
    }
    public virtual void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;
        if (dano < 0)
            dano = 0;
        alvo.Vida -= dano;
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {dano} de dano!");
    }
}

public class PokemonFogo : Pokemon
{
    public PokemonFogo(string nome, string tipo, int vida, int ataque, int defesa) : base(nome, tipo, vida, ataque, defesa) { }
    public override void Atacar(Pokemon alvo)
    {
        if (alvo.Tipo == "Grama")
        {
            Console.WriteLine($"{Nome} é super efetivo contra {alvo.Nome}!");
            Ataque += 5;
        }

        int dano = Ataque + 2 - alvo.Defesa;
        if (dano < 0)
            dano = 0;
        alvo.Vida -= dano;
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {dano} de dano!");
    }
}
public class PokemonAgua : Pokemon
{
    public PokemonAgua(string nome, string tipo, int vida, int ataque, int defesa) : base(nome, tipo, vida, ataque, defesa) { }
    public override void Atacar(Pokemon alvo)
    {
        if (alvo.Tipo == "Fogo")
        {
            Console.WriteLine($"{Nome} é super efetivo contra {alvo.Nome}!");
            Ataque += 5;
        }
        int dano = Ataque - alvo.Defesa;
        if (dano < 0)
            dano = 0;
        alvo.Vida -= dano;
        Vida += 2;
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {dano} de dano!");
    }
}
public class PokemonGrama : Pokemon
{
    public PokemonGrama(string nome, string tipo, int vida, int ataque, int defesa) : base(nome, tipo, vida, ataque, defesa) { }
    public override void Atacar(Pokemon alvo)
    {
        if (alvo.Tipo == "Agua")
        {
            Console.WriteLine($"{Nome} é super efetivo contra {alvo.Nome}!");
            Ataque += 5;
        }
        bool critico = new Random().Next(0, 100) < 20;

        int dano = Ataque - alvo.Defesa + (critico ? 5 : 0);
        if (dano < 0)
            dano = 0;
        alvo.Vida -= dano;
        Console.WriteLine(critico ? $"{Nome} atacou {alvo.Nome} causando {dano} de dano! DANO CRÍTICO!" : $"{Nome} atacou {alvo.Nome} causando {dano} de dano!");
    }
}


public class Treinador
{
    public string Nome { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public void AdicionarPokemon(Pokemon p)
    {
        if (Pokemons == null)
            Pokemons = new List<Pokemon>();
        Pokemons.Add(p);
    }
    public void ListarPokemons()
    {
        Console.WriteLine($"{Nome} tem os seguintes pokémons:");
        for (int i = 0; i < Pokemons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Pokemons[i].Nome}");
        }
    }
    public Pokemon EscolherPokemon(int indice)
    {
        if (indice < 1 || indice > Pokemons.Count)
        {
            Console.WriteLine("Índice inválido!");
            return null;
        }
        return Pokemons[indice - 1];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Treinador ash = new Treinador { Nome = "Ash" };
        Treinador misty = new Treinador { Nome = "Misty" };
        Pokemon pikachu = new Pokemon("Pikachu", "Elétrico", 100, 20, 10);
        Pokemon charmander = new PokemonFogo("Charmander", "Fogo", 80, 25, 8);
        Pokemon squirtle = new PokemonAgua("Squirtle", "Água", 90, 18, 12);
        Pokemon bulbasaur = new PokemonGrama("Bulbasaur", "Grama", 85, 22, 9);
        ash.AdicionarPokemon(charmander);
        ash.AdicionarPokemon(pikachu);
        misty.AdicionarPokemon(squirtle);
        misty.AdicionarPokemon(bulbasaur);
        ash.ListarPokemons();
        misty.ListarPokemons();
        Console.WriteLine("\nBatalha entre charmander e Squirtle:");
        squirtle.Atacar(charmander);
        charmander.ExibirStatus();
    }
}


