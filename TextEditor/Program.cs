using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do ?");
            Console.WriteLine("1 - Open Document");
            Console.WriteLine("2 - Create new Document");
            Console.WriteLine("0 - Exit");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;

            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Enter file path?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);

            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter your message.(ESC to exit)");
            Console.WriteLine("--------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Saving(text);

        }

        static void Saving(string text)
        {
            Console.Clear();
            Console.WriteLine("Select the directory to save your document");
            var path = Console.ReadLine();

            // Open and Close files
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"File{path} saved successfull");
            Console.ReadLine();
            Menu();
        }
    }
}