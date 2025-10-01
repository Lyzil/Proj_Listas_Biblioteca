using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proj_Listas_Biblioteca
{
    internal class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;
        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora, List<Exemplar> exemplares)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = exemplares;
        }
        public Livro(int isbn) : this(isbn, "", "", "", new List<Exemplar>())
        {
            Isbn = isbn;
        }
        public void adicionarExemplar(Exemplar exemplar) 
        {
            if (!exemplares.Contains(exemplar))
                exemplares.Add(exemplar);
        }
        public int qtdeExemplares() { return exemplares.Count; }
        public int qtdeDisponiveis() 
        {
            int qtdeDisponivel = 0;
            foreach (Exemplar exemplar in exemplares)
            {
                if (exemplar.disponivel())
                    qtdeDisponivel++;
            }
            return qtdeDisponivel;
        }
        public int qtdeEmprestimos() 
        {
            int total = 0;
            foreach (Exemplar ex in exemplares)
                total += ex.qtdeEmprestimos();
            return total;
        }
        public double percDisponibilidade() 
        {
            if (qtdeExemplares() == 0) return 0;
            return Math.Round((qtdeDisponiveis() / (Double)qtdeExemplares()) * 100, 2);
        }
        public override bool Equals(object obj)
        {
            return (this.isbn == ((Livro)obj).Isbn);
        }
    }
}
