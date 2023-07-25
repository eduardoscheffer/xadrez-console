
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
}