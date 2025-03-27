namespace ConsoleApp2;

public class Kontener
{
    
    public static List<Kontener> wszystkieKontenery = new List<Kontener>();
    
    public double masa_ladunku;
    public double wysokosc;
    public double waga_wlasna;
    public double glebokosc;
    public double max_ladownosc;
    public string nr_Seryjny;
    
    public Kontener(double masaLadunku, double _wysokosc, double wagaWlasna, double _glebokosc, double maxLadownosc, string nrSeryjny)
    {
        masa_ladunku = masaLadunku;
        wysokosc = _wysokosc;
        waga_wlasna = wagaWlasna;
        glebokosc = _glebokosc;
        
        if (poprawnyNrSeryjny(nrSeryjny))
        {
            nr_Seryjny = "KON-" + nrSeryjny.ToUpper() + "-" + wszystkieKontenery.Count;
        }
        else
        {
            Console.WriteLine("Prosze podać jedną literę.");
        }

        max_ladownosc = maxLadownosc;


        if (maxLadownosc < masaLadunku)
        {
            throw new OverflowException("Podana masa ładunku przekracza maksymalną ładownośc kontenera!");
        }
        {
            
        }
  
        wszystkieKontenery.Add(this);
        
        
        
    }
    
    bool poprawnyNrSeryjny(string nrSeryjny)
    {
        return nrSeryjny.Length == 1 && char.IsLetter(nrSeryjny[0]);
    }
    
    public virtual void oproznijLadunek()
    {
        this.masa_ladunku = 0;
    }
    
    public virtual void dodajLadunek(double masaNowegoLadunku) 
    {
        if (this.masa_ladunku + masaNowegoLadunku <= this.max_ladownosc)
        {
            this.masa_ladunku += masaNowegoLadunku;
        }
        else
        {
            throw new OverfillException();
        }
    }

    public override string ToString()
    {
        return "Numer seryjny: " + this.nr_Seryjny  + " " +
               "Masa ładunku: " + this.masa_ladunku + " " +
               "Wysokość: " + this.wysokosc + " " +
               "Waga własna: " + this.waga_wlasna + " kg" +
               "Głębokość: " + this.glebokosc +" m" +
               "Maksymalna ładowność: " + this.max_ladownosc + " kg";
    }

}