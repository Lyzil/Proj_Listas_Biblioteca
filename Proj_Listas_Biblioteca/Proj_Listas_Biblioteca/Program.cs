using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj_Listas_Biblioteca;

namespace Proj_Listas_Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            Livros biblioteca = new Livros(new List<Livro>());

        /*      Script para teste
         * 
            Livro livro1 = new Livro(1001, "C# Avançado", "Autor A", "Editora X", new List<Exemplar>());
            biblioteca.adicionar(livro1);
            Livro livro2 = new Livro(1002, "Java Básico", "Autor B", "Editora Y", new List<Exemplar>());
            biblioteca.adicionar(livro2);
            biblioteca.adicionar(new Livro(1001, "Outro C#", "Autor C", "Editora Z", new List<Exemplar>()));
            Console.WriteLine("\n--- Pesquisando livro 1001 ---");
            Livro encontrado = biblioteca.pesquisar(new Livro(1001));
            if (encontrado != null)
                Console.WriteLine($"Livro encontrado: {encontrado.Titulo}");
            else
                Console.WriteLine("Livro não encontrado.");
            Console.WriteLine("\n--- Adicionando exemplares ao livro 1001 ---");
            encontrado.adicionarExemplar(new Exemplar(1));
            encontrado.adicionarExemplar(new Exemplar(2));
            encontrado.adicionarExemplar(new Exemplar(3));
            encontrado.adicionarExemplar(new Exemplar(1));
            Console.WriteLine($"Qtde de exemplares: {encontrado.qtdeExemplares()}");
            Console.WriteLine($"Qtde disponíveis: {encontrado.qtdeDisponiveis()}");
            Console.WriteLine($"Qtde empréstimos: {encontrado.qtdeEmprestimos()}");
            Console.WriteLine($"% Disponibilidade: {encontrado.percDisponibilidade()}%\n");
            Console.WriteLine("\n--- Emprestando exemplar 1 ---");
            bool emprestou = encontrado.Exemplares[0].emprestar();
            Console.WriteLine(emprestou ? "Empréstimo realizado." : "Falha no empréstimo.");
            Console.WriteLine($"Disponível? {encontrado.Exemplares[0].disponivel()}");
            emprestou = encontrado.Exemplares[0].emprestar();
            Console.WriteLine(emprestou ? "Empréstimo realizado." : "Falha no empréstimo (já emprestado).");
            Console.WriteLine($"Qtde disponíveis após empréstimo: {encontrado.qtdeDisponiveis()}");
            Console.WriteLine($"Qtde empréstimos: {encontrado.qtdeEmprestimos()}");
            Console.WriteLine("\n--- Devolvendo exemplar 1 ---");
            bool devolveu = encontrado.Exemplares[0].devolver();
            Console.WriteLine(devolveu ? "Devolução realizada." : "Falha na devolução.");
            Console.WriteLine($"Disponível? {encontrado.Exemplares[0].disponivel()}");
            Console.WriteLine($"Qtde disponíveis: {encontrado.qtdeDisponiveis()}");
            devolveu = encontrado.Exemplares[0].devolver();
            Console.WriteLine(devolveu ? "Devolução realizada." : "Falha na devolução (já está disponível).");
            Console.WriteLine("\n--- Histórico do livro 1001 ---");
            foreach (Exemplar ex in encontrado.Exemplares)
            {
                Console.WriteLine($"Exemplar: {ex.Tombo}");
                foreach (Emprestimo emp in ex.Emprestimos)
                {
                    string devolucao = emp.DtDevolucao == DateTime.MinValue ? "Ainda não devolvido" : emp.DtDevolucao.ToString();
                    Console.WriteLine($"   Emprestado em: {emp.DtEmprestimo}, Devolução: {devolucao}");
                }
            }*/

            Console.WriteLine("\n===== FIM DOS TESTES =====");

            do
            {
                Console.WriteLine("Menu de opções " +
                    "\n0. Sair " +
                    "\n1. Adicionar livro " +
                    "\n2. Pesquisar livro (sintético) " +
                    "\n3. Pesquisar livro (analítico)  " +
                    "\n4. Adicionar exemplar " +
                    "\n5. Registrar empréstimo " +
                    "\n6. Registrar devolução" +
                    "\nEscolhe a opção que deseja: ");

                string inputOpcao = Console.ReadLine();
                if (!int.TryParse(inputOpcao, out opcao))
                {
                    Console.WriteLine("Ocorreu um erro, verifique se digitou corretamente.\n");
                    continue;
                }
                switch (opcao)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("\ndigite o ISBN (id): ");
                        if (!int.TryParse(Console.ReadLine(), out int addIsbn)){
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Livro livroExistente = biblioteca.pesquisar(new Livro(addIsbn));
                        if (livroExistente != null){
                            Console.WriteLine("Já existe um livro com esse ISBN!\n");
                            break;
                        }
                        Console.WriteLine("digite o Titulo: ");
                        string addTitulo = Console.ReadLine();
                        Console.WriteLine("digite o/a Autor(a): ");
                        string addAutor = Console.ReadLine();
                        Console.WriteLine("digite a Editora: ");
                        string AddEditora = Console.ReadLine();

                        Livro novo = new Livro(addIsbn, addTitulo, addAutor, AddEditora, new List<Exemplar>());
                        biblioteca.adicionar(novo); 
                        break;
                    case 2:
                        Console.WriteLine("\ndigite o ISBN (id) a ser pesquisado");
                        if (!int.TryParse(Console.ReadLine(), out int idISBN))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Livro livroPesquisado = biblioteca.pesquisar(new Livro(idISBN));
                        if (livroPesquisado != null && livroPesquisado.Isbn != -1)
                        {
                            Console.WriteLine("-----Info do livro-----\n");
                            Console.WriteLine(
                                $"ISBN: {livroPesquisado.Isbn} - " +
                                $"Titulo: {livroPesquisado.Titulo} - " +
                                $"Autor: {livroPesquisado.Autor} - " +
                                $"Editora: {livroPesquisado.Editora} - " +
                                $"Qtde de Exemplares: {livroPesquisado.qtdeExemplares()} - " +
                                $"Qtde Disponivel: {livroPesquisado.qtdeDisponiveis()} - " +
                                $"Qtde de Emprestimos: {livroPesquisado.qtdeEmprestimos()} - " +
                                $"Percentual de Disponibilidade: {livroPesquisado.percDisponibilidade()}%");
                        }
                        else { Console.WriteLine("Livro não encontrado!\n"); }
                        break;
                    case 3:
                        Console.WriteLine("\ndigite o ISBN (id) a ser pesquisado");
                        if (!int.TryParse(Console.ReadLine(), out int idISBN2))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Livro livroPesquisado2 = biblioteca.pesquisar(new Livro(idISBN2));
                        if (livroPesquisado2 != null && livroPesquisado2.Isbn != -1)
                        {
                            StringBuilder infoExemplar = new StringBuilder();
                            foreach (Exemplar exemplar in livroPesquisado2.Exemplares)
                            {
                                infoExemplar.AppendLine($"Exemplar: {exemplar.Tombo}");
                                foreach (Emprestimo emprestimo in exemplar.Emprestimos)
                                {
                                    infoExemplar.AppendLine($"  Empréstimo: {emprestimo.DtEmprestimo} - Devolução: {emprestimo.DtDevolucao}");
                                }
                            }
                            Console.WriteLine("-----Info do livro-----\n");
                            Console.WriteLine(
                                $"ISBN: {livroPesquisado2.Isbn} - " +
                                $"Titulo: {livroPesquisado2.Titulo} - " +
                                $"Autor: {livroPesquisado2.Autor} - " +
                                $"Editora: {livroPesquisado2.Editora} - " +
                                $"Qtde de Exemplares: {livroPesquisado2.qtdeExemplares()} - " +
                                $"Qtde Disponivel: {livroPesquisado2.qtdeDisponiveis()} - " +
                                $"Qtde de Emprestimos: {livroPesquisado2.qtdeEmprestimos()} - " +
                                $"Percentual de Disponibilidade: {livroPesquisado2.percDisponibilidade()}%" +
                            infoExemplar);
                        }
                        else { Console.WriteLine("Livro não encontrado!\n"); }
                        break;
                    case 4:
                        Console.WriteLine("\nDigite o ISBN (id) do livro: ");
                        if (!int.TryParse(Console.ReadLine(), out int Idlivro))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Console.WriteLine("\nDigite o id do novo exemplar: ");
                        if (!int.TryParse(Console.ReadLine(), out int IdNovo))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Livro livroConsultado = biblioteca.pesquisar(new Livro(Idlivro));
                        if(livroConsultado == null || livroConsultado.Isbn == -1) { Console.WriteLine("Erro, livro não existe"); break; }
                        if (livroConsultado.Exemplares.Any(ex => ex.Tombo == IdNovo))
                        {
                            Console.WriteLine("Já existe um exemplar com esse tombo!\n");
                            break;
                        }
                        livroConsultado.adicionarExemplar(new Exemplar(IdNovo));
                        break;
                    case 5:
                        Console.WriteLine("\nDigite o ISBN (id) do livro: ");
                        if (!int.TryParse(Console.ReadLine(), out int IdlivroExemplar))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Console.WriteLine("\nDigite o id do novo exemplar: ");
                        if (!int.TryParse(Console.ReadLine(), out int IdExemplar))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Livro livroExemplar = biblioteca.pesquisar(new Livro(IdlivroExemplar));
                        if (livroExemplar == null || livroExemplar.Isbn == -1) { Console.WriteLine("Erro, livro não existe"); break; }
                        Exemplar exemplarSelecionado = null;
                        foreach (Exemplar ex in livroExemplar.Exemplares)
                        {
                            if (ex.Tombo == IdExemplar)
                            {
                                exemplarSelecionado = ex;
                                break;
                            }
                        }
                        if (exemplarSelecionado == null)
                            Console.WriteLine("Exemplar não encontrado!\n");
                       
                        else{
                            bool emprestoud = exemplarSelecionado.emprestar();
                            if (emprestoud)
                                Console.WriteLine("Empréstimo registrado com sucesso!\n");
                            else
                                Console.WriteLine("Exemplar já está emprestado, não é possível emprestar novamente!\n");
                        }
                        break;
                    case 6:
                        Console.WriteLine("\nDigite o ISBN (id) do livro: ");
                        if (!int.TryParse(Console.ReadLine(), out int IdlivroDevolcao))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Console.WriteLine("\nDigite o id do novo exemplar: ");
                        if (!int.TryParse(Console.ReadLine(), out int IdExemplarDevolucao))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Livro livroDevolucao = biblioteca.pesquisar(new Livro(IdlivroDevolcao));
                        if (livroDevolucao == null || livroDevolucao.Isbn == -1) { Console.WriteLine("Erro, livro não existe"); break; }
                        Exemplar exemplarPesquisado = null;
                        foreach (Exemplar ex in livroDevolucao.Exemplares)
                        {
                            if (ex.Tombo == IdExemplarDevolucao)
                            {
                                exemplarPesquisado = ex;
                                break;
                            }
                        }
                        if (exemplarPesquisado == null)
                            Console.WriteLine("Exemplar não encontrado!\n");

                        else
                        {
                            bool devolvi = exemplarPesquisado.devolver();
                            if (devolvi)
                                Console.WriteLine("Devolução registrada com sucesso!\n");
                            else
                                Console.WriteLine("Exemplar já está disponível, não é possível devolver!\n");
                        }
                        break;
                }
            } while (opcao != 0);
        }
    }

}
