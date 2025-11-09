using BiblicalArchitecture.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BiblicalArchitecture.Infrastructure.Data
{
    public static class ModuloSeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Verifica se já existem módulos no banco
                if (context.Modulos.Any())
                {
                    return; // Já tem dados
                }

                // Obtém os módulos iniciais
                var modulos = ObterModulosIniciais();

                // Adiciona os módulos ao contexto
                await context.Modulos.AddRangeAsync(modulos);
                
                // Salva as alterações no banco de dados
                await context.SaveChangesAsync();
            }
        }

        public static List<Modulo> ObterModulosIniciais()
        {
            var modulos = new List<Modulo>();

            // Módulo 1: Introdução
            var moduloIntroducao = new Modulo(
                "Introdução à Arquitetura de Software",
                "Conceitos fundamentais de arquitetura de software e sua importância no desenvolvimento de sistemas.",
                1
            );

            // Aula 1.1: Apresentação
            moduloIntroducao.AdicionarAula(new Aula(
                "Apresentação do Curso",
                "Visão geral do curso e objetivos de aprendizado.",
                "Bem-vindo ao curso de Arquitetura de Software baseado em princípios bíblicos. Neste curso, exploraremos como os princípios de design de software podem ser relacionados com lições e histórias da Bíblia.",
                1,
                1
            ));

            // Aula 1.2: O que é Arquitetura de Software?
            moduloIntroducao.AdicionarAula(new Aula(
                "O que é Arquitetura de Software?",
                "Entendendo o conceito e a importância da arquitetura de software.",
                "A arquitetura de software é como o projeto estrutural de um edifício. Assim como o Tabernáculo foi construído com um projeto específico (Êxodo 25-40), nossos sistemas de software precisam de uma base sólida e bem planejada.",
                15,
                2
            ));

            // Exemplo Bíblico 1: A Construção do Tabernáculo
            var exemploTabernaculo = new ExemploBiblico(
                "A Construção do Tabernáculo",
                "Êxodo 25-40",
                "Deus deu instruções detalhadas a Moisés sobre como construir o Tabernáculo, incluindo materiais, dimensões e propósitos específicos para cada elemento.",
                "Assim como Deus deu um projeto detalhado para o Tabernáculo, um bom arquiteto de software deve criar um design claro e bem documentado para seus sistemas."
            );
            moduloIntroducao.AdicionarExemplo(exemploTabernaculo);

            // Exemplo Bíblico 2: A Torre de Babel
            var exemploBabel = new ExemploBiblico(
                "A Torre de Babel",
                "Gênesis 11:1-9",
                "O povo tentou construir uma torre que chegasse aos céus, mas Deus confundiu suas línguas e o projeto falhou.",
                "Sem uma comunicação clara e um propósito bem definido, mesmo os projetos mais ambiciosos estão fadados ao fracasso. A arquitetura de software requer clareza de propósito e comunicação efetiva."
            );
            moduloIntroducao.AdicionarExemplo(exemploBabel);

            // Módulo 2: Princípios de Design
            var moduloPrincipios = new Modulo(
                "Princípios de Design de Software",
                "Aprenda os princípios fundamentais de design de software e como eles se relacionam com princípios bíblicos.",
                2
            );

            // Aulas do Módulo 2
            moduloPrincipios.AdicionarAula(new Aula(
                "SOLID - Princípios Básicos",
                "Entendendo os princípios SOLID de design orientado a objetos.",
                "Os princípios SOLID são como os Dez Mandamentos para o desenvolvimento de software. Eles nos guiam na criação de sistemas mais flexíveis, compreensíveis e fáceis de manter.",
                20,
                1
            ));

            // Exemplo Bíblico para o Módulo 2
            moduloPrincipios.AdicionarExemplo(new ExemploBiblico(
                "A Sabedoria de Salomão",
                "1 Reis 3:5-14",
                "Deus deu a Salomão sabedoria e inteligência extraordinárias, e uma imensidão de entendimento.",
                "Assim como Salomão buscou sabedoria para governar com justiça, devemos buscar sabedoria para criar sistemas bem estruturados e eficientes."
            ));

            modulos.Add(moduloIntroducao);
            modulos.Add(moduloPrincipios);

            return modulos;
        }
    }
}
