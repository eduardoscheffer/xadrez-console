using tabuleiro;

namespace xadrez;
internal class PosicaoXadrez
{
    public char coluna { get; set; }
    public int linha { get; set; }

    public PosicaoXadrez(char coluna, int linha)
    {
        this.coluna = coluna;
        this.linha = linha;
    }



    // metodo que transforma a posicao do xadrez pra posicao do tabuleiro(matriz):
    public Posicao toPosicao() => new(8 - linha, coluna - 'a');

    public override string ToString() => $"{coluna}{linha}";
}

