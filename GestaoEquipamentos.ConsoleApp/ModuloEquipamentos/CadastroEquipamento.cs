using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    public class CadastroEquipamento
    {
        static int ContadorDeEquipamento = 1;

        static ArrayList listaEquipamentos = new ArrayList();
        
        public static string ApresentarMenuCadastroEquipamento()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Cadastro de Equipamentos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir um Novo Equipamento");

            Console.WriteLine("Digite 2 para Visulizar Equipamentos");

            Console.WriteLine("Digite 3 para Editar Equipamentos");

            Console.WriteLine("Digite 4 para Excluir Equipamentos");

            Console.WriteLine();

            Console.WriteLine("Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void CadastrarEquipamento(string opcaoCadastroEquipamentos)
        {
            if (opcaoCadastroEquipamentos == "1")
            {
                InserirNovoEquipamento();
            }
            else if (opcaoCadastroEquipamentos == "2")
            {
                bool temEquipamentos = VisualizarEquipamentos(true);

                if (temEquipamentos)
                    Console.ReadLine();
            }
            else if (opcaoCadastroEquipamentos == "3")
            {
                EditarEquipamento();
            }
            else if (opcaoCadastroEquipamentos == "4")
            {
                //Excluir um equipamento existente
                ExcluirEquipamento();
            }
        }

        static void ExcluirEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarEquipamento();

            Equipamento equipamento = SelecionarEquipamentoPorId(idSelecionado);

            listaEquipamentos.Remove(equipamento);          

            Program.ApresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }

        static void EditarEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentos = VisualizarEquipamentos(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarEquipamento();

            GravarEquipamento(idSelecionado, "EDITAR");

            Program.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
        }

        public static int EncontrarEquipamento()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Equipamento: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarEquipamentoPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        static void GravarEquipamento(int id, string tipoOperacao)
        {
            string nome;
            bool nomeInvalido;

            do
            {
                nomeInvalido = false;
                Console.Write("Digite o nome do Equipamento: ");
                nome = Console.ReadLine();

                if (nome.Length <= 6)
                {
                    nomeInvalido = true;
                    Program.ApresentarMensagem("Nome inválido. Informe no mínimo 6 letras", ConsoleColor.Red);
                }
            }
            while (nomeInvalido);

            Console.Write("Digite o preco do Equipamento: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação: ");
            string dataFabricacao = Console.ReadLine();

            Console.Write("Digite o Fabricante: ");
            string fabricante = Console.ReadLine();

            if (tipoOperacao == "INSERIR")
            {
                Equipamento equipamento = new Equipamento();

                equipamento.id = id;
                equipamento.nome = nome;
                equipamento.preco = preco;
                equipamento.numeroSerie = numeroSerie;
                equipamento.dataFabricacao = dataFabricacao;
                equipamento.fabricante = fabricante;

                listaEquipamentos.Add(equipamento);
              
            }
            else if (tipoOperacao == "EDITAR")
            {
                Equipamento equipamento = SelecionarEquipamentoPorId(id);
                equipamento.nome = nome;
                equipamento.preco = preco;
                equipamento.numeroSerie = numeroSerie;
                equipamento.dataFabricacao = dataFabricacao;
                equipamento.fabricante = fabricante;
            }
        }

        public static Equipamento SelecionarEquipamentoPorId(int id)
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

        public static bool VisualizarEquipamentos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaEquipamentos.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Nome", "Fabricante");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (Equipamento e in listaEquipamentos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", e.id, e.nome, e.fabricante);
            }
         
            Console.ResetColor();

            return true;
        }

        static void InserirNovoEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Inserindo Novo Equipamento: ");

            GravarEquipamento(ContadorDeEquipamento, "INSERIR");

            IncrementarIdEquipamento();

            Program.ApresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);
        }

        static void IncrementarIdEquipamento()
        {
            ContadorDeEquipamento++;
        }

        public static void CadastrarAlgunsEquipamentosAutomaticamente()
        {
            //listaIdsEquipamento.Add(ContadorDeEquipamento);
            //listaNomesEquipamento.Add("Impressora");
            //listaPrecosEquipamento.Add(1500);
            //listaNumerosSerieEquipamento.Add("123-abc");
            //listaDatasFabricaoEquipamento.Add("12/12/2022");
            //listaFabricanteEquipamento.Add("Lexmark");

            ContadorDeEquipamento++;
        }
        
    }
}
