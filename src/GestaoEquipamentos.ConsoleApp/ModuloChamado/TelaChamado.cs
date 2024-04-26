using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    private readonly RepositorioChamado repositorioChamado = new();

    public TelaEquipamento telaEquipamento = null;

    public char ApresentarMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Chamados            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastrar Chamado");
        Console.WriteLine("2 - Editar Chamado");
        Console.WriteLine("3 - Excluir Chamado");
        Console.WriteLine("4 - Visualizar Chamados");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        var operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        return operacaoEscolhida;
    }

    public void CadastrarChamado()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Chamados            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("Cadastrando Chamado...");

        Console.WriteLine();

        var novoChamado = ObterChamado();

        var erros = novoChamado.Validar();

        if (erros.Length > 0)
        {
            ApresentarErros(erros);
            return;
        }

        repositorioChamado.Cadastrar(novoChamado);
    }

    public void EditarChamado()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Chamados            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("Editando Chamado...");

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja editar: ");
        var idChamadoEscolhido = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        var novoChamado = ObterChamado();

        var erros = novoChamado.Validar();

        if (erros.Length > 0)
        {
            ApresentarErros(erros);
            return;
        }

        var conseguiuEditar = repositorioChamado.Editar(idChamadoEscolhido, novoChamado);
    }

    public void ExcluirChamado()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Chamados            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("Excluindo Chamado...");

        Console.WriteLine();

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja excluir: ");
        var idChamadoEscolhido = Convert.ToInt32(Console.ReadLine());

        var conseguiuExcluir = repositorioChamado.Excluir(idChamadoEscolhido);
    }

    private Chamado ObterChamado()
    {
        telaEquipamento.VisualizarEquipamentos(false);

        var conseguiuConverter = false;

        var idEquipamento = 0;

        while (!conseguiuConverter)
        {
            Console.Write("Digite o ID do equipamento defeituoso: ");
            conseguiuConverter = int.TryParse(Console.ReadLine(), out idEquipamento);

            if (!conseguiuConverter)
                Console.WriteLine("Por favor, informe um ID válido!\n");
        }

        var equipamentoSelecionado = (Equipamento)telaEquipamento.repositorio.SelecionarPorId(idEquipamento);

        Console.Write("Digite o título do chamado: ");
        var titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        var descricao = Console.ReadLine();

        var novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

        return novoChamado;
    }

    public void VisualizarChamados(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Chamados            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Visualizando Chamados...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
            "Id", "Título", "Equipamento", "Dias em Aberto"
        );

        var chamadosCadastrados = repositorioChamado.SelecionarTodos();

        foreach (Chamado chamado in chamadosCadastrados)
        {
            if (chamado == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                chamado.Id, chamado.Titulo, chamado.EquipamentoSelecionado.Nome, chamado.QuantidadeDiasEmAberto
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    private void ApresentarErros(string[] erros)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        for (var i = 0; i < erros.Length; i++)
            Console.WriteLine(erros[i]);

        Console.ResetColor();
        Console.ReadLine();
    }
}