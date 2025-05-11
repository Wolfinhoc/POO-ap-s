Alunos: - Bruno Rocco Wolfardt	
        - Adriel Silveira Ostrovski
        - Orlando Felipe De Souza Vaz Dourado

# Gerenciador de Compromissos

Este projeto implementa uma aplicação de console em C# para gerenciar compromissos de usuários, permitindo o registro de participantes, criação de anotações e definição do local onde o compromisso será realizado.

---

## -------------------- Estrutura do Projeto -------------------
### ------------------- Usuario.cs -----------------------------

Classe responsável por representar o usuário responsável por um ou mais compromissos.

#### Propriedades:
- `string Nome`: Nome completo do usuário.
- `List<Compromisso> _compromissos`: Lista privada dos compromissos atribuídos ao usuário.
- `IReadOnlyCollection<Compromisso> Compromissos`: Exposição somente leitura da lista de compromissos.

#### Métodos:
- `AdicionarCompromisso(Compromisso compromisso)`: Adiciona um compromisso ao usuário com validação de duplicidade.

### ------------------------------ Compromisso.cs ------------------------------

Classe principal que representa um compromisso agendado, contendo informações de data, hora, responsável, local, participantes e anotações.

#### Atributos Privados:
- `_data`, `_hora`: Armazenam data e hora do compromisso.
- `_participantes`, `_anotacoes`: Listas privadas de participantes e anotações.

#### Propriedades:
- `string Data`: Data do compromisso com validação no formato "dd/MM/yyyy".
- `string Hora`: Hora do compromisso com validação no formato "hh:mm".
- `string Descricao`: Descrição do compromisso.
- `string Local`: Nome do local onde será realizado.

#### Métodos:
- Validações internas para data e hora.
- Participantes e anotações são adicionados através de métodos específicos (associação e composição).
- `ToString()`: Retorna representação amigável do compromisso.

---

### ------------------------------ Participante.cs ------------------------------

Classe que representa um participante de um compromisso.

#### Propriedades:
- `string Nome`: Nome do participante.
- `List<Compromisso> _compromissos`: Lista de compromissos em que participa.
- `IReadOnlyCollection<Compromisso> Compromissos`: Exposição somente leitura da lista.

#### Métodos:
- `AdicionarCompromisso(Compromisso compromisso)`: Associa o participante ao compromisso de forma bidirecional (associação N:N).

---

### ------------------------------ Anotacao.cs ------------------------------

Classe usada para registrar observações dentro de um compromisso. Essa classe é usada exclusivamente na composição de `Compromisso`.

#### Propriedades:
- `string Texto`: Texto da anotação.
- `DateTime DataCriacao`: Data e hora da criação da anotação (gerada automaticamente no construtor).

---

### ------------------------------ Local.cs ------------------------------

Classe que representa o local onde um compromisso será realizado.

#### Propriedades:
- `string Nome`: Nome do local (ex: "Sala 101", "Auditório").
- `int CapacidadeMaxima`: Número máximo de pessoas permitidas no local.

#### Métodos:
- `ValidarCapacidade(int quantidade)`: Verifica se o número informado ultrapassa a capacidade máxima.

---

## ------------------------------ Observações --------------------------------------

## ------------------------------ Tipos de Associação ------------------------------

- **Associação Simples**  
  A classe `Compromisso` está associada diretamente a um `Usuario` e a um `Local`, ambos definidos como propriedades.

- **Composição**  
  A classe `Compromisso` contém a lista de `Anotacao`. As anotações existem exclusivamente dentro do compromisso, sendo criadas e gerenciadas internamente.

- **Associação N:N**  
  Um `Compromisso` pode ter vários `Participante`s, e cada `Participante` pode estar em vários compromissos. A atualização é bidirecional, mantendo a consistência entre ambos os lados.

---

## ------------------------------ Encapsulamento das Coleções ------------------------------

- As listas de participantes, anotações e compromissos são privadas.
- São expostas apenas como `IReadOnlyCollection`, impedindo modificações externas.
- Isso garante:
  - Validações obrigatórias ao adicionar elementos.
  - Proteção da integridade dos dados.
  - Separação entre leitura e manipulação de dados, alinhado com o princípio de **encapsulamento** da POO.

---

## ------------------------------ Capacidade Máxima do Local ------------------------------

- A classe `Local` possui o método `ValidarCapacidade(int quantidade)` que é invocado antes de adicionar um novo participante ao compromisso.
- Se o número de participantes ultrapassar o valor definido em `CapacidadeMaxima`, uma exceção é lançada.
- Esse controle garante que o local não fique superlotado e mantém a integridade dos dados.

---

## ------------------------------ Organização por POO ------------------------------

O sistema foi estruturado com base nos princípios da Programação Orientada a Objetos:

- **Responsabilidade Única (SRP)**:  
  Cada classe possui uma responsabilidade clara. Ex: `Usuario` gerencia compromissos, `Compromisso` gerencia participantes e anotações.

- **Encapsulamento**:  
  As listas são protegidas contra alterações externas e só podem ser modificadas por métodos internos com validação.

- **Alta Coesão e Baixo Acoplamento**:  
  As classes estão bem coesas, fazendo apenas o que lhes é devido, e interagem por meio de associações controladas.

- **Composição e Associação**:  
  A modelagem respeita a natureza das relações entre entidades reais (ex: anotações não existem fora de um compromisso).
"""
