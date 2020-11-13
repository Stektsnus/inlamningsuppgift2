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
        /* CLASS: Person
         * PURPOSE: Used to store and retrieve data about persons contact information for making an address list
         */

        public string name, address, telephone, email;
        public Person(string N, string A, string T, string E)
        {
            /* METHOD: Person (constructor)
             * PURPOSE: Used when a new Person object is to be created using know data from for instance a text file
             * PARAMETERS: string N     -   a string containing information that is going to be the value for the object variable 'name'
             *             string A     -   a string containing information that is going to be the value for the object variable 'address'
             *             string T     -   a string containing information that is going to be the value for the object variable 'telephone'
             *             string E     -   a string containing information that is going to be the value for the object variable 'email'
             * RETURN VALUE: none
             */

            name = N;
            address = A;
            telephone = T;
            email = E;
        }

        public Person()
        {
            /* METHOD: Person (constructor)
             * PURPOSE: Used when a new Person object with no documented data is available through a file
             *          The user is by him/herself puting in the values for the object variables
             * PARAMETERS: none
             * RETURN VALUE: none
             */

            Console.Write("  1. enter name:    ");
            name = Console.ReadLine();
            Console.Write("  2. enter address:  ");
            address = Console.ReadLine();
            Console.Write("  3. enter telephone: ");
            telephone = Console.ReadLine();
            Console.Write("  4. enter email:   ");
            email = Console.ReadLine();
        }

        public void AddOrChangeInformation(string variable, string value)
        {
            /* METHOD: AddOrChangeInformation
             * PURPOSE: Used to add or change information of a given object variable of a Person object
             * PARAMETERS: string variable  -   a string representing the variable to be changed
             *             string value     -   a string with the new value for the variable  
             * RETURN VALUE: none
             */

            if (variable == "name") 
            {
                name = value;
            }
            else if (variable == "address")
            {
                address = value;
            }
            else if (variable == "telephone")
            {
                telephone = value;
            }
            else if (variable == "email")
            {
                email = value;
            }
            else
            {
                Console.WriteLine("Please enter valid variable name.");
            }
        }
        
        public void Print() 
        {
            /* METHOD: Print 
             * PURPOSE: Used to print the contact information of a given Person object
             * PARAMETERS: none
             * RETURN VALUE: none
             */
            Console.WriteLine($"{name}, {address}, {telephone}, {email}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /* METHOD: Main (static)
             * PURPOSE: Used to call the right function depending on the user input
             * PARAMETERS: args - Command-line arguments from the operating system
             * RETURN VALUE: none
             */

            // Variable delcarations:
            List<Person> Dict = new List<Person>();
            string filePath = @"C:\Users\sebas\Dropbox\Programmering\vs\Progmet\inlamningsuppgift2\address.txt";
            Dict.AddRange(LoadFile(filePath));
            
            Console.WriteLine("Hello and welcome to the address list");
            Console.WriteLine("Write 'stop' to stop!");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "stop")
                {
                    Console.WriteLine("Bye!");
                }
                else if (command == "new")
                {
                    AddPerson(Dict);
                }
                else if (command == "remove")
                {
                    RemovePerson(Dict);
                }
                else if (command == "show")
                {
                    ShowPersons(Dict);
                }
                else if (command == "change")
                {
                    ChangePerson(Dict);
                }
                else
                {
                    Console.WriteLine("Unknown command: {0}", command);
                }
            } while (command != "stop");
        }

        private static void ShowPersons(List<Person> Dict)
        {
            /* METHOD: ShowPersons (static)
             * PURPOSE: Used to show all the persons in the address list Dict
             * PARAMETERS: List<Person> Dict - A list of Person objects
             * RETURN VALUE: none
             */

            for (int i = 0; i < Dict.Count(); i++)
            {
                Dict[i].Print();
                
            }
        }

        private static void ChangePerson(List<Person> Dict)
        {
            /* METHOD: ChangePerson (static)
             * PURPOSE: Used to change the value of any given object variable in a given person in the address list Dict
             * PARAMETERS: List<Person> Dict - A list of Person objects
             * RETURN VALUE: none
             */

            Console.Write("Who do you want to change (enter name): ");
            string personToChange = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == personToChange) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Unfortunately: {0} was not found in the address list", personToChange);
            }
            else
            {
                Console.Write("What would you like to change (name, address, telephone or email): ");
                string changeVariable = Console.ReadLine();
                Console.Write("What would you like to change {0} on {1} to: ", changeVariable, personToChange);
                string newValue = Console.ReadLine();
                switch (changeVariable)
                {
                    case "name": Dict[found].name = newValue; break;
                    case "address": Dict[found].address = newValue; break;
                    case "telephone": Dict[found].telephone = newValue; break;
                    case "email": Dict[found].email = newValue; break;
                    default: break;
                }
            }
        }

        private static void RemovePerson(List<Person> Dict)
        {
            /* METHOD: RemovePerson (static)
             * PURPOSE: Used to remove a given Person object from the list Dict
             * PARAMETERS: List<Person> Dict - A list of Person objects
             * RETURN VALUE: none
             */

            Console.Write("Who would you like to remove (enter name): ");
            string personToRemove = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == personToRemove) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Unfortunately: {0} was not found in the address list", personToRemove);
            }
            else
            {
                Dict.RemoveAt(found);
            }
        }

        private static void  AddPerson(List<Person> Dict)
        {
            /* METHOD: AddPerson (static)
             * PURPOSE: Used to create and add a new person to the list Dict
             * PARAMETERS: List<Person> Dict - A list of Person objects
             * RETURN VALUE: none
             */

            Console.WriteLine("Adding new person");
            Person P = new Person();
            Dict.Add(P);
        }

        private static List<Person> LoadFile(string filePath)
        {
            /* METHOD: LoadFile (static)
             * PURPOSE: Used to load a file from the given filepath
             * PARAMETERS: string filePath - A string representing the filepath to a file containing information about persons and their address data
             * RETURN VALUE: List<Person> newPersons - a list of Person objects of created from the information contained in the loaded file
             */

            Console.Write("Loading the address list ... ");
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
            Console.WriteLine("done!");
            return newPersons;
        }
    }
}