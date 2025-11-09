namespace BiblicalArchitecture.Domain.Entidades.Solid
{
    public abstract class PrincipioSolid
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sigla { get; protected set; }
        public string Descricao { get; protected set; }
        public string ExemploCodigo { get; protected set; }
        public string ReferenciaBiblica { get; protected set; }
        public string Versiculo { get; protected set; }
        public string AplicacaoPratica { get; protected set; }

        protected PrincipioSolid(int id, string nome, string sigla, string descricao, string exemploCodigo, string referenciaBiblica, string versiculo, string aplicacaoPratica)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            Descricao = descricao;
            ExemploCodigo = exemploCodigo;
            ReferenciaBiblica = referenciaBiblica;
            Versiculo = versiculo;
            AplicacaoPratica = aplicacaoPratica;
        }
    }
}
