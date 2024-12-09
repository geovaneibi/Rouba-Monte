# Jogo de Cartas: Rouba Montes

Este projeto em C# simula o jogo de cartas **Rouba Montes**, onde jogadores competem para roubar montes de outros participantes, retirando cartas do **monte de compras** e utilizando diversas estratégias baseadas na carta da vez. O sistema foi desenvolvido com foco no uso de estruturas de dados, como **fila circular**, **pilhas** e **listas flexíveis**, implementadas manualmente sem o uso de coleções prontas da biblioteca .NET.

## Funcionalidades

- **Baralho:** Composto por 52 cartas numeradas de 1 a 13 (Ás, 2-10, Valete, Dama e Rei), sem distinção de naipes (Copas, Espadas, Ouros, Paus).
- **Jogadores:** Número configurável de jogadores, cada um com seu próprio monte de cartas.
- **Fila Circular:** Os jogadores jogam em sequência, com turnos alternados de forma circular.
- **Ações no Jogo:**
  - **Roubo de Monte:** Os jogadores podem roubar o monte de outro jogador se a carta da vez for igual ao topo do monte do adversário.
  - **Área de Descarte:** Os jogadores podem pegar cartas da área de descarte se forem iguais à carta da vez.
  - **Inserção no Monte:** A carta da vez pode ser adicionada ao topo do monte do jogador se for igual à carta do topo.
  - **Descarte:** Se nenhuma condição for atendida, a carta da vez é descartada.
- **Sistema de Turnos:** O jogo termina quando o **monte de compras** acaba. O jogador com mais cartas no final vence.

## Estruturas de Dados Utilizadas

- **Fila Circular:** Gerencia a ordem de jogadas dos jogadores, permitindo alternar turnos de forma eficiente.
- **Pilha:** Representa os montes de cartas dos jogadores, seguindo a lógica LIFO (Last In, First Out).
- **Lista Flexível:** Gerencia a área de descarte, permitindo uma manipulação dinâmica das cartas descartadas.

## Objetivo do Projeto

O objetivo deste projeto é praticar a implementação de estruturas de dados em C#, aplicando conceitos de programação como manipulação de arrays, listas, pilhas e filas. O jogo serve como uma simulação divertida e simples para consolidar habilidades relacionadas a lógica de jogo, controle de turnos e manipulação eficiente de dados.

## Como Jogar

1. Clone o repositório:
   ```bash
   git clone https://github.com/geovaneibi/Rouba-Monte
   ```
2. Abra o projeto no Visual Studio ou em outro editor de C#.
3. Compile e execute o programa.
4. Siga as instruções no console para configurar o número de jogadores e iniciar o jogo.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação principal.
- **.NET**: Framework utilizado para o desenvolvimento.
- **Estruturas de Dados:** Fila Circular, Pilha, Lista Flexível.

## Licença

Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT).

