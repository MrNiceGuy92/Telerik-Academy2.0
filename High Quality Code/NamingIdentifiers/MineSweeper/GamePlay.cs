namespace MineSweeper
{
    using System;
    using System.Collections.Generic;

    public class GamePlay
    {
        public static void Main(string[] arguments)
        {
            const int MAXIMUM_POINTS = 35;

            string command = string.Empty;
            char[,] playingField = CreatePlayingField();
            char[,] mineField = PlaceMines();
            int pointsCounter = 0;
            bool isGameOver = false;
            List<PointsSheat> winnersList = new List<PointsSheat>(6);
            int row = 0;
            int column = 0;
            bool startGame = true; 
            bool maxPointsReached = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Let's play mines. Command 'top' shows the rankings, 'restart' starts a new game, 'exit' exits the game!");
                    DrawBoard(playingField);
                    startGame = false;
                }

                Console.Write("Input row and column: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= playingField.GetLength(0) && column <= playingField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(winnersList);
                        break;
                    case "restart":
                        playingField = CreatePlayingField();
                        mineField = PlaceMines();
                        DrawBoard(playingField);
                        isGameOver = false;
                        startGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Thanks for playing!");
                        break;
                    case "turn":
                        if (mineField[row, column] != '*')
                        {
                            if (mineField[row, column] == '-')
                            {
                                NewPlayerTurn(playingField, mineField, row, column);
                                pointsCounter++;
                            }

                            if (MAXIMUM_POINTS == pointsCounter)
                            {
                                maxPointsReached = true;
                            }
                            else
                            {
                                DrawBoard(playingField);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine(string.Format("{0}Inavalid command!{1}", Environment.NewLine, Environment.NewLine));
                        break;
                }

                if (isGameOver)
                {
                    DrawBoard(mineField);

                    Console.Write(string.Format(
                        "{0}You died with {1} points. " +
                        "Input your nickname: ", 
                        Environment.NewLine, 
                        pointsCounter));

                    string playerNickname = Console.ReadLine();
                    PointsSheat newPlayerScoreInfo = new PointsSheat(playerNickname, pointsCounter);

                    if (winnersList.Count < 5)
                    {
                        winnersList.Add(newPlayerScoreInfo);
                    }
                    else
                    {
                        for (int i = 0; i < winnersList.Count; i++)
                        {
                            if (winnersList[i].Points < newPlayerScoreInfo.Points)
                            {
                                winnersList.Insert(i, newPlayerScoreInfo);
                                winnersList.RemoveAt(winnersList.Count - 1);
                                break;
                            }
                        }
                    }

                    winnersList.Sort((PointsSheat r1, PointsSheat r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    winnersList.Sort((PointsSheat r1, PointsSheat r2) => r2.Points.CompareTo(r1.Points));

                    Ranking(winnersList);
                    playingField = CreatePlayingField();
                    mineField = PlaceMines();
                    pointsCounter = 0;

                    isGameOver = false;
                    startGame = true;
                }

                if (maxPointsReached)
                {
                    Console.WriteLine(string.Format("{0}Congratulations, you've won!", Environment.NewLine));
                    DrawBoard(mineField);

                    Console.WriteLine("Input your name: ");
                    string name = Console.ReadLine();

                    PointsSheat newWinner = new PointsSheat(name, pointsCounter);

                    winnersList.Add(newWinner);
                    Ranking(winnersList);
                    playingField = CreatePlayingField();
                    mineField = PlaceMines();
                    pointsCounter = 0;

                    maxPointsReached = false;
                    startGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Thanks for playing! Made in Bulgaria.");
            Console.Read();
        }

        private static void Ranking(List<PointsSheat> points)
        {
            Console.WriteLine(string.Format("{0}Points:", Environment.NewLine));

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} points",
                        i + 1, 
                        points[i].PlayerName, 
                        points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(string.Format("Empty ranking!{0}", Environment.NewLine));
            }
        }

        private static void NewPlayerTurn(
                                            char[,] field,
                                            char[,] mines, 
                                            int row, 
                                            int col)
        {
            char numberOfMines = GenerateMineCount(mines, row, col);
            mines[row, col] = numberOfMines;
            field[row, col] = numberOfMines;
        }

        private static void DrawBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playingField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> mineList = new List<int>();

            while (mineList.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!mineList.Contains(randomNumber))
                {
                    mineList.Add(randomNumber);
                }
            }

            foreach (int mine in mineList)
            {
                int col = mine / cols;
                int row = mine % cols;

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playingField[col, row - 1] = '*';
            }

            return playingField;
        }

        private static void CalculateMinesToPlace(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] != '*')
                    {
                        char numberOfMines = GenerateMineCount(field, row, col);
                        field[row, col] = numberOfMines;
                    }
                }
            }
        }

        private static char GenerateMineCount(char[,] mineField, int row, int col)
        {
            int mineCounter = 0;
            int rows = mineField.GetLength(0);
            int cols = mineField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mineField[row - 1, col] == '*')
                {
                    mineCounter++;
                }
            }

            if (row + 1 < rows)
            {
                if (mineField[row + 1, col] == '*')
                {
                    mineCounter++;
                }
            }

            if (col - 1 >= 0)
            {
                if (mineField[row, col - 1] == '*')
                {
                    mineCounter++;
                }
            }

            if (col + 1 < cols)
            {
                if (mineField[row, col + 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mineField[row - 1, col - 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (mineField[row - 1, col + 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mineField[row + 1, col - 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (mineField[row + 1, col + 1] == '*')
                {
                    mineCounter++;
                }
            }

            return char.Parse(mineCounter.ToString());
        }
    }
}