using enigpus.Models;
using enigpus.Services;

namespace enigpus.Utils;

public class BookHelper
{
    public static string CodeGenerator(List<Book> books)
    {
        if (books.Count > 0)
        {
            var lastBook = books[books.Count - 1];
            var lastCode = lastBook.Code.Split("-");

            var code = int.Parse(lastCode[1]) + 1;
            return "B-" + code;
        }

        return "B-1";
    }
}