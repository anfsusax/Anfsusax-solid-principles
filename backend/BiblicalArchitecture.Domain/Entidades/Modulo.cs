using System.Collections.Generic;

namespace BiblicalArchitecture.Domain.Entidades
{
    public class Modulo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int Ordem { get; private set; }
        public ICollection<Aula> Aulas { get; private set; }
        public ICollection<ExemploBiblico> Exemplos { get; private set; }

        protected Modulo() { }

        public Modulo(string nome, string descricao, int ordem)
        {
            Nome = nome;
            Descricao = descricao;
            Ordem = ordem;
            Aulas = new List<Aula>();
            Exemplos = new List<ExemploBiblico>();
        }

        public void AdicionarAula(Aula aula)
        {
            Aulas.Add(aula);
        }

        public void AdicionarExemplo(ExemploBiblico exemplo)
        {
            Exemplos.Add(exemplo);
        }
    }
}
