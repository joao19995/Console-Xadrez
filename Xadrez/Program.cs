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
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.Write("origem:");
                    Posicao origem = Tela.LerPosicaoXadrez().toposicao();
                    Console.Write("destino:");
                    Posicao destino = Tela.LerPosicaoXadrez().toposicao();
                    partida.executaMovimento(origem, destino);
                }
               




            }catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
           

            Console.ReadLine();
        }
    }
}
