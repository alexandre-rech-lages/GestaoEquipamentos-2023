using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class RepositorioEquipamento
    {
        private static int ContadorDeEquipamento = 1;

        private static ArrayList listaEquipamentos = new ArrayList();

        public static void Inserir(Equipamento equipamento)
        {
            equipamento.id = ContadorDeEquipamento;

            listaEquipamentos.Add(equipamento);

            IncrementarIdEquipamento();
        }

        public static Equipamento SelecionarPorId(int id)
        {
            Equipamento equipamento = null;

            foreach (Equipamento e in listaEquipamentos)
            {
                if (e.id == id)
                {
                    equipamento = e;
                    break;
                }
            }

            return equipamento;
        }

        public static void Editar(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamento = SelecionarPorId(id);

            equipamento.nome = equipamentoAtualizado.nome;
            equipamento.preco = equipamentoAtualizado.preco;
            equipamento.numeroSerie = equipamentoAtualizado.numeroSerie;
            equipamento.dataFabricacao = equipamentoAtualizado.dataFabricacao;
            equipamento.fabricante = equipamentoAtualizado.fabricante;
        }

        public static void Excluir(int id)
        {
            Equipamento equipamento = SelecionarPorId(id);

            listaEquipamentos.Remove(equipamento);
        }

        public static ArrayList SelecionarTodos()
        {
            return listaEquipamentos;
        }
       
        public static void CadastrarAlgunsEquipamentosAutomaticamente()
        {
            Equipamento equipamento = new Equipamento();

            equipamento.id = ContadorDeEquipamento;
            equipamento.nome = "Impressora";
            equipamento.preco = 1500;
            equipamento.numeroSerie = "123-abc";
            equipamento.dataFabricacao = "12/12/2022";
            equipamento.fabricante = "Lexmark";

            listaEquipamentos.Add(equipamento);

            ContadorDeEquipamento++;
        }

        #region métodos privados
        private static void IncrementarIdEquipamento()
        {
            ContadorDeEquipamento++;
        }
        #endregion
    }
}
