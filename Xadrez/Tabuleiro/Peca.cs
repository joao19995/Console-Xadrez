using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

        

        public void incrementarQtDeMovimetos()
        {
            qtMovimentos++;
        }

    }
}
