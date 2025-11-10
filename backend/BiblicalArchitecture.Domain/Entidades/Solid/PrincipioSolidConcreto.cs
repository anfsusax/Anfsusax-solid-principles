namespace BiblicalArchitecture.Domain.Entidades.Solid
{
    public class PrincipioSolidConcreto : PrincipioSolid
    {
        public PrincipioSolidConcreto(
            int id, 
            string nome, 
            string sigla, 
            string descricao, 
            string exemploCodigo, 
            string referenciaBiblica, 
            string versiculo, 
            string aplicacaoPratica) 
            : base(id, nome, sigla, descricao, exemploCodigo, referenciaBiblica, versiculo, aplicacaoPratica)
        {
        }
    }
}
