namespace ConsoleApp2;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    private bool czyNiebezpieczny;

    public KontenerNaPlyny(double masaLadunku, double _wysokosc, double wagaWlasna, double _glebokosc, double maxLadownosc, string nrSeryjny, bool czyNiebezpiecznyLadunek)
        : base(masaLadunku, _wysokosc, wagaWlasna, _glebokosc, maxLadownosc, nrSeryjny)
    {
        czyNiebezpieczny = czyNiebezpiecznyLadunek;
    }

    public override void dodajLadunek(double masaNowegoLadunku)
    {
        if (czyNiebezpieczny && masaNowegoLadunku + masa_ladunku> max_ladownosc * 0.5)
        {
            IHazardNotifier.Notify(this.nr_Seryjny);
            throw new OverfillException(); 
        }
        else if (masaNowegoLadunku + masa_ladunku > max_ladownosc * 0.9)
        {
            IHazardNotifier.Notify(this.nr_Seryjny);
            throw new OverfillException(); 
            
        }
        else
        {
            base.dodajLadunek(masaNowegoLadunku); 
        }
      
    }
}
