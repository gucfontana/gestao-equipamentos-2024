namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorio = new();

    public TelaEquipamento()
    {
        var equipTest = new Equipamento("", "", "", 0, DateTime.Now);

        repositorio.Cadastrar(equipTest);
    }

    public char ApresentarMenu()
    {
        Console.Clear();


        Console.WriteLine("Gestão de Equipamentos - 2024");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastrar Equipamento");
        Console.WriteLine("2 - Editar Equipamento");
        Console.WriteLine("3 - Excluir Equipamento");
        Console.WriteLine("4 - Visualizar Equipamentos");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        var operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        return operacaoEscolhida;
    }

    public void CadastrarEquipamento()
    {
        Console.Clear();

        Console.WriteLine("Gestão de Equipamentos - 2024");

        Console.WriteLine();

        Console.WriteLine("Cadastrando Equipamento...");

        Console.WriteLine();

        var equipamento = ObterEquipamento();

        var erros = equipamento.Validar();

        if (erros.Length > 0)
        {
            ApresentarErros(erros);
            return;
        }

        repositorio.Cadastrar(equipamento);

        Program.ExibirMensagem("O equipamento foi cadastrado com sucesso!", ConsoleColor.Green);
    }

    private void ApresentarErros(string[] erros)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        for (var i = 0; i < erros.Length; i++)
            Console.WriteLine(erros[i]);

        Console.ResetColor();
        Console.ReadLine();
    }

    public void EditarEquipamento()
    {
        Console.Clear();

        Console.WriteLine("Gestão de Equipamentos - 2024");

        Console.WriteLine();

        Console.WriteLine("Editando Equipamento...");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do equipamento que deseja editar: ");
        var idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.Existe(idEquipamentoEscolhido))
        {
            Program.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
            return;
        }

        Console.WriteLine();

        var equipamento = ObterEquipamento();

        var erros = equipamento.Validar();

        if (erros.Length > 0)
        {
            ApresentarErros(erros);
            return;
        }

        var conseguiuEditar = repositorio.Editar(idEquipamentoEscolhido, equipamento);

        if (!conseguiuEditar)
        {
            Program.ExibirMensagem("Houve um erro durante a edição de equipamento", ConsoleColor.Red);
            return;
        }

        Program.ExibirMensagem("O equipamento foi editado com sucesso!", ConsoleColor.Green);
    }

    public void ExcluirEquipamento()
    {
        Console.Clear();

        Console.WriteLine("Gestão de Equipamentos - 2024");

        Console.WriteLine();

        Console.WriteLine("Excluindo Equipamento...");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do equipamento que deseja excluir: ");
        var idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.Existe(idEquipamentoEscolhido))
        {
            Program.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
            return;
        }

        var conseguiuExcluir = repositorio.Excluir(idEquipamentoEscolhido);

        if (!conseguiuExcluir)
        {
            Program.ExibirMensagem("Houve um erro durante a exclusão do equipamento", ConsoleColor.Red);
            return;
        }

        Program.ExibirMensagem("O equipamento foi excluído com sucesso!", ConsoleColor.Green);
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();

            Console.WriteLine("Gestão de Equipamentos - 2024");

            Console.WriteLine();

            Console.WriteLine("Visualizando Equipamentos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
            "Id", "Nome", "Fabricante", "Preço", "Data de Fabricação"
        );

        var equipamentosCadastrados = repositorio.SelecionarTodos();

        foreach (Equipamento equip in equipamentosCadastrados)
        {
            if (equip == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                equip.Id, equip.Nome, equip.Fabricante, equip.PrecoAquisicao,
                equip.DataFabricacao.ToShortDateString() // "17/04/2024"
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    private Equipamento ObterEquipamento()
    {
        Console.Write("Digite o nome do equipamento: ");
        var nome = Console.ReadLine();

        Console.Write("Digite o número de série do equipamento: ");
        var numeroSerie = Console.ReadLine();

        Console.Write("Digite o nome do fabricante do equipamento: ");
        var fabricante = Console.ReadLine();

        Console.Write("Digite o preço de aquisição do equipamento: R$ ");
        var precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (formato: dd/MM/aaaa): ");
        var dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        var equipamento = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);
        return equipamento;
    }
}