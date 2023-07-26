using tabuleiro;

namespace xadrez;
internal class PartidaXadrez
{
    public Tabuleiro tab { get; private set; }
    private int turno { get; set; }
    private Cor jogadorAtual { get; set; }

    public PartidaXadrez()
    {
        tab = new Tabuleiro(8, 8);
        turno = 1;
        jogadorAtual = Cor.Branca;
        colocarPecas();
    }

    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = tab.retirarPeca(origem);
        p.incrementarMovimento();
        Peca pecaCapturada = tab.retirarPeca(destino);
        tab.colocarPeca(p, destino);
    }

    private void colocarPecas()
    {
        tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('e', 1).toPosicao());
        tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('a', 1).toPosicao());
        tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('h', 1).toPosicao());

        tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('a', 8).toPosicao());
        tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('e', 8).toPosicao());
        tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('h', 8).toPosicao());

    }
}

