using System;
using Tabuleiro;

namespace Xadrez.xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
