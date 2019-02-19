using System;
using Tabuleiro;

namespace xadrez
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
        private bool podeMover (Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p==null||p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);

            //cima
            pos.defenirValores(posicao.Linha - 1, posicao.Coluna);
            if (tabuleiro.posValida(pos)&& podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //ne
            pos.defenirValores(posicao.Linha - 1, posicao.Coluna+1);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.defenirValores(posicao.Linha , posicao.Coluna +1);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //direita
            pos.defenirValores(posicao.Linha+1, posicao.Coluna + 1);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //baixo
            pos.defenirValores(posicao.Linha, posicao.Coluna);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //so
            pos.defenirValores(posicao.Linha+11, posicao.Coluna -1);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esq
            pos.defenirValores(posicao.Linha, posicao.Coluna - 1);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //no
            pos.defenirValores(posicao.Linha-1, posicao.Coluna - 1);
            if (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
