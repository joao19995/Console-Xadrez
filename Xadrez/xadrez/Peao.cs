using System;
using Tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tabuleiro.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.defenirValores(posicao.Linha - 1, posicao.Coluna);
                if (tabuleiro.posValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                pos.defenirValores(posicao.Linha - 2, posicao.Coluna);
                if (tabuleiro.posValida(pos) && livre(pos) && qtMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                pos.defenirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (tabuleiro.posValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
            }

            else
            {
                pos.defenirValores(posicao.Linha + 1, posicao.Coluna);
                if (tabuleiro.posValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                pos.defenirValores(posicao.Linha + 2, posicao.Coluna);
                if (tabuleiro.posValida(pos) && livre(pos) && qtMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                pos.defenirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tabuleiro.posValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
            }
            return mat;
        }
    }
}


