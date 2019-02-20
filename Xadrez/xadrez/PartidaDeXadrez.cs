using System;
using Tabuleiro;
using System.Collections.Generic;

namespace xadrez 
{
    class PartidaDeXadrez
    {
        public Tabuleiro.Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public HashSet<Peca> pecas;
        public HashSet<Peca> capturadas;
        public bool xeque { get; set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            jogadorAtual = Cor.Branca;            
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

       

        public Peca executaMovimento ( Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtDeMovimetos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.ColocarPeca(p,destino);
            if(pecaCapturada!= null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino , Peca pecaCapturada)
        {

            Peca p = tab.retirarPeca(destino);
            p.decrementarQtDeMovimetos();
            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem ,Posicao destino)
        {
           Peca pecaCapturada = executaMovimento(origem,destino);
            if (EstaXeque(jogadorAtual))
            {
                DesfazMovimento(origem,destino,pecaCapturada);
                throw new TabuleiroException("nao pode executarmovimento");
            }
            if (EstaXeque(Adversaria(jogadorAtual))){
                xeque = true;
            }
            else
            {
                xeque = false;
            }
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

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
                    
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }

            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria (Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca x in PecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool EstaXeque(Cor cor)
        {
            Peca r = Rei(cor);
            foreach(Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[r.posicao.Linha, r.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        private void colocarNovaPeca(char coluna ,int linha ,Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toposicao());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {

            /* colocarNovaPeca('c' ,1 ,new Torre(tab, Cor.Branca));
             colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
             colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
             colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
             colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
             colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));

             colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
             colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
             colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
             colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
             colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
             colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));*/

            colocarNovaPeca('e', 4, new Rei(tab, Cor.Branca));
            colocarNovaPeca('b', 4, new Rei(tab, Cor.Preta));
        }
    }
}
