export interface PassoGuia {
  titulo: string;
  descricao: string;
}

export const resumoPorSigla: Record<string, string[]> = {
  S: [
    'Uma classe = um motivo para mudar',
    'Validar, salvar e notificar ficam separados',
    'Facilita testes porque cada parte é isolada'
  ],
  O: [
    'Adicione comportamentos sem reescrever código',
    'Use estratégias para novos cenários',
    'Reduz risco ao evoluir o sistema'
  ],
  L: [
    'Classes filhas honram o contrato da base',
    'Evite tratamentos especiais para subclasses',
    'Substituir não deve quebrar o uso'
  ],
  I: [
    'Interfaces pequenas e focadas',
    'Cada classe implementa só o necessário',
    'Evita métodos “não suportados”'
  ],
  D: [
    'Camadas altas falam com abstrações',
    'Troque implementações sem tocar na regra',
    'Injeção de dependência facilita testes'
  ]
};

export const passosGuiados: Record<string, PassoGuia[]> = {
  S: [
    { titulo: 'Observe o fluxo principal', descricao: 'A classe de cadastro coordena o processo, mas delega cada tarefa.' },
    { titulo: 'Veja responsabilidades isoladas', descricao: 'Validador, repositório e serviço de e-mail têm funções únicas.' },
    { titulo: 'Perceba a troca fácil de peças', descricao: 'Basta trocar uma implementação sem mexer nas demais.' }
  ],
  O: [
    { titulo: 'Identifique a abstração', descricao: 'O contrato de frete define a regra geral.' },
    { titulo: 'Repare nas extensões', descricao: 'Cada classe adiciona um cálculo específico.' },
    { titulo: 'Note o uso estável', descricao: 'O serviço permanece o mesmo mesmo com novas opções.' }
  ],
  L: [
    { titulo: 'Separe comportamentos por interface', descricao: 'Nem toda ave precisa do método de voar.' },
    { titulo: 'Veja quem respeita o contrato', descricao: 'O pardal cumpre todos os requisitos de uma ave que voa.' },
    { titulo: 'Entenda o ajuste', descricao: 'O pinguim continua sendo ave sem quebrar o espetáculo.' }
  ],
  I: [
    { titulo: 'Comece pelas necessidades', descricao: 'Divida capacidades como imprimir, escanear e enviar fax.' },
    { titulo: 'Combine conforme o equipamento', descricao: 'A multifuncional usa todas, a simples só imprime.' },
    { titulo: 'Evite métodos vazios', descricao: 'Nenhuma classe precisa lançar “não suportado”.' }
  ],
  D: [
    { titulo: 'Observe as abstrações', descricao: 'Interfaces `ILogger` e `IPedidoRepository` são contratos.' },
    { titulo: 'Veja a inversão', descricao: 'O serviço recebe dependências prontas, não cria objetos.' },
    { titulo: 'Troque implementações sem dor', descricao: 'Basta injetar outro repositório para salvar em outro lugar.' }
  ]
};

export const ideiasPraticas: Record<string, string[]> = {
  S: [
    'Separe validação, persistência e comunicação em classes diferentes.',
    'Revise classes grandes e divida por responsabilidades.',
    'Use testes unitários para garantir cada peça isolada.'
  ],
  O: [
    'Prefira adicionar novas classes em vez de editar as existentes.',
    'Use padrões como Strategy para comportamentos variáveis.',
    'Planeje extensões futuras para manter o código estável.'
  ],
  L: [
    'Garanta que subclasses funcionem onde a base é esperada.',
    'Evite sobrescrever métodos apenas para lançar exceções.',
    'Considere interfaces diferentes quando comportamentos divergirem.'
  ],
  I: [
    'Crie interfaces pequenas e combine-as conforme necessário.',
    'Agrupe métodos por quem realmente usa.',
    'Busque classes sem métodos vazios: indica interface grande demais.'
  ],
  D: [
    'Dependa de interfaces mesmo quando só há uma implementação.',
    'Use injeção de dependência para montar serviços.',
    'Troque implementações concretas facilmente em testes.'
  ]
};
