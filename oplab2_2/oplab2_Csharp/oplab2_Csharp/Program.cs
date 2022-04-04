using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace oplab2_Csharp
{
   class Program
    {
        static void Main(string[] args)
        {
            //створення назв файлів
            const string inputPath = "input.txt";
            const string del35Path = "del35.txt";
            const string VoenkomPath = "voenkom.txt";
            //створення файла зі списком абітурієнтів
            InitEntities(inputPath);
            var people = GetFromFile(inputPath);
            OutputPeople(people, "Here are people:");
            //видалення зі списку абітурієнтів старших 35 років та занесення до нового файлу
            var del35people = Del35(people);
            OutputPeople(del35people, "Here are people under 35:");

            WriteToFile(del35people, del35Path, FileMode.OpenOrCreate);

            var del35people_fromfile = GetFromFile(del35Path);
            //створення файлу зі списком абітурієнтів призивного віку
            var voenkom = Voenkom(del35people_fromfile, VoenkomPath);
            OutputPeople(voenkom, "Here are people who should go to voenkom:");
            WriteToFile(voenkom, VoenkomPath, FileMode.OpenOrCreate);

            //перевірка файлів
            Console.WriteLine("Checking files...\n");
            var del35newlist = GetFromFile(del35Path);
            OutputPeople(del35newlist, "From file del35:");

            var voenkomnewlist = GetFromFile(VoenkomPath);
            OutputPeople(voenkomnewlist, "From file voenkom:");
        }

        private static void OutputPeople(List<Person> people, string prompt)
        {
            Console.WriteLine(prompt);

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        private static void InitEntities(string path)
        {
            var people = new List<Person>()
            {
                new Person( "Ivan36", "11.04.1986", "male"),
                new Person( "Ivan34-35", "04.04.1987", "male"),
                new Person( "Lucy22", "12.07.2000", "female"),
                new Person( "Nik18+", "04.04.2004", "male"),
                new Person( "Max17", "17.05.2004", "male")
            };

            WriteToFile(people, path, FileMode.OpenOrCreate);
        }

        private static List<Person> Voenkom(List<Person> old, string path)
        {
            var people= new List<Person>();

            foreach (var person in old)
            {
                var date = person.GetBirthDate().Split('.');
                int year = Convert.ToInt32(date[2]);
                int month;
                int day;

                if(date[1].StartsWith("0"))
                {
                    month = Convert.ToInt32(date[1].Substring(1));
                }
                else
                {
                    month = Convert.ToInt32(date[1]);
                }

                if (date[0].StartsWith("0"))
                {
                    day = Convert.ToInt32(date[0].Substring(1));
                }
                else
                {
                    day = Convert.ToInt32(date[0]);
                }

                if (year > 1995 && year < 2004 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }

                if (month > 4 && year == 1995 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }
                if (day > 4 && month == 4 && year == 1995 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }
                
                if (month < 4 && year == 2004 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }
                if (day <= 4 && month == 4 && year == 2004 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }
                
            }
            return people;
        }

        private static List<Person> Del35(List<Person> old)
        {
            var people = new List<Person>();

            foreach (var person in old)
            {
                var date = person.GetBirthDate().Split('.');

                int year = Convert.ToInt32(date[2]);

                int month;
                int day;

                if (date[1].StartsWith("0"))
                {
                    month = Convert.ToInt32(date[1].Substring(1));
                }
                else
                {
                    month = Convert.ToInt32(date[1]);
                }

                if (date[0].StartsWith("0"))
                {
                    day = Convert.ToInt32(date[0].Substring(1));
                }
                else
                {
                    day = Convert.ToInt32(date[0]);
                }

                if (year > 1987)
                {
                    people.Add(person);
                }
                if (year == 1987 && month > 4 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }
                if (year == 1987 && day > 4 && month == 4 && string.Equals(person.GetSex(), "male"))
                {
                    people.Add(person);
                }
                

            }
            return people;
        }

        private static void WriteToFile(List<Person> people, string outputPath, FileMode fileMode)
        {
            var stream = File.Open(outputPath, FileMode.Create);

            var binaryFormatter = new BinaryFormatter();

            foreach (var person in people)
            {
                binaryFormatter.Serialize(stream, person);
            }

            stream.Close();
        }

        private static List<Person> GetFromFile(string outputPath)
        {
            var people = new List<Person>();
            var stream = File.Open(outputPath, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();

            while (stream.Position < stream.Length)
            {
                people.Add((Person)binaryFormatter.Deserialize(stream));
            }

            stream.Close();

            return people;
        }
   }
}


