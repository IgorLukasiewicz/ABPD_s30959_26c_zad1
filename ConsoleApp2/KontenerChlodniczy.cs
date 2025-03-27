namespace ConsoleApp2;

public class KontenerChlodniczy : Kontener, IHazardNotifier
{
    private Produkt typProdukt;
    private double temperatruaKontenera;
    
    public KontenerChlodniczy(double masaLadunku, double _wysokosc, double wagaWlasna, double _glebokosc,
        double maxLadownosc, string nrSeryjny, Produkt produkt, double _temperatruaKontenera)
        : base(masaLadunku, _wysokosc, wagaWlasna, _glebokosc, maxLadownosc, nrSeryjny)
    {
        this.typProdukt = produkt;

        if (_temperatruaKontenera >= this.typProdukt.temperatura)
        {
            this.temperatruaKontenera = _temperatruaKontenera;
        }
        else
        {
            throw new Exception("Temperatura kontenera jest za niska dla tego produktu!");
        }
    }
    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Typ produktu: " + this.typProdukt.produkt  +
               "Temperatura kontenera: " + this.temperatruaKontenera + " stopni Celsjusza";
    }

}