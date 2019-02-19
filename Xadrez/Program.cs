﻿using System;
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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguradar jogador " + partida.jogadorAtual);
                        Console.WriteLine();

                        Console.Write("origem:");
                        Posicao origem = Tela.LerPosicaoXadrez().toposicao();
                        partida.validaPosicoesDeOrigem(origem);
                        bool[,] posisoensPosiveis = partida.tab.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, posisoensPosiveis);
                        Console.WriteLine();
                        Console.Write("destino:");
                        Posicao destino = Tela.LerPosicaoXadrez().toposicao();
                        partida.voidValidarPosicaoDeDestino(origem, destino);
                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
               




            }catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
           

            Console.ReadLine();
        }
    }
}
