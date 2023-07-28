﻿using xadrez;
using tabuleiro;

namespace xadrez_console;
class Tela
{
    public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
    {
        for (int i = 0; i < tabuleiro.linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tabuleiro.colunas; j++)
            {
                ImprimirPeca(tabuleiro.Peca(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void ImprimirPartida(PartidaXadrez partida)
    {
        ImprimirTabuleiro(partida.tab);
        Console.WriteLine();
        imprimirPecasCapturadas(partida);
        Console.WriteLine();
        Console.WriteLine("Turno: " + partida.Turno);
        if (!partida.Terminada)
        {
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            if (partida.xeque)
                Console.WriteLine("XEQUE!");
        }
        else
        {
            Console.WriteLine("XEQUEMATE!");
            Console.WriteLine($"Vencedor {partida.JogadorAtual}");
        }
    }

    public static void imprimirPecasCapturadas(PartidaXadrez partida)
    {
        Console.WriteLine("Peças capturadas:");
        Console.Write("Brancas: ");
        ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
        Console.WriteLine();
        Console.Write("Pretas: ");
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        Console.ForegroundColor = aux;
        Console.WriteLine();
    }

    public static void ImprimirConjunto(HashSet<Peca> conjunto)
    {
        Console.Write("[");
        foreach (Peca x in conjunto)
        {
            Console.Write(x + " ");
        }
        Console.Write("]");
    }

    public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoePossiveis)
    {

        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < tab.linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.colunas; j++)
            {
                if (posicoePossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = fundoOriginal;
                }
                ImprimirPeca(tab.Peca(i, j));
                Console.BackgroundColor = fundoOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = fundoOriginal;
    }


    public static PosicaoXadrez LerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");

        return new PosicaoXadrez(coluna, linha);

    }

    public static void ImprimirPeca(Peca peca)
    {
        if (peca == null)
            Console.Write("- ");
        else
        {
            if (peca.cor == Cor.Branca)
                Console.Write(peca);
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ResetColor();
            }
            Console.Write(" ");
        }

    }
}

