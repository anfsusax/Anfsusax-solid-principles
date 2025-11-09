namespace BiblicalArchitecture.Domain.Entidades
{
    public class Aula
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Conteudo { get; private set; }
        public int DuracaoMinutos { get; private set; }
        public int Ordem { get; private set; }
        public int ModuloId { get; private set; }
        public Modulo Modulo { get; private set; }

        protected Aula() { }

        public Aula(string titulo, string descricao, string conteudo, int duracaoMinutos, int ordem)
        {
            Titulo = titulo;
            Descricao = descricao;
            Conteudo = conteudo;
            DuracaoMinutos = duracaoMinutos;
            Ordem = ordem;
        }
    }
}
