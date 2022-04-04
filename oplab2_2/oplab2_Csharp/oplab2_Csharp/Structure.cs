using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace oplab2_Csharp
{
    [Serializable]

    public struct Person
    {
        public Person(string name, string date, string sex)
        {
            Name = name;
            BirthDate = date;
            Sex = sex;
        }

        private string Name
        { get; set; }

        private string BirthDate
        { get; set; }

        private string Sex
        { get; set; }

        public string GetName()
        {
            return Name;
        }

        public string GetBirthDate()
        {
            return BirthDate;
        }

        public string GetSex()
        {
            return Sex;
        }

        public override string ToString()
        {
            return $"Person=[{ Name }, { BirthDate },{ Sex }]";
        }
    }
}