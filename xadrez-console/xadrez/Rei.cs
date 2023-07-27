
using tabuleiro;

namespace xadrez;
class Rei : Peca
{
    public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
    {
    }

    private bool PodeMover(Posicao pos) // checa se a peça pode mover dada uma posicao
    {
        Peca p = tab.Peca(pos);
        return p == null || p.cor != this.cor; // checa se o local da posicao dada está vazio ou com uma peça adversária
    }
    public override bool[,] MovimentosPossiveis()
    {
        var mat = new bool[tab.linhas, tab.colunas]; // instanciando uma matriz 8x8

        var pos = new Posicao(0, 0);

        // acima
        pos.DefinirValores(posicao.linha - 1, posicao.coluna);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // ne
        pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // direita
        pos.DefinirValores(posicao.linha, posicao.coluna + 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // se
        pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // abaixo
        pos.DefinirValores(posicao.linha + 1, posicao.coluna);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // so
        pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // esquerda
        pos.DefinirValores(posicao.linha, posicao.coluna - 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // no
        pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        return mat;
    }

    public override string ToString() => "R";
}
