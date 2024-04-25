/*Vamos desenvolver um jogo?

Simples, um jogo de bingo.

As regras do bingo são as seguintes:

1 - As cartelas possuem 25 números escritos em ordem aleatória.( Feito )

2 - Os números sorteados vão de 1 a 99.

Se algum jogador completar uma linha a pontuação para todos passa a valer somente a coluna de qualquer cartela e vice-versa. (Depois)

A partir daí, só vale a pontuação de cartela cheia. ( depois)

Os sorteios devem acontecer até algum jogador completar a cartela (BINGO!). (depos)

São 3 possibilidades de pontos: (depos)

Ao completar uma linha, o jogador recebe 1 ponto.

Ao completar uma coluna, o jogador recebe 1 ponto.

Ao completar a cartela, o jogador recebe 5 pontos.

3 - Você vai precisar controlar o sorteio, onde não podem acontecer números repetidos, e também controlar as cartelas, onde cada cartela deve ter marcado os 
números sorteados para verificação do preenchimento da linha / coluna / cartela para contabilizar os pontos.

Ao final do jogo, deverá ser mostrado quem foram os jogadores vencedores e a pontuação de cada um.(penultimo)

Recursos opcionais: (Ultimo)

Cada jogador pode ter mais de uma cartela.
O jogo deve ser capaz de ser jogado por mais de 2 jogadores, onde o usuário informa no inicio do programa a quantidade de jogadores que ele deseja.*/

int linhaColuna = 5, maxSorteados = 25;
int[,] cartela;
int[] jaSorteados = new int[99];
int contadorJaSorteados = 0;

//Imprimir uma Cartela
void ImprimirMatriz(int[,] matriz, String mensagem)
{
    Console.WriteLine("\n" + mensagem);

    for (int linha = 0; linha < linhaColuna; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < linhaColuna; coluna++)
            Console.Write(matriz[linha, coluna] + " ");

    }

    Console.WriteLine();

}


//Criação De Uma Cartela
int[,] CriacaoCartela(){

    int[,] cartela = new int[linhaColuna, linhaColuna];
    int[] sorteadosParaCartela = new int[maxSorteados];
    int sorteadoAtual;
    int passador = 0;
    

    sorteadoAtual = new Random().Next(1, 99);
    sorteadosParaCartela[0] = sorteadoAtual;

    for (int i = 1; i < maxSorteados; i++)
    {
        sorteadoAtual = new Random().Next(1, 99);

        for (int j = 0; j < i; j++)
        {
            if (sorteadosParaCartela[j] == sorteadoAtual)
            {
                i--;
                break;
            }
            else
            {
                sorteadosParaCartela[i] = sorteadoAtual;
            }
        }

    }

    for (int linha = 0; linha < linhaColuna; linha++)
    {
        for(int coluna = 0; coluna < linhaColuna; coluna++)
        {
            cartela[linha, coluna] = sorteadosParaCartela[passador];
            passador++;
        }
    }

    return cartela;
}

//Sorteador Rodada
void Sorteador(){

    bool novoNumero = true;
    int sorteadoAtual;
   
    while (novoNumero)
    {
        sorteadoAtual = new Random().Next(1, 100);

        for (int i = 0; i < 99; i++)
        {
            if (sorteadoAtual == jaSorteados[i])
            {

                Sorteador();

            }
            else
            {
                jaSorteados[i] = sorteadoAtual;
                Console.WriteLine("Numero Sorteado: " + jaSorteados[i]);
                novoNumero = false;
                break;
            }
        }
    }
}


cartela = CriacaoCartela();

ImprimirMatriz(cartela, "Cartela");

while(contadorJaSorteados < 99)
{
    Sorteador();
    contadorJaSorteados++;
}