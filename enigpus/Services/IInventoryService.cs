using enigpus.Models;

namespace enigpus.Services;

public interface IInventoryService
{
    void addBook(Book book);
    List<Book> getAllBooks();
    IEnumerable<Book> searchBook(string title);
}