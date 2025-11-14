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

        static void printAllUsersMenu()
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

        static void writeAllTripsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Odaberi način ispisivanja putovanja:");
            Console.WriteLine("\t1 - po redu upisa");
            Console.WriteLine("\t2 - uzlazno po ukupnom trošku");
            Console.WriteLine("\t3 - silazno po ukupnom trošku");
            Console.WriteLine("\t4 - uzlazno po kilometraži");
            Console.WriteLine("\t5 - silazno po kilometraži");
            Console.WriteLine("\t6 - uzlazno po datumu putovanja");
            Console.WriteLine("\t7 - silazno po datumu putovanja");
            Console.WriteLine("\t0 - odustani");
            Console.WriteLine();
            Console.Write("Odabir: ");
        }

        static void writeAnalysisMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Odaberi izvještaj koji želiš vidjeti:");
            Console.WriteLine("\t1 - ukupna potrošnja goriva");
            Console.WriteLine("\t2 - ukupni troškovi goriva");
            Console.WriteLine("\t3 - prosječna potrošnja goriva u L/100km");
            Console.WriteLine("\t4 - putovanje s najvećom potrošnjom goriva");
            Console.WriteLine("\t5 - pregled putovanja po datumu");
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

        static void writeAllTripsFormatted(List<(int, int, DateTime, double, double, double, double)> trips)
        {
            foreach (var trip in trips)
            {
                Console.WriteLine();
                Console.WriteLine("Putovanje #{0}", trip.Item2);
                Console.WriteLine("Datum: {0}", trip.Item3.ToShortDateString());
                Console.WriteLine("Kilometri: {0}", trip.Item4);
                Console.WriteLine("Gorivo: {0} L", trip.Item5);
                Console.WriteLine("Cijena po litri: {0} EUR", trip.Item6);
                Console.WriteLine("Ukupno: {0} EUR", trip.Item7);
            }
        }

        static void writeAllUsersOlderThan20(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            Console.WriteLine("Svi korisnici koji imaju više od 20 godina:");
            foreach (var user in list)
                if (DateTime.Now.Year - user.Item4.Year >= 20 && DateTime.Now.Month >= user.Item4.Month && DateTime.Now.Day >= user.Item4.Day)
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
                var nameAndSurnameInList = list.Where(person => person.Item2.ToUpper().Equals(nameAndSurname[0].ToUpper()) && person.Item3.ToUpper().Equals(nameAndSurname[1].ToUpper())).ToList();

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

            Console.WriteLine("Jeste li sigurni da želite izbrisati korisnika sa id-em {0}?\n\t1 - DA\n\t0 - NE", idToDelete);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            list.RemoveAll(person => person.Item1 == idToDelete);
            Console.WriteLine("Korisnik sa id-em {0} je uspješno izbrisan!", idToDelete);
        }

        static void deleteTripById(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllTrips(trips);

            Console.Write("Upiši id putovanja koje želiš izbrisati: ");
            var idToDelete = idInList(trips);

            Console.WriteLine("Jeste li sigurni da želite izbrisati putovanje sa id-em {0}?\n\t1 - DA\n\t0 - NE", idToDelete);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            var trip = trips.Where(trip => trip.Item2 == idToDelete).FirstOrDefault();
            var user = users.Where(user => user.Item5.Contains(trip)).FirstOrDefault();

            user.Item5.Remove(trip);
            trips.Remove(trip);
            Console.WriteLine("Putovanje s id-em {0} uspješno izbrisano!", idToDelete);
        }

        static void deleteUserByNameAndSurname(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            writeAllUsers(list);

            Console.Write("Upiši ime i prezime korisnika kojeg želiš izbrisati: ");
            var nameAndSurnameToDelete = nameAndSurnameInList(list);

            Console.WriteLine("Jeste li sigurni da želite obrisati korisnika {0} {1}?\n\t1 - DA\n\t0 - NE", nameAndSurnameToDelete[0], nameAndSurnameToDelete[1]);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            list.RemoveAll(person => person.Item2.ToUpper().Equals(nameAndSurnameToDelete[0]) && person.Item3.ToUpper().Equals(nameAndSurnameToDelete[1]));
            Console.WriteLine("Korisnik {0} {1} uspješno je izbrisan!", nameAndSurnameToDelete[0], nameAndSurnameToDelete[1]);
        }

        static void deleteTripsMoreExpensiveThan(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllTrips(trips);

            Console.Write("Upiši najveći trošak koji putovanja mogu imati: ");
            var highestCost = validDoubleInput();

            Console.WriteLine("Jeste li sigurni da želite obrisati sva putovanja skuplja od {0} EUR?\n\t1 - DA\n\t0 - NE", highestCost);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            var tripsMoreExpensiveThan = trips.Where(trip => trip.Item7 > highestCost).ToList();
            foreach (var trip in tripsMoreExpensiveThan)
            {
                var user = users.Where(user => user.Item5.Contains(trip)).FirstOrDefault();
                user.Item5.Remove(trip);
                trips.Remove(trip);
            }

            Console.WriteLine("Sva putovanja skuplja od {0} uspješno su izbrisana!", highestCost);
        }

        static void deleteTripsLessExpensiveThan(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            Console.Write("Upiši najmanje trošak koji putovanja mogu imati: ");
            var lowestCost = validDoubleInput();

            Console.WriteLine("Jeste li sigurni da želite obrisati sva putovanja jeftinija od {0} EUR?\n\t1 - DA\n\t0 - NE", lowestCost);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            var tripsLessExpensiveThan = trips.Where(trip => trip.Item7 < lowestCost).ToList();
            foreach (var trip in tripsLessExpensiveThan)
            {
                var user = users.Where(user => user.Item5.Contains(trip)).FirstOrDefault();
                user.Item5.Remove(trip);
                trips.Remove(trip);
            }

            Console.WriteLine("Sva putovanja jeftinija od {0} uspješno su izbrisana!", lowestCost);
        }

        static void addNewUser(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            Console.WriteLine();
            int id = list.Count() + 1;
            Console.Write("Unesi ime novog korisnika: ");
            string name = validStringInput();
            Console.Write("Unesi prezime novog korisnika: ");
            string surname = validStringInput();
            Console.Write("Unesi datum rođenja novog korisnika (YYYY-MM-DD): ");
            DateTime dateOfBirth = validDateInput();
            var trips = new List<(int, int, DateTime, double, double, double, double)>();

            list.Add((id, name, surname, dateOfBirth, trips));
            Console.WriteLine("Novi korisnik uspješno dodan!");
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

            Console.WriteLine("Jeste li sigurni da želite urediti korisnika s id-em {0}?\n\t1 - DA\n\t0 - NE", id);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            var userToEdit = list.Where(user => user.Item1 == id).FirstOrDefault();
            list.Remove(userToEdit);

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

            list.Add((id, name, surname, dateOfBirth, trips));
            list.OrderBy(user => user.Item1);

            Console.WriteLine("Novi podaci korisnika s id-em {0} uspješno su spremljeni!", id);
        }

        static void printAllUsers(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> list)
        {
            printAllUsersMenu();
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

            var idOfTrip = trips.Count() + 1;
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
            Console.WriteLine("Novo putovanje uspješno je dodano!");
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

        static void editTrip(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllTrips(trips);
            Console.Write("Unesi id putovanja koje želiš uređivati: ");
            var input = idInList(trips);

            Console.WriteLine("Jeste li sigurni da želite urediti putovanje s id-em {0}?\n\t1 - DA\n\t0 - NE", input);
            Console.Write("Odabir: ");
            var areYouSure = validIntegerInput(0, 1);

            if (areYouSure == 0)
                return;

            var tripToEdit = trips.Where(trip => trip.Item2 == input).FirstOrDefault();
            var userWithTripToEdit = users.Where(user => user.Item5.Contains(tripToEdit)).FirstOrDefault();

            Console.Write("Unesi novi datum putovanja korisnika ili 1111-11-11 ako ne želiš mijenjati datum rođenja: ");
            DateTime dateOfTravel = validDateInput();
            if (dateOfTravel.Equals(1111 - 11 - 11))
                dateOfTravel = tripToEdit.Item3;

            Console.Write("Unesi novu kilometražu puta ili 0 ako je ne želiš mijenjati: ");
            double kmPassed = validDoubleInput();
            if (kmPassed == 0)
                kmPassed = tripToEdit.Item4;

            Console.Write("Unesi novu količinu potrošenog goriva u litrama ili 0 ako ga ne želiš mijenjati: ");
            double fuelUsed = validDoubleInput();
            if (fuelUsed == 0)
                fuelUsed = tripToEdit.Item5;

            Console.Write("Unesi novu cijenu goriva ili 0 ako je ne želiš mijenjati: ");
            double fuelPrice = validDoubleInput();
            if (fuelPrice == 0)
                fuelPrice = tripToEdit.Item4;

            var fuelCost = fuelPrice * fuelUsed;

            var editedTrip = (tripToEdit.Item1, tripToEdit.Item2, dateOfTravel, kmPassed, fuelUsed, fuelPrice, fuelCost);
            trips.Remove(tripToEdit);
            trips.Add(editedTrip);
            trips.OrderBy(trip => trip.Item2);

            foreach (var user in users)
                if (user.Equals(userWithTripToEdit))
                {
                    user.Item5.Remove(tripToEdit);
                    user.Item5.Add(editedTrip);
                    user.Item5.OrderBy(item => item.Item2);
                }

            Console.WriteLine("Novi podaci putovanja s id-em {0} uspješno su pohranjeni!", input);
        }

        static void printAllTrips(List<(int, int, DateTime, double, double, double, double)> trips, List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllTripsMenu();
            int input = validIntegerInput(0, 7);

            if (input == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Sva putovanja:");
                writeAllTripsFormatted(trips);
            }

            if (input == 2)
            {
                var tripsByRisingCost = trips.OrderBy(order => order.Item7).ToList();
                writeAllTrips(tripsByRisingCost);
            }

            if (input == 3)
            {
                var tripsByDescendingCost = trips.OrderByDescending(order => order.Item7).ToList();
                writeAllTrips(tripsByDescendingCost);
            }

            if (input == 4)
            {
                var tripsByRisingKmPassed = trips.OrderBy(order => order.Item4).ToList();
                writeAllTrips(tripsByRisingKmPassed);
            }

            if (input == 5)
            {
                var tripsByDescendingKmPassed = trips.OrderByDescending(order => order.Item4).ToList();
                writeAllTrips(tripsByDescendingKmPassed);
            }

            if (input == 6)
            {
                var tripsByRisingDateOfTravel = trips.OrderBy(order => order.Item3).ToList();
                writeAllTrips(tripsByRisingDateOfTravel);
            }

            if (input == 6)
            {
                var tripsByDescendingDateOfTravel = trips.OrderByDescending(order => order.Item3).ToList();
                writeAllTrips(tripsByDescendingDateOfTravel);
            }
        }

        static void totalFuelUsage(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllUsers(users);
            Console.Write("Upiši id korisnika kojem želiš pregledati potrošnju goriva: ");
            int input = idInList(users);

            var user = users.Where(user => user.Item1 == input).FirstOrDefault();
            double totalFuelUsage = 0;
            foreach (var trip in user.Item5)
                totalFuelUsage += trip.Item5;

            Console.WriteLine("Korisnik {0} {1} ukupno je potrošio {2} L goriva",user.Item2, user.Item3, totalFuelUsage);
        }

        static void totalFuelCost(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllUsers(users);
            Console.Write("Upiši id korisnika kojem želiš pregledati ukupan trošak: ");
            int input = idInList(users);

            var user = users.Where(user => user.Item1 == input).FirstOrDefault();
            double totalFuelCost = 0;
            foreach (var trip in user.Item5)
                totalFuelCost += trip.Item7;

            Console.WriteLine("Korisnik {0} {1} ukupno je potrošio {2} EUR", user.Item2, user.Item3, totalFuelCost);
        }

        static void averageFuelUsage(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllUsers(users);
            Console.Write("Upiši id korisnika kojem želiš pregledati prosječnu potrošnju: ");
            int input = idInList(users);

            var user = users.Where(user => user.Item1 == input).FirstOrDefault();
            double totalFuelUsage = 0;
            foreach (var trip in user.Item5)
                totalFuelUsage += trip.Item5;

            double totalKm = 0;
            foreach (var trip in user.Item5)
                totalKm += trip.Item4;

            double averageFuelUsage = (totalFuelUsage / totalKm) * 100;

            Console.WriteLine("Korisnik {0} {1} prosječno je potrošio {2} L/100km", user.Item2, user.Item3, averageFuelUsage);
        }

        static void tripWithHighestFuelUsage(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllUsers(users);
            Console.Write("Upiši id korisnika kojem želiš pregledati prosječnu potrošnju: ");
            int input = idInList(users);

            var user = users.Where(user => user.Item1 == input).FirstOrDefault();
            var maxFuelUsage = user.Item5.MaxBy(x => x.Item5);

            var tripsWithMaxUsage = new List<(int, int, DateTime, double, double, double, double)>();
            foreach (var trip in user.Item5)
                if(trip.Item5.Equals(maxFuelUsage))
                    tripsWithMaxUsage.Add(trip);

            Console.WriteLine("Putovanja sa najvećom potrošnjom goriva kod putnika {0} {1}:", user.Item2, user.Item3);
            writeAllTripsFormatted(tripsWithMaxUsage);
        }

        static void printTripsByDate(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAllUsers(users);
            Console.Write("Upiši id korisnika kojem želiš pregledati putovanja na određeni datum: ");
            int input = idInList(users);
            var user = users.Where(user => user.Item1 == input).FirstOrDefault();

            Console.Write("Unesi željeni datum (YYYY-MM-DD): ");
            var inputDate = validDateInput();

            var tripsOnCertainDate = new List<(int, int, DateTime, double, double, double, double)>();
            foreach (var trip in user.Item5)
                if(trip.Item3.Equals(inputDate))
                    tripsOnCertainDate.Add(trip);

            if(tripsOnCertainDate.Count() == 0)
            {
                Console.WriteLine("Korisnik {0} {1} nije putovao na taj datum.", user.Item2, user.Item3);
                return;
            }

            Console.WriteLine("Sva putovanja na određeni datum: ");
            foreach (var trip in tripsOnCertainDate)
                Console.WriteLine("{0,-2} - {1}, {2}km, {3} EUR", trip.Item2, trip.Item3.ToShortDateString(), trip.Item4, trip.Item7);
        }

        static void analizeTrips(List<(int, string, string, DateTime, List<(int, int, DateTime, double, double, double, double)>)> users)
        {
            writeAnalysisMenu();
            int input = validIntegerInput(0, 5);

            if (input == 1)
                totalFuelUsage(users);

            if (input == 2)
                totalFuelCost(users);

            if (input == 3)
                averageFuelUsage(users);

            if (input == 4)
                tripWithHighestFuelUsage(users);

            if (input == 5)
                printTripsByDate(users);
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
                    case 4:
                        printAllTrips(trips, users);
                        break;
                    case 5:
                        analizeTrips(users);
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
                (5, 5, new DateTime(2025, 7, 2), 60.3, 21.3, 1.39, 21.3 * 1.39),
                (6, 6, new DateTime(2024, 6, 4), 300.2, 31.2, 1.43, 31.2 * 1.43),
                (7, 7, new DateTime(2000, 12, 4), 123, 43.3, 1.27, 43.3 * 1.27),
                (4, 8, new DateTime(1980, 12, 17), 300.2, 54.3, 1.29, 53.3 * 1.29),
                (2, 9, new DateTime(2013, 6, 22), 345, 122, 1.43, 122 * 1.43),
                (6, 10, new DateTime(2011, 9, 23), 125.4, 64.3, 1.31, 64.3 * 1.31),
                (1, 11, new DateTime(2021, 11, 25), 642, 96.2, 1.35, 96.2 * 1.35),
            };

            var users = new List<(int id, string userName, string userSurname, DateTime dateOfBirth, List<(int, int, DateTime, double, double, double, double)>)>
            {
                (1, "Andrea", "Barada", new DateTime(2005, 7, 15), trips.Where(t => t.userId == 1).ToList()),
                (2, "Mia", "Barada", new DateTime(2005, 7, 15), trips.Where(t => t.userId == 2).ToList()),
                (3, "Daria", "Pažanin", new DateTime(2005, 6, 26), trips.Where(t => t.userId == 3).ToList()),
                (4, "Sara", "Cigler", new DateTime(2006, 3, 10), trips.Where(t => t.userId == 4).ToList()),
                (5, "Ante", "Antić", new DateTime(2000, 7, 15), trips.Where(t => t.userId == 5).ToList()),
                (6, "Mate", "Matić", new DateTime(2002, 12, 12), trips.Where(t => t.userId == 6).ToList()),
                (7, "Ana", "Bartululuu", new DateTime(2005, 7, 26), trips.Where(t => t.userId == 7).ToList()),
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


