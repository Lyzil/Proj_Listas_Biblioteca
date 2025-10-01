using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Listas_Biblioteca
{
    internal class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;
        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int tombo, List<Emprestimo> emprestimos)
        {
            Tombo = tombo;
            Emprestimos = emprestimos;
        }
        public Exemplar(int tombo) : this(tombo, new List<Emprestimo>())
        {
            Tombo = tombo;
        }
        public bool emprestar()
        {
            if (!disponivel()) return false;
            emprestimos.Add(new Emprestimo(DateTime.Now));
            return true;
        }
        public bool devolver()
        {
            if (disponivel()) return false; 
            emprestimos.Last().DtDevolucao = DateTime.Now;
            return true;
        }
        public bool disponivel()
        {
            if (Emprestimos.Count == 0 ) { return true; }

            Emprestimo ultimo = emprestimos.Last();
            return ultimo.DtDevolucao != DateTime.MinValue;
        }
        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        }
    }
}
