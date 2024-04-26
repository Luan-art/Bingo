/*Vamos desenvolver um jogo?

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

String[] jogadores;
int linhaColuna = 5, maxSorteados = 25, escopoNumero = 99, marcadosCartela = 0, acheiNaTabela = 0;
int pontosJogador = 0;
int[,] cartela;
bool fezLinha = false, fezColuna = false;
int[] jaSorteados = new int[99], pontosLinha = new int[linhaColuna], pontosColuna = new int[linhaColuna];
bool preencherColuna = false, preencherLinha = false;

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

//sortearAleatoriamente
int[] Sortear( int maximo)
{
    int[] sorteados = new int[maximo];

    int sorteadoAtual;

    sorteadoAtual = new Random().Next(1, escopoNumero+1);
    sorteados[0] = sorteadoAtual;

    for (int i = 1; i < maximo; i++)
    {
        sorteadoAtual = new Random().Next(1, escopoNumero+1);

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
int[,] CriacaoCartela(){

    int[,] cartela = new int[linhaColuna, linhaColuna + 1];
    int[] sorteadosParaCartela;
    int passador = 0;

    sorteadosParaCartela = Sortear(maxSorteados);

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

//Verifica pontos na Tabela toda
int VerificarTabela(int[,] cartela, int indiceSorteado)
{
    
    for (int linha = 0; linha < linhaColuna; linha++)
    {
        for (int coluna = 0; coluna < linhaColuna; coluna++)
        {
            if (cartela[linha, coluna] == jaSorteados[indiceSorteado])
            {
                acheiNaTabela++;
            }
        }
        
    }

    return acheiNaTabela;
}

//Verifica pontos em cada Coluna
void VerificarColunas(int[,] cartela, int indiceSorteado)
{
    if (!fezColuna)
    {
        for (int linha = 0; linha < linhaColuna; linha++)
        {
            for (int coluna = 0; coluna < linhaColuna; coluna++)
            {
                if (cartela[linha, coluna] == jaSorteados[indiceSorteado])
                {
                    pontosColuna[coluna]++;
                }
            }

        }

        for(int colunas = 0; colunas < linhaColuna; colunas++)
        {
            if (pontosColuna[colunas] == linhaColuna)
            {
                Console.WriteLine("FeZ Coluna!!!");
                pontosJogador++;
                fezColuna = true;
            }
        }
    }
}

//Verifica pontos em cada Linha
void VerificarLinhas(int[,] cartela, int indiceSorteado)
{
    if (!fezLinha)
    {
        for (int coluna = 0; coluna < linhaColuna; coluna++)
        {
            for (int linha = 0; linha < linhaColuna; linha++)
            {
                if (cartela[linha, coluna] == jaSorteados[indiceSorteado])
                {
                    pontosLinha[linha]++;
                }
            }

        }

        for (int linhas = 0; linhas < linhaColuna; linhas++)
        {
            if (pontosLinha[linhas] == linhaColuna)
            {
                Console.WriteLine("FeZ Linha!!!");
                pontosJogador++;
                fezLinha = true;
            }
        }
    }
}

String[] identificarJogador()
{
    int numeroJogador = 0;
    String[] nomesJogadores = new string[2];

    do
    {
        Console.WriteLine("Bem vindo ao Bingo, digite seu nome: ");
        nomesJogadores[numeroJogador] = Console.ReadLine();
        numeroJogador++;

    } while (numeroJogador < nomesJogadores.Length);

    return nomesJogadores;
}

    jogadores = identificarJogador();
    
    cartela = CriacaoCartela();

    ImprimirMatriz(cartela, "Cartela");

    jaSorteados = Sortear(escopoNumero);

    for (int i = 0; i < jaSorteados.Length; i++)
    {
        Console.WriteLine("Numero Da Rodade " + jaSorteados[i]);

        marcadosCartela = VerificarTabela(cartela, i);

        if (marcadosCartela == 25)
        {
            Console.WriteLine("BINGO");
            pontosJogador += 5;
            Console.ReadKey();
            break;

        }
        else
        {
            Console.WriteLine("Numeros na sua Cartela " + marcadosCartela);
            Console.ReadKey();
        }

        VerificarLinhas(cartela, i);
        VerificarColunas(cartela, i);
    }

    Console.WriteLine("Parabens Jogador!!! Você Fez " + pontosJogador + " Pontos!!!!");




