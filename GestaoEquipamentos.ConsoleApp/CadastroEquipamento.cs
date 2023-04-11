﻿using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    public class CadastroEquipamento
    {
        static int ContadorDeEquipamento = 1;

        public static ArrayList listaIdsEquipamento = new ArrayList();
        public static ArrayList listaNomesEquipamento = new ArrayList();
        static ArrayList listaPrecosEquipamento = new ArrayList();
        static ArrayList listaNumerosSerieEquipamento = new ArrayList();
        static ArrayList listaDatasFabricaoEquipamento = new ArrayList();
        static ArrayList listaFabricanteEquipamento = new ArrayList();
        
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

            int posicao = listaIdsEquipamento.IndexOf(idSelecionado);

            listaIdsEquipamento.RemoveAt(posicao);
            listaNomesEquipamento.RemoveAt(posicao);
            listaPrecosEquipamento.RemoveAt(posicao);
            listaNumerosSerieEquipamento.RemoveAt(posicao);
            listaDatasFabricaoEquipamento.RemoveAt(posicao);
            listaFabricanteEquipamento.RemoveAt(posicao);

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

                idInvalido = listaIdsEquipamento.Contains(idSelecionado) == false;

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
                //utilizado para inserção
                listaIdsEquipamento.Add(id);
                listaNomesEquipamento.Add(nome);
                listaPrecosEquipamento.Add(preco);
                listaNumerosSerieEquipamento.Add(numeroSerie);
                listaDatasFabricaoEquipamento.Add(dataFabricacao);
                listaFabricanteEquipamento.Add(fabricante);
            }
            else if (tipoOperacao == "EDITAR")
            {
                //utilizado para edição
                int posicao = listaIdsEquipamento.IndexOf(id);

                listaIdsEquipamento[posicao] = id;
                listaNomesEquipamento[posicao] = nome;
                listaPrecosEquipamento[posicao] = preco;
                listaNumerosSerieEquipamento[posicao] = numeroSerie;
                listaDatasFabricaoEquipamento[posicao] = dataFabricacao;
                listaFabricanteEquipamento[posicao] = fabricante;
            }
        }

        public static bool VisualizarEquipamentos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaIdsEquipamento.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Nome", "Fabricante");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            for (int i = 0; i < listaIdsEquipamento.Count; i++)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}",
                    listaIdsEquipamento[i], listaNomesEquipamento[i], listaFabricanteEquipamento[i]);
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
            listaIdsEquipamento.Add(ContadorDeEquipamento);
            listaNomesEquipamento.Add("Impressora");
            listaPrecosEquipamento.Add(1500);
            listaNumerosSerieEquipamento.Add("123-abc");
            listaDatasFabricaoEquipamento.Add("12/12/2022");
            listaFabricanteEquipamento.Add("Lexmark");

            ContadorDeEquipamento++;
        }
        
    }
}
