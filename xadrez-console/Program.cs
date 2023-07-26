using tabuleiro;
using xadrez;

namespace xadrez_console;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            PartidaXadrez partida = new PartidaXadrez();

            Tela.imprimirTabuleiro(partida.tab);
        }
        catch (TabuleiroException e)
        {

            Console.WriteLine(e.Message);
        }


        Console.ReadLine();
    }
}