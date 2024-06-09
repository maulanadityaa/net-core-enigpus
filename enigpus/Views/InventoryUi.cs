using enigpus.Models;
using enigpus.Services;
using enigpus.Utils;

namespace enigpus.Views;

public class InventoryUi
{
    private readonly IInventoryService _inventoryService = new InventoryService();

    public void Run()
    {
        Menu();
    }

    private void Menu()
    {
        while (true)
        {
            Console.WriteLine("=============== Enigpus ================");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Get All Books");
            Console.WriteLine("3. Search Book by Title");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    GetAllBooks();
                    break;
                case "3":
                    SearchBook();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private void AddBook()
    {
        Console.WriteLine("1. Novel");
        Console.WriteLine("2. Magazine");
        Console.Write("Enter your choice: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddNovel();
                break;
            case "2":
                AddMagazine();
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }

    private void AddNovel()
    {
        Console.WriteLine("============== Add Novel ===============");
        Console.Write("Enter Title : ");
        var title = Console.ReadLine();
        Console.Write("Enter Publisher : ");
        var publisher = Console.ReadLine();
        Console.Write("Enter Published Year : ");
        var publishedYear = int.Parse(Console.ReadLine() ?? string.Empty);

        var code = BookHelper.CodeGenerator(_inventoryService.getAllBooks());

        var novel = new Novel
        {
            Code = code,
            Title = title,
            Publisher = publisher,
            YearPublished = publishedYear
        };

        _inventoryService.addBook(novel);
    }

    private void AddMagazine()
    {
        Console.WriteLine("============== Add Magazine ===============");
        Console.Write("Enter Title : ");
        var title = Console.ReadLine();
        Console.Write("Enter Publisher : ");
        var publisher = Console.ReadLine();
        Console.Write("Enter Published Year : ");
        var publishedYear = int.Parse(Console.ReadLine() ?? string.Empty);

        var code = BookHelper.CodeGenerator(_inventoryService.getAllBooks());

        var novel = new Magazine
        {
            Code = code,
            Title = title,
            Publisher = publisher,
            YearPublished = publishedYear
        };

        _inventoryService.addBook(novel);
    }

    private void GetAllBooks()
    {
        var books = _inventoryService.getAllBooks();


        if (books.Count == 0)
        {
            Console.WriteLine("================ No books available =================");
            return;
        }

        foreach (var book in books)
        {
            switch (book)
            {
                case Novel novel:
                    Console.WriteLine("================ Novel =================");
                    Console.WriteLine($"Code : {novel.Code}");
                    Console.WriteLine($"Title : {novel.Title}");
                    Console.WriteLine($"Publisher : {novel.Publisher}");
                    Console.WriteLine($"Year Published : {novel.YearPublished}");
                    Console.WriteLine();
                    break;
                case Magazine magazine:
                    Console.WriteLine("================ Magazine =================");
                    Console.WriteLine($"Code : {magazine.Code}");
                    Console.WriteLine($"Title : {magazine.Title}");
                    Console.WriteLine($"Publisher : {magazine.Publisher}");
                    Console.WriteLine($"Year Published : {magazine.YearPublished}");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private void SearchBook()
    {
        Console.WriteLine("================ Search Book by Title =================");
        Console.Write("Enter Title : ");
        var title = Console.ReadLine();

        var books = _inventoryService.searchBook(title ?? throw new InvalidOperationException("Invalid operation"));

        if (books.Count() == 0)
        {
            Console.WriteLine($"================ No books with title : {title} =================");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"Code : {book.Code}");
            Console.WriteLine($"Title : {book.Title}");
            Console.WriteLine($"Publisher : {book.Publisher}");
            Console.WriteLine($"Year Published : {book.YearPublished}");
            Console.WriteLine();
        }
    }
}