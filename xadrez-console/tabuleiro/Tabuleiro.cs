
namespace tabuleiro;
internal class Tabuleiro
{
    public int linhas { get; set; }
    public int colunas { get; set; }

    // matriz de peças:
    private Peca[,] pecas;

    public Tabuleiro(int linhas, int colunas)
    {
        this.linhas = linhas;
        this.colunas = colunas;
        pecas = new Peca[linhas, colunas];
    }
    
    // metodo de Peca que retorna uma Peca do tabuleiro, ja que a propriedade eh private:
    public Peca peca(int linha, int coluna) => pecas[linha, coluna];
}