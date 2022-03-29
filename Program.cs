using System;
using DIO.SERIES.Classes;

namespace DIO.SERIES
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpçãoUsuario();
            while(opcaoUsuario != "X") {
                switch(opcaoUsuario) {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpçãoUsuario();
            }
        }

        private static void VisualizarSerie() {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie() {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        } 

        private static void AtualizarSerie() {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Generos)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Generos), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Generos) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, novaSerie);
        }

        private static void ListarSeries() 
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if(lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista) 
            {
                Console.WriteLine($"#ID {serie.Id} - {serie.Titulo} {(serie.Excluido?"(Excluida)" : "")}");
            }
        }

        private static void InserirSerie() 
        {
            foreach (int i in Enum.GetValues(typeof(Generos)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Generos), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Generos) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpçãoUsuario() 
        {
            Console.WriteLine();
            Console.WriteLine(
                @"
                Dio Séries
                Informe a opção desejada:
                1 - Listar séries
                2 - Inserir nova série
                3 - Atualizar série
                4 - Excluir série
                5 - Visualizar série
                C - Limpar tela
                X - Sair
                "
            );
            Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }
    }
}
