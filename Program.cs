using System.Reflection;

namespace C__demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA");
            Console.WriteLine("1 - Korisnici");
            Console.WriteLine("2 - Putovanja");
            Console.WriteLine("0 - Izlaz iz aplikacije");

            var trips = new List<(int id, DateTime dateOfTravel, double kmPassed, double fuelUsed, double fuelPrice, double fuelCost)>
            {
                (1, new DateTime(2023, 1, 10), 200.4, 19.2, 1.7, 19.2 * 1.7),
                (2, new DateTime(2024, 8, 15), 189.3, 20.1, 1.49, 20.1 * 1.49),
                (3, new DateTime(2022, 4, 22), 400.29, 16.5, 1.53, 16.5 * 1.53),
                (4, new DateTime(2025, 10, 25), 205.5, 12.4, 1.83, 12.4 * 1.83),
                (2, new DateTime(2025, 7, 2), 60.3, 21.3, 1.39, 21.3 * 1.39),
                (4, new DateTime(2024, 6, 4), 300.2, 31.2, 1.43, 31.2 * 1.43)
            };

            var users = new List<(int id, string userName, string userSurname, DateTime dateOfBirth, List<(int, DateTime, double, double, double, double)>)>
            {
                (1, "Andrea", "Barada", new DateTime(2005, 7, 15), trips.Where(t => t.id == 1).ToList()),
                (2, "Mia", "Barada", new DateTime(2005, 7, 15), trips.Where(t => t.id == 2).ToList()),
                (3, "Daria", "Pažanin", new DateTime(2005, 6, 26), trips.Where(t => t.id == 3).ToList()),
                (4, "Sara", "Cigler", new DateTime(2006, 3, 10), trips.Where(t => t.id == 4).ToList())
            };


            Console.Write("Odabir: ");
            int menuInput;
            while(true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out menuInput) && menuInput >= 0 && menuInput <= 2)
                    break;

                Console.Write("Neispravan unos, unesi broj 0-2: ");
            }
        }
    }
}


