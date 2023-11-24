namespace Basic
{
    public class Notebook
    {
        public void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Dodaj notatkę");
                Console.WriteLine("2. Pokaż notatki");
                Console.WriteLine("3. Skasuj notatkę");
                Console.WriteLine("4. Wyjdź");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNote();
                        break;
                    case "2":
                        ShowNotes();
                        Console.ReadKey();
                        break;
                    case "3":
                        DeleteNotes();
                        Console.ReadKey();
                        break;
                    case "4":
                        running = false;
                        break;
                }
            }
        }
        static void AddNote()
        {
            Console.WriteLine("Co chcesz zapisać?");
            string note = Console.ReadLine();
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            File.AppendAllText("notes.txt", $"{dateTime}: {note} {Environment.NewLine}");  
        }
        static void ShowNotes()
        {
            string[] notes = File.ReadAllLines("notes.txt");
            foreach (string note in notes)
            {
                Console.WriteLine(note);
            }
        }
        static void DeleteNotes()
        {
            Console.WriteLine("Wybierz notatkę do usunięcia:");
            Console.WriteLine();
            string[] notes = File.ReadAllLines("notes.txt");
            for (int i = 0; i < notes.Length; i++)
            {
                Console.WriteLine($"notatka {i+1}: {notes[i]}");
            }
            Console.WriteLine();
            Console.WriteLine( "Wpisz numer notatki, którą chcesz usunąć:");
            if(int.TryParse(Console.ReadLine(), out int noteNumber) && noteNumber >= 1 && noteNumber <= notes.Length)
            {
                List<string> updateNotes = notes.ToList();
                updateNotes.RemoveAt(noteNumber - 1);
                File.WriteAllLines("notes.txt", updateNotes);
                Console.WriteLine("Notatka została usunięta");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer notatki, spróbuj jeszcze raz.");
            }
            Console.WriteLine("Kliknij dowolny przycisk aby wrócić do menu");


        }
    }
}

