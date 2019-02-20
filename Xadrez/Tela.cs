using System;
using System.Collections.Generic;
using Tabuleiro;
using xadrez;

namespace Xadrez
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguradar jogador " + partida.jogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("pecas Capturadas:");
            Console.Write("brancas:");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("pretas:");           
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tab)
        {
            for (int i=0; i<tab.linhas; i++)
            {
                Console.Write(8-i +" ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    
                        imprimirPeca(tab.peca(i, j));
                                     
                    
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            
        }

        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tab, bool[,] posicoesPosiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPosiveis[i, j] == true)
                    {
                        
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1]+"");
            return new PosicaoXadrez(coluna, linha);
        }
        

        
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
