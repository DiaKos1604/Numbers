using Basic.BankAccount;
using System;
using System.Threading;


namespace Basic.Menu
{
    public class BankMenu
    {
        public static void StartMenu(string userId, string login, Bank bank)
        {
            string[] options = { "1.Usuń konto", "2.Wpłać pieniądze", "3.Wypłać pieniądze", "4.Sprawdź saldo", "5.Zrób przelew", "6.Wyloguj mnie" };
            int selectedIndex = 0;
            Console.CursorVisible = false;
            int accountNumber;
            if (!int.TryParse(userId, out accountNumber))
            {
                Console.WriteLine("Niepoprawny identyfikator konta.");
                return;
            }

            Account userAccount = bank.GetAccount(accountNumber);

            while (true)
            {
                MainMenu(options, selectedIndex);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0) selectedIndex = options.Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex == options.Length) selectedIndex = 0;
                        break;

                    case ConsoleKey.Enter:
                        switch (selectedIndex)
                        {
                            case 0:
                                bank.RemoveAccount(accountNumber);
                                Console.WriteLine("Konto zostało pomyślnie usunięte.");
                                break;
                            case 1:
                                Console.WriteLine("Podaj kwotę do wpłaty:");
                                if (float.TryParse(Console.ReadLine(), out float depositAmount))
                                {
                                    userAccount.Deposit(depositAmount);
                                    Console.WriteLine("Wpłata wykonana.");
                                }
                                else
                                {
                                    Console.WriteLine("Nieprawidłowa kwota.");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Podaj kwotę do wypłaty:");
                                if (float.TryParse(Console.ReadLine(), out float withdrawAmount))
                                {
                                    userAccount.Withdraw(withdrawAmount);
                                    Console.WriteLine("Wypłata wykonana.");
                                }
                                else
                                {
                                    Console.WriteLine("Nieprawidłowa kwota.");
                                }
                                break;
                            case 3:
                                Console.WriteLine($"Saldo Twojego konta wynosi: {userAccount.GetBalance()}");
                                break;
                            case 4:
                                Console.WriteLine("Podaj numer konta docelowego:");
                                if (int.TryParse(Console.ReadLine(), out int otherAccountNumber))
                                {
                                    var otherAccount = bank.GetAccount(otherAccountNumber);
                                    if (otherAccount != null)
                                    {
                                        Console.WriteLine("Podaj kwotę do przelewu:");
                                        if (float.TryParse(Console.ReadLine(), out float transferAmount))
                                        {
                                            userAccount.Transfer(otherAccount, transferAmount);
                                            Console.WriteLine("Przelew wykonany pomyślnie.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nieprawidłowa kwota.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Konto nie istnieje");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nieprawidłowy numer konta");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Zostałeś wylogowany. Zapraszamy ponownie.");
                                Thread.Sleep(1000);
                                return;
                        }
                        break;
                }
                Thread.Sleep(500);
            }

        }
        public static void MainMenu(string[] options, int selectedIndex)
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();

            }
        }
    } 
}
//if (selectedIndex == 1)
//{
//    Console.Clear();
//    Console.WriteLine("Wybierz numer konta do usunięcia");
//    int accountNumberToRemove = int.Parse(Console.ReadLine());
//    bank.RemoveAccount(accountNumberToRemove);
//    Console.WriteLine("Konto zostało pomyślnie usunięte.");
//    break;
//}
//else if (selectedIndex == 2)
//{
//    Console.Clear();
//    Console.WriteLine("Podaj kwotę do wpłaty:");
//    float amount = float.Parse(Console.ReadLine());
//    userAccount.Deposit(amount);
//    break;
//}
//else if (selectedIndex == 3)
//{
//    Console.Clear();
//    Console.WriteLine("Podaj kwotę do wypłaty:");
//    float amount = float.Parse(Console.ReadLine());
//    userAccount.Withdraw(amount);
//    break;
//}
//else if (selectedIndex == 4)
//{
//    Console.Clear();
//    userAccount.GetBalance();
//    break;
//}
//else if (selectedIndex == 5)
//{
//    Console.Clear();
//    Console.WriteLine("Podaj numer konta docelowego:");
//    int otherAccountNumber = int.Parse(Console.ReadLine());
//    var otherAccount = bank.GetAccount(otherAccountNumber);
//    if (otherAccount != null)
//    {
//        try
//        {
//            Console.WriteLine("Podaj kwotę do wpłaty:");
//            float amount = float.Parse(Console.ReadLine());
//            userAccount.Transfer(otherAccount, amount);
//            Console.WriteLine("Przelew wykonany pomyślnie.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Błąd: " + ex.Message);
//        }
//    }


