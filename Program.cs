using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;

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

        static void writeDeleteUserMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Odaberi način brisanja korisnika:");
            Console.WriteLine("\t1 - briši po id-u");
            Console.WriteLine("\t2 - briši po imenu i prezimenu");
            Console.WriteLine("\t0 - odustani");
            Console.WriteLine();
            Console.Write("Odabir: ");
        }

        static void printAllUsersMenu(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.WriteLine("Odaberi način ispisivanja korisnika:");
            Console.WriteLine("\t1 - ispiši sve korisnike");
            Console.WriteLine("\t2 - ispiši sve korisnike koji imaju više od 20 godina");
            Console.WriteLine("\t3 - ispiši sve korisnike koji imaju barem 2 putovanja");
            Console.WriteLine("\t0 - odustani");
            Console.WriteLine();
            Console.Write("Odabir: ");
        }

        static void writeDeleteTripMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Odaberi način brisanja putovanja:");
            Console.WriteLine("\t1 - briši po id-u");
            Console.WriteLine("\t2 - briši po sva putovanja skuplja od nekog iznosa: ");
            Console.WriteLine("\t3 - briši po sva putovanja jeftinija od nekog iznosa: ");
            Console.WriteLine("\t0 - odustani");
            Console.WriteLine();
            Console.Write("Odabir: ");
        }

        static void writeAllUsers(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.WriteLine("{0,-2} - ime i prezime svih korisnika: ", "id");
            foreach (var user in list)
                Console.WriteLine("{0,-2} - {1} {2}", user.Item1, user.Item2, user.Item3);
            Console.WriteLine();
        }

        static void writeAllTrips(List<(int, int, DateTime, double, double, double, double)> trips)
        {
            Console.WriteLine();
            Console.WriteLine("{0,-2} - datum polaska, broj kilometara i trošak svih putovanja", "id");
            foreach (var trip in trips)
                Console.WriteLine("{0,-2} - {1}, {2}km, {3} EUR", trip.Item2, trip.Item3.ToShortDateString(), trip.Item4, trip.Item7);
        }

        static void writeAllUsersFormatted(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.WriteLine("Svi korisnici:");
            foreach (var user in list)
                Console.WriteLine("{0,-5} - {1} - {2} - {3}", user.Item1, user.Item2, user.Item3, user.Item4.ToShortDateString());
        }

        static void writeAllUsersOlderThan20(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.WriteLine("Svi korisnici koji imaju više od 20 godina:");
            foreach (var user in list)
                if (DateTime.Now.Year - user.Item4.Year >= 20 && DateTime.Now.Month > user.Item4.Month && DateTime.Now.Day > user.Item4.Day)
                    Console.WriteLine("{0} - {1} {2}, {3}", user.Item1, user.Item2, user.Item3, user.Item4.ToShortDateString());
        }

        static void writeAllUsersWithMultipleTrips(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.WriteLine("Svi korisnici koji imaju barem 2 godina:");
            foreach (var user in list)
                if (user.Item5.Count() >= 2)
                    Console.WriteLine("{0} - {1} {2}, {3}", user.Item1, user.Item2, user.Item3, user.Item4.ToShortDateString());
        }

        static int validIntegerInput()
        {
            int intInput;
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out intInput))
                    break;

                Console.Write("Neispravan unos, unesi pozitivan broj: ");
            }
            return intInput;
        }

        static double validDoubleInput()
        {
            double doubleInput;
            while (true)
            {
                string input = Console.ReadLine();

                if (double.TryParse(input, out doubleInput))
                    break;

                Console.Write("Neispravan unos, unesi pozitivan decimalan broj: ");
            }
            return doubleInput;
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

        static DateTime validDateInput()
        {
            DateTime dateInput;
            while (true)
            {
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out dateInput) && dateInput <= DateTime.Now)
                    break;

                Console.Write("Neispravan unos, unesi datum do {0} u formatu YYYY-MM-DD: ", DateTime.Now.ToShortDateString());
            }
            return dateInput;
        }

        static string validStringInput()
        {
            string name;

            while (true)
            {
                name = Console.ReadLine();

                if (name.All(char.IsLetter))
                    break;

                Console.Write("Unesi ime/prezime koje sadrži samo slova: ");
            }
            return name;
        }

        static string[] validNameAndSurnameInput()
        {
            string[] nameAndSurname;

            while (true)
            {
                var input = Console.ReadLine();
                nameAndSurname = input.ToUpper().Split(" ");

                if (nameAndSurname.Length == 2)
                    break;

                Console.Write("Unesi ime i prezime u formatu 'Ime prezime': ");
            }

            return nameAndSurname;
        }

        static int uniqueId(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            int id;
            while (true)
            {
                id = validIntegerInput();
                var idInList = list.Where(person => person.Item1 == id).ToList();
                if (idInList.Count == 0)
                    break;

                Console.Write("Unesi jedinstveni id: ");
            }
            return id;
        }

        static int uniqueId(List<(int, int, DateTime, double, double, double, double)> list)
        {
            int id;
            while (true)
            {
                id = validIntegerInput();
                var idInList = list.Where(trip => trip.Item1 == id).ToList();
                if (idInList.Count == 0)
                    break;

                Console.Write("Unesi jedinstveni id: ");
            }
            return id;
        }

        static int idInList(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            int id;
            while (true)
            {
                id = validIntegerInput();
                var idInList = list.Where(person => person.Item1 == id).ToList();
                if (idInList.Count != 0)
                    break;

                Console.Write("Unesi postojeći id: ");
            }
            return id;
        }

        static int idInList(List<(int, int, DateTime, double, double, double, double)> list)
        {
            int id;
            while (true)
            {
                id = validIntegerInput();
                var idInList = list.Where(trip => trip.Item2 == id).ToList();
                if (idInList.Count != 0)
                    break;

                Console.Write("Unesi postojeći id: ");
            }
            return id;
        }

        static string[] nameAndSurnameInList(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            string[] nameAndSurname;

            while (true)
            {
                nameAndSurname = validNameAndSurnameInput();
                var nameAndSurnameInList = list.Where(person => person.Item2.ToUpper().Equals(nameAndSurname[0]) && person.Item3.ToUpper().Equals(nameAndSurname[1])).ToList();

                if (nameAndSurnameInList.Count != 0)
                    break;

                Console.Write("Unesi ime i prezime postojećeg korisnika: ");
            }

            return nameAndSurname;
        }

        static void deleteUserById(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            writeAllUsers(list);

            Console.Write("Upiši id korisnika kojeg želiš izbrisati: ");
            var idToDelete = idInList(list);

            list.RemoveAll(person => person.Item1 == idToDelete);
        }

        static void deleteTripById(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllTrips(trips);

            Console.Write("Upiši id putovanja koje želiš izbrisati: ");
            var idToDelete = idInList(trips);

            var trip = trips.Where(trip => trip.Item2 == idToDelete).FirstOrDefault();
            var user = users.Where(user => user.Item5.Contains(trip)).FirstOrDefault();

            user.Item5.Remove(trip);
            trips.Remove(trip);
        }

        static void deleteUserByNameAndSurname(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            writeAllUsers(list);

            Console.Write("Upiši ime i prezime korisnika kojeg želiš izbrisati: ");
            var nameAndSurnameToDelete = nameAndSurnameInList(list);

            list.RemoveAll(person => person.Item2.ToUpper().Equals(nameAndSurnameToDelete));
        }

        static void deleteTripsMoreExpensiveThan(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllTrips(trips);

            Console.Write("Upiši najveći trošak koji putovanja mogu imati: ");
            var highestCost = validDoubleInput();

            var tripsMoreExpensiveThan = trips.Where(trip => trip.Item7 > highestCost).ToList();
            foreach (var trip in tripsMoreExpensiveThan)
            {
                var user = users.Where(user => user.Item5.Contains(trip)).FirstOrDefault();
                user.Item5.Remove(trip);
                trips.Remove(trip);
            }
        }

        static void deleteTripsLessExpensiveThan(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            Console.Write("Upiši najveći trošak koji putovanja mogu imati: ");
            var lowestCost = validDoubleInput();

            var tripsLessExpensiveThan = trips.Where(trip => trip.Item7 < lowestCost).ToList();
            foreach (var trip in tripsLessExpensiveThan)
            {
                var user = users.Where(user => user.Item5.Contains(trip)).FirstOrDefault();
                user.Item5.Remove(trip);
                trips.Remove(trip);
            }
        }


        static void addNewUser(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.Write("Unesi id novog korisnika: ");
            int id = uniqueId(list);
            Console.Write("Unesi ime novog korisnika: ");
            string name = validStringInput();
            Console.Write("Unesi prezime novog korisnika: ");
            string surname = validStringInput();
            Console.Write("Unesi datum rođenja novog korisnika: ");
            DateTime dateOfBirth = validDateInput();
            var trips = new List<(int, int, DateTime, double, double, double, double)>();

            list.Add((id, name, surname, dateOfBirth, trips));
        }

        static void deleteUser(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            writeDeleteUserMenu();
            int input = validIntegerInput(0, 2);

            if (input == 1)
                deleteUserById(list);

            if (input == 2)
                deleteUserByNameAndSurname(list);
        }

        static void editUser(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            writeAllUsers(list);
            Console.Write("Upiši id korisnika čije podatke želiš urediti: ");
            var id = idInList(list);

            int indexOfItem = 0;
            foreach (var user in list)
                if (user.Item1 == id)
                    indexOfItem = list.IndexOf(user);

            var userToEdit = list.ElementAt(indexOfItem);
            list.RemoveAt(indexOfItem);

            Console.Write("Unesi novo ime korisnika ili X ako ne želiš mijenjati ime: ");
            string name = validStringInput();
            if (name.ToUpper().Equals("X"))
                name = userToEdit.Item2;

            Console.Write("Unesi novo prezime korisnika ili X ako ne želiš mijenjati prezime: ");
            string surname = validStringInput();
            if (surname.ToUpper().Equals("X"))
                surname = userToEdit.Item3;

            Console.Write("Unesi novi datum rođenja korisnika ili 1111-11-11 ako ne želiš mijenjati datum rođenja: ");
            DateTime dateOfBirth = validDateInput();
            if (dateOfBirth.Equals(1111-11-11))
                dateOfBirth = userToEdit.Item4;

            var trips = new List<(int, int, DateTime, double, double, double, double)>();

            list.Insert(indexOfItem, (id, name, surname, dateOfBirth, trips));

        }

        static void printAllUsers(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            printAllUsersMenu(list);
            int input = validIntegerInput(0, 3);

            if (input == 1)
                writeAllUsersFormatted(list);
            if (input == 2)
                writeAllUsersOlderThan20(list);
            if (input == 3)
                writeAllUsersWithMultipleTrips(list);
        }

        static void addNewTrip(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllUsers(users);
            Console.Write("Unesi id korisnika kojemu želiš dodati putovanje: ");
            var input = idInList(users);
            var user = users.Where(user => user.Item1 == input).FirstOrDefault();

            Console.Write("Unesi id putovanja: ");
            var idOfTrip = uniqueId(trips);
            Console.Write("Unesi datum (YYYY-MM-DD): ");
            DateTime dateOfTravel = validDateInput();
            Console.Write("Unesi kilometražu: ");
            double kmPassed = validDoubleInput();
            Console.Write("Unesi potrošeno gorivo (L): ");
            double fuelUsed = validDoubleInput();
            Console.Write("Unesi cijenu goriva po litri: ");
            double fuelPrice = validDoubleInput();

            double fuelCost = fuelUsed * fuelPrice;
            var trip = (input, idOfTrip, dateOfTravel, kmPassed, fuelUsed, fuelPrice, fuelCost);

            trips.Add(trip);
            user.Item5.Add(trip);
        }

        static void deleteTrips(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeDeleteTripMenu();
            int input = validIntegerInput(0, 3);

            if (input == 1)
                deleteTripById(trips, users);

            if (input == 2)
                deleteTripsMoreExpensiveThan(trips, users);

            if (input == 3)
                deleteTripsLessExpensiveThan(trips, users);
        }

        static void editTrip(List<(int, int, DateTime, double, double, double, double)> trips)
        {

        }

        static void userMenu(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            while (true)
            {
                writeUserMenu();
                int userInput = validIntegerInput(0, 4);

                switch (userInput)
                {
                    case 0:
                        return;
                    case 1:
                        addNewUser(list);
                        break;
                    case 2:
                        deleteUser(list);
                        break;
                    case 3:
                        editUser(list);
                        break;
                    case 4:
                        printAllUsers(list);
                        break;
                    default:
                        break;
                }
            }
        }

        static void tripsMenu(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            while (true)
            {
                writeTripMenu();
                int tripsInput = validIntegerInput(0, 5);

                switch (tripsInput)
                {
                    case 0:
                        return;
                    case 1:
                        addNewTrip(trips, users);
                        break;
                    case 2:
                        deleteTrips(trips, users);
                        break;
                    case 3:
                        editTrip(trips, users);
                        break;

                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA");

            var trips = new List<(int userId, int tripId, DateTime dateOfTravel, double kmPassed, double fuelUsed, double fuelPrice, double fuelCost)>
            {
                (1, 1, new DateTime(2023, 1, 10), 200.4, 19.2, 1.7, 19.2 * 1.7),
                (2, 2, new DateTime(2024, 8, 15), 189.3, 20.1, 1.49, 20.1 * 1.49),
                (3, 3, new DateTime(2022, 4, 22), 400.29, 16.5, 1.53, 16.5 * 1.53),
                (4, 4, new DateTime(2025, 10, 25), 205.5, 12.4, 1.83, 12.4 * 1.83),
                (2, 5, new DateTime(2025, 7, 2), 60.3, 21.3, 1.39, 21.3 * 1.39),
                (4, 6, new DateTime(2024, 6, 4), 300.2, 31.2, 1.43, 31.2 * 1.43)
            };

            var users = new List<(int id, string userName, string userSurname, DateTime dateOfBirth, List<(int, int, DateTime, double, double, double, double)>)>
            {
                (1, "Andrea", "Barada", new DateTime(2005, 7, 15), trips.Where(t => t.userId == 1).ToList()),
                (2, "Mia", "Barada", new DateTime(2005, 7, 15), trips.Where(t => t.userId == 2).ToList()),
                (3, "Daria", "Pažanin", new DateTime(2005, 6, 26), trips.Where(t => t.userId == 3).ToList()),
                (4, "Sara", "Cigler", new DateTime(2006, 3, 10), trips.Where(t => t.userId == 4).ToList())
            };


            while (true)
            {
                writeMainMenu();
                int mainInput = validIntegerInput(0, 2);

                if (mainInput == 0)
                    return;

                if (mainInput == 1)
                    userMenu(users);

                if (mainInput == 2)
                    tripsMenu(trips, users);
            }
        }
    }
}


