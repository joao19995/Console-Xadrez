using System;
using Tabuleiro;
using xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro.Tabuleiro tab = new Tabuleiro.Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 1));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(0, 0));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(6, 0));

                Tela.ImprimirTabuleiro(tab);
            }catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
           

            Console.ReadLine();
        }
    }
}
