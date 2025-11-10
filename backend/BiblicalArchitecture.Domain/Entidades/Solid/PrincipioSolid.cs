using System.Collections.Generic;
using System.Linq;

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
        public IReadOnlyList<BlocoCodigoResponsabilidade> BlocosCodigo { get; protected set; }

        protected PrincipioSolid(
            int id,
            string nome,
            string sigla,
            string descricao,
            string exemploCodigo,
            string referenciaBiblica,
            string versiculo,
            string aplicacaoPratica,
            IEnumerable<BlocoCodigoResponsabilidade>? blocosCodigo = null)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            Descricao = descricao;
            ExemploCodigo = exemploCodigo;
            ReferenciaBiblica = referenciaBiblica;
            Versiculo = versiculo;
            AplicacaoPratica = aplicacaoPratica;
            BlocosCodigo = (blocosCodigo ?? Enumerable.Empty<BlocoCodigoResponsabilidade>()).ToList().AsReadOnly();
        }
    }
}
