namespace ConsoleApp2;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public KontenerNaGaz(double masaLadunku, double _wysokosc, double wagaWlasna, double _glebokosc,
        double maxLadownosc, string nrSeryjny)
        : base(masaLadunku, _wysokosc, wagaWlasna, _glebokosc, maxLadownosc, nrSeryjny)
    {
    }

    public override void oproznijLadunek()
    {
        this.masa_ladunku = 0.05 * masa_ladunku;
    }
}
