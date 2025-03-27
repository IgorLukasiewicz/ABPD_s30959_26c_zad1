namespace ConsoleApp2;

public interface IHazardNotifier
{
    public static void Notify(string nrKontenera)
    {
        Console.WriteLine("Niebezpieczna sytuacja w kontenerze  " + nrKontenera);
    }
}