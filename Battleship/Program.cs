using BattleshipGame;

string input = "";
string message = "";
int selectedX, selectedY;
bool isGameEnd = false;
bool cheats = false;

List<Battleship> battleships = new List<Battleship>();

Battleship battleship = new("battleship",5, battleships);
battleships.Add(battleship);

Battleship destroyer1 = new("destroyer", 4, battleships);
battleships.Add(destroyer1);

Battleship destroyer2 = new("destroyer", 4, battleships);
battleships.Add(destroyer2);

Board board = new Board(battleships);

while (!isGameEnd)
{
    Console.Clear();
    Console.WriteLine(board.GetBoard());
    Console.WriteLine(message);

    if (cheats)
    {
        Cheats(battleships);
    }

    Console.WriteLine();    
    Console.Write("Pick a tile to bomb (ex. C5): ");

    input = Console.ReadLine();

    if (!String.IsNullOrEmpty(input))
    {
        if (String.Equals(input.ToLower(), "cheats") && !cheats)
        {
            cheats = true;
            message = "Cheats are open!";
        }
        else
        {
            selectedX = charToInt(input[0]);
            input = input.Remove(0, 1);

            if (Int32.TryParse(input, out selectedY)
                && selectedX > 0 && selectedX < 11
                && selectedY > 0 && selectedY < 11)
            {
                if (board.IsShootable(selectedX, selectedY))
                {
                    message = board.Shoot(selectedX, selectedY);
                }
                else
                {
                    message = "You've already shot that tile!";
                }
            }
            else
            {
                message = "Wrong Input!";
            }
        }        
    }
    else
    {
        message = "Empty Input!";
    }
    isGameEnd = IsGameOver(battleships);
}

Console.Clear();
Console.WriteLine(board.GetBoard());
Console.WriteLine("You Win!");

static int charToInt(char c)
{
    return (int)Char.ToUpper(c)-64;
}

static bool IsGameOver(List<Battleship> battleships)
{
    foreach (var ship in battleships)
    {
        if (ship.IsAlive)
        {
            return false;
        }
    }
    return true;
}

static void Cheats(List<Battleship> battleships)
{
    Console.WriteLine();
    foreach (var ship in battleships)
    {
        foreach (var coordinates in ship.GetCoordinates())
        {
            Console.WriteLine($"{(char)(coordinates[0]+64)} {coordinates[1]}");
        }
        Console.WriteLine("----------");
    }
}