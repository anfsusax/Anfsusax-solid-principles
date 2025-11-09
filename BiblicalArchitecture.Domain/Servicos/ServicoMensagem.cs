namespace BiblicalArchitecture.Domain.Servicos
{
    // Interfaces (Abstrações de alto nível)
    public interface IMensageiro
    {
        void EntregarMensagem(string mensagem);
    }

    public interface IOuvinte
    {
        void ReceberMensagem(string mensagem);
    }

    // Implementações (Detalhes de baixo nível)
    public class Anjo : IMensageiro
    {
        public void EntregarMensagem(string mensagem)
        {
            // "O anjo Gabriel foi enviado por Deus..." - Lucas 1:26
        }
    }

    public class Profeta : IMensageiro
    {
        public void EntregarMensagem(string mensagem)
        {
            // "Assim diz o Senhor..." - Comum em todos os profetas
        }
    }

    // Classe de alto nível que depende de abstrações (DIP)
    public class ServicoMensagem
    {
        private readonly IMensageiro _mensageiro;
        private readonly IOuvinte _ouvinte;

        // Injeção de dependência via construtor
        public ServicoMensagem(IMensageiro mensageiro, IOuvinte ouvinte)
        {
            _mensageiro = mensageiro;
            _ouvinte = ouvinte;
        }

        public void TransmitirMensagem(string mensagem)
        {
            _mensageiro.EntregarMensagem(mensagem);
            _ouvinte.ReceberMensagem(mensagem);
        }
    }
}