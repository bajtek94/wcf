using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client.MyService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            
            try
            {
                Console.WriteLine("CONNECTION Warszawa -> Skierniewice");
                TrainConnection[] list = client.FindConnection("Warszawa", "Skierniewice");
                printConnection(list);
                Console.WriteLine("\n");
                Console.WriteLine("CONNECTION Warszawa -> Lowicz");
                TrainConnection[] list1 = client.FindConnection("Warszawa", "Lowicz");
                printConnection(list1);
                Console.WriteLine("\n");
                Console.WriteLine("CONNECTION Skierniewice -> Warszawa");
                TrainConnection[] list2 = client.FindConnection("Skierniewice", "Warszawa");
                printConnection(list2);
                Console.WriteLine("\n");
                Console.WriteLine("Click any button to search connection with bad name of city");
                Console.ReadKey();
                Console.WriteLine("BAD CITY");
                TrainConnection[] list3 = client.FindConnection("Warszawaaaa", "Skierniewice");
                printConnection(list3);
            }
            catch(Exception)
            {
                Console.WriteLine("City doesn't exist!");
            }
            Console.ReadKey();
        }

        static void printConnection(TrainConnection[] list)
        {
            foreach (TrainConnection tc in list)
            {
                string start = tc.StartTimek__BackingField.Hour.ToString() + ":" + tc.StartTimek__BackingField.Minute.ToString();
                string end = tc.EndTimek__BackingField.Hour.ToString() + ":" + tc.EndTimek__BackingField.Minute.ToString();
                Console.WriteLine("(" + start + ")" + tc.City1k__BackingField + " -> (" + end + ")" + tc.City2k__BackingField);
            }
            if(list.Length == 0)
            {
                Console.WriteLine("There isn't any connection for your search.");
            }
        }

    }

}
