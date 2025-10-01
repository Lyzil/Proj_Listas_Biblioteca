using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj_Listas_Biblioteca;

namespace Proj_Listas_Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            Livros biblioteca = new Livros(new List<Livro>());

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
                        Console.WriteLine("\ndigite o ISBN id): ");
                        if (!int.TryParse(Console.ReadLine(), out int addIsbn))
                        {
                            Console.WriteLine("ID inválido!\n");
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
                        Console.WriteLine("\ndigite o ID a ser pesquisado");
                        if (!int.TryParse(Console.ReadLine(), out int idPesquisa))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Contato contatoPesquisado = listaContatos.pesquisar(new Contato(idPesquisa));
                        if (contatoPesquisado.Id != -1 && contatoPesquisado != null)
                        {
                            Console.WriteLine(contatoPesquisado.ToString());
                        }
                        else { Console.WriteLine("Contato não encontrado!\n"); }
                        break;
                    case 3:
                        Console.WriteLine("\ndigite o ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int altID))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }
                        Contato contatoExistente = listaContatos.pesquisar(new Contato(altID));
                        if (contatoExistente.Id == -1)
                        {
                            Console.WriteLine("Contato não encontrado!\n");
                            break;
                        }
                        Console.WriteLine("digite o Nome: ");
                        string altNome = Console.ReadLine();

                        Console.WriteLine("digite o email: ");
                        string altEmail = Console.ReadLine();

                        Console.WriteLine("digite o dia atual: ");
                        if (!int.TryParse(Console.ReadLine(), out int altd))
                        {
                            Console.WriteLine("Dia inválido!\n");
                            break;
                        }
                        Console.WriteLine("digite o mes atual: ");
                        if (!int.TryParse(Console.ReadLine(), out int altm))
                        {
                            Console.WriteLine("Mês inválido!\n");
                            break;
                        }
                        Console.WriteLine("digite o ano atual: ");
                        if (!int.TryParse(Console.ReadLine(), out int alta))
                        {
                            Console.WriteLine("Ano inválido!\n");
                            break;
                        }
                        contatoExistente.Nome = altNome;
                        contatoExistente.Email = altEmail;
                        contatoExistente.DtNasc = new Data(altd, altm, alta);

                        Console.WriteLine("Deseja adicionar um novo telefone? (S/N)");
                        string resp = Console.ReadLine().Trim().ToUpper();
                        if (resp == "S")
                        {
                            Console.WriteLine("digite o tipo do telefone: ");
                            string alttipo = Console.ReadLine();
                            Console.WriteLine("digite o número do telefone: ");
                            string altnumero = Console.ReadLine();
                            contatoExistente.adicionarTelefone(new Telefone(alttipo, altnumero));
                        }
                        Console.WriteLine(listaContatos.alterar(contatoExistente)
                            ? "Alterado com sucesso!\n"
                            : "Não foi possível alterar\n");
                        break;
                    case 4:
                        Console.WriteLine("\nDigite o Id pra remover : ");
                        if (!int.TryParse(Console.ReadLine(), out int IdDel))
                        {
                            Console.WriteLine("ID inválido!\n");
                            break;
                        }

                        Console.WriteLine(listaContatos.remover(new Contato(IdDel))
                            ? "Contato apagado com sucesso"
                            : "Contato não encontrado!\n");
                        break;
                    case 5:
                        Console.WriteLine("-----Lista de contatos-----\n");
                        foreach (Contato contatos in listaContatos.Agenda)
                        {
                            Console.WriteLine(contatos.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("\nOcorreu um erro, verifique se digitou corretamente.\n");
                        break;
                }
            } while (opcao != 0);
        }
    }
}