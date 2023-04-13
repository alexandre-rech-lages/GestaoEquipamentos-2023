using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public int ContadorDeId = 1;

        public ArrayList listaRegistros = new ArrayList();

        public void IncrementarId()
        {
            ContadorDeId++;
        }

    }
}
