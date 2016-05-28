using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:49847/";
            var container = new ODataClientas.Default.Container(new Uri(serviceUri));

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{1} | {2}, {3} r.",game.Title,game.AgeRate,game.Year );
            }

            Console.WriteLine("Dodanie gry");
            container.AddToGames(new ODataClientas.Library.Game {Title = "Nowa",Id=10,Year=2016,AgeRate=21,CreatorCompany="CDP" });
            var serviceResponse = container.SaveChanges();

            //kody odpowiedzi
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
            Console.WriteLine();

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} : {1} | {2}, {3} r.", game.Id, game.Title, game.AgeRate, game.Year);
            }

            Console.WriteLine();

            Console.WriteLine("Lista koszulek na karty:");
            Console.WriteLine("{0}", container.GetAvailableCardShirts());

            Console.WriteLine();

            Console.WriteLine("Lista sklepów:");
            foreach (var shop in container.Stores)
            {
                Console.WriteLine("{0} : {1} ", shop.Name,shop.Address);
            }

            Console.WriteLine("Usuwanie sklepu o nazwie Empik");
            container.Stores.Where(s => s.Name == "Empik").ToList().ForEach(s => container.DeleteObject(s));
            serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }

            Console.WriteLine("Lista sklepów:");
            foreach (var shop in container.Stores)
            {
                Console.WriteLine("{0} : {1} ", shop.Name, shop.Address);
            }

            Console.ReadKey();
        }
    }
}
