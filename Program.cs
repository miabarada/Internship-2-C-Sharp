using System.Reflection;

namespace C__demo
{
    internal class Program
    {
        static void writeMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Korisnici");
            Console.WriteLine("2 - Putovanja");
            Console.WriteLine("0 - Izlaz iz aplikacije");
            Console.WriteLine();
            Console.Write("Odabir: ");
        }

        static void writeUserMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Unos novog korisnika");
            Console.WriteLine("2 - Brisanje korisnika");
            Console.WriteLine("3 - Uređivanje korisnika");
            Console.WriteLine("4 - Pregled svih korisnika");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            Console.WriteLine();
            Console.Write("Odabir: ");
        }

        static void writeTripMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Unos novog putovanja");
            Console.WriteLine("2 - Brisanje putovanja");
            Console.WriteLine("3 - Uređivanje postojećeg putovanja");
            Console.WriteLine("4 - Pregled svih putovanja");
            Console.WriteLine("5 - Izvještaji i analize");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            Console.WriteLine();

            Console.Write("Odabir: ");
        }

        static int validIntegerInput(int bottomLimit, int topLimit)
        {
            int intInput;
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out intInput) && intInput >= bottomLimit && intInput <= topLimit)
                    break;

                Console.Write("Neispravan unos, unesi broj {0}-{1}: ", bottomLimit, topLimit);
            }
            return intInput;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA");

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


           
        }
    }
}


