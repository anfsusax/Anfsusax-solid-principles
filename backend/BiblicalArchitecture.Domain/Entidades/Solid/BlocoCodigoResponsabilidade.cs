namespace BiblicalArchitecture.Domain.Entidades.Solid
{
    public class BlocoCodigoResponsabilidade
    {
        public string Titulo { get; }
        public string Papel { get; }
        public string Codigo { get; }
        public string? Explicacao { get; }
        public string? CorSugestao { get; }

        public BlocoCodigoResponsabilidade(
            string titulo,
            string papel,
            string codigo,
            string? explicacao = null,
            string? corSugestao = null)
        {
            Titulo = titulo;
            Papel = papel;
            Codigo = codigo;
            Explicacao = explicacao;
            CorSugestao = corSugestao;
        }
    }
}

