using System;
using System.Collections.Generic;
using System.Linq;


namespace Collections
{
    class Program
    {
        private static Dictionary<int, List<Entity>> ListDictionary(List<Entity> list_)
        {
            var list = list_;
            list_ = list_.GroupBy(z => z.ParentId)
                .Select(o => o.OrderBy(z => z.Id).First())
                .ToList();
            var dictionary = list_.ToDictionary(z => z.ParentId, z => new List<Entity>());
            foreach (var item in list)
            {
                dictionary[item.ParentId].Add(item);
            }
            return dictionary;
        }

        static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity>()
            {
               new Entity { Id = 1, ParentId = 0, Name = "Root entity"},
               new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
               new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
               new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
               new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"}
            };

            var dictionary = ListDictionary(entities);

            foreach (var firstItem in dictionary)
            {
                Console.Write($"Key = {firstItem.Key}, ");

                foreach (var secondItem in firstItem.Value)
                {
                    if (firstItem.Value.Count > 1)
                    {
                        Console.Write($"Value = List {{Entity{{Id = {secondItem.Id}}}}}, ");

                    }

                    else
                    {
                        Console.WriteLine($"Value = List {{Entity{{Id = {secondItem.Id}}}}}");
                    }
                }
                if (firstItem.Value.Count > 1) Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
