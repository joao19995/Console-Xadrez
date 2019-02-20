using System;
using Tabuleiro ;

namespace Tabuleiro
{
    abstract class Peca
    {
        

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtMovimentos { get; set; }
        public Tabuleiro tabuleiro { get; set; }

        public Peca( Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;           
            this.tabuleiro = tabuleiro;
            this.qtMovimentos = 0;
        }

        public abstract bool[,] MovimentosPossiveis();


        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (mat[i, j]==true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public void incrementarQtDeMovimetos()
        {
            qtMovimentos++;
        }
        public void decrementarQtDeMovimetos()
        {
            qtMovimentos--;
        }
    }
}
