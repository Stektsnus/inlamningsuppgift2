using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlamningsuppgift2
{
    class Person
    {
        public string namn, adress, telefon, email;
        public Person(string N, string A, string T, string E)
        {
            namn = N; adress = A; telefon = T; email = E;
        }
        public void Print() 
        {
            Console.WriteLine($"{namn}, {adress}, {telefon}, {email}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Variable delcarations
            List<Person> Dict = new List<Person>();
            string filePath = @"C:\Users\sebas\Dropbox\Programmering\vs\Progmet\inlamningsuppgift2\address.txt";
            Dict.AddRange(LoadFile(filePath));
            
            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då!");
                }
                else if (command == "ny")
                {
                    Dict.Add(AddPerson());
                }
                else if (command == "ta bort")
                {
                    RemovePerson(Dict);
                }
                else if (command == "visa")
                {
                    ShowPersons(Dict);
                }
                else if (command == "ändra")
                {
                    ChangePerson(Dict);
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
        }

        private static void ShowPersons(List<Person> Dict)
        {
            for (int i = 0; i < Dict.Count(); i++)
            {
                Dict[i].Print();
                
            }
        }

        private static void ChangePerson(List<Person> Dict)
        {
            Console.Write("Vem vill du ändra (ange namn): ");
            string villÄndra = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].namn == villÄndra) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", villÄndra);
            }
            else
            {
                Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
                string fältAttÄndra = Console.ReadLine();
                Console.Write("Vad vill du ändra {0} på {1} till: ", fältAttÄndra, villÄndra);
                string nyttVärde = Console.ReadLine();
                switch (fältAttÄndra)
                {
                    case "namn": Dict[found].namn = nyttVärde; break;
                    case "adress": Dict[found].adress = nyttVärde; break;
                    case "telefon": Dict[found].telefon = nyttVärde; break;
                    case "email": Dict[found].email = nyttVärde; break;
                    default: break;
                }
            }
        }

        private static void RemovePerson(List<Person> Dict)
        {
            Console.Write("Vem vill du ta bort (ange namn): ");
            string villTaBort = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].namn == villTaBort) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", villTaBort);
            }
            else
            {
                Dict.RemoveAt(found);
            }
        }

        private static Person AddPerson()
        {
            
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            string name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            string adress = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            string telefon = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            string email = Console.ReadLine();
            Person P = new Person(name, adress, telefon, email);

            return P;
        }

        private static List<Person> LoadFile(string filePath)
        {
            Console.Write("Laddar adresslistan ... ");
            List<Person> newPersons = new List<Person>();
            using (StreamReader fileStream = new StreamReader(@"C:\Users\sebas\Dropbox\Programmering\vs\Progmet\inlamningsuppgift2\address.txt"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    // Console.WriteLine(line);
                    string[] word = line.Split('#');
                    // Console.WriteLine("{0}, {1}, {2}, {3}", word[0], word[1], word[2], word[3]);
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    newPersons.Add(P);
                }
            }
            Console.WriteLine("klart!");
            return newPersons;
        }
    }
}