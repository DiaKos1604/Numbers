namespace Basic.Menu
{
    public class Menu
    {
        public static void MainMenu()
        {
            string[] options = { "1. Logowanie ", "2. Rejestracja ", "3. Wyjście " };
            int selectedIndex = 0;

            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 20);

                MoveMain(options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = options.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex == options.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (selectedIndex == options.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Do zobaczenia!");

                            Thread.Sleep(1000);
                            return;
                        }

                        if (selectedIndex == 0)
                        {
                            Console.Clear();
                            Login.LoginToAccount();
                            break;

                        }

                        else if (selectedIndex == 1)
                        {
                            Console.Clear();
                            Login.Registration();
                            break;
                        }
                        Console.ReadKey();
                        break;
                }

            }

        }
        public static void MoveMain(string[] options, int selectedIndex)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 15);


            for (int i = 0; i < options.Length; i++)
            {

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

        }
        public static void Move(string[] options, int selectedIndex, string ID, string login)
        {
            Console.Clear();

            for (int i = 0; i < options.Length; i++)
            {

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

        }

    }
}

