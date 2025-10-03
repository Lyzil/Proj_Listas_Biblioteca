using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Listas_Biblioteca
{
    internal class Livros
    {
        private List<Livro> acervo = new List<Livro>();
        internal List<Livro> Acervo { get => acervo; }
        public Livros(List<Livro> livroLista)
        {
            this.acervo = livroLista;
        }
        public Livros() : this(new List<Livro>()) { }
        public void adicionar(Livro livro)
        {
            if (!acervo.Contains(livro))
            {
                acervo.Add(livro);
                Console.WriteLine("Adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao adicionar!");
            }
        }
        public Livro pesquisar(Livro livro)
        {
            int id = acervo.IndexOf(livro);
            if (id >= 0)
                return acervo[id];
            return null;
        }
    }
}
