namespace enigpus.Models;

public class Novel : Book
{
    public override string GetTitle()
    {
        return Title;
    }
}