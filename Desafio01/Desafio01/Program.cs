using System;
using System.Runtime.Intrinsics.X86;

namespace Desafio;

public class JogoDaVelha
{
    public static void Main(String[] args)
    {
        string[,] jogoDaVelha = tabuleiro();
        printTabuleiro(jogoDaVelha);
        Console.WriteLine("Insira o valor da sua jogada");
        string posicao = Console.ReadLine();
        int[] play = jogada(jogoDaVelha, posicao);
        Console.WriteLine(play);
        printTabuleiro(jogoDaVelha);
    }

    public static string[,] tabuleiro()
    {
        string[,] tabuleiro = { { "7", "8", "9" },
                                { "4", "5", "6" },
                                { "1", "2", "3" }};

        return tabuleiro;
    }
    
    public static void printTabuleiro(string[,] tabuleiro)
    {   
        for(int i = 0; i < tabuleiro.GetLength(0); i++)
        {

            Console.Write("  ");
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if(j+1 == tabuleiro.GetLength(1))
                {
                    Console.WriteLine(tabuleiro[i, j]);
                }else
                {
                    Console.Write(tabuleiro[i, j] + " | ");
                }
            }
            if (i + 1 == tabuleiro.GetLength(1))
                break;
            Console.WriteLine(" ───────────");
        }
    }

    public static int[] jogada(string[,] tabuleiro, string posicao)
    {
        int[] jogada = new int[2]; 
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if (tabuleiro[i, j] == posicao)
                {
                    tabuleiro[i, j] = "X";
                    jogada[0] = i;
                    jogada[1] = j;

                }
            }
        }
        return jogada;
    }

    public static bool venceu(string[,] tabuleiro)
    {
        string valorAnterior = "";
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if (j > 1 && tabuleiro[i, j] == "X") ;
                {

                }
            }
        }

        for (int i = 0; i < valorAnterior.GetLength(0); i++)
        {
            while (aux >= 0)
            {
                diagonalSec = valorAnterior[i, aux];
                aux--;
                break;
            }

        }
    }
}