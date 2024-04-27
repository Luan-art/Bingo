﻿/*Vamos desenvolver um jogo?

Simples, um jogo de bingo.

As regras do bingo são as seguintes:

1 - As cartelas possuem 25 números escritos em ordem aleatória.( Feito )

2 - Os números sorteados vão de 1 a 99. (feito)

Se algum jogador completar uma linha a pontuação para todos passa a valer somente a coluna de qualquer cartela e vice-versa. (Depois) (feito)

A partir daí, só vale a pontuação de cartela cheia. ( depois) (Feito)

Os sorteios devem acontecer até algum jogador completar a cartela (BINGO!). (depos) (Feito)

São 3 possibilidades de pontos: (depos) (feito)

Ao completar uma linha, o jogador recebe 1 ponto.

Ao completar uma coluna, o jogador recebe 1 ponto.

Ao completar a cartela, o jogador recebe 5 pontos.

3 - Você vai precisar controlar o sorteio, onde não podem acontecer números repetidos, e também controlar as cartelas, onde cada cartela deve ter marcado os 
números sorteados para verificação do preenchimento da linha / coluna / cartela para contabilizar os pontos.

Ao final do jogo, deverá ser mostrado quem foram os jogadores vencedores e a pontuação de cada um.(penultimo) 

Recursos opcionais: (Ultimo)

Cada jogador pode ter mais de uma cartela.
O jogo deve ser capaz de ser jogado por mais de 2 jogadores, onde o usuário informa no inicio do programa a quantidade de jogadores que ele deseja.*/

int linhaColuna = 5, maxSorteados = 25, escopoNumero = 25, marcadosCartela = 0, variavelParaContinuarJogando = 0, numeroRodada;
int nJogadores = NumeroJogadores(), escopoSorteio = 99;
String[] jogadores = new String[nJogadores];
int[] pontosJogador = new int[nJogadores];
int[,,] cartela = new int[linhaColuna, linhaColuna, nJogadores];
int[] jaSorteados = new int[escopoSorteio], acheiNaTabela = new int[nJogadores];
int[,] pontosLinha = new int[linhaColuna, nJogadores], pontosColuna = new int[linhaColuna, nJogadores];
bool fezLinha = false, fezColuna = false, fezTabela = false, continuaJogando = true;


//Imprimir uma Cartela
void ImprimirMatriz(int[,,] matriz, String mensagem, int qualMatriz, int[] jaSorteados)
{
    bool sorteadosAnteriormente;

    Console.WriteLine("\n" + mensagem);

    for (int linha = 0; linha < linhaColuna; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < linhaColuna; coluna++)
        {
            sorteadosAnteriormente = false;

            for (int verificador = 0; verificador < numeroRodada; verificador++)
            {
                if (matriz[linha, coluna, qualMatriz] == jaSorteados[verificador])
                {
                    sorteadosAnteriormente = true;
                    break;
                }

            }

            if (sorteadosAnteriormente)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(matriz[linha, coluna, qualMatriz] + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(matriz[linha, coluna, qualMatriz] + " ");
            }

        }
    }

    Console.WriteLine();

}


//sortearAleatoriamente
int[] Sortear(int maximo)
{
    int[] sorteados = new int[maximo];

    int sorteadoAtual;

    sorteadoAtual = new Random().Next(1, escopoSorteio + 1);
    sorteados[0] = sorteadoAtual;

    for (int i = 1; i < maximo; i++)
    {
        sorteadoAtual = new Random().Next(1, escopoSorteio + 1);

        for (int j = 0; j < i; j++)
        {
            if (sorteados[j] == sorteadoAtual)
            {
                i--;
                break;
            }
            else
            {
                sorteados[i] = sorteadoAtual;
            }
        }

    }

    return sorteados;
}

//Criação De Uma Cartela
int[,,] CriacaoCartela(int qualMatriz)
{

    int[] sorteadosParaCartela;
    int passador = 0;

    sorteadosParaCartela = Sortear(maxSorteados);

    for (int linha = 0; linha < linhaColuna; linha++)
    {
        for (int coluna = 0; coluna < linhaColuna; coluna++, passador++)
        {
            cartela[linha, coluna, qualMatriz] = sorteadosParaCartela[passador];

        }
    }

    return cartela;
}

//Verifica pontos na Tabela toda
int VerificarTabela(int[,,] cartela, int indiceSorteado, int qualMatriz)
{
    if (!fezTabela)
    {
        for (int linha = 0; linha < linhaColuna; linha++)
        {
            for (int coluna = 0; coluna < linhaColuna; coluna++)
            {
                if (cartela[linha, coluna, qualMatriz] == jaSorteados[indiceSorteado])
                {
                    acheiNaTabela[qualMatriz]++;
                }
            }
        }
    }
    return acheiNaTabela[qualMatriz];
}

//Verifica pontos em cada Coluna
void VerificarColunas(int[,,] cartela, int indiceSorteado, int qualMatriz)
{
    if (!fezColuna)
    {
        for (int linha = 0; linha < linhaColuna; linha++)
        {
            for (int coluna = 0; coluna < linhaColuna; coluna++)
            {
                if (cartela[linha, coluna, qualMatriz] == jaSorteados[indiceSorteado])
                {
                    pontosColuna[coluna, qualMatriz]++;
                       
                }
            }

        }

        for (int colunas = 0; colunas < linhaColuna; colunas++)
        {
            if (pontosColuna[colunas, qualMatriz] == linhaColuna)
            {
                Console.WriteLine("FeZ Coluna!!!Parabéns" + jogadores[qualMatriz]);
                pontosJogador[qualMatriz]++;
                fezColuna = true;
            }
        }
    }
}

//Verifica pontos em cada Linha
void VerificarLinhas(int[,,] cartela, int indiceSorteado, int qualMatriz)
{
    if (!fezLinha)
    {
        for (int coluna = 0; coluna < linhaColuna; coluna++)
        {
            for (int linha = 0; linha < linhaColuna; linha++)
            {
                if (cartela[linha, coluna, qualMatriz] == jaSorteados[indiceSorteado])
                {
                    pontosLinha[linha, qualMatriz]++;
                }
            }

        }

        for (int linhas = 0; linhas < linhaColuna; linhas++)
        {
            if (pontosLinha[linhas, qualMatriz] == linhaColuna)
            {
                Console.WriteLine("FeZ Linha!!!Parabéns " + jogadores[qualMatriz]);
                pontosJogador[qualMatriz]++;
                fezLinha = true;
            }
        }
    }
}

//Identifica Jogadores por nome e armazena num vetor de nomes
String[] IdentificarJogador()
{
    int numeroJogador = 0;
    String[] nomesJogadores = new String[nJogadores];

    do
    {
        Console.WriteLine("Bem vindo ao Bingo, digite seu nome: ");
        nomesJogadores[numeroJogador] = Console.ReadLine();
        numeroJogador++;

    } while (numeroJogador < nomesJogadores.Length);

    return nomesJogadores;
}

int NumeroJogadores()
{
    int numeroJogadores;
    Console.WriteLine("Digite o numero de jogadores: ");
    numeroJogadores = int.Parse(Console.ReadLine());

    return numeroJogadores;
}

/*int NumeroCartelas()
{
    int numeroCartelas;
    Console.WriteLine("Digite o numero de Cartelas: ");
    numeroCartelas = int.Parse(Console.ReadLine());

    return numeroCartelas;
}*/

jogadores = IdentificarJogador();

do
{
    Console.Clear();
    jaSorteados = Sortear(escopoSorteio);
    numeroRodada = 0;
    continuaJogando = true;

    for (int i = 0; i < jogadores.Length; i++)
    {
        Console.WriteLine($"\nEssa e a sua cartela {jogadores[i]}\n " +
            $"Bom jogo!");
        cartela = CriacaoCartela(i);
        ImprimirMatriz(cartela, "Cartela", i, jaSorteados);
    }


    
    for (int i = 0; i < escopoSorteio && !fezTabela; i++)
    {
        numeroRodada++;
        Console.ReadLine();
        Console.WriteLine("\nNumero Sorteado " + jaSorteados[i]);

        for (int j = 0; j < jogadores.Length; j++)
        {
            marcadosCartela = VerificarTabela(cartela, i, j);
            ImprimirMatriz(cartela, "Sua Cartela Atualiza ", j, jaSorteados);
    


            if (marcadosCartela == 25)
            {
                fezTabela = true;
                Console.WriteLine("BINGO DO JOGADOR " + jogadores[j]);
                pontosJogador[j] += 5;
                Console.ReadKey();
                break;
                    
            }
            else
            {
                Console.WriteLine($"Numeros na sua Cartela {jogadores[j]} {marcadosCartela}");
                Console.ReadKey();
            }
           
            VerificarLinhas(cartela, i, j);
            VerificarColunas(cartela, i, j);


        }

    }
    
    for(int i = 0; i < jogadores.Length; i++)
    {
        Console.WriteLine("Pontos: " + jogadores[i] + " !!! Você tem " + pontosJogador[i] + " Pontos!!!!");
    }

    do
    {
        Console.WriteLine("Deseja Jogar Mais uma rodada [1]");
        Console.WriteLine("Deseja finalizar o Jogo [2]");
        variavelParaContinuarJogando = int.Parse(Console.ReadLine());

        switch (variavelParaContinuarJogando)
        {
            case 1:
                Console.WriteLine("\nVamos para mais uma!\n");
                fezLinha = false;
                fezColuna = false;
                fezTabela = false;
                marcadosCartela = 0;
                numeroRodada = 0;

                for (int j = 0; j < nJogadores; j++)
                {
                    acheiNaTabela[j] = 0;

                    for (int i = 0; i < linhaColuna; i++)
                    {
                        pontosLinha[i,j] = 0;
                        pontosColuna[i,j] = 0;
                    }
                }
                break;
            case 2:
                Console.WriteLine("\nJogo Finalizado!\n");
                continuaJogando = false;
                break;
            default:
                Console.WriteLine("\nInsira um valor valido!\n");
                break;
        }
    } while (variavelParaContinuarJogando != 1 && variavelParaContinuarJogando != 2);


} while (continuaJogando);

int pontosMaiores = pontosJogador[0];
int indiceMaior = 0;

for (int j = 1; j < jogadores.Length; j++)
{
    if (pontosJogador[j] > pontosMaiores)
    {
        pontosMaiores = pontosJogador[j];
        indiceMaior = j;
    }

}
Console.WriteLine($"\nParabes {jogadores[indiceMaior]} você ganhou com {pontosJogador[indiceMaior]}\n");

Console.ReadKey();




