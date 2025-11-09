namespace BiblicalArchitecture.Domain.Entidades
{
    // Exemplo de Encapsulamento e Estado/Comportamento
    public class Pessoa
    {
        protected string Nome { get; private set; }
        protected int Idade { get; private set; }
        protected string Vocacao { get; private set; }

        public Pessoa(string nome, int idade, string vocacao)
        {
            Nome = nome;
            Idade = idade;
            Vocacao = vocacao;
        }

        // Exemplo de comportamento
        public virtual string Apresentar()
        {
            return $"Eu sou {Nome}, tenho {Idade} anos e minha vocação é {Vocacao}.";
        }
    }

    // Exemplo de Herança e Polimorfismo
    public class Profeta : Pessoa
    {
        public string Mensagem { get; private set; }

        public Profeta(string nome, int idade, string mensagem) 
            : base(nome, idade, "Profeta")
        {
            Mensagem = mensagem;
        }

        // Exemplo de Polimorfismo
        public override string Apresentar()
        {
            return $"{base.Apresentar()} Minha mensagem é: {Mensagem}";
        }
    }

    // Outro exemplo de Herança e Polimorfismo
    public class Rei : Pessoa
    {
        public string Reino { get; private set; }

        public Rei(string nome, int idade, string reino) 
            : base(nome, idade, "Rei")
        {
            Reino = reino;
        }

        public override string Apresentar()
        {
            return $"{base.Apresentar()} Governo sobre o reino de {Reino}.";
        }
    }
}