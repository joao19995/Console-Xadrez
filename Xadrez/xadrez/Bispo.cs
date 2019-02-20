using System;
using Tabuleiro;

namespace xadrez
    {
        class Bispo : Peca
        {
            public Bispo(Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
            {
            }
            public override string ToString()
            {
                return "B";
            }

            private bool podeMover(Posicao pos)
            {
                Peca p = tabuleiro.peca(pos);
                return p == null || p.cor != cor;
            }

            public override bool[,] MovimentosPossiveis()
            {
                bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
                Posicao pos = new Posicao(0, 0);

                //no
                pos.defenirValores(posicao.Linha - 1, posicao.Coluna-1);
                while (tabuleiro.posValida(pos) && podeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                    {
                        break;
                    }
                    pos.defenirValores(pos.Linha-1 , pos.Coluna - 1);
                }


            //ne
            pos.defenirValores(posicao.Linha - 1, posicao.Coluna + 1);
            while (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defenirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //so
            //cima
            pos.defenirValores(posicao.Linha + 1, posicao.Coluna - 1);
            while (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defenirValores(pos.Linha +1, pos.Coluna - 1);
            }

            //se
            //cima
            pos.defenirValores(posicao.Linha + 1, posicao.Coluna + 1);
            while (tabuleiro.posValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defenirValores(pos.Linha + 1, pos.Coluna + 1);
            }
            return mat;
            }
        }
    }

