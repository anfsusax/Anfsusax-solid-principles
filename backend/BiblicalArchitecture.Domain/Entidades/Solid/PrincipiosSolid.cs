namespace BiblicalArchitecture.Domain.Entidades.Solid
{
    public class SingleResponsability : PrincipioSolid
    {
        public SingleResponsability() : base(
            id: 1,
            "Princípio da Responsabilidade Única (Single Responsibility Principle - SRP)",
            "S",
            "Uma classe deve ter apenas um motivo para mudar, ou seja, deve ter apenas uma responsabilidade.",
            """
namespace SolidPrinciples.SRP;

using System;
using System.Threading.Tasks;

public record User(string Name, string Email);

public interface IUserValidator
{
    bool IsValid(User user);
}

public class UserValidator : IUserValidator
{
    public bool IsValid(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            return false;

        if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
            return false;

        return true;
    }
}

public interface IUserRepository
{
    Task SaveAsync(User user);
}

public class SqlUserRepository : IUserRepository
{
    public Task SaveAsync(User user)
    {
        Console.WriteLine($"[Repository] Salvando {user.Name} no banco de dados.");
        return Task.CompletedTask;
    }
}

public interface IEmailSender
{
    Task SendWelcomeAsync(User user);
}

public class SmtpEmailSender : IEmailSender
{
    public Task SendWelcomeAsync(User user)
    {
        Console.WriteLine($"[Email] Enviando boas-vindas para {user.Email}.");
        return Task.CompletedTask;
    }
}

public class UserRegistrationService
{
    private readonly IUserValidator _validator;
    private readonly IUserRepository _repository;
    private readonly IEmailSender _emailSender;

    public UserRegistrationService(
        IUserValidator validator,
        IUserRepository repository,
        IEmailSender emailSender)
    {
        _validator = validator;
        _repository = repository;
        _emailSender = emailSender;
    }

    public async Task RegisterAsync(User user)
    {
        if (!_validator.IsValid(user))
            throw new InvalidOperationException("Usuário inválido.");

        await _repository.SaveAsync(user);
        await _emailSender.SendWelcomeAsync(user);
    }
}

public static class Program
{
    public static async Task Main()
    {
        var service = new UserRegistrationService(
            new UserValidator(),
            new SqlUserRepository(),
            new SmtpEmailSender());

        await service.RegisterAsync(new User("Débora", "debora@example.com"));
    }
}
""",
            "1 Coríntios 12:12-27",
            "Porque, assim como o corpo é um e tem muitos membros, e todos os membros do corpo, embora muitos, formam um só corpo, assim também é Cristo. Pois em um só corpo todos nós fomos batizados em um único Espírito: quer judeus, quer gregos, quer escravos, quer livres. E a todos nós foi dado beber de um único Espírito. O corpo não é feito de um só membro, mas de muitos.",
            "Assim como cada parte do corpo tem uma função específica (olhos para ver, ouvidos para ouvir), no código cada classe deve ter uma única responsabilidade bem definida. Isso torna o sistema mais organizado, fácil de manter e testar.",
            new[]
            {
                new BlocoCodigoResponsabilidade(
                    "Modelo de dados",
                    "model",
                    "public record User(string Name, string Email);",
                    "Representa os dados do usuário de forma imutável."
                ),
                new BlocoCodigoResponsabilidade(
                    "Validação de usuário",
                    "validator",
                    """
public interface IUserValidator
{
    bool IsValid(User user);
}

public class UserValidator : IUserValidator
{
    public bool IsValid(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            return false;

        if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
            return false;

        return true;
    }
}
""",
                    "Toda a lógica de validação fica isolada aqui."
                ),
                new BlocoCodigoResponsabilidade(
                    "Persistência",
                    "repository",
                    """
public interface IUserRepository
{
    Task SaveAsync(User user);
}

public class SqlUserRepository : IUserRepository
{
    public Task SaveAsync(User user)
    {
        Console.WriteLine($"[Repository] Salvando {user.Name} no banco de dados.");
        return Task.CompletedTask;
    }
}
""",
                    "Responsável apenas por salvar dados."
                ),
                new BlocoCodigoResponsabilidade(
                    "Infraestrutura de e-mail",
                    "infrastructure",
                    """
public interface IEmailSender
{
    Task SendWelcomeAsync(User user);
}

public class SmtpEmailSender : IEmailSender
{
    public Task SendWelcomeAsync(User user)
    {
        Console.WriteLine($"[Email] Enviando boas-vindas para {user.Email}.");
        return Task.CompletedTask;
    }
}
""",
                    "Cuida somente do envio de notificações."
                ),
                new BlocoCodigoResponsabilidade(
                    "Regra de negócio",
                    "service",
                    """
public class UserRegistrationService
{
    private readonly IUserValidator _validator;
    private readonly IUserRepository _repository;
    private readonly IEmailSender _emailSender;

    public UserRegistrationService(
        IUserValidator validator,
        IUserRepository repository,
        IEmailSender emailSender)
    {
        _validator = validator;
        _repository = repository;
        _emailSender = emailSender;
    }

    public async Task RegisterAsync(User user)
    {
        if (!_validator.IsValid(user))
            throw new InvalidOperationException("Usuário inválido.");

        await _repository.SaveAsync(user);
        await _emailSender.SendWelcomeAsync(user);
    }
}
""",
                    "Orquestra as dependências, mantendo cada responsabilidade separada."
                ),
                new BlocoCodigoResponsabilidade(
                    "Ponto de entrada",
                    "bootstrap",
                    """
public static class Program
{
    public static async Task Main()
    {
        var service = new UserRegistrationService(
            new UserValidator(),
            new SqlUserRepository(),
            new SmtpEmailSender());

        await service.RegisterAsync(new User("Débora", "debora@example.com"));
    }
}
""",
                    "Configura as dependências e executa o fluxo."
                )
            }
        ) { }
    }

    public class OpenClosed : PrincipioSolid
    {
        public OpenClosed() : base(
            id: 2,
            "Princípio Aberto/Fechado (Open/Closed Principle - OCP)",
            "O",
            "As entidades do software devem estar abertas para extensão, mas fechadas para modificação.",
            """
namespace SolidPrinciples.OCP;

using System;
using System.Collections.Generic;

public record Order(decimal Total, decimal Weight, string DestinationZip);

public abstract class ShippingStrategy
{
    public abstract decimal Calculate(Order order);
}

public class StandardShipping : ShippingStrategy
{
    public override decimal Calculate(Order order)
        => Math.Max(15m, order.Weight * 2m);
}

public class ExpressShipping : ShippingStrategy
{
    public override decimal Calculate(Order order)
        => Math.Max(40m, order.Weight * 3.5m);
}

public class LocalPickupShipping : ShippingStrategy
{
    public override decimal Calculate(Order order) => 0m;
}

public class ShippingService
{
    private readonly Dictionary<string, ShippingStrategy> _strategies = new();

    public ShippingService()
    {
        RegisterStrategy("standard", new StandardShipping());
        RegisterStrategy("express", new ExpressShipping());
    }

    public void RegisterStrategy(string key, ShippingStrategy strategy)
        => _strategies[key] = strategy;

    public decimal CalculateCost(string option, Order order)
    {
        if (!_strategies.TryGetValue(option, out var strategy))
            throw new InvalidOperationException($"Opção '{option}' não suportada.");

        return strategy.Calculate(order);
    }
}

public static class Program
{
    public static void Main()
    {
        var service = new ShippingService();
        service.RegisterStrategy("pickup", new LocalPickupShipping());

        var order = new Order(250m, 10m, "01000-000");
        Console.WriteLine($"Entrega expressa: R$ {service.CalculateCost(\"express\", order)}");
        Console.WriteLine($"Retirada local: R$ {service.CalculateCost(\"pickup\", order)}");
    }
}
""",
            "Gênesis 6:14-16",
            "Faça para você uma arca de tábuas de cipreste: você fará compartimentos na arca e a revestirá de piche por dentro e por fora. Esta é a maneira como você a fará: a arca terá cento e trinta e cinco metros de comprimento, vinte e dois metros e meio de largura e treze metros e meio de altura. Você fará um teto para a arca, deixando uma abertura de quarenta e cinco centímetros entre o teto e as laterais. Coloque uma porta na lateral da arca. Faça um andar inferior, um segundo e um terceiro.",
            "Assim como a arca de Noé foi projetada com uma estrutura básica que podia acomodar diferentes tipos de animais sem precisar ser modificada, nosso código deve ser estruturado para permitir a adição de novos comportamentos através de extensões, sem modificar o código existente.",
            new[]
            {
                new BlocoCodigoResponsabilidade(
                    "Modelo do pedido",
                    "model",
                    "public record Order(decimal Total, decimal Weight, string DestinationZip);",
                    "Agrupa os dados necessários para calcular frete."
                ),
                new BlocoCodigoResponsabilidade(
                    "Contrato de cálculo",
                    "contract",
                    """
public abstract class ShippingStrategy
{
    public abstract decimal Calculate(Order order);
}
""",
                    "Define o ponto de extensão sem conhecer implementações futuras."
                ),
                new BlocoCodigoResponsabilidade(
                    "Estratégias concretas",
                    "extension",
                    """
public class StandardShipping : ShippingStrategy
{
    public override decimal Calculate(Order order)
        => Math.Max(15m, order.Weight * 2m);
}

public class ExpressShipping : ShippingStrategy
{
    public override decimal Calculate(Order order)
        => Math.Max(40m, order.Weight * 3.5m);
}

public class LocalPickupShipping : ShippingStrategy
{
    public override decimal Calculate(Order order) => 0m;
}
""",
                    "Novas opções de frete são adicionadas sem tocar no código antigo."
                ),
                new BlocoCodigoResponsabilidade(
                    "Serviço orquestrador",
                    "service",
                    """
public class ShippingService
{
    private readonly Dictionary<string, ShippingStrategy> _strategies = new();

    public ShippingService()
    {
        RegisterStrategy("standard", new StandardShipping());
        RegisterStrategy("express", new ExpressShipping());
    }

    public void RegisterStrategy(string key, ShippingStrategy strategy)
        => _strategies[key] = strategy;

    public decimal CalculateCost(string option, Order order)
    {
        if (!_strategies.TryGetValue(option, out var strategy))
            throw new InvalidOperationException($"Opção '{option}' não suportada.");

        return strategy.Calculate(order);
    }
}
""",
                    "Consome as extensões via dicionário, permanecendo fechado para mudanças."
                ),
                new BlocoCodigoResponsabilidade(
                    "Demonstração",
                    "bootstrap",
                    """
public static class Program
{
    public static void Main()
    {
        var service = new ShippingService();
        service.RegisterStrategy("pickup", new LocalPickupShipping());

        var order = new Order(250m, 10m, "01000-000");
        Console.WriteLine($"Entrega expressa: R$ {service.CalculateCost("express", order)}");
        Console.WriteLine($"Retirada local: R$ {service.CalculateCost("pickup", order)}");
    }
}
""",
                    "Faz uso das estratégias sem alterações no serviço principal."
                )
            }
        ) { }
    }

    public class LiskovSubstitution : PrincipioSolid
    {
        public LiskovSubstitution() : base(
            id: 3,
            "Princípio da Substituição de Liskov (Liskov Substitution Principle - LSP)",
            "L",
            "As classes derivadas devem ser substituíveis por suas classes base sem quebrar a aplicação.",
            """
namespace SolidPrinciples.LSP;

using System;
using System.Collections.Generic;

public interface IBird
{
    void Eat();
}

public interface IFlyingBird : IBird
{
    void Fly();
}

public class Sparrow : IFlyingBird
{
    public void Eat() => Console.WriteLine("O pardal está bicando sementes.");

    public void Fly() => Console.WriteLine("O pardal está voando.");
}

public class Penguin : IBird
{
    public void Eat() => Console.WriteLine("O pinguim está pescando no gelo.");
}

public class BirdShow
{
    public void StartFlightShow(IEnumerable<IFlyingBird> birds)
    {
        foreach (var bird in birds)
        {
            bird.Fly();
        }
    }
}

public static class Program
{
    public static void Main()
    {
        var birdsThatFly = new List<IFlyingBird>
        {
            new Sparrow()
            // Um pinguim não pode ser adicionado aqui, porque não implementa IFlyingBird.
        };

        var show = new BirdShow();
        show.StartFlightShow(birdsThatFly);

        IBird penguin = new Penguin(); // Ainda conseguimos tratar o pinguim como uma ave.
        penguin.Eat();
    }
}
""",
            "Mateus 5:17-18",
            "Não pensem que vim abolir a Lei ou os Profetas; não vim abolir, mas cumprir. Digo a verdade: Enquanto existirem céus e terra, de forma alguma desaparecerá da Lei a menor letra ou o menor traço, até que tudo se cumpra.",
            "Assim como Jesus cumpriu perfeitamente a Lei sem quebrar nenhum de seus princípios, as classes derivadas devem cumprir rigorosamente o contrato estabelecido por suas classes base. Se uma subclasse não pode ser usada no lugar de sua classe base sem causar comportamentos inesperados, o princípio de Liskov está sendo violado.",
            new[]
            {
                new BlocoCodigoResponsabilidade(
                    "Contrato das aves",
                    "contract",
                    """
public interface IBird
{
    void Eat();
}

public interface IFlyingBird : IBird
{
    void Fly();
}
""",
                    "Define comportamentos separados: nem toda ave precisa voar."
                ),
                new BlocoCodigoResponsabilidade(
                    "Ave que voa corretamente",
                    "implementation",
                    """
public class Sparrow : IFlyingBird
{
    public void Eat() => Console.WriteLine("O pardal está bicando sementes.");

    public void Fly() => Console.WriteLine("O pardal está voando.");
}
""",
                    "Cumpre o contrato de `IFlyingBird` sem surpresas."
                ),
                new BlocoCodigoResponsabilidade(
                    "Ave que não voa",
                    "implementation",
                    """
public class Penguin : IBird
{
    public void Eat() => Console.WriteLine("O pinguim está pescando no gelo.");
}
""",
                    "Não implementa `Fly`, evitando exceções em tempo de execução."
                ),
                new BlocoCodigoResponsabilidade(
                    "Uso seguro do contrato",
                    "service",
                    """
public class BirdShow
{
    public void StartFlightShow(IEnumerable<IFlyingBird> birds)
    {
        foreach (var bird in birds)
        {
            bird.Fly();
        }
    }
}
""",
                    "Aceita apenas aves que sabem voar, mantendo a coerência do contrato."
                ),
                new BlocoCodigoResponsabilidade(
                    "Demonstração",
                    "bootstrap",
                    """
public static class Program
{
    public static void Main()
    {
        var birdsThatFly = new List<IFlyingBird>
        {
            new Sparrow()
        };

        var show = new BirdShow();
        show.StartFlightShow(birdsThatFly);

        IBird penguin = new Penguin();
        penguin.Eat();
    }
}
""",
                    "Mostra como cada classe pode ser usada sem quebrar expectativas."
                )
            }
        ) { }
    }

    public class InterfaceSegregation : PrincipioSolid
    {
        public InterfaceSegregation() : base(
            id: 4,
            "Princípio da Segregação de Interface (Interface Segregation Principle - ISP)",
            "I",
            "Muitas interfaces específicas são melhores do que uma interface geral.",
            """
namespace SolidPrinciples.ISP;

using System;

public class Document
{
    public string Content { get; init; } = string.Empty;
}

public interface IPrinter
{
    void Print(Document document);
}

public interface IScanner
{
    void Scan(Document document);
}

public interface IFax
{
    void SendFax(Document document);
}

public class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print(Document document) => Console.WriteLine("Imprimindo documento...");
    public void Scan(Document document) => Console.WriteLine("Digitalizando documento...");
    public void SendFax(Document document) => Console.WriteLine("Enviando fax...");
}

public class SimplePrinter : IPrinter
{
    public void Print(Document document) => Console.WriteLine("Impressora simples: impressão concluída.");
}

public static class Program
{
    public static void Main()
    {
        Document doc = new() { Content = "Contrato confidencial" };

        IPrinter printer = new SimplePrinter();
        printer.Print(doc); // Não obriga a implementar métodos desnecessários.

        MultiFunctionPrinter officeDevice = new();
        officeDevice.Scan(doc);
    }
}
""",
            "1 Coríntios 12:4-11",
            "Há diferentes tipos de dons, mas o Espírito é o mesmo. Há diferentes tipos de ministérios, mas o Senhor é o mesmo. Há diferentes formas de atuação, mas é o mesmo Deus quem efetua tudo em todos. A cada um, porém, é dada a manifestação do Espírito, visando ao bem comum. Pelo Espírito, a um é dada a palavra de sabedoria; a outro, a palavra de conhecimento; a outro, fé; a outro, dons de curar; a outro, poder para operar milagres; a outro, profecia; a outro, discernimento de espíritos; a outro, variedade de línguas; e ainda a outro, interpretação de línguas. Todas essas coisas, porém, são realizadas pelo mesmo e único Espírito, e ele as distribui individualmente, a cada um, como quer.",
            "Assim como o Espírito Santo distribui diferentes dons espirituais de acordo com a necessidade e capacidade de cada um, nossas interfaces devem ser específicas e focadas, permitindo que as classes implementem apenas o que realmente precisam. Isso evita a criação de classes com métodos que não fazem sentido para elas, mantendo o código mais limpo e coeso.",
            new[]
            {
                new BlocoCodigoResponsabilidade(
                    "Documento simples",
                    "model",
                    """
public class Document
{
    public string Content { get; init; } = string.Empty;
}
""",
                    "Objeto que trafega entre as interfaces."
                ),
                new BlocoCodigoResponsabilidade(
                    "Interfaces pequenas",
                    "contract",
                    """
public interface IPrinter
{
    void Print(Document document);
}

public interface IScanner
{
    void Scan(Document document);
}

public interface IFax
{
    void SendFax(Document document);
}
""",
                    "Divide capacidades para que cada classe implemente só o necessário."
                ),
                new BlocoCodigoResponsabilidade(
                    "Equipamento multifuncional",
                    "implementation",
                    """
public class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print(Document document) => Console.WriteLine("Imprimindo documento...");
    public void Scan(Document document) => Console.WriteLine("Digitalizando documento...");
    public void SendFax(Document document) => Console.WriteLine("Enviando fax...");
}
""",
                    "Implementa várias interfaces porque tem suporte a todas as funções."
                ),
                new BlocoCodigoResponsabilidade(
                    "Equipamento simples",
                    "implementation",
                    """
public class SimplePrinter : IPrinter
{
    public void Print(Document document) => Console.WriteLine("Impressora simples: impressão concluída.");
}
""",
                    "Imprime sem precisar declarar métodos inúteis."
                ),
                new BlocoCodigoResponsabilidade(
                    "Demonstração",
                    "bootstrap",
                    """
public static class Program
{
    public static void Main()
    {
        Document doc = new() { Content = "Contrato confidencial" };

        IPrinter printer = new SimplePrinter();
        printer.Print(doc);

        MultiFunctionPrinter officeDevice = new();
        officeDevice.Scan(doc);
    }
}
""",
                    "Mostra como cada classe usa apenas as interfaces relevantes."
                )
            }
        ) { }
    }

    public class DependencyInversion : PrincipioSolid
    {
        public DependencyInversion() : base(
            id: 5,
            "Princípio da Inversão de Dependência (Dependency Inversion Principle - DIP)",
            "D",
            "Dependa de abstrações, não de implementações concretas.",
            """
namespace SolidPrinciples.DIP;

using System;
using System.Threading.Tasks;

public record Pedido(int Id, string Cliente);

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[LOG] {message}");
}

public interface IPedidoRepository
{
    Task SaveAsync(Pedido pedido);
}

public class InMemoryPedidoRepository : IPedidoRepository
{
    public Task SaveAsync(Pedido pedido)
    {
        Console.WriteLine($"[Repository] Pedido {pedido.Id} salvo em memória.");
        return Task.CompletedTask;
    }
}

public class PedidoService
{
    private readonly ILogger _logger;
    private readonly IPedidoRepository _repository;

    public PedidoService(ILogger logger, IPedidoRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task ProcessarAsync(Pedido pedido)
    {
        _logger.Log($"Processando pedido {pedido.Id} para {pedido.Cliente}.");
        await _repository.SaveAsync(pedido);
        _logger.Log($"Pedido {pedido.Id} processado.");
    }
}

public static class Program
{
    public static async Task Main()
    {
        var service = new PedidoService(
            new ConsoleLogger(),
            new InMemoryPedidoRepository());

        await service.ProcessarAsync(new Pedido(42, "Ana"));
    }
}
""",
            "Provérbios 3:5-6",
            "Confie no Senhor de todo o seu coração e não se apoie em seu próprio entendimento; reconheça o Senhor em todos os seus caminhos, e ele endireitará as suas veredas.",
            "Assim como devemos depender de Deus e não apenas de nossa própria compreensão, no desenvolvimento de software devemos depender de abstrações (interfaces) em vez de implementações concretas. Isso torna nosso código mais flexível, testável e fácil de manter, permitindo que troquemos implementações sem afetar o código que as utiliza.",
            new[]
            {
                new BlocoCodigoResponsabilidade(
                    "Modelo de pedido",
                    "model",
                    "public record Pedido(int Id, string Cliente);",
                    "Define os dados da compra processada."
                ),
                new BlocoCodigoResponsabilidade(
                    "Contrato de logging",
                    "contract",
                    """
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[LOG] {message}");
}
""",
                    "Camada alta fala apenas com a abstração, escolhendo qualquer implementação."
                ),
                new BlocoCodigoResponsabilidade(
                    "Contrato de persistência",
                    "contract",
                    """
public interface IPedidoRepository
{
    Task SaveAsync(Pedido pedido);
}

public class InMemoryPedidoRepository : IPedidoRepository
{
    public Task SaveAsync(Pedido pedido)
    {
        Console.WriteLine($"[Repository] Pedido {pedido.Id} salvo em memória.");
        return Task.CompletedTask;
    }
}
""",
                    "Permite substituir o armazenamento sem alterar a regra de negócio."
                ),
                new BlocoCodigoResponsabilidade(
                    "Regra de negócio",
                    "service",
                    """
public class PedidoService
{
    private readonly ILogger _logger;
    private readonly IPedidoRepository _repository;

    public PedidoService(ILogger logger, IPedidoRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task ProcessarAsync(Pedido pedido)
    {
        _logger.Log($"Processando pedido {pedido.Id} para {pedido.Cliente}.");
        await _repository.SaveAsync(pedido);
        _logger.Log($"Pedido {pedido.Id} processado.");
    }
}
""",
                    "Depende só de interfaces, cumprindo a inversão de dependência."
                ),
                new BlocoCodigoResponsabilidade(
                    "Configuração de execução",
                    "bootstrap",
                    """
public static class Program
{
    public static async Task Main()
    {
        var service = new PedidoService(
            new ConsoleLogger(),
            new InMemoryPedidoRepository());

        await service.ProcessarAsync(new Pedido(42, "Ana"));
    }
}
""",
                    "Injeta as dependências concretas na borda da aplicação."
                )
            }
        ) { }
    }
}
