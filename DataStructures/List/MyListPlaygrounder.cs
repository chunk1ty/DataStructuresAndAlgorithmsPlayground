using System;
using System.Collections.Generic;

namespace DataStructures.List
{
    public static class MyListPlaygrounder
    {
        public static void Play()
        {
            var list = new List<int>();

            // #Add
            var mylist = new MyList<int>();
            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Count: {mylist.Count}");
            
            // #Insert
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // mylist.Insert(2, 17);
            // foreach (var item in mylist)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine($"Count: {mylist.Count}");

            // #RemoveAt
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // mylist.RemoveAt(2);
            // foreach (var item in mylist)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine($"Count: {mylist.Count}");
            
            // #Remove
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // mylist.Remove(2);
            // foreach (var item in mylist)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine($"Count: {mylist.Count}");

            // #Contains 
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // Console.WriteLine($"Contains [17] - {mylist.Contains(17)}");
            // Console.WriteLine($"Contains [3] - {mylist.Contains(3)}");
            
            // #Find
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // Console.WriteLine($"Find [17] - {mylist.Find(x => x == 17)}");
            // Console.WriteLine($"Find [3] - {mylist.Find(x => x == 3)}");
            
            // #FindAll
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // foreach (var item in mylist.FindAll(x => x > 3))
            // {
            //     Console.WriteLine(item);
            // }
            
            // #IndexOf
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // Console.WriteLine($"IndexOf [17] - {mylist.IndexOf(17)}");
            // Console.WriteLine($"IndexOf [4] - {mylist.IndexOf(4)}");

            // #Clear
            // var mylist = new MyList<int> {1, 2, 3, 4, 5};
            // mylist.Clear();
            // foreach (var item in mylist)
            // {
            //     Console.WriteLine(item);
            // }
        }
    }
}