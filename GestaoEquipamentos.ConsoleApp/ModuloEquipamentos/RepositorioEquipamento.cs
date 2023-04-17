using GestaoEquipamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class RepositorioEquipamento : Repositorio
    {                                        
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
