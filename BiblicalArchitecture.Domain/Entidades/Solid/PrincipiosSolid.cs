namespace BiblicalArchitecture.Domain.Entidades.Solid
{
    public class SingleResponsability : PrincipioSolid
    {
        public SingleResponsability() : base(
            id: 1,
            "Princípio da Responsabilidade Única (Single Responsibility Principle - SRP)",
            "S",
            "Uma classe deve ter apenas um motivo para mudar, ou seja, deve ter apenas uma responsabilidade.",
            "SRP: Cada classe deve ter uma única responsabilidade.\n\n// Ruim:\nclass UsuarioService {\n    void ValidarDados() { /* ... */ }\n    void EnviarEmail() { /* ... */ }\n    void SalvarBanco() { /* ... */ }\n}\n\n// Bom:\nclass Validador { /* ... */ }\nclass EmailService { /* ... */ }\nclass UsuarioRepository { /* ... */ }",
            "1 Coríntios 12:12-27",
            "Porque, assim como o corpo é um e tem muitos membros, e todos os membros do corpo, embora muitos, formam um só corpo, assim também é Cristo. Pois em um só corpo todos nós fomos batizados em um único Espírito: quer judeus, quer gregos, quer escravos, quer livres. E a todos nós foi dado beber de um único Espírito. O corpo não é feito de um só membro, mas de muitos.",
            "Assim como cada parte do corpo tem uma função específica (olhos para ver, ouvidos para ouvir), no código cada classe deve ter uma única responsabilidade bem definida. Isso torna o sistema mais organizado, fácil de manter e testar."
        ) { }
    }

    public class OpenClosed : PrincipioSolid
    {
        public OpenClosed() : base(
            id: 2,
            "Princípio Aberto/Fechado (Open/Closed Principle - OCP)",
            "O",
            "As entidades do software devem estar abertas para extensão, mas fechadas para modificação.",
            "OCP: Abra para extensão, feche para modificação.\n\n// Ruim:\nclass Relatorio {\n    public void Gerar(string tipo) {\n        if (tipo == \"PDF\") { /* ... */ }\n        else if (tipo == \"Excel\") { /* ... */ }\n        // Novo formato requer modificar a classe\n    }\n}\n\n// Bom:\ninterface IRelatorio { void Gerar(); }\nclass RelatorioPDF : IRelatorio { /* ... */ }\nclass RelatorioExcel : IRelatorio { /* ... */ }\nclass RelatorioWord : IRelatorio { /* ... */ }",
            "Gênesis 6:14-16",
            "Faça para você uma arca de tábuas de cipreste: você fará compartimentos na arca e a revestirá de piche por dentro e por fora. Esta é a maneira como você a fará: a arca terá cento e trinta e cinco metros de comprimento, vinte e dois metros e meio de largura e treze metros e meio de altura. Você fará um teto para a arca, deixando uma abertura de quarenta e cinco centímetros entre o teto e as laterais. Coloque uma porta na lateral da arca. Faça um andar inferior, um segundo e um terceiro.",
            "Assim como a arca de Noé foi projetada com uma estrutura básica que podia acomodar diferentes tipos de animais sem precisar ser modificada, nosso código deve ser estruturado para permitir a adição de novos comportamentos através de extensões, sem modificar o código existente."
        ) { }
    }

    public class LiskovSubstitution : PrincipioSolid
    {
        public LiskovSubstitution() : base(
            id: 3,
            "Princípio da Substituição de Liskov (Liskov Substitution Principle - LSP)",
            "L",
            "As classes derivadas devem ser substituíveis por suas classes base sem quebrar a aplicação.",
            "LSP: Classes derivadas devem ser substituíveis por suas classes base.\n\n// Ruim:\nclass Retangulo {\n    public virtual int Largura { get; set; }\n    public virtual int Altura { get; set; }\n    public int Area() => Largura * Altura;\n}\n\nclass Quadrado : Retangulo {\n    public override int Largura { set { base.Largura = base.Altura = value; } }\n    public override int Altura { set { base.Altura = base.Largura = value; } }\n}\n\n// Bom:\ninterface IForma { int Area(); }\nclass Retangulo : IForma { /* ... */ }\nclass Quadrado : IForma { /* ... */ }",
            "Mateus 5:17-18",
            "Não pensem que vim abolir a Lei ou os Profetas; não vim abolir, mas cumprir. Digo a verdade: Enquanto existirem céus e terra, de forma alguma desaparecerá da Lei a menor letra ou o menor traço, até que tudo se cumpra.",
            "Assim como Jesus cumpriu perfeitamente a Lei sem quebrar nenhum de seus princípios, as classes derivadas devem cumprir rigorosamente o contrato estabelecido por suas classes base. Se uma subclasse não pode ser usada no lugar de sua classe base sem causar comportamentos inesperados, o princípio de Liskov está sendo violado."
        ) { }
    }

    public class InterfaceSegregation : PrincipioSolid
    {
        public InterfaceSegregation() : base(
            id: 4,
            "Princípio da Segregação de Interface (Interface Segregation Principle - ISP)",
            "I",
            "Muitas interfaces específicas são melhores do que uma interface geral.",
            "ISP: Muitas interfaces específicas são melhores que uma geral.\n\n// Ruim:\ninterface IAnimal {\n    void Andar();\n    void Voar();\n    void Nadar();\n}\n\nclass Pato : IAnimal { /* ... */ }\nclass Peixe : IAnimal { /* ... */ } // Forçado a implementar Voar()!\n\n// Bom:\ninterface IAndador { void Andar(); }\ninterface IVoador { void Voar(); }\ninterface INadador { void Nadar(); }\n\nclass Pato : IAndador, IVoador, INadador { /* ... */ }\nclass Peixe : INadador { /* ... */ }",
            "1 Coríntios 12:4-11",
            "Há diferentes tipos de dons, mas o Espírito é o mesmo. Há diferentes tipos de ministérios, mas o Senhor é o mesmo. Há diferentes formas de atuação, mas é o mesmo Deus quem efetua tudo em todos. A cada um, porém, é dada a manifestação do Espírito, visando ao bem comum. Pelo Espírito, a um é dada a palavra de sabedoria; a outro, a palavra de conhecimento; a outro, fé; a outro, dons de curar; a outro, poder para operar milagres; a outro, profecia; a outro, discernimento de espíritos; a outro, variedade de línguas; e ainda a outro, interpretação de línguas. Todas essas coisas, porém, são realizadas pelo mesmo e único Espírito, e ele as distribui individualmente, a cada um, como quer.",
            "Assim como o Espírito Santo distribui diferentes dons espirituais de acordo com a necessidade e capacidade de cada um, nossas interfaces devem ser específicas e focadas, permitindo que as classes implementem apenas o que realmente precisam. Isso evita a criação de classes com métodos que não fazem sentido para elas, mantendo o código mais limpo e coeso."
        ) { }
    }

    public class DependencyInversion : PrincipioSolid
    {
        public DependencyInversion() : base(
            id: 5,
            "Princípio da Inversão de Dependência (Dependency Inversion Principle - DIP)",
            "D",
            "Dependa de abstrações, não de implementações concretas.",
            "DIP: Dependa de abstrações, não de implementações.\n\n// Ruim:\nclass PedidoService {\n    private readonly SqlDatabase _database;\n    public PedidoService() {\n        _database = new SqlDatabase(); // Dependência concreta\n    }\n}\n\n// Bom:\ninterface IRepositorio {\n    void Salvar(Pedido pedido);\n}\n\nclass PedidoService {\n    private readonly IRepositorio _repositorio;\n    public PedidoService(IRepositorio repositorio) { // Injeção de dependência\n        _repositorio = repositorio;\n    }\n}",
            "Provérbios 3:5-6",
            "Confie no Senhor de todo o seu coração e não se apoie em seu próprio entendimento; reconheça o Senhor em todos os seus caminhos, e ele endireitará as suas veredas.",
            "Assim como devemos depender de Deus e não apenas de nossa própria compreensão, no desenvolvimento de software devemos depender de abstrações (interfaces) em vez de implementações concretas. Isso torna nosso código mais flexível, testável e fácil de manter, permitindo que troquemos implementações sem afetar o código que as utiliza."
        ) { }
    }
}
