using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado : Entidade
{
    private readonly DateTime dataAbertura;

    public Equipamento EquipamentoSelecionado;

    public Chamado(string titulo, string descricacao, Equipamento equipamentoSelecionado)
    {
        Titulo = titulo;
        Descricacao = descricacao;
        dataAbertura = DateTime.Now;
        EquipamentoSelecionado = equipamentoSelecionado;
    }

    public string Descricacao { get; set; }
    public string Titulo { get; set; }

    public int QuantidadeDiasEmAberto
    {
        get
        {
            var dataHoje = DateTime.Now;

            var diferenca = dataHoje.Subtract(dataAbertura);

            var diferencaNumero = diferenca.Days;

            return diferencaNumero;
        }
    }

    public string[] Validar()
    {
        var erros = new string[3];
        var contadorErros = 0;

        if (string.IsNullOrEmpty(Titulo))
        {
            erros[0] = "O título é obrigatório";
            contadorErros++;
        }

        if (string.IsNullOrEmpty(Descricacao))
        {
            erros[1] = "A descrição é obrigatória";
            contadorErros++;
        }

        if (EquipamentoSelecionado == null)
        {
            erros[2] = "O equipamento é obrigatório";
            contadorErros++;
        }

        var errosFiltrados = new string[contadorErros];

        Array.Copy(erros, errosFiltrados, contadorErros);

        return errosFiltrados;
    }
}