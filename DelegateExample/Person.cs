

using System;

namespace DelegateExample
{
    public class Person : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Name} | {BirthDate}";
        }

        public int CompareTo(object obj)
        {
            var person = (Person)obj;
            return Id.CompareTo(person.Id);
        }

        public static Comparison<Person> CompareByName = delegate (Person p1, Person p2)
        {
            return p1.Name.CompareTo(p2.Name);
        };

        public static Comparison<Person> CompareByBirthDate = delegate (Person p1, Person p2)
        {
            return p1.BirthDate.CompareTo(p2.BirthDate);
        };
    }
}
