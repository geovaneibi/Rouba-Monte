# Jogo de Cartas: Rouba Montes

Este projeto em C# simula o jogo de cartas **Rouba Montes**, onde os jogadores tentam roubar montes de outros jogadores. O sistema utiliza conceitos de estruturas de dados como **fila circular**, **pilha** e **listas** para simular o jogo.

## Funcionalidades:
Baralho: Composto por 52 cartas numeradas de 1 a 13 (Ás, 2-10, Valete, Dama e Rei), sem distinção de naipes (Copas, Espadas, Ouros, Paus).
Jogadores: Número configurável de jogadores, cada um com seu próprio monte de cartas.
Fila Circular: Os jogadores jogam em sequência, com turnos alternados de forma circular.
Ações no Jogo:
Roubo de Monte: Os jogadores podem roubar o monte de outro jogador se a carta da vez for igual ao topo do monte do adversário.
Área de Descarte: Os jogadores podem pegar cartas da área de descarte se forem iguais à carta da vez.
Inserção no Monte: A carta da vez pode ser adicionada ao topo do monte do jogador se for igual à carta do topo.
Descarte: Se nenhuma condição for atendida, a carta da vez é descartada.
Sistema de Turnos: O jogo termina quando o monte de compras acaba. O jogador com mais cartas no final vence.
## Estruturas de Dados:
- **Fila Circular**
- **Pilha**
- **Lista Flexível**

## Como Jogar:
1. Clone o repositório.
2. Abra no Visual Studio e execute o código.
3. Siga as instruções no console.

## Licença:
MIT License
