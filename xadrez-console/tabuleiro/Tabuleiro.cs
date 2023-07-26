
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

    // sobecarga do metodo peca:
    public Peca peca(Posicao pos) => pecas[pos.linha, pos.coluna];

    // metodo que checa se existe uma peça em uma determinada posicao:
    public bool existePeca(Posicao pos)
    {
        validarPosicao(pos); // primeiro faz a validação da posicao
        return peca(pos) != null;
    }

    // metodo que adiciona uma peca ao tabuleiro
    public void colocarPeca (Peca peca, Posicao posicao)
    {
        if (existePeca(posicao))
            throw new TabuleiroException("Já existe uma peça nessa posição!");
        // vai na matriz do campo pecas e coloca um objeto do tipo Peca:
        pecas[posicao.linha, posicao.coluna] = peca;
        peca.posicao = posicao;
    }

    // metodo pra retirar uma peca do tabuleiro:
    public Peca retirarPeca(Posicao pos)
    {
        if (peca(pos) != null)
        {
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;

        }
        else
            return null;

    }

    // metodo que checa se uma posicao é valida no tabuleiro:
    public bool posicaoValida (Posicao pos) => (pos.linha < 0 || pos.linha > linhas || pos.coluna < 0 || pos.coluna > colunas) ? false : true;

    public void validarPosicao (Posicao pos)
    {
        if (!posicaoValida(pos))
            throw new TabuleiroException("Posicao Invalida!");
    }

}