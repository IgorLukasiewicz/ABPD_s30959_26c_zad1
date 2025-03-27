namespace ConsoleApp2;

public class Produkt

{
    public static List<string> bazaNazwProduktow = new List<string>();
    public static List<Produkt> bazaProduktow = new List<Produkt>();
    
    public string produkt { get; set; }
    public double temperatura { get; set; }

    public Produkt(string _produkt, double _temperatura)
    {
        if (bazaNazwProduktow.Contains(_produkt))
        {
            throw new Exception("Taki produkt już istnieje");
        }
        this.produkt = _produkt;
        this.temperatura = _temperatura;
        bazaNazwProduktow.Add(_produkt);
        bazaProduktow.Add(this);
    }
}