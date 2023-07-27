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

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine($"Turno: {partida.turno}");
                    Console.WriteLine($"Aguardando jogada: {partida.jogadorAtual}");

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.validarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDeDestino(origem, destino);

                    partida.realizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {

                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
        catch (TabuleiroException e)
        {

            Console.WriteLine(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        Console.ReadLine();
    }
}