using tabuleiro;
using xadrez;

namespace xadrez_console;
class Program
{
    static void Main(string[] args)
    {
        var tab = new Tabuleiro(8, 8);

        tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 0));
        tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
        tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(2, 14));



        Tela.imprimirTabuleiro(tab);

        Console.WriteLine();
    }
}