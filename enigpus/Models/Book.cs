using System.Runtime.InteropServices.JavaScript;

namespace enigpus.Models;

public abstract class Book
{
    public string Code { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public string YearPublished { get; set; }

    public abstract string GetTitle();
}