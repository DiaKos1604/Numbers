using Basic.BankAccount;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Basic.Menu
{
    public class Login
    {
        public static void LoginToAccount()

        {
            Console.WriteLine("Wprowadź dane do logowania");

            Console.WriteLine("Login:");
            var login = Console.ReadLine();

            Console.WriteLine("Hasło:");
            var password = Console.ReadLine();

            var user = ValidateUser(login, HashPassword(password)); 
            if (user != null)
            {
                if (user.Password == password)
                {
                    Console.Clear();
                    Console.WriteLine($"Witaj {user.Login}");
                    Bank bank = user.Bank;
                    BankMenu.StartMenu(user.Id, user.Login,bank);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa nazwa użytkownika lub hasło.");
                }
            }
            else
            {
                Console.WriteLine("Przykro mi, logowanie się nie powiodło");
            }
            Console.ReadLine();
            Console.Clear();

        }
        public static User ValidateUser(string login, string hashedPassword)
        {
            string csvFile = Path.Combine("..\\..\\Data\\users.csv");

            if (!File.Exists(csvFile))
            {
                Console.WriteLine("Plik użytkowników nie został znaleziony.");
                return null;
            }

            var lines = File.ReadAllLines(csvFile).Skip(1);
            var users = lines
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(','))
                .Where(parts => parts.Length == 3)
                .Select(parts => new User { Id = parts[0], Login = parts[1], Password = parts[2] });
            
            var user = users.FirstOrDefault(u => u.Login == login && u.Password == hashedPassword);
            return user;
        }
        public static void Registration()
        {
            while (true)
            {

                Console.WriteLine("Nazwa użytkownika: ");
                string newLogin = Console.ReadLine();

                if (CheckLoginExists(newLogin))
                {
                    Console.WriteLine("Użytkownik o takim loginie już istnieje.\n");
                    Console.ReadKey();

                }

                else
                {
                    Console.WriteLine("Hasło musi mieć min. 10 znaków (min. jedna duża litera, jedna cyfra i jeden znak specjalny).Wprowadź swoje hasło:");
                    string newPassword = Console.ReadLine();

                    Console.WriteLine("Hasło(powtórz): ");
                    string checkNewPassword = Console.ReadLine();

                    if (!IsPasswordValid(newPassword))
                    {
                        Console.WriteLine("Hasło nie spełnia wymagań (min. 10 znaków, jedna duża litera, jedna cyfra i jeden znak specjalny)\n");
                        Console.ReadKey();
                    }

                    else
                    {

                        if (newPassword == checkNewPassword)
                        {
                            string newUserId = GuidGenerator();
                            AddUser(newLogin, newPassword);
                            Console.WriteLine("Użytkownik został zarejestrowany.");
                            Thread.Sleep(1500);
                            return;
                            // BankMenu.StartMenu(newUserId, newLogin);

                        }
                        else
                        {
                            Console.WriteLine("Hasła nie są takie same!\n");
                            Thread.Sleep(1500);
                        }

                    }
                }
                Console.Clear();

            }

        }

        static bool CheckLoginExists(string login)
        {

            string path = Path.Combine("..\\..\\Data\\users.csv");

            if (!File.Exists(path))
            {

                Console.WriteLine("Błąd połączenia z bazą danych!");
                return false;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(",");
                    if (fields.Length >= 2 && fields[1] == login.ToLower())
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        static bool IsPasswordValid(string password)
        {
            return password.Length >= 10 && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "\\d") && Regex.IsMatch(password, "\\W");
        }

        static void AddUser(string login, string password)
        {
            string hashedPassword = HashPassword(password);
            string path = Path.Combine("..\\..\\Data\\users.csv");

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{GuidGenerator()},{login},{hashedPassword}");
            }
        }
        public static string GuidGenerator()
        {
            Guid guid = Guid.NewGuid();
            string newGuid = guid.ToString();
            return newGuid;
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Konwersja stringa na bajty
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Hashowanie hasła
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Konwersja bajtów z powrotem na stringa w formacie hexadecymalnym
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

    }
}
