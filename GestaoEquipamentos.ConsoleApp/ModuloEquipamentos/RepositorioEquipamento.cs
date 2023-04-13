using GestaoEquipamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class RepositorioEquipamento : Repositorio
    {        
        public void Inserir(Equipamento equipamento)
        {
            equipamento.id = ContadorDeId;

            listaRegistros.Add(equipamento);

            IncrementarId();
        }

        public Equipamento SelecionarPorId(int id)
        {
            Equipamento equipamento = null;

            foreach (Equipamento e in listaRegistros)
            {
                if (e.id == id)
                {
                    equipamento = e;
                    break;
                }
            }

            return equipamento;
        }

        public void Editar(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamento = SelecionarPorId(id);

            equipamento.nome = equipamentoAtualizado.nome;
            equipamento.preco = equipamentoAtualizado.preco;
            equipamento.numeroSerie = equipamentoAtualizado.numeroSerie;
            equipamento.dataFabricacao = equipamentoAtualizado.dataFabricacao;
            equipamento.fabricante = equipamentoAtualizado.fabricante;
        }

        public void Excluir(int id)
        {
            Equipamento equipamento = SelecionarPorId(id);

            listaRegistros.Remove(equipamento);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }
       
        public void CadastrarAlgunsEquipamentosAutomaticamente()
        {
            Equipamento equipamento = new Equipamento();

            equipamento.id = ContadorDeId;
            equipamento.nome = "Impressora";
            equipamento.preco = 1500;
            equipamento.numeroSerie = "123-abc";
            equipamento.dataFabricacao = "12/12/2022";
            equipamento.fabricante = "Lexmark";

            Inserir(equipamento);
        }  
    }
}
