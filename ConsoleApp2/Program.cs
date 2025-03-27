namespace ConsoleApp2;

public class MainClass
{
    public static void Main(String[] args)
    {
        
        Kontenerowiec Kontenerowiec1 = new Kontenerowiec(10, 10, 1000);
        Kontenerowiec Kontenerowiec2 = new Kontenerowiec(15, 15, 15);
        Produkt produkt1 = new Produkt("Masło", 12.5);
        Produkt produkt2 = new Produkt("Czosnek", 100);
        Produkt produkt3 = new Produkt("Gaz", 10);
        Produkt produkt4 = new Produkt("Mleko", 10);
        
        
        bool czyKontynuowac = true;

        while (czyKontynuowac)
        {
            
            Console.WriteLine("Proszę wybrać operację: " + "\n" +
                              "0. Stworzenie kontenera danego typu" + "\n"+
                              "1. Załadowanie ładunku do danego kontenera: " + "\n"+
                              "2. Załadowanie kontenera na statek" + "\n"+
                              "3. Załadowanie listy kontenerów na statek" + "\n"+
                              "4. Usunięcie kontenera ze statku" + "\n"+
                              "5. Rozładowanie kontenera" + "\n"+
                              "6. Zastąpienie kontenera na statku o danym numerze innym kontenerem" + "\n"+
                              "7. Możliwość przeniesienie kontenera między dwoma statkami" + "\n"+
                              "8.  Wypisanie informacji o danym kontenerze" + "\n"+
                              "9.  Wypisanie informacji o danym statku i jego ładunku");
            
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "0":
                    stworzKontener();
                    break;
                case "1":
                    Console.WriteLine("Podaj numer seryjny kontenera:");
                    string nrSeryjnyKontenera = Console.ReadLine();

                    Console.WriteLine("Podaj wagę ładunku:");
                    double ladunek = double.Parse(Console.ReadLine());
                    
                    zaladujDoKontenera(nrSeryjnyKontenera, ladunek);
                    break;
                case "2":
                    Console.WriteLine("Podaj id kontenerowca:");
                    int idKontenerowca = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Podaj numer seryjny kontenera:");
                    string nrSeryjnyKontenera2 = Console.ReadLine();
                    
                    zaladujNaKontenerowiec(idKontenerowca, nrSeryjnyKontenera2);
                    break;
                case "3":
                    Console.WriteLine("Podaj ID kontenerowca:");
                    int idKontenerowca2 = int.Parse(Console.ReadLine());

                    listaKontenerowNaStatek(idKontenerowca2);
                    break;
                case "4":
                    Console.WriteLine("Podaj ID Kontenerowca:");
                    int idKontenerowca3 = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Podaj numer seryjny kontenera:");
                    string nrSeryjnyKontenera3 = Console.ReadLine();
                    usunZKontenerowca(idKontenerowca3, nrSeryjnyKontenera3);
                    break;
                case "5":
                    Console.WriteLine("Podaj numer seryjny kontenera:");
                    string nrSeryjnyKontenera4 = Console.ReadLine();
                    oproznijKontener(nrSeryjnyKontenera4);
                    break;
                case "6":
                    wymianaKontenerow();
                    break;
                case "7":
                    wymianaStatkow();
                    break;
                case "8":
                    kontenerInfo();
                    break;
                case "9":
                    kontenerowiecInfo();
                    break;
                default:
                    Console.WriteLine("Koniec programu");
                    czyKontynuowac = false;
                    break;
            }
            Console.WriteLine("Kontenery: " + "\n");
            foreach (Kontener kontener in Kontener.wszystkieKontenery)
            {
                Console.WriteLine(kontener.ToString());
                Console.WriteLine("\n");
            }
            
            Console.WriteLine("\n");
            Console.WriteLine("Kontenerowce: " + "\n");
            foreach (Kontenerowiec kontenerowiec in Kontenerowiec.kontenerowce)
            {
                Console.WriteLine(kontenerowiec.ToString());
                Console.WriteLine("\n");
            }
            
            if (czyKontynuowac)
            {
                Console.WriteLine("Czy chcesz kontynuować? (t/n)");
                string odpowiedz = Console.ReadLine().ToLower();
                if (odpowiedz != "t")
                {
                    czyKontynuowac = false;
                    Console.WriteLine("Program zakończony.");
                }
            }
        }
    }
    
    public static Kontener stworzKontener()
{
    Console.WriteLine("Proszę podać masę ładunku: ");
    double masaLadunku = double.Parse(Console.ReadLine());

    Console.WriteLine("Proszę podać wysokość kontenera: ");
    double wysokosc = double.Parse(Console.ReadLine());

    Console.WriteLine("Proszę podać wagę własną kontenera: ");
    double wagaWlasna = double.Parse(Console.ReadLine());

    Console.WriteLine("Proszę podać głębokość kontenera: ");
    double glebokosc = double.Parse(Console.ReadLine());

    Console.WriteLine("Proszę podać maksymalną ładowność kontenera: ");
    double maxLadownosc = double.Parse(Console.ReadLine());

    Console.WriteLine("Proszę podać numer seryjny kontenera: ");
    string nrSeryjny = Console.ReadLine();
    
    switch (nrSeryjny.ToUpper())
    {
        case "L":
            Console.WriteLine("Proszę podaj czy ładunek jest niebezpieczny: 1 - tak, 0 - nie");
            int czyNiebezpieczny = int.Parse(Console.ReadLine());
            if (czyNiebezpieczny == 1)
            {
                return new KontenerNaPlyny(masaLadunku, wysokosc, wagaWlasna, glebokosc, maxLadownosc, nrSeryjny, true);
            }
            else if (czyNiebezpieczny == 0)
            {
                return new KontenerNaPlyny(masaLadunku, wysokosc, wagaWlasna, glebokosc, maxLadownosc, nrSeryjny, false);
            }
            else
            {
                Console.WriteLine("Podaj poprawną wartość.");
            }
            break;

        case "G":
            return new KontenerNaGaz(masaLadunku, wysokosc, wagaWlasna, glebokosc, maxLadownosc, nrSeryjny);
            break;

        case "C":
            Console.WriteLine("Proszę podać temperaturę kontenera: ");
            double temperaturaPodana = double.Parse(Console.ReadLine());

            Console.WriteLine("Proszę podać nazwę produktu: ");
            string nazwaPodana = Console.ReadLine();
            
            if (!Produkt.bazaNazwProduktow.Contains(nazwaPodana))
            {
                Console.WriteLine("Produkt o podanej nazwie nie istnieje w bazie.");
                break;
            }

            Produkt dodany = Produkt.bazaProduktow.Find(p => p.produkt == nazwaPodana);
            return new KontenerChlodniczy(masaLadunku, wysokosc, wagaWlasna, glebokosc, maxLadownosc, nrSeryjny, dodany, temperaturaPodana);
            break;

        default:
            Console.WriteLine("Nieznany typ kontenera.");
            break;
    }

    return null;
}

    public static void zaladujDoKontenera(string nrSeryjnyKontenera, double ladunek)
    {
        Kontener kontenerDoZaładowania = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKontenera);

        if (kontenerDoZaładowania != null)
        {
            kontenerDoZaładowania.dodajLadunek(ladunek);
        }
        else
        {
            Console.WriteLine("Kontener o podanym numerze seryjnym nie został znaleziony.");
        }
    }

    public static void zaladujNaKontenerowiec(int idKontenerowca, string nrSeryjnyKontenera)
    {
        Kontenerowiec kontenerowiec = Kontenerowiec.kontenerowce.Find(k => k.id == idKontenerowca);

        if (kontenerowiec != null)
        {
            Kontener kontener = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKontenera);

            if (kontener != null)
            {
                kontenerowiec.kontenerowiec.Add(kontener);
                Console.WriteLine(
                    $"Kontener {nrSeryjnyKontenera} został załadowany na kontenerowiec {idKontenerowca}.");
            }
            else
            {
                Console.WriteLine("Kontener o podanym numerze seryjnym nie został znaleziony.");
            }
        }
        else
        {
            Console.WriteLine("Kontenerowiec o podanym ID nie został znaleziony.");
        }
    }

    public static void listaKontenerowNaStatek(int idKontenerowca)
    {
        Kontenerowiec kontenerowiec = Kontenerowiec.kontenerowce.Find(k => k.id == idKontenerowca);
        if (kontenerowiec != null)
        {
            bool czyKontynowac = true;

            while (czyKontynowac)
            {
                Console.WriteLine("Podaj Numer Seryjny Kontenera");
                String nrSeryjny = Console.ReadLine();
               Kontener nowyKontener =  Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjny);
                Console.WriteLine("Kontynuować? true/false");
                kontenerowiec.dodajKontener(nowyKontener);
                czyKontynowac = bool.Parse(Console.ReadLine());
              
            }
        }
    }
    
    public static void usunZKontenerowca (int idKontenerowca, string nrSeryjnyKontenera)
    {
        Kontenerowiec kontenerowiec = Kontenerowiec.kontenerowce.Find(k => k.id == idKontenerowca);

        if (kontenerowiec != null)
        {
            Kontener kontener = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKontenera);

            if (kontener != null)
            {
                kontenerowiec.kontenerowiec.Remove(kontener);
                Console.WriteLine(
                    $"Kontener {nrSeryjnyKontenera} został usunięty na kontenerowiec {idKontenerowca}.");
            }
            else
            {
                Console.WriteLine("Kontener o podanym numerze seryjnym nie został znaleziony.");
            }
        }
        else
        {
            Console.WriteLine("Kontenerowiec o podanym ID nie został znaleziony.");
        }
    }


    public static void oproznijKontener(string nrSeryjnyKontenera)
    {
        Kontener kontener = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKontenera);
        if (kontener != null)
        {
            kontener.oproznijLadunek();
        }
        else
        {
            Console.WriteLine("Nie znaleziony kontenera");
        }
    }

    public static void wymianaKontenerow()
    {
        Console.WriteLine("Proszę podać numer seryjny kontenera, który ma zostać wymieniony: ");
        string nrSeryjnyKonteneraWymienianego = Console.ReadLine();

        Console.WriteLine("Proszę podać numer seryjny nowego kontenera: ");
        string nrSeryjnyKonteneraNowego = Console.ReadLine();
        
        Kontener kontenerWymieniany = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKonteneraWymienianego);
        if (kontenerWymieniany == null)
        {
            Console.WriteLine("Nie znaleziono kontenera do wymiany.");
            return;
        }
        
        Kontener kontenerNowy = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKonteneraNowego);
        if (kontenerNowy == null)
        {
            Console.WriteLine("Nie znaleziono nowego kontenera.");
            return;
        }
        
        Kontenerowiec kontenerowiec = Kontenerowiec.kontenerowce.Find(k => k.kontenerowiec.Contains(kontenerWymieniany));
        if (kontenerowiec == null)
        {
            Console.WriteLine("Nie znaleziono statku zawierającego podany kontener.");
            return;
        }
        
        kontenerowiec.kontenerowiec.Remove(kontenerWymieniany);
        kontenerowiec.kontenerowiec.Add(kontenerNowy);

        Console.WriteLine("Kontener" + nrSeryjnyKonteneraWymienianego+  "został wymieniony na " + nrSeryjnyKonteneraNowego);
    }


    public static void wymianaStatkow()
    {
        
        Console.WriteLine("Podaj ID starego statku: ");
        int idStatekStary = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj ID nowego statku: ");
        int idStatekNowy = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj numer seryjny kontenera do przeniesienia: ");
        string nrSeryjnyKontenera = Console.ReadLine();
        
        Kontenerowiec staryStatek = Kontenerowiec.kontenerowce.FirstOrDefault(s => s.id == idStatekStary);
        if (staryStatek == null)
        {
            Console.WriteLine("Nie znaleziono starego statku.");
            return;
        }
        
        Kontenerowiec nowyStatek = Kontenerowiec.kontenerowce.FirstOrDefault(s => s.id == idStatekNowy);
        if (nowyStatek == null)
        {
            Console.WriteLine("Nie znaleziono nowego statku.");
            return;
        }
        
        Kontener kontenerDoPrzeniesienia = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjnyKontenera);

        if (kontenerDoPrzeniesienia == null)
        {
            Console.WriteLine("Kontener o podanym numerze seryjnym nie istnieje.");
            return;
        }
        
        if (staryStatek.kontenerowiec.Contains(kontenerDoPrzeniesienia))
        {
            staryStatek.kontenerowiec.Remove(kontenerDoPrzeniesienia);
            nowyStatek.kontenerowiec.Add(kontenerDoPrzeniesienia);
        
            Console.WriteLine("Kontener " + nrSeryjnyKontenera + " został przeniesiony ze statku " + idStatekStary + " na statek " + idStatekNowy);
        }
        else
        {
            Console.WriteLine("Kontener nie znajduje się na starym statku.");
        }
    }

    public static void kontenerInfo()
    {
        Console.WriteLine("Podaj numer seryjny kontenera:");
        string nrSeryjny = Console.ReadLine(); 
        
        Kontener kontener = Kontener.wszystkieKontenery.Find(k => k.nr_Seryjny == nrSeryjny);
        
        if (kontener != null)
        {
            Console.WriteLine(kontener.ToString());
        }
        else
        {
            Console.WriteLine("Kontener o podanym numerze seryjnym nie istnieje.");
        }
    }
    public static void kontenerowiecInfo()
    {
        Console.WriteLine("Podaj numer ID kontenerowca:");
        
        bool isValidId = int.TryParse(Console.ReadLine(), out int idKontenerowca);
        
        if (isValidId)
        {
            Kontenerowiec kontenerowiec = Kontenerowiec.kontenerowce.FirstOrDefault(k => k.id == idKontenerowca);
            
            if (kontenerowiec != null)
            {
                Console.WriteLine(kontenerowiec.ToString());
            }
            else
            {
                Console.WriteLine("Kontenerowiec o podanym numerze ID nie istnieje.");
            }
        }
        else
        {
            Console.WriteLine("Podany numer ID jest niepoprawny. Proszę podać liczbę całkowitą.");
        }
    }
}


























