﻿using tabuleiro;
using xadrez;

namespace xadrez_console;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 0));
            tab.colocarPeca(new Torre(Cor.Branca, tab), new Posicao(0, 1));
            tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(1, 0));
            tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(1, 1));
            tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(1, 2));

            Tela.imprimirTabuleiro(tab);
        }
        catch (TabuleiroException e)
        {

            Console.WriteLine(e.Message);
        }


        Console.ReadLine();
    }
}