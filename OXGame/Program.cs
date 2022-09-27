namespace OXGame
{
    internal class Program
    {
        enum Direction { 
            up,down,left,right
        }
        class Field
        {
            private char[,] field = new char[3,3];

            private int cursorY = 0;
            private int cursorX = 0;

            private bool turn = false;
            public Field()
            {
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        field[i,j] = '.';
                    }
                }
            }
            private void moveCursor(Direction d)
            {
                switch(d){
                    case Direction.up:
                        if(cursorY>0)
                            cursorY--;
                        break;
                    case Direction.down:
                        if(cursorY<2)
                            cursorY++;
                        break;
                    case Direction.left:
                        if (cursorX > 0)
                            cursorX--;
                        break;
                    case Direction.right:
                        if (cursorX < 2)
                            cursorX++;
                        break;
                    default:
                        break;

                }
            }

            private void SetSign() {
                if (field[cursorY, cursorX] == '.')
                {
                    if (turn)
                        SetO(cursorY, cursorX);
                    else
                        SetX(cursorY, cursorX);
                    turn = !turn;
                }
            
            }
            public bool CheckVictory()
            {
                if (field[0, 0] == 'X' && field[0, 1] == 'X' && field[0, 2] == 'X' || field[1, 0] == 'X' && field[1, 1] == 'X' && field[1, 2] == 'X' || field[2, 0] == 'X' && field[2, 1] == 'X' && field[2, 2] == 'X' || field[0, 0] == 'X' && field[1, 0] == 'X' && field[2, 0] == 'X' || field[0, 1] == 'X' && field[1, 1] == 'X' && field[2, 1] == 'X' || field[0, 2] == 'X' && field[1, 2] == 'X' && field[2, 2] == 'X' || field[0, 0] == 'X' && field[1, 1] == 'X' && field[2, 2] == 'X' || field[2, 0] == 'X' && field[1, 1] == 'X' && field[0, 2] == 'X' || field[0, 0] == 'O' && field[0, 1] == 'O' && field[0, 2] == 'O' || field[1, 0] == 'O' && field[1, 1] == 'O' && field[1, 2] == 'O' || field[2, 0] == 'O' && field[2, 1] == 'O' && field[2, 2] == 'O' || field[0, 0] == 'O' && field[1, 0] == 'O' && field[2, 0] == 'O' || field[0, 1] == 'O' && field[1, 1] == 'O' && field[2, 1] == 'O' || field[0, 2] == 'O' && field[1, 2] == 'O' && field[2, 2] == 'O' || field[0, 0] == 'O' && field[1, 1] == 'O' && field[2, 2] == 'O' || field[2, 0] == 'O' && field[1, 1] == 'O' && field[0, 2] == 'O')
                    return true;
                else
                    return false;

            }
            public void Congratulations()
            {
                if (!turn)
                    Console.WriteLine("O win!");
                else
                    Console.WriteLine("X win!");
            }
            public void SetX(int x, int y) { field[x, y] = 'X'; }
            public void SetO(int x, int y) { field[x, y] = 'O'; }

            public void ReadKey(ConsoleKeyInfo input)
            {
                if(input.Key == ConsoleKey.UpArrow)
                    moveCursor(Direction.up);
                if(input.Key == ConsoleKey.DownArrow)
                    moveCursor(Direction.down);
                if(input.Key == ConsoleKey.LeftArrow)
                    moveCursor(Direction.left);
                if(input.Key == ConsoleKey.RightArrow)
                    moveCursor(Direction.right);
                if (input.Key == ConsoleKey.Spacebar)
                    SetSign();

            }
            public void PrintField()
            {
                Console.Clear();
                for(int i = 0; i < 3; i++)
                {
                    for(int j= 0; j < 3; j++)
                    {
                        Console.Write(field[i,j]);
                        if (i == cursorY && j == cursorX)
                            Console.Write('@');
                        else
                            Console.Write(' ');
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Field field = new Field();
            field.PrintField();
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                field.ReadKey(input);
                field.PrintField();
                if (field.CheckVictory())
                {
                    field.Congratulations();
                    break;
                }
            }
        }
    }
}