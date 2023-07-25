
namespace tabuleiro;

class Peca
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
}
