using System;
using Tabuleiro;
using Xadrez.xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro.Tabuleiro tab = new Tabuleiro.Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 1));
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 0));


            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
