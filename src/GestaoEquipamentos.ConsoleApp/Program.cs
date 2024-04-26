using GestaoEquipamentos.ConsoleApp.ModuloChamado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp;

public class Program
{
    private static void Main(string[] args)
    {
        var telaEquipamento = new TelaEquipamento();

        var telaChamado = new TelaChamado();
        telaChamado.telaEquipamento = telaEquipamento;

        var opcaoSairEscolhida = false;

        while (!opcaoSairEscolhida)
        {
            var opcaoPrincipalEscolhida = ApresentarMenuPrincipal();
            char operacaoEscolhida;

            switch (opcaoPrincipalEscolhida)
            {
                case '1':
                    operacaoEscolhida = telaEquipamento.ApresentarMenu();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        break;

                    if (operacaoEscolhida == '1')
                        telaEquipamento.CadastrarEquipamento();

                    else if (operacaoEscolhida == '2')
                        telaEquipamento.EditarEquipamento();

                    else if (operacaoEscolhida == '3')
                        telaEquipamento.ExcluirEquipamento();

                    else if (operacaoEscolhida == '4')
                        telaEquipamento.VisualizarEquipamentos(true);

                    break;

                case '2':
                    operacaoEscolhida = telaChamado.ApresentarMenu();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        break;

                    if (operacaoEscolhida == '1')
                        telaChamado.CadastrarChamado();

                    if (operacaoEscolhida == '2')
                        telaChamado.EditarChamado();

                    if (operacaoEscolhida == '3')
                        telaChamado.ExcluirChamado();

                    else if (operacaoEscolhida == '4')
                        telaChamado.VisualizarChamados(true);

                    break;

                default:
                    opcaoSairEscolhida = true;
                    break;
            }
        }

        Console.ReadLine();
    }

    private static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("Gestão de Equipamentos - 2024");

        Console.WriteLine();

        Console.WriteLine("1 - Gerência de Equipamentos");
        Console.WriteLine("2 - Gerência de Chamados");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");

        var opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }

    public static void ExibirMensagem(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;

        Console.WriteLine();

        Console.WriteLine(mensagem);

        Console.ResetColor();

        Console.ReadLine();
    }
}