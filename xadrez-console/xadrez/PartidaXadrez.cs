using tabuleiro;

namespace xadrez;
internal class PartidaXadrez
{
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor jogadorAtual { get; private set; }
    public bool terminada { get; private set; }

    public PartidaXadrez()
    {
        tab = new Tabuleiro(8, 8);
        turno = 1;
        jogadorAtual = Cor.Branca;
        terminada = false;
        ColocarPecas();
    }

    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = tab.RetirarPeca(origem);
        p.incrementarMovimento();
        Peca pecaCapturada = tab.RetirarPeca(destino);
        tab.ColocarPeca(p, destino);
    }

    public void realizaJogada(Posicao origem, Posicao destino) 
    { 
        executaMovimento(origem, destino);
        turno++;
        mudaJogador();
    }

    public void validarPosicaoDeOrigem(Posicao pos)
    {
        if (tab.Peca(pos) == null)
            throw new TabuleiroException("Não existe peça na posição de origem escolhida");
        if (jogadorAtual != tab.Peca(pos).cor)
            throw new TabuleiroException("O turno é da outras peças!");
        if (!tab.Peca(pos).existeMovimentosPossiveis())
            throw new TabuleiroException("Não existe movimentos possíveis para essa peça.");
    }

    public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
    {
        if (!tab.Peca(origem).PodeMoverPara(destino)) throw new TabuleiroException("Posição de destino inválida.");
    }

    private void mudaJogador()
    {
        if (jogadorAtual == Cor.Branca)
            jogadorAtual = Cor.Preta;
        else
            jogadorAtual = Cor.Branca;
    }   
    private void ColocarPecas()
    {
        tab.ColocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('e', 1).ToPosicao());
        tab.ColocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('a', 1).ToPosicao());
        tab.ColocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('h', 1).ToPosicao());

        tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('a', 8).ToPosicao());
        tab.ColocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('e', 8).ToPosicao());
        tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('h', 8).ToPosicao());

    }
}

