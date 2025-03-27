namespace ConsoleApp2;

public class OverfillException : Exception
{
    public OverfillException() : base("Masa ladunku jest za duza"){}
    public OverfillException(string message) : base(message) {}
}
