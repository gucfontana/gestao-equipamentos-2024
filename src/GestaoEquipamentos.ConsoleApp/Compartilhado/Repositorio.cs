namespace GestaoEquipamentos.ConsoleApp.Compartilhado;

public class Repositorio
{
    protected int contadorId = 1;
    protected Entidade[] registros = new Entidade[100];

    public void Cadastrar(Entidade novoRegistro)
    {
        novoRegistro.Id = contadorId++;

        RegistrarItem(novoRegistro);
    }

    public bool Editar(int id, Entidade novaEntidade)
    {
        novaEntidade.Id = id;

        for (var i = 0; i < registros.Length; i++)
            if (registros[i] == null)
            {
            }

            else if (registros[i].Id == id)
            {
                registros[i] = novaEntidade;

                return true;
            }

        return false;
    }

    public bool Excluir(int id)
    {
        for (var i = 0; i < registros.Length; i++)
            if (registros[i] == null)
            {
            }

            else if (registros[i].Id == id)
            {
                registros[i] = null;
                return true;
            }

        return false;
    }

    public Entidade[] SelecionarTodos()
    {
        return registros;
    }

    public Entidade SelecionarPorId(int id)
    {
        for (var i = 0; i < registros.Length; i++)
        {
            var e = registros[i];

            if (e == null)
                continue;

            if (e.Id == id)
                return e;
        }

        return null;
    }

    public bool Existe(int id)
    {
        for (var i = 0; i < registros.Length; i++)
        {
            var e = registros[i];

            if (e == null)
                continue;

            if (e.Id == id)
                return true;
        }

        return false;
    }

    protected void RegistrarItem(Entidade novoRegistro)
    {
        for (var i = 0; i < registros.Length; i++)
            if (registros[i] != null)
            {
            }

            else
            {
                registros[i] = novoRegistro;
                break;
            }
    }
}