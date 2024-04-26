using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : Entidade
{
    public Equipamento(string nome, string numeroSerie, string fabricante, decimal precoAquisicao,
        DateTime dataFabricacao)
    {
        Nome = nome;
        NumeroSerie = numeroSerie;
        Fabricante = fabricante;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }

    public string Nome { get; set; }
    public string NumeroSerie { get; set; }
    public string Fabricante { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }

    public string[] Validar()
    {
        var erros = new string[3];
        var contadorErros = 0;

        if (Nome.Length < 3)
        {
            erros[0] = "O Nome do Equipamento precisa conter ao menos 3 caracteres";
            contadorErros++;
        }

        if (Fabricante.Length < 3)
        {
            erros[1] = "O Fabricante do Equipamento precisa conter ao menos 3 caracteres";
            contadorErros++;
        }

        if (!NumeroSerie.Contains('-'))
        {
            erros[2] = "O Número de Série do Equipamento precisa conter o caractere '-'.";
            contadorErros++;
        }

        var errosFiltrados = new string[contadorErros];

        Array.Copy(erros, errosFiltrados, contadorErros);

        return errosFiltrados;
    }
}