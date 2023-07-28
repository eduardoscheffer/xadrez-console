using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez;
internal class PartidaXadrez
{
    public Tabuleiro tab { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool Terminada { get; private set; }
    private HashSet<Peca> Pecas { get; set; }
    private HashSet<Peca> Capturadas { get; set; }
    public bool xeque { get; private set; }

    public PartidaXadrez()
    {
        tab = new Tabuleiro(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Pecas = new HashSet<Peca>();
        Capturadas = new HashSet<Peca>();
        ColocarPecas();
    }

    public Peca executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = tab.RetirarPeca(origem);
        p.incrementarMovimento();
        Peca pecaCapturada = tab.RetirarPeca(destino);
        tab.ColocarPeca(p, destino);
        if (pecaCapturada != null)
            Capturadas.Add(pecaCapturada);
        return pecaCapturada;
    }

    public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
    {
        Peca p = tab.RetirarPeca(destino);
        p.dexrementarMovimento();
        if (pecaCapturada != null)
        {
            tab.ColocarPeca(pecaCapturada, destino);
            Capturadas.Remove(pecaCapturada);
        }
        tab.ColocarPeca(p, origem);
    }

    public void realizaJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = executaMovimento(origem, destino);

        if (EstaEmXeque(JogadorAtual))
        {
            DesfazMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeque.");
        }

        xeque = (EstaEmXeque(Adversaria(JogadorAtual))) ? true: false;

        if (TesteXequeMate(Adversaria(JogadorAtual))) Terminada = true;

        Turno++;
        mudaJogador();
    }

    public void validarPosicaoDeOrigem(Posicao pos)
    {
        if (tab.Peca(pos) == null)
            throw new TabuleiroException("Não existe peça na posição de origem escolhida");
        if (JogadorAtual != tab.Peca(pos).cor)
            throw new TabuleiroException("O turno é da outras peças!");
        if (!tab.Peca(pos).existeMovimentosPossiveis())
            throw new TabuleiroException("Não existe movimentos possíveis para essa peça.");
    }

    public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
    {
        if (!tab.Peca(origem).MovimentoPossivel(destino)) throw new TabuleiroException("Posição de destino inválida.");
    }

    private void mudaJogador()
    {
        if (JogadorAtual == Cor.Branca)
            JogadorAtual = Cor.Preta;
        else
            JogadorAtual = Cor.Branca;
    }

    public HashSet<Peca> PecasCapturadas(Cor cor)
    {
        return new HashSet<Peca>(Capturadas.Where(peca => peca.cor == cor));
    }

    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca peca in Pecas)
        {
            if (peca.cor == cor)
                aux.Add(peca);
        }
        // retirar as ja capturadas
        aux.ExceptWith(PecasCapturadas(cor)); // metodo void ExceptWith modifica a HashSet original, percorre a lista e remove as duplicatas com base no HashSet passado como parâmetro
        return aux;
    }

    private Peca Rei(Cor cor)
    {
        foreach (Peca x in PecasEmJogo(cor))
        {
            if (x is Rei) return x;
        }
        return null;
    }

    private static Cor Adversaria(Cor cor)
    {
        if (cor == Cor.Branca)
            return Cor.Preta;
        else
            return Cor.Branca;
    }

    public bool EstaEmXeque(Cor cor)
    { 
        Peca R = Rei(cor);
        foreach (Peca x in PecasEmJogo(Adversaria(cor)))
        {
            bool[,] mat = x.MovimentosPossiveis();
            if (mat[R.posicao.linha, R.posicao.coluna])
                return true;
        }
        return false;
    }

    public bool TesteXequeMate(Cor cor)
    {
        if (!EstaEmXeque(cor))
        {
            return false;
        }
        foreach (Peca x in PecasEmJogo(cor))
        {
            bool[,] mat = x.MovimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        Posicao origem = x.posicao;
                        Posicao destino = new Posicao(i, j);
                        Peca pecaCapturada = executaMovimento(origem, destino);
                        bool testeXeque = EstaEmXeque(cor);
                        DesfazMovimento(origem, destino, pecaCapturada);
                        if (!testeXeque)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
        Pecas.Add(peca);
    }
    private void ColocarPecas()
    {
        ColocarNovaPeca('a', 1, new Torre(Cor.Branca, tab));
        ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, tab));
        ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, tab));
        ColocarNovaPeca('d', 1, new Dama(Cor.Branca, tab));
        ColocarNovaPeca('e', 1, new Rei(Cor.Branca, tab));
        ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, tab));
        ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, tab));
        ColocarNovaPeca('h', 1, new Torre(Cor.Branca, tab));
        ColocarNovaPeca('a', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('b', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('c', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('d', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('e', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('f', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('g', 2, new Peao(Cor.Branca, tab, this));
        ColocarNovaPeca('h', 2, new Peao(Cor.Branca, tab, this));

        ColocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
        ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, tab));
        ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, tab));
        ColocarNovaPeca('d', 8, new Dama(Cor.Preta, tab));
        ColocarNovaPeca('e', 8, new Rei(Cor.Preta, tab));
        ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, tab));
        ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, tab));
        ColocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));
        ColocarNovaPeca('a', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('b', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('c', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('d', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('e', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('f', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('g', 7, new Peao(Cor.Preta, tab, this));
        ColocarNovaPeca('h', 7, new Peao(Cor.Preta, tab, this));

    }
}

