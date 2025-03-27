namespace ConsoleApp2;

public class Kontenerowiec
{
    public int id;
    
    public int maxLiczbaKontenerow;

    public int maxPredkosc;

    public int maxWaga;

    public List<Kontener> kontenerowiec;
    
    public static List<Kontenerowiec> kontenerowce = new List<Kontenerowiec>();

    public Kontenerowiec(int _maxLiczbaKontenerow, int _maxPredkosc, int _maxWaga)
    {
        this.maxWaga = _maxWaga;
        this.maxPredkosc = _maxPredkosc;
        this.maxLiczbaKontenerow = _maxLiczbaKontenerow;
        kontenerowiec = new List<Kontener>();
        kontenerowce.Add(this);
        this.id = kontenerowce.Count;
    }

    public void dodajKontener(Kontener kontener)
    {
        if (this.kontenerowiec.Count < this.maxLiczbaKontenerow && policzMaseKontenerow() + kontener.masa_ladunku <= this.maxWaga)
        {
            this.kontenerowiec.Add(kontener);
        }

        else
        {
            Console.WriteLine("Kontenerowiec jest pełny");
        }
    }

    public double policzMaseKontenerow()
    {
        double obecnaMasa = 0;
        foreach (Kontener kontener in this.kontenerowiec)
        {
            obecnaMasa += kontener.masa_ladunku;
        }
        return obecnaMasa;
    }

    public void pokazKontenery()
    {
        foreach (Kontener kontener in this.kontenerowiec)
        {
            Console.WriteLine(kontener.ToString());
        }
    }
    public override string ToString()
    {
        string konteneryInfo = "";
        
        foreach (Kontener kontener in this.kontenerowiec)
        {
            konteneryInfo += kontener.nr_Seryjny + ",  ";
        }

        return "ID kontenerowca: " + this.id + ",  " +
               "Maksymalna liczba kontenerów: " +  this.maxLiczbaKontenerow + ",  "+
               "Maksymalna prędkość: " + this.maxPredkosc + " " + "wezlow" + ",  " +
               "Maksymalna waga: " + this.maxWaga + " kg,  "+
               "Kontenery na kontenerowcu: " + konteneryInfo;
    }

}