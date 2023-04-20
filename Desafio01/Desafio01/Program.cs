using System;

namespace Desafio;

public class JogoDaVelha
{
    public static void Main(String[] args)
    {
        playing();
    }

    public static void playing()
    {
        string[,] jogoDaVelha = tabuleiro();
        bool stop = false;
        string player = "X";


        while (!stop)
        {
            printTabuleiro(jogoDaVelha);
            Console.Write("Jogador: "+player+" insira a sua jogada: ");
            string posicao = Console.ReadLine();



            jogada(jogoDaVelha, posicao, player);
            Console.Clear();
            if(venceu(jogoDaVelha, player))
            {
                Console.WriteLine(@"
 __     __                                                                                                  
|  \   |  \                                                                                                 
| $$   | $$  ______    _______   ______         __     __   ______   _______    _______   ______   __    __ 
| $$   | $$ /      \  /       \ /      \       |  \   /  \ /      \ |       \  /       \ /      \ |  \  |  \
 \$$\ /  $$|  $$$$$$\|  $$$$$$$|  $$$$$$\       \$$\ /  $$|  $$$$$$\| $$$$$$$\|  $$$$$$$|  $$$$$$\| $$  | $$
  \$$\  $$ | $$  | $$| $$      | $$    $$        \$$\  $$ | $$    $$| $$  | $$| $$      | $$    $$| $$  | $$
   \$$ $$  | $$__/ $$| $$_____ | $$$$$$$$         \$$ $$  | $$$$$$$$| $$  | $$| $$_____ | $$$$$$$$| $$__/ $$
    \$$$    \$$    $$ \$$     \ \$$     \          \$$$    \$$     \| $$  | $$ \$$     \ \$$     \ \$$    $$
     \$      \$$$$$$   \$$$$$$$  \$$$$$$$           \$      \$$$$$$$ \$$   \$$  \$$$$$$$  \$$$$$$$  \$$$$$$ 

                                                Jogador "+player);
                stop = true;
            }
            player = player == "X" ? "O" : "X";
        }
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
        Console.WriteLine(
              @" 
                                     _   _      _             _             
                                    | | (_)    | |           | |            
                                    | |_ _  ___| |_ __ _  ___| |_ ___   ___ 
                                    | __| |/ __| __/ _` |/ __| __/ _ \ / _ \
                                    | |_| | (__| || (_| | (__| || (_) |  __/
                                     \__|_|\___|\__\__,_|\___|\__\___/ \___|
            ");
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            Console.Write("\t\t\t\t\t\t ");
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
            Console.WriteLine("\t\t\t\t\t\t───────────");
        }
    }

    public static void jogada(string[,] tabuleiro, string posicao, string player)
    {
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if ((tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O") && tabuleiro[i, j] == posicao)
                {
                    tabuleiro[i, j] = player;
                }
            }
        }
    }

    public static bool venceu(string[,] tabuleiro, string player)
    {

        if(checkDiagonal(tabuleiro, player) || checkReverseDiagonal(tabuleiro, player) || checkLineAndColum(tabuleiro, player))
        {
            return true;
        }
        return false;
    }

    public static bool checkDiagonal(string[,] tabuleiro, string player)
    {
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if (i==j && tabuleiro[i, j] != player)
                    return false;
            }

        }
        return true;
    }

    public static bool checkReverseDiagonal(string[,] tabuleiro, string player)
    {
        int aux = tabuleiro.GetLength(1) -1;
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            while (aux >= 0)
            {
                if (tabuleiro[i, aux] != player)
                    return false;

                aux--;
                break;
            }

        }
        return true;
    }

    public static bool checkLineAndColum(string[,] tabuleiro, string player)
    {
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if (tabuleiro[0, j] == player && tabuleiro[1, j] == player && tabuleiro[2, j] == player)
                    return true;
            }
            if (tabuleiro[i, 0] == player && tabuleiro[i, 1] == player && tabuleiro[i, 2] == player)
                return true;
        }
        return false;
    }
}