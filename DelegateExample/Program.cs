using System;
using DataStructures;

namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = new CustomLinkedList<Person>();

            try
            {
                personList.Add(new Person
                {
                    Id = 1,
                    Name = "Juan",
                    BirthDate = DateTime.Parse("2019/01/25")
                });

                personList.Add(new Person
                {
                    Id = 2,
                    Name = "Paco",
                    BirthDate = DateTime.Parse("2019/01/25")
                });

                personList.Add(new Person
                {
                    Id = 1,
                    Name = "Pedro",
                    BirthDate = DateTime.Parse("2019/01/26")
                }, Person.CompareByBirthDate);

                var paco = personList.Find(x => x.Name == "Paco");
                Console.WriteLine(paco);

                var notPaco = personList.Find(x => x.Name != "Paco");
                Console.WriteLine(notPaco);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
