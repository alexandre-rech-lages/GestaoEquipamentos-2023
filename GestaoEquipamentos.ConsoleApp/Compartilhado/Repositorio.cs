using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public int ContadorDeId = 1;

        public ArrayList listaRegistros = new ArrayList();

        public void Inserir(Entidade registro)
        {
            registro.id = ContadorDeId;

            listaRegistros.Add(registro);

            IncrementarId();
        }

        public void Editar(int id, Entidade registroAtualizado)
        {
            Entidade registro = SelecionarPorId(id);

            registro.Atualizar(registroAtualizado);
        }

        public void Excluir(int id)
        {
            Entidade registro = SelecionarPorId(id);

            listaRegistros.Remove(registro);
        }

        public Entidade SelecionarPorId(int id)
        {
            Entidade registro = null;

            foreach (Entidade e in listaRegistros)
            {
                if (e.id == id)
                {
                    registro = e;
                    break;
                }
            }

            return registro;
        }
        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public void IncrementarId()
        {
            ContadorDeId++;
        }

    }
}
