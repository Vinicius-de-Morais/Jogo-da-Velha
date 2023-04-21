using System;
using System.Numerics;

namespace Desafio;

public class JogoDaVelha
{
    public static void Main(String[] args)
    {
        while (true)
        {
            Console.WriteLine("Deseja jogar: ");
            Console.WriteLine("1 - Jogador x Maquina");
            Console.WriteLine("2 - Jogador x Jogador");
            string decisao = Console.ReadLine();
            if (decisao == "1")
            {
                Console.Clear();
                playingMachine();
                break;
            } else if(decisao == "2"){
                Console.Clear();
                playing();
                break;
            } else
            {
                Console.WriteLine("Opcao invalida");
            }
        }
    }

    public static void playingMachine()
    {
        string[,] tictactoe = tabuleiro();
        string player = "X";
        string machine = "O";
        int jogadas = 0;

        while (true)
        {
            printTabuleiro(tictactoe);
            Console.Write("Jogador: " + player + " insira a sua jogada: ");
            string posicao = Console.ReadLine();

            // jogada do player
            jogada(tictactoe, posicao, player);
            Console.Clear();
            if (venceu(tictactoe, player))
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

                                                Jogador " + player);
                break;
            }

            // jogada da maquina
            machinePlayer(tictactoe, machine);

            if (venceu(tictactoe, machine))
            {
                Console.WriteLine(@"
 __     __                                                                          __                     
|  \   |  \                                                                        |  \                    
| $$   | $$  ______    _______   ______          ______    ______    ______    ____| $$  ______   __    __ 
| $$   | $$ /      \  /       \ /      \        /      \  /      \  /      \  /      $$ /      \ |  \  |  \
 \$$\ /  $$|  $$$$$$\|  $$$$$$$|  $$$$$$\      |  $$$$$$\|  $$$$$$\|  $$$$$$\|  $$$$$$$|  $$$$$$\| $$  | $$
  \$$\  $$ | $$  | $$| $$      | $$    $$      | $$  | $$| $$    $$| $$   \$$| $$  | $$| $$    $$| $$  | $$
   \$$ $$  | $$__/ $$| $$_____ | $$$$$$$$      | $$__/ $$| $$$$$$$$| $$      | $$__| $$| $$$$$$$$| $$__/ $$
    \$$$    \$$    $$ \$$     \ \$$     \      | $$    $$ \$$     \| $$       \$$    $$ \$$     \ \$$    $$
     \$      \$$$$$$   \$$$$$$$  \$$$$$$$      | $$$$$$$   \$$$$$$$ \$$        \$$$$$$$  \$$$$$$$  \$$$$$$ 
                                               | $$                                                        
                                               | $$                                                        
                                                \$$ 

                                                Para a maquina" );
                break;
            }
            
            // verificando empate
            jogadas += 2;
            if(jogadas == 9)
            {

            }
        }
    }

    public static void playing()
    {
        string[,] jogoDaVelha = tabuleiro();
        bool stop = false;
        string player = "X";
        int jogadas = 0;


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
            
            // em caso de empate
            jogadas++;
            if (jogadas == 9)
            {

            }
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
            if (tabuleiro[i, i] != player)
                return false;
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

    public static void machinePlayer(string[,] tabuleiro, string player)
    {
        if (tabuleiro[1, 1] == "5")
        {
            jogada(tabuleiro, "5", player);
            return;
        }

        machineWinLineMove(tabuleiro,player);

        machineWinColunmMove(tabuleiro, player);

        machineWinDiagonalMove(tabuleiro, player);

        machineWinReverseDiagonalMove(tabuleiro, player);

        Random random = new Random();
        int row, col;
        string jogadaAtual;
        do
        {
            row = random.Next(3);
            col = random.Next(3);
            jogadaAtual = tabuleiro[row, col];
        } while (!(jogadaAtual != "X" && jogadaAtual != "O"));
        jogada(tabuleiro, jogadaAtual, player);
        return;

    }

    public static void machineWinLineMove(string[,] tabuleiro, string player)
    {
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            int count = 0;
            string emptyIndex = "";

            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if (tabuleiro[i, j] == player)
                {
                    count++;
                }
                else if (tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O")
                {
                    emptyIndex = tabuleiro[i, j];
                }
            }

            if (count == 2 && emptyIndex != "")
            {
                jogada(tabuleiro, emptyIndex, player);
            }
        }
    }

    public static void machineWinColunmMove(string[,] tabuleiro, string player)
    {
        for (int j = 0; j < tabuleiro.GetLength(1); j++)
        {
            int count = 0;
            string emptyIndex = "";

            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                if (tabuleiro[i, j] == player)
                {
                    count++;
                }
                else if (tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O")
                {
                    emptyIndex = tabuleiro[i, j];
                }
            }

            if (count == 2 && emptyIndex != "")
            {
                jogada(tabuleiro, emptyIndex, player);
                return;
            }
        }

    }


    public static void machineWinDiagonalMove(string[,] tabuleiro, string player)
    {
        int count = 0;
        string emptyIndex = "";

        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            if (tabuleiro[i, i] == player)
            {
                count++;
            }
            else if (tabuleiro[i, i] != "X" && tabuleiro[i, i] != "O")
            {
                emptyIndex = tabuleiro[i, i];
            }
        }

        if (count == 2 && emptyIndex != "")
        {
            jogada(tabuleiro, emptyIndex, player);
            return;
        }

    }

    public static void machineWinReverseDiagonalMove(string[,] tabuleiro, string player)
    {
        int count = 0;
        string emptyIndex = "";

        for (int i = 0, j = tabuleiro.GetLength(1) - 1; i < tabuleiro.GetLength(0); i++, j--)
        {
            if (tabuleiro[i, j] == player)
            {
                count++;
            }
            else if (tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O")
            {
                emptyIndex = tabuleiro[i, j];
            }
        }

        if (count == 2 && emptyIndex != "")
        {
            jogada(tabuleiro, emptyIndex, player);
            return;
        }
    }
}


