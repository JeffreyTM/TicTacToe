char[,] board = { { 'Z', 'Z', 'Z' }, 
                  { 'Z', 'Z', 'Z' }, 
                  { 'Z', 'Z', 'Z' } };

List<int> filledSpots = new List<int>();
char currentTurn = 'X';
bool isGameOver = false;

Console.WriteLine(
    "Welcome to Tic Tac Toe, intended for two players. To begin, press enter. To exit, type 'Exit' or 'x'");

// While Loop which plays games until the user stops
string line = Console.ReadLine().ToLower();
while (line != "exit" || line != "x")
{  
    ResetGame();
    PlayGame();
    Console.WriteLine("Press enter to play again. To exit, type 'Exit' or 'x'");
    line = Console.ReadLine().ToLower();
}

Console.WriteLine("Farewell!");
return;

void PlayGame()
{
    while (filledSpots.Count <= 9 && !isGameOver)
    {
        if (currentTurn == 'X' && WinCheck() == 'Z')
        {
            Console.Clear();
            Console.WriteLine("Current Board:\n" + DisplayLayout());
            Console.WriteLine("Player X: Please type a number from 1-9 to indicate where you want to play.");
            SetValue('X');
            currentTurn = 'O';
        }
        else if (currentTurn == 'O' && WinCheck() == 'Z')
        {
            Console.Clear();
            Console.WriteLine("Current Board:\n" + DisplayLayout());
            Console.WriteLine("Player O: Please type a number from 1-9 to indicate where you want to play.");
            SetValue('O');
            currentTurn = 'X';
        }
        else
        {
            isGameOver = true;
            char winner = WinCheck();
            Console.Clear();
            Console.WriteLine("Finished Board:\n" + DisplayLayout());
            Console.WriteLine($"Player {winner} wins!");
        }
    }

}

void ResetGame()
{
    isGameOver = false;
    filledSpots.Clear();
    currentTurn = 'X';
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            board[i, j] = 'Z';
        }
    }
}

char WinCheck()
{
    // Horizontal
    char[] win = {'Z', 'Z', 'Z'};

    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++) 
        {
            if (board[i, j] != 'Z')
            {
                win[j] = board[i, j];
            }
        }
        if (win[0] != 'Z' && win[0] == win[1] && win[1] == win[2])
        {
            return win[0];
        }
    }

    // Vertical
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
        if (board[j, i] != 'Z')
            {
                win[j] = board[i, j];
            }
        }
        if (win[0] != 'Z' && win[0] == win[1] && win[1] == win[2])
        {
            return win[0];
        }
    }

    // 2 Diagonal
    if (board[1, 1] != 'Z')
    {
        if ((board[1, 1] == board[0, 0] && board [1, 1] == board[2, 2]) 
            || (board[1, 1] == board[2, 0] && board[1, 1] == board[0, 2]))
        {
            return board[1, 1];
        }
       /* if (board[1, 1] == board[2, 0] && board [1, 1] == board [0, 2])
        {
            return board[1, 1];
        }*/
    }


    return 'Z';
}

void SetValue(char player)
{
    bool isHandled;
    int index;
    do
    {
        isHandled = true;
        int.TryParse(Console.ReadLine(), out index);
        
        if (filledSpots.Contains(index))
        {
            index = -1;
        }

        switch (index)
        {
            case 1:
                board[0, 0] = player;
                break;
            case 2:
                board[0, 1] = player;
                break;
            case 3:
                board[0, 2] = player;
                break;
            case 4:
                board[1, 0] = player;
                break;
            case 5:
                board[1, 1] = player;
                break;
            case 6:
                board[1, 2] = player;
                break;
            case 7:
                board[2, 0] = player;
                break;
            case 8:
                board[2, 1] = player;
                break;
            case 9:
                board[2, 2] = player;
                break;
            case -1:
                isHandled = false;
                Console.Clear();
                Console.WriteLine("Current Board:\n" + DisplayLayout());
                Console.WriteLine($"Error: The value entered has already been played.");
                Console.WriteLine(
                    $"Player {player}: Please type a number from 1-9 to indicate where you want to play.");
                break;
            default:
                isHandled = false;
                Console.Clear();
                Console.WriteLine("Current Board:\n" + DisplayLayout());
                Console.WriteLine("Incorrect input.\n" +
                    $"Player {player}: Please type a number from 1-9 to indicate where you want to play.");
                break;
        }
    }
    while (!isHandled);

    filledSpots.Add(index);
}

string DisplayLayout()
{
    string layout = "";

    for (int i = 0; i < board.GetLength(0); i++)
    {
        layout += "\n";

        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[i, j] == 'Z')
            {
                if (j < board.GetLength(1) - 1)
                {
                    layout += "   |";
                }
                else
                {
                    layout += "   ";
                }
            }
            else if (j < board.GetLength(1) - 1)
            {
                layout += $" {board[i, j]} |";
            }
            else
            {
                layout += $" {board[i, j]}";
            }
        }
        if (i < board.GetLength(0) - 1)
        {
            layout += "\n _________\n";
        }
    }
    return layout + "\n";
}