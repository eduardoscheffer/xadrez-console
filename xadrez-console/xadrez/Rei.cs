
using tabuleiro;

namespace xadrez;
class Rei : Peca
{
    public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
    {
    }

    private bool podeMover(Posicao pos) // checa se a peça pode mover dada uma posicao
    {
        Peca p = tab.peca(pos);
        return p == null || p.cor != this.cor; // checa se o local da posicao dada está vazio ou com uma peça adversária
    }
    public override bool[,] movimentosPossiveis()
    {
        var mat = new bool[tab.linhas, tab.colunas]; // instanciando uma matriz 8x8

        var pos = new Posicao(0, 0);

        // acima
        pos.definirValores(posicao.linha - 1, posicao.coluna);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // ne
        pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // direita
        pos.definirValores(posicao.linha, posicao.coluna + 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // se
        pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // abaixo
        pos.definirValores(posicao.linha + 1, posicao.coluna);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // so
        pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // esquerda
        pos.definirValores(posicao.linha, posicao.coluna - 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }
        // no
        pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        return mat;
    }

    public override string ToString() => "R";
}
