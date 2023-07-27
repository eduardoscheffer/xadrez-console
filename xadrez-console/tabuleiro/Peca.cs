
namespace tabuleiro;

abstract class Peca
{
    public Posicao posicao { get; set; }
    public Cor cor { get; protected set; }
    public int qteMovimentos { get; protected set; }
    public Tabuleiro tab { get; protected set; }

    public Peca(Cor cor, Tabuleiro tab)
    {
        this.posicao = null; // inicia a Peca com posicao indefinida, será definida no metodo Tabuleiro.colocarPeca
        this.cor = cor;
        this.tab = tab;
        this.qteMovimentos = 0;
    }

    public void incrementarMovimento() => qteMovimentos++;

    public bool existeMovimentosPossiveis()
    {
        bool[,] mat = MovimentosPossiveis();

        for (int i = 0; i < tab.linhas; i++)
        {
            for (int j = 0; j < tab.colunas; j++)
            {
                if (mat[i, j])
                    return true;
            }
        }
        return false;
    }

    public bool PodeMoverPara(Posicao pos)
    {

        return MovimentosPossiveis()[pos.linha, pos.coluna]; // return mat[pos.linha, pos.coluna]
        
    }

    public abstract bool[,] MovimentosPossiveis();
}
