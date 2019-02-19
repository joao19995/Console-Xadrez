using System;
using Tabuleiro;

namespace xadrez 
{
    class PartidaDeXadrez
    {
        public Tabuleiro.Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            jogadorAtual = Cor.Branca;            
            terminada = false;
            colocarPecas();
        }

       

        public void executaMovimento ( Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtDeMovimetos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.ColocarPeca(p,destino);
        }

        public void RealizaJogada(Posicao origem ,Posicao destino)
        {
            executaMovimento(origem,destino);
            Turno++;
            MudaJogador();

        }

        public void validaPosicoesDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null){
                throw new TabuleiroException("Não Existe peca");
            }
            if (jogadorAtual!= tab.peca(pos).cor)
            {
                throw new TabuleiroException("peca do oponente");
            }
            if (! tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Nao existe movimnetos possiveis");
            }
        }

        public void voidValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("posiçao invalida");
            }
        }

        private void MudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;

            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {

            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 1).toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toposicao());
        }
    }
}
