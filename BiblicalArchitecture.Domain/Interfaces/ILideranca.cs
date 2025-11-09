namespace BiblicalArchitecture.Domain.Interfaces
{
    // Exemplo de Interface Segregation Principle (ISP)
    public interface ILideranca
    {
        void Liderar();
    }

    public interface IEnsinamento
    {
        void Ensinar();
    }

    public interface IProfecia
    {
        void Profetizar();
    }

    // Exemplo: Moisés implementava todas as interfaces
    public class Moises : ILideranca, IEnsinamento, IProfecia
    {
        public void Liderar()
        {
            // "E Moisés tirou os filhos de Israel do Mar Vermelho" - Êxodo 15:22
        }

        public void Ensinar()
        {
            // "E estas palavras que hoje te ordeno estarão no teu coração; e as ensinarás..." - Deuteronômio 6:6-7
        }

        public void Profetizar()
        {
            // "E nunca mais se levantou em Israel profeta como Moisés" - Deuteronômio 34:10
        }
    }

    // Exemplo: Samuel implementava apenas duas interfaces
    public class Samuel : IEnsinamento, IProfecia
    {
        public void Ensinar()
        {
            // "E Samuel julgou a Israel todos os dias da sua vida" - 1 Samuel 7:15
        }

        public void Profetizar()
        {
            // "E crescia Samuel, e o Senhor era com ele, e não deixou cair em terra nenhuma de suas palavras" - 1 Samuel 3:19
        }
    }
}