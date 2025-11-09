namespace BiblicalArchitecture.Domain.Factories
{
    // Exemplo de Factory Method Pattern
    public abstract class LiderFactory
    {
        public abstract ILider CriarLider();
    }

    public interface ILider
    {
        string ObterTitulo();
        void Liderar();
    }

    // Implementações concretas
    public class ReiFactory : LiderFactory
    {
        public override ILider CriarLider()
        {
            return new Rei();
        }
    }

    public class JuizFactory : LiderFactory
    {
        public override ILider CriarLider()
        {
            return new Juiz();
        }
    }

    public class Rei : ILider
    {
        public string ObterTitulo()
        {
            return "Rei de Israel";
        }

        public void Liderar()
        {
            // "Davi pastoreou-os com integridade de coração" - Salmo 78:72
        }
    }

    public class Juiz : ILider
    {
        public string ObterTitulo()
        {
            return "Juiz de Israel";
        }

        public void Liderar()
        {
            // "O Senhor levantou juízes que os libertaram" - Juízes 2:16
        }
    }
}