using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        //Herança e Polimorfismo
        // Protected, Virtual, Override, Object        
        static void Main(string[] args)
        {
            Chamado chamado = new Chamado();

            Entidade chamado2 = chamado;

            Object chamado3 = chamado;

            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
            repositorioEquipamento.CadastrarAlgunsEquipamentosAutomaticamente();

            RepositorioChamado repositorioChamado = new RepositorioChamado();
            repositorioChamado.repositorioEquipamento = repositorioEquipamento;

            repositorioChamado.CadastrarAlgunsChamadosAutomaticamente();

            TelaEquipamento telaEquipamento = new TelaEquipamento();
            telaEquipamento.repositorioEquipamento = repositorioEquipamento;

            TelaChamado telaChamado = new TelaChamado();
            telaChamado.repositorioEquipamento = repositorioEquipamento;
            telaChamado.repositorioChamado = repositorioChamado;
            telaChamado.telaEquipamento = telaEquipamento;

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroEquipamentos = telaEquipamento.ApresentarMenuCadastroEquipamento();

                    if (opcaoCadastroEquipamentos == "s")
                        continue;

                    if (opcaoCadastroEquipamentos == "1")
                    {
                        telaEquipamento.InserirNovoEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "2")
                    {
                        bool temEquipamentos = telaEquipamento.VisualizarEquipamentos(true);

                        if (temEquipamentos)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroEquipamentos == "3")
                    {
                        telaEquipamento.EditarEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "4")
                    {
                        telaEquipamento.ExcluirEquipamento();
                    }
                }
                else if (opcao == "2")
                {
                    string opcaoCadastroChamados = telaChamado.ApresentarMenuCadastroChamado();

                    if (opcaoCadastroChamados == "s")
                        continue;

                    if (opcaoCadastroChamados == "1")
                    {
                        telaChamado.InserirNovoChamado();
                    }
                    else if (opcaoCadastroChamados == "2")
                    {
                        bool temChamados = telaChamado.VisualizarChamados(true);

                        if (temChamados)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroChamados == "3")
                    {
                        telaChamado.EditarChamado();
                    }
                    else if (opcaoCadastroChamados == "4")
                    {
                        telaChamado.ExcluirChamado();
                    }
                }
            }
        }

        static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Gestão de Equipamentos 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Equipamentos");

            Console.WriteLine("Digite 2 para Controlar Chamados");

            Console.WriteLine();

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }

    class ProgramExemploHerancaPolimorfismo
    {

        static void Main2(string[] args)
        {
            Cachorro cachorro1 = new Cachorro();

            Animal cachorro2 = cachorro1;

            object cachorro3 = cachorro2;

            ArrayList listaAnimais = new ArrayList();

            Animal gato = new Gato();
            Animal passaro = new Passaro();
            Girafa girafa = new Girafa();
            Animal animal = new Animal();

            listaAnimais.Add(cachorro1);
            listaAnimais.Add(gato);
            listaAnimais.Add(passaro);
            listaAnimais.Add(girafa);
            listaAnimais.Add(animal);

            foreach (Animal a in listaAnimais)
            {
                FazerSom(a);
            }
        }

        static void FazerSom(Animal animal) //Polimorfismo
        {
            Console.WriteLine("Fazendo som: ");

            animal.EmitirSom();

            Console.WriteLine("------------");
        }

        //static void FazerSomDeCachorro(Cachorro cachorro)
        //{
        //    Console.WriteLine( "Fazendo som: " );
        //    cachorro.EmitirSom();
        //    Console.WriteLine( "------------" );
        //}

        //static void FazerSomDeGato(Gato gato)
        //{
        //    Console.WriteLine("Fazendo som: ");
        //    gato.EmitirSom();
        //    Console.WriteLine("------------");
        //}
    }

    class Animal
    {
        public virtual void EmitirSom()
        {
            Console.WriteLine("Fazendo um som qualquer");
        }
    }

    class Cachorro : Animal
    {
        public override void EmitirSom()
        {
            Console.WriteLine("au au");
        }
    }

    class Gato : Animal
    {
        public override void EmitirSom()
        {
            Console.WriteLine("miau");
        }
    }

    class Passaro : Animal
    {
        public override void EmitirSom()
        {
            Console.WriteLine("Piu piu");
        }
    }

    class Girafa : Animal
    {

    }
}
