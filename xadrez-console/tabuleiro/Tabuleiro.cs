
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
    public Peca Peca(int linha, int coluna) => pecas[linha, coluna];

    // sobecarga do metodo peca:
    public Peca Peca(Posicao pos)
    {
        return pecas[pos.linha, pos.coluna];
    }
    // metodo que checa se existe uma peça em uma determinada posicao:
    public bool ExistePeca(Posicao pos)
    {
        ValidarPosicao(pos); // primeiro faz a validação da posicao
        return Peca(pos) != null;
    }

    // metodo que adiciona uma peca ao tabuleiro
    public void ColocarPeca(Peca peca, Posicao posicao)
    {
        if (ExistePeca(posicao))
            throw new TabuleiroException("Já existe uma peça nessa posição!");
        // vai na matriz do campo pecas e coloca um objeto do tipo Peca:
        pecas[posicao.linha, posicao.coluna] = peca;
        peca.posicao = posicao; // atualiza a propriedade posicao da peça
    }

    // metodo pra retirar uma peca do tabuleiro:
    public Peca RetirarPeca(Posicao pos)
    {
        if (Peca(pos) != null)
        {
            Peca aux = Peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;

        }
        else
            return null;

    }

    // metodo que checa se uma posicao é valida no tabuleiro:
    public bool PosicaoValida(Posicao pos) => (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas) ? false : true;

    public void ValidarPosicao(Posicao pos)
    {
        if (!PosicaoValida(pos))
            throw new TabuleiroException("Posicao Invalida!");
    }

}