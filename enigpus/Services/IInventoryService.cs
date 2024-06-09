using enigpus.Models;

namespace enigpus.Services;

public interface IInventoryService
{
    Book addBook(Book book);
    List<Book> getAllBooks();
    IEnumerable<Book> searchBook(string title);
}