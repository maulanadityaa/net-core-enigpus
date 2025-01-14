using enigpus.Models;

namespace enigpus.Services;

public class InventoryService : IInventoryService
{
    private readonly List<Book> _books = new List<Book>();

    public Book addBook(Book book)
    {
       _books.Add(book);
       return book;
    }

    public List<Book> getAllBooks()
    {
        return _books;
    }

    public IEnumerable<Book> searchBook(string title)
    {
        return _books.Where(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}