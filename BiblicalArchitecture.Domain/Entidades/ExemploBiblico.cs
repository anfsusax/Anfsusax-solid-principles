namespace BiblicalArchitecture.Domain.Entidades
{
    public class ExemploBiblico
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Passagem { get; private set; }
        public string Descricao { get; private set; }
        public string Aplicacao { get; private set; }
        public int ModuloId { get; set; }
        public Modulo? Modulo { get; set; }

        // Constructor for EF Core
        protected ExemploBiblico() { }

        public ExemploBiblico(string titulo, string passagem, string descricao, string aplicacao)
        {
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Passagem = passagem ?? throw new ArgumentNullException(nameof(passagem));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Aplicacao = aplicacao ?? throw new ArgumentNullException(nameof(aplicacao));
        }
    }
}
